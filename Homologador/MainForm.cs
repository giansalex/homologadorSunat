using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autofac;
using FacturacionElectronica.GeneradorXml.Entity;
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
using Squirrel;

namespace Homologador
{
    /// <summary>
    /// Class MainForm.
    /// </summary>
    public partial class MainForm : MetroForm
    {
        private SunatApi _auth;
        private Action<string> Success;
        private Action<string> Error;
        private readonly ILifetimeScope _lifetimeScope;

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
                        Content = Convert.FromBase64String(sett.Certificado),
                        Password = sett.ClaveCert
                    }
                };
            }
        }

        public MainForm(ILifetimeScope lifetimeScope)
        {
            InitializeComponent();
            Success = SuccessBox;
            Error = ErrorBox;
            Theme = MetroThemeStyle.Dark;
            _lifetimeScope = lifetimeScope;
            Load += MainForm_Load;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Task.Factory.StartNew(async () => await UpdateApp());
            Init();
        }

        private async void Init()
        {
            try
            {
                InitLoad();
                var assembly = Assembly.GetExecutingAssembly();
                lblVersion.Text = assembly.GetName().Version.ToString(3);

                var sett = Settings.Default;
                UriProvider.IsProveedor = sett.EsProveedor;
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

        private async Task UpdateApp()
        {
            try
            {
                using (var mgr = await UpdateManager.GitHubUpdateManager(Resources.GibhubLinkProject))
                {
                    var updates = await mgr.CheckForUpdate();
                    var lastVersion = updates?.ReleasesToApply?.OrderBy(x => x.Version).LastOrDefault();
                    if (lastVersion == null)
                    {
                        return;
                    }

                    if (MetroMessageBox.Show(this, string.Format(Resources.MsgFormatUpdateAvailable, lastVersion.Version),
                            Resources.MsgUpdateAvaliableTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    {
                        return;
                    }
                    ConfigHelper.BackupSettings();
#if DEBUG
                    SuccessBox("DEBUG: Don't actually perform the update in debug mode");
                }
#else
                    await mgr.DownloadReleases(new[] { lastVersion });
                    await mgr.ApplyReleases(updates);
                    await mgr.UpdateApp();
                    ConfigHelper.RestoreSettings();
                    SuccessBox(Resources.MsgRestartAfterUpdate);

                }

                UpdateManager.RestartApp();
#endif
            }
            catch (Exception e)
            {
                ErrorBox("Update check failed with an exception: " + e.Message);
            }
        }
        private void InitLoad()
        {
            spinner.Visible = true;
        }

        private async void btnRun_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception er)
            {
                spinner.Visible = false;
                Error(er.Message);
            }
        }

        private async Task Factura_Run()
        {
            var rows = gridFacturas.SelectedRows;
            if (rows.Count == 0) return;

            InitLoad();
            Status("Iniciando Envío...");

            var mng = new BillManager(_company);
            var fgenerator = new FacturaGenerator()
                    .ToCompany(_company)
                    .ForDoc("01");

            foreach (DataGridViewRow row in rows)
            {
                if (row.Cells["festado"].Value.ToString()
                    .Equals("Aprobado", StringComparison.InvariantCultureIgnoreCase)) continue;

                var grCode = row.Cells["fgroup"].Value.ToString();
                var lines = int.Parse(row.Cells["fcantidad"].Value.ToString());
                var hasNcr = bool.Parse(row.Cells["fnotacr"].Value.ToString());
                var hasNdb = bool.Parse(row.Cells["fnotadb"].Value.ToString());

                var inv = fgenerator
                    .ForGroup(GroupHelper.GetFromCode(grCode))
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
            spinner.Visible = false;
            var msg = gridFacturas.SelectedRows.Count > 1 ? "Facturas Enviadas" : "Factura Enviada";
            if (gridFacturas.SelectedRows.Count > 1) Success(msg);
            Status(msg);
        }

        private async Task Boleta_Run()
        {
            var rows = gridBoletas.SelectedRows;
            if (rows.Count == 0) return;
            InitLoad();
            Status("Iniciando Envío...");

            var mng = new BillManager(_company);
            var fgenerator = new FacturaGenerator()
                .ToCompany(_company)
                .ForDoc("03");

            foreach (DataGridViewRow row in rows)
            {
                if (row.Cells["bestado"].Value.ToString()
                    .Equals("Aprobado", StringComparison.InvariantCultureIgnoreCase)) continue;

                var grCode = row.Cells["bgroup"].Value.ToString();
                var lines = int.Parse(row.Cells["bcantidad"].Value.ToString());
                var hasNcr = bool.Parse(row.Cells["bnotacr"].Value.ToString());
                var hasNdb = bool.Parse(row.Cells["bnotadb"].Value.ToString());

                var inv = fgenerator
                    .ForGroup(GroupHelper.GetFromCode(grCode))
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
                    var result = await mng.Send(ncr);
                    var cell = row.Cells["bnotacr"];
                    cell.Value = !result.Success;
                    cell.ToolTipText = result.Description;
                }

                if (hasNdb)
                {
                    var ndb = nGene.BuildNdb();
                    var result = await mng.Send(ndb);
                    var cell = row.Cells["bnotadb"];
                    cell.Value = !result.Success;
                    cell.ToolTipText = result.Description;
                }
            }
            spinner.Visible = false;
            var msg = gridBoletas.SelectedRows.Count > 1 ? "Boletas Enviadas" : "Boleta Enviada";
            if (gridBoletas.SelectedRows.Count > 1) Success(msg);
            Status(msg);
        }

        private async Task Resumen_Run()
        {
            int cant;
            if (!int.TryParse(mtxtItemsRes.Text, out cant))
            {
                Error("Numero de items invalido");
                mtxtBajaCant.Focus();
                return;
            }

            await SendResumen(cant);
        }

        private async Task SendResumen(int cant)
        {
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
            int cant;
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
            if (obj["fecfinetapa"].ToString() != "-")
            {
                Success("Ya finalizo el proceso de homologación");
                return;
            }

            JToken token;
            if (obj.TryGetValue("facturas", out token) && token.HasValues)
            {
                LoadFacs((JArray)token);
            }
            else
            {
                mtabFacturas.Visible = false;
                mtabBajas.Visible = false;
            }

            if (obj.TryGetValue("boletas", out token) && token.HasValues)
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
                    var state = (string)caso1["estado"];
                    if (isNota)
                    {
                        if (state.Equals("Aprobado", StringComparison.InvariantCultureIgnoreCase)) continue;

                        if (desc.Contains("dito")) // credito
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
                        if (state.Equals("Aprobado", StringComparison.InvariantCultureIgnoreCase)) continue;

                        if (desc.Contains("dito"))
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
            var node = items.FirstOrDefault(r => string.IsNullOrWhiteSpace(r["fecnot"].ToString()));
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
            using (var frm = _lifetimeScope.Resolve<ConfigurationForm>())
            {
                var result = frm.ShowDialog(this);
                var sett = Settings.Default;
                if (string.IsNullOrWhiteSpace(sett.Ruc)
                    || string.IsNullOrWhiteSpace(sett.Usuario)
                    || string.IsNullOrWhiteSpace(sett.Clave))
                {
                    Application.Exit();
                    return;
                }

                if (result == DialogResult.OK)
                    Init();
            }
        }

        #region Messages Box
        private void SuccessBox(string msg)
        {
            MetroMessageBox.Show(this, msg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void ErrorBox(string msg)
        {
            MetroMessageBox.Show(this, msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void Alert(string msg)
        {
            MetroMessageBox.Show(this, msg, "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        #endregion

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

        private void pictGithub_Click(object sender, EventArgs e)
        {
            Process.Start(Resources.GibhubLinkProject);
        }

        private async void pictSendAll_Click(object sender, EventArgs e)
        {
            Success = Status;
            Error = Status;
            var isPse = Settings.Default.EsProveedor;
            try
            {
                await Factura_Run();
                await Boleta_Run();
                await SendResumen(5);
                if (isPse)
                    await SendResumen(3);
                await Baja_Run();
            }
            catch (Exception)
            {
                ErrorBox("No se pudo enviar todos los casos de pruebas.");
            }
            finally
            {
                Success = SuccessBox;
                Error = ErrorBox;
            }
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

            var arrs = doc.Split('-');
            var inv = CreateInvoiceForNote(isFact ? "01" : "03", arrs[0], arrs[1]);

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

        private InvoiceHeader CreateInvoiceForNote(string tipo, string serie, string correlativo)
        {
            var inv = new FacturaGenerator()
                .ToCompany(_company)
                .ForDoc(tipo)
                .ForGroup(GrupoPrueba.Gravada)
                .WithLines(1)
                .Build();

            inv.SerieDocumento = serie;
            inv.CorrelativoDocumento = correlativo;

            return inv;
        }
        #endregion
    }
}
