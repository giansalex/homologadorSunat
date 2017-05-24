using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Homologador.Fe.Auth;
using Homologador.Fe.Manage;
using Homologador.Fe.Model;
using Homologador.Fe.Pruebas;
using Homologador.Model;
using Homologador.Properties;
using MetroFramework;
using MetroFramework.Forms;
using Newtonsoft.Json.Linq;

namespace Homologador
{
    public partial class MainForm : MetroForm
    {
        private SunatApi _auth;

        private Company _company
        {
            get
            {
                var sett = Settings.Default;
                return new Company
                {
                    Ruc = sett.Ruc,
                    RazonSocial = sett.RzSocial,
                    NombreComercial = sett.NComercial,
                    User = sett.Usuario,
                    Clave = sett.Clave,
                    Address = new CompanyAddress
                    {
                        Ubigueo = sett.Ubigueo,
                        Urbanizacion = sett.Urbanizacion,
                        Departamento = sett.Departamento,
                        Provincia = sett.Provincia,
                        Distrito = sett.Distrito,
                        Direccion = sett.Direccion
                    },
                    Certified = new Certified
                    {
                        Content = Convert.FromBase64String(sett.Ceritificado),
                        Password = sett.ClaveCert
                    }
                };
            }
        }

        public MainForm()
        {
            InitializeComponent();
            Theme = MetroThemeStyle.Dark;
            Load += MainForm_Load;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Init();
        }

        private async void Init()
        {
            var sett = Settings.Default;
            if (string.IsNullOrWhiteSpace(sett.Ruc)
                || string.IsNullOrWhiteSpace(sett.Usuario)
                || string.IsNullOrWhiteSpace(sett.Clave))
            {
                InvokeOnClick(btnSetting, null);
                return;
            }

            _auth = new SunatApi(sett.Ruc, sett.Usuario, sett.Clave);
            _auth.Login();
            await Extractor();
        }

        private void InitLoad()
        {
            var x = (Width - spinner.Width) / 2;
            var y = (Height - spinner.Height) / 2;
            spinner.Location = new Point(x, y);
            spinner.Visible = true;
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            switch (tbDocs.SelectedTab.Name)
            {
                case nameof(mtabFacturas):
                    Factura_Run();
                    break;
                case nameof(mtabBoletas):
                    Boleta_Run();
                    break;
                case nameof(mtabResumen):
                    Resumen_Run();
                    break;
                case nameof(mtabBajas):
                    Baja_Run();
                    break;
            }
        }

        private void Factura_Run()
        {
            var rows = gridFacturas.SelectedRows;
            if (rows.Count == 0) return;
            var mng = new BillManager(_company);
            var fgenerator = new FacturaGenerator()
                    .ToCompany(_company)
                    .ForDoc("01");
            
            foreach (DataGridViewRow row in rows)
            {
                var gr = row.Cells["fgroup"].Value.ToString();
                var lines = int.Parse(row.Cells["fcantidad"].Value.ToString());
                var hasNcr = bool.Parse(row.Cells["fnotacr"].Value.ToString());
                var hasNdb = bool.Parse(row.Cells["fnotadb"].Value.ToString());

                var inv = fgenerator
                    .ForGroup(ToEnum<GrupoPrueba>(gr))
                    .WithLines(lines)
                    .Build();

                var res = mng.Send(inv);
                row.Cells["festado"].Value = res.Description;
                if (res.Success)
                {
                    var nGene = new NotaGenerator()
                        .From(inv);

                    if (hasNcr)
                    {
                        var ncr = nGene.BuildNcr();
                        mng.Send(ncr);
                    }

                    if (hasNdb)
                    {
                        var ndb = nGene.BuildNdb();
                        mng.Send(ndb);
                    }
                }
            }
            
        }

        private void Boleta_Run()
        {

        }

        private void Resumen_Run()
        {
            //TODO: Add label for status in ResumenTab
            int cant;
            if (!int.TryParse(mtxtBajaCant.Text, out cant))
            {
                Error("Numero de items invalido");
                mtxtBajaCant.Focus();
                return;
            }

            var resumen = new ResumenGenerator()
                .ToCompany(_company)
                .WithLines(cant)
                .Build();

            var mng = new BillManager(_company);
            var r = mng.Send(resumen);
            if (r.Success)
            {
                Status($@"Resumen enviado exitosamente: {r.Code}-{r.Description}");
                return;
            }
            Error(r.Description);
        }

        private void Baja_Run()
        {
            //TODO: Add label for status in BajaTab
            int cant ;
            if (!int.TryParse(mtxtBajaCant.Text, out cant))
            {
                MetroMessageBox.Show(this, "Numero de items invalido", "Error");
                mtxtBajaCant.Focus();
                return;
            }

            var voided = new BajaGenerator()
                .ToCompany(_company)
                .WithLines(cant)
                .Build();

            var mng = new BillManager(_company);
            var r = mng.Send(voided);
            if (r.Success)
            {
                Status($@"Baja enviada exitosamente: {r.Code}-{r.Description}");
                return;
            }
            Error(r.Description);
        }

        private async Task Extractor()
        {
            var numpr = await GetNumProceso();
            if (string.IsNullOrEmpty(numpr))
            {
                Alert("No se encontro ningún proceso de homologación vigente");
                return;    
            }

            var json = await _auth.GetPruebas(numpr);
            if (json == null)
            {
                Alert("No se pudo obtener informacion de las pruebas");
                return;
            }
            var obj = JObject.Parse(json);
            //if (obj["fecfinetapa"].ToString() != "-")
            //{
            //    Success("Ya finalizo el proceso de homologación");
            //    return;
            //}

            JToken token;
            if (obj.TryGetValue("facturas", out token))
            {
                LoadFacs((JArray)token);
            }
            {
                mtabFacturas.Visible = false;
                mtabBajas.Visible = false;
            }

            if (obj.TryGetValue("boletas", out token))
            {
                LoadBols((JArray)token);
            }
            else
            {
                mtabBoletas.Visible = false;
                mtabResumen.Visible = false;
            }
            
        }

        private void LoadFacs(JArray facturas)
        {
            var facGroup = new List<Caso>();
            foreach (var factura in facturas)
            {
                var group = (int)factura["codGrupo"];
                if (group == 14)
                {
                    mtabResumen.Visible = true;
                    continue;
                }
                var casos = (JArray)factura["casos"];
                var subGroup = new List<Caso>();
                foreach (var caso1 in casos)
                {
                    var desc = (string)caso1["descaso"];
                    var isNota = desc.StartsWith("NOTA", StringComparison.InvariantCultureIgnoreCase);
                    var num = GetNumItems(desc, isNota);
                    if (isNota)
                    {
                        if (desc.Contains("crédito"))
                            subGroup[num - 1].HasNotaCredit = true;
                        else
                            subGroup[num - 1].HasNotaDebit = true;
                        //continue;
                    }

                    var cs = new Caso
                    {
                        Codigo = (string)caso1["codcaso"],
                        Documento = (string)caso1["numdoc"],
                        Grupo = group,
                        Descripcion = desc,
                        Estado = (string)caso1["estado"],
                        Lines = num
                    };
                    subGroup.Add(cs);
                }
                facGroup.AddRange(subGroup);
            }
            lblCountFact.Text = facGroup.Count + @" Registros";

            foreach (var gr in facGroup)
            {
                gridFacturas.Rows.Add(gr.Grupo, gr.Codigo, gr.Descripcion, gr.Documento, gr.Lines, gr.HasNotaCredit, gr.HasNotaDebit, gr.Estado);
            }
        }
        private void LoadBols(JArray boletas)
        {
            var bolGroup = new List<Caso>();
            foreach (var boleta in boletas)
            {
                var group = (int)boleta["codGrupo"];
                if (group == 13) // Resumen
                {
                    mtabResumen.Visible = true;
                    continue;
                }
                var casos = (JArray)boleta["casos"];
                var subGroup = new List<Caso>();
                foreach (var caso1 in casos)
                {
                    var desc = (string)caso1["descaso"];
                    var isNota = desc.StartsWith("NOTA", StringComparison.InvariantCultureIgnoreCase);
                    var num = GetNumItems(desc, isNota);
                    if (isNota)
                    {
                        if (desc.Contains("crédito"))
                            subGroup[num - 1].HasNotaCredit = true;
                        else
                            subGroup[num - 1].HasNotaDebit = true;
                    }

                    var cs = new Caso
                    {
                        Codigo = (string)caso1["codcaso"],
                        Documento = (string)caso1["numdoc"],
                        Grupo = group,
                        Descripcion = desc,
                        Estado = (string)caso1["estado"],
                        Lines = isNota ? 0 : num
                    };
                    subGroup.Add(cs);
                }
                bolGroup.AddRange(subGroup);
            }
            lblCountBoletas.Text = bolGroup.Count + @" Registros";
            foreach (var gr in bolGroup)
            {
                gridBoletas.Rows.Add(gr.Grupo, gr.Codigo, gr.Descripcion, gr.Documento, gr.Lines, gr.HasNotaCredit, gr.HasNotaDebit, gr.Estado);
            }
        }
        private async Task<string> GetNumProceso()
        {
            var json = await _auth.GetSolicitudes();
            var obj = JObject.Parse(json);
            var items = (JArray)obj["items"];
            var node = items.FirstOrDefault(r => string.IsNullOrWhiteSpace(r["fecnot"].ToString()));
            if (node != null) return (string)node["numsol"];
            return null;
        }

        private int GetNumItems(string content, bool isNota)
        {
            var arrs = content.Split(' ');
            if (isNota)
            {
                return int.Parse(arrs[arrs.Length - 1]);
            }
            return int.Parse(arrs[arrs.Length - 2]);
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            using (var frm = new ConfigurationForm())
            {
                frm.ShowDialog(this);
                var sett = Settings.Default;
                if (string.IsNullOrWhiteSpace(sett.Ruc)
                    || string.IsNullOrWhiteSpace(sett.Usuario)
                    || string.IsNullOrWhiteSpace(sett.Clave))
                {
                    Close();
                    return;
                }
                Init();
            }
        }

        private void Success(string msg)
        {
            MetroMessageBox.Show(this, msg, "Success");
        }
        private void Error(string msg)
        {
            MetroMessageBox.Show(this, msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void Alert(string msg)
        {
            MetroMessageBox.Show(this, msg, "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private T ToEnum<T>(string code)
        {
            return (T) Enum.ToObject(typeof(T), int.Parse(code));
        }

        private void Status(string msg)
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(() => lblStatus.Text = msg));
                return;
            }
            lblStatus.Text = msg;
        }
    }
}
