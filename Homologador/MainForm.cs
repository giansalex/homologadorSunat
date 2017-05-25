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
using MetroFramework.Controls;
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
            try
            {
                InitLoad();
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
                await Extractor()
                    .ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Error(e.Message);
            }
            Invoke(new MethodInvoker(() => spinner.Visible = false));
        }

        private void InitLoad()
        {
            var x = (Width - spinner.Width) / 2;
            var y = (Height - spinner.Height) / 2;
            spinner.Location = new Point(x, y);
            spinner.Visible = true;
        }

        private async void btnRun_Click(object sender, EventArgs e)
        {
            switch (tbDocs.SelectedTab.Name)
            {
                case nameof(mtabFacturas):
                    await Factura_Run();
                    break;
                case nameof(mtabBoletas):
                    await Boleta_Run();
                    break;
                case nameof(mtabResumen):
                    await Resumen_Run();
                    break;
                case nameof(mtabBajas):
                    await Baja_Run();
                    break;
            }
        }

        private async Task Factura_Run()
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

                var res = await mng.Send(inv);
                row.Cells["festado"].Value = res.Description;
                if (!res.Success) continue;

                row.Cells["fdocumento"].Value = $"{inv.SerieDocumento}-{inv.CorrelativoDocumento}";
                var nGene = new NotaGenerator()
                    .From(inv);

                if (hasNcr)
                {
                    var ncr = nGene.BuildNcr();
                    row.Cells["fnotacr"].Value = !(await mng.Send(ncr)).Success;
                }

                if (hasNdb)
                {
                    var ndb = nGene.BuildNdb();
                    row.Cells["fnotadb"].Value = !(await mng.Send(ndb)).Success;
                }
            }
            var msg = gridFacturas.SelectedRows.Count > 1 ? "Facturas Enviadas" : "Factura Enviada";
            if (gridFacturas.SelectedRows.Count > 1) Success(msg);
            Status(msg);
        }

        private async Task Boleta_Run()
        {
            var rows = gridBoletas.SelectedRows;
            if (rows.Count == 0) return;
            var mng = new BillManager(_company);
            var fgenerator = new FacturaGenerator()
                .ToCompany(_company)
                .ForDoc("03");

            foreach (DataGridViewRow row in rows)
            {
                var gr = row.Cells["bgroup"].Value.ToString();
                var lines = int.Parse(row.Cells["bcantidad"].Value.ToString());
                var hasNcr = bool.Parse(row.Cells["bnotacr"].Value.ToString());
                var hasNdb = bool.Parse(row.Cells["bnotadb"].Value.ToString());

                var gro = gr == "12" ? GrupoPrueba.OtrasMonedas : (GrupoPrueba)Enum.ToObject(typeof(GrupoPrueba), int.Parse(gr) - 7);
                var inv = fgenerator
                    .ForGroup(gro)
                    .WithLines(lines)
                    .Build();

                var res = await mng.Send(inv);
                row.Cells["bestado"].Value = res.Description;
                if (!res.Success) continue;

                row.Cells["bdocumento"].Value = $"{inv.SerieDocumento}-{inv.CorrelativoDocumento}";
                var nGene = new NotaGenerator()
                    .From(inv);

                if (hasNcr)
                {
                    var ncr = nGene.BuildNcr();
                    row.Cells["bnotacr"].Value = !(await mng.Send(ncr)).Success;
                }

                if (hasNdb)
                {
                    var ndb = nGene.BuildNdb();
                    row.Cells["bnotadb"].Value = !(await mng.Send(ndb)).Success;
                }
            }
            var msg = gridBoletas.SelectedRows.Count > 1 ? "Boletas Enviadas" : "Boleta Enviada";
            if (gridBoletas.SelectedRows.Count > 1) Success(msg);
            Status(msg);
        }

        private async Task Resumen_Run()
        {
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
            var r = await mng.Send(resumen);
            if (r.Success)
            {
                Status($@"Resumen enviado exitosamente: {r.Code}-{r.Description}");
                return;
            }
            Error(r.Description);
        }

        private async Task Baja_Run()
        {
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
            var r = await mng.Send(voided);
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
                var casos = (JArray)factura["casos"];

                if (group == 14) // Bajas
                {
                    mtabResumen.Visible = true;
                    lblStateBaja.Text = (string)casos.First["estado"];
                    continue;
                }
                
                var subGroup = new List<Caso>();
                foreach (var caso1 in casos)
                {
                    var desc = (string)caso1["descaso"];
                    var isNota = desc.StartsWith("NOTA", StringComparison.InvariantCultureIgnoreCase);
                    var num = GetNumItems(desc, isNota);
                    var state = (string) caso1["estado"];
                    if (isNota)
                    {
                        //if (state.Equals("Aprobado", StringComparison.InvariantCultureIgnoreCase)) continue;
                        
                        if (desc.Contains("crédito"))
                            subGroup[num - 1].HasNotaCredit = true;
                        else
                            subGroup[num - 1].HasNotaDebit = true;
                        continue;
                    }

                    var cs = new Caso
                    {
                        Codigo = (string)caso1["codcaso"],
                        Documento = (string)caso1["numdoc"],
                        Grupo = group,
                        Descripcion = desc,
                        Estado = state,
                        Lines = num
                    };
                    subGroup.Add(cs);
                }
                facGroup.AddRange(subGroup);
            }
            lblCountFact.Text = facGroup.Count + @" Registros";

            gridFacturas.Rows.Clear();
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
                var casos = (JArray)boleta["casos"];
                if (group == 13) // Resumen
                {
                    mtabResumen.Visible = true;
                    lblStateResumen.Text = (string)casos.First["estado"];
                    continue;
                }
                
                var subGroup = new List<Caso>();
                foreach (var caso1 in casos)
                {
                    var desc = (string)caso1["descaso"];
                    var isNota = desc.StartsWith("NOTA", StringComparison.InvariantCultureIgnoreCase);
                    var num = GetNumItems(desc, isNota);
                    var state = (string)caso1["estado"];
                    if (isNota)
                    {
                        //if (state.Equals("Aprobado", StringComparison.InvariantCultureIgnoreCase)) continue;

                        if (desc.Contains("crédito"))
                            subGroup[num - 1].HasNotaCredit = true;
                        else
                            subGroup[num - 1].HasNotaDebit = true;
                        continue;
                    }

                    var cs = new Caso
                    {
                        Codigo = (string)caso1["codcaso"],
                        Documento = (string)caso1["numdoc"],
                        Grupo = group,
                        Descripcion = desc,
                        Estado = state,
                        Lines = num
                    };
                    subGroup.Add(cs);
                }
                bolGroup.AddRange(subGroup);
            }
            lblCountBoletas.Text = bolGroup.Count + @" Registros";
            gridBoletas.Rows.Clear();
            foreach (var gr in bolGroup)
            {
                gridBoletas.Rows.Add(gr.Grupo, gr.Codigo, gr.Descripcion, gr.Documento, gr.Lines, gr.HasNotaCredit, gr.HasNotaDebit, gr.Estado);
            }
        }
        private async Task<string> GetNumProceso()
        {
            var json = await _auth.GetSolicitudes();
            if (json == null) return null;
            var obj = JObject.Parse(json);
            var items = (JArray)obj["items"];
            //var node = items.FirstOrDefault(r => string.IsNullOrWhiteSpace(r["fecnot"].ToString()));
            var node = items.FirstOrDefault();
            if (node != null) return (string)node["numsol"];
            return null;
        }

        private int GetNumItems(string content, bool isNota)
        {
            var arrs = content.Split(' ');
            return int.Parse(isNota ? arrs[arrs.Length - 1] : arrs[arrs.Length - 2]);
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
                    Application.Exit();
                    return;
                }
                Init();
            }
        }

        #region Messages Box
        private void Success(string msg)
        {
            MetroMessageBox.Show(this, msg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void Error(string msg)
        {
            MetroMessageBox.Show(this, msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void Alert(string msg)
        {
            MetroMessageBox.Show(this, msg, "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        } 
        #endregion

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

        private void mtcontextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var source = mtcontextMenu.SourceControl as MetroGrid;

            if (source?.SelectedRows.Count != 1) return;

            var suffix = source == gridBoletas ? "b" : "f";
            var cells = source.SelectedRows[0].Cells;

            var hasNcr = (bool)cells[suffix + "notacr"].Value;
            var hasNdb = (bool)cells[suffix + "notadb"].Value;
            if (hasNcr || hasNdb)
            {
                menuNcr.Visible = hasNcr;
                menuNdb.Visible = hasNdb;
                return;
            }
            e.Cancel = true;
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            Init();
        }

        #region Notas

        private async void menuNota_Click(object sender, EventArgs e)
        {
            var grid = (MetroGrid)mtcontextMenu.SourceControl;
            var rows = grid.SelectedRows;
            if (rows.Count != 1) return;

            var isFact = mtcontextMenu.SourceControl == gridFacturas;
            var sufx = isFact ? "f" : "b";
            var row = rows[0];

            var doc = row.Cells[sufx + "documento"].Value.ToString();
            if (!doc.Contains("-"))
            {
                Alert("Caso de prueba, no tiene documento enviado.");
                return;
            }

            var gr = row.Cells[sufx + "group"].Value.ToString();
            
            var lines = int.Parse(row.Cells[sufx + "cantidad"].Value.ToString());
            GrupoPrueba gro;

            if (isFact)
            {
                gro = ToEnum<GrupoPrueba>(gr);
            }
            else
            {
                gro = gr == "12"
                    ? GrupoPrueba.OtrasMonedas
                    : (GrupoPrueba)Enum.ToObject(typeof(GrupoPrueba), int.Parse(gr) - 7);
            }

            var inv = new FacturaGenerator()
                    .ToCompany(_company)
                    .ForDoc(isFact ? "01" : "03")
                    .ForGroup(gro)
                    .WithLines(lines)
                    .Build();

            var arrs = doc.Split('-');
            inv.SerieDocumento = arrs[0];
            inv.CorrelativoDocumento = arrs[1];

            var mng = new BillManager(_company);

            var gn = new NotaGenerator()
                        .From(inv);

            if (sender == menuNcr)
            {
                var ncr = gn.BuildNcr();
                row.Cells[sufx + "notacr"].Value = !(await mng.Send(ncr)).Success;
            }
            else
            {
                var ncr = gn.BuildNdb();
                row.Cells[sufx + "notadb"].Value = !(await mng.Send(ncr)).Success;
            }
            
        }
        #endregion
    }
}
