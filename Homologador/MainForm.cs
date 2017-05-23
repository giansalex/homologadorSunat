using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacturacionElectronica.GeneradorXml;
using FacturacionElectronica.GeneradorXml.Res;
using FacturacionElectronica.Homologacion;
using FacturacionElectronica.Homologacion.Res;
using Homologador.Fe.Auth;
using Homologador.Fe.Pruebas;
using Homologador.Model;
using Homologador.Properties;
using Homologador.Pruebas;
using MetroFramework;
using MetroFramework.Forms;
using Newtonsoft.Json.Linq;

namespace Homologador
{
    public partial class MainForm : MetroForm
    {
        private SunatApi _auth;
        public MainForm()
        {
            InitializeComponent();
            Theme = MetroThemeStyle.Dark;
            Load += MainForm_Load;
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            var sett = Settings.Default;
            //TODO: Init Login from config validate with exist configuration
            _auth = new SunatApi(sett.Ruc, sett.Usuario, sett.Clave);
            await Extractor();
            //tbDocs.Enabled = false;
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
            
        }

        private void Boleta_Run()
        {

        }

        private void Resumen_Run()
        {
            int cant;
            if (!int.TryParse(mtxtBajaCant.Text, out cant))
            {
                MetroMessageBox.Show(this, "Numero de items invalido", "Error");
                mtxtBajaCant.Focus();
                return;
            }

            var resumen = new ResumenGenerator()
                .ToCompany(GetCompany())
                .WithLines(cant)
                .Build();
        }

        private void Baja_Run()
        {
            int cant ;
            if (!int.TryParse(mtxtBajaCant.Text, out cant))
            {
                MetroMessageBox.Show(this, "Numero de items invalido", "Error");
                mtxtBajaCant.Focus();
                return;
            }

            var voided = new BajaGenerator()
                .ToCompany(GetCompany())
                .WithLines(cant)
                .Build();
;
        }

        private async Task Extractor()
        {
            _auth.Init();
            var numpr = await GetNumProceso();
            if (string.IsNullOrEmpty(numpr))
            {
                MetroMessageBox.Show(this, "No se encontro ningún proceso de homologación vigente", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;    
            }

            var json = await _auth.GetPruebas(numpr);
            if (json == null)
            {
                MetroMessageBox.Show(this, "No se pudo obtener informacion de las pruebas", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var obj = JObject.Parse(json);
            //if (obj["fecfinetapa"].ToString() != "-")
            //{
            //    MetroMessageBox.Show(this, "Ya finalizo el proceso de homologación", "Finalizado", MessageBoxButtons.OK);
            //    return;
            //}

            LoadFacs((JArray)obj["facturas"]);
            LoadBols((JArray)obj["boletas"]);
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

        private Company GetCompany()
        {
            var sett = Settings.Default;
            return new Company
            {
                Ruc = sett.Ruc,
                RazonSocial = sett.RzSocial,
                NombreComercial = sett.NComercial,
                Address = new CompanyAddress
                {
                    Ubigueo = sett.Ubigueo,
                    Urbanizacion = sett.Urbanizacion,
                    Departamento = sett.Departamento,
                    Provincia = sett.Provincia,
                    Distrito = sett.Distrito,
                    Direccion = sett.Direccion
                }
            };
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            using (var sett = new ConfigurationForm())
            {
                sett.ShowDialog(this); 
            }
        }

        private void Send()
        {
            var fact = new FacturaGenerator()
                .ToCompany(GetCompany())
                .ForGroup(GrupoPrueba.Gravada)
                .ForDoc("03")
                .WithLines(1)
                .Build();

            var gen = new XmlDocGenerator(new X509Certificate2("", ""));
            var op = new OperationResult();
            var r = gen.GeneraDocumentoInvoice(ref op, fact);
            var sett = Settings.Default;
            var mng = new SunatManager(new SolConfig
            {
                Ruc = sett.Ruc,
                Usuario = sett.Usuario,
                Clave = sett.Clave,
                Service = ServiceSunatType.Homologacion
            });
            var res = mng.SendDocument(r.FileName, r.Content);
        }
    }
}
