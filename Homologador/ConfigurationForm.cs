using System;
using System.IO;
using System.Windows.Forms;
using Homologador.Fe.Auth;
using Homologador.Properties;
using MetroFramework;
using MetroFramework.Forms;
using Newtonsoft.Json.Linq;

namespace Homologador
{
    public partial class ConfigurationForm : MetroForm
    {
        public ConfigurationForm()
        {
            InitializeComponent();
            Load += ConfigurationForm_Load;
        }

        private void ConfigurationForm_Load(object sender, EventArgs e)
        {
            var sett = Settings.Default;
            txtRuc.Text = sett.Ruc;
            txtRsz.Text = sett.RzSocial;
            txtNomComercial.Text = sett.NComercial;
            txtUbigueo.Text = sett.Ubigueo;
            txtDirecion.Text = sett.Direccion;
            txtUrbanizacion.Text = sett.Urbanizacion;
            txtDepartment.Text = sett.Departamento;
            txtProvincia.Text = sett.Provincia;
            txtDistrito.Text = sett.Distrito;
            txtUser.Text = sett.Usuario;
            txtClave.Text = sett.Clave;
            txtClaveCert.Text = sett.ClaveCert;
            txtPathCertify.Tag = sett.Certificado;
            chkProveedor.Checked = sett.EsProveedor;
            metroTabControl1.SelectTab(0);
        }

        private void btnCertificate_Click(object sender, EventArgs e)
        {
            var open = new OpenFileDialog {Filter = @"Pfx Files (*.pfx)|*.pfx"};
            if (open.ShowDialog() != DialogResult.OK)
                return;

            txtPathCertify.Tag = null;
            txtPathCertify.Text = open.FileName;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidarCredenciales()) return;

            var sett = Settings.Default;
            sett.Ruc = txtRuc.Text;
            sett.RzSocial = txtRsz.Text;
            sett.NComercial = txtNomComercial.Text;
            sett.Ubigueo = txtUbigueo.Text;
            sett.Direccion = txtDirecion.Text;
            sett.Urbanizacion = txtUrbanizacion.Text;
            sett.Departamento = txtDepartment.Text;
            sett.Provincia = txtProvincia.Text;
            sett.Distrito = txtDistrito.Text;
            sett.Usuario = txtUser.Text;
            sett.Clave = txtClave.Text;
            sett.ClaveCert = txtClaveCert.Text;
            sett.EsProveedor = chkProveedor.Checked;
            var pathCert = txtPathCertify.Text;

            if (txtPathCertify.Tag != null && (string)txtPathCertify.Tag != string.Empty)
            {
                sett.Certificado = (string)txtPathCertify.Tag;
            }
            else if (!string.IsNullOrWhiteSpace(pathCert) && File.Exists(pathCert))
            {
                var bytes = File.ReadAllBytes(pathCert);
                sett.Certificado = Convert.ToBase64String(bytes);
            }
            Settings.Default.Save();
            Close();
        }

        private bool ValidarCredenciales()
        {
            try
            {
                if (RucAuth.Validate(txtRuc.Text, txtUser.Text, txtClave.Text)) return true;
                MetroMessageBox.Show(this, "Credenciales invalidas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRuc.Focus();
            }
            catch (Exception e)
            {
                MetroMessageBox.Show(this, e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        private void btnLoadConfig_Click(object sender, EventArgs e)
        {
            var  dialog = new OpenFileDialog
            {
                Filter = Resources.FileFilterJson
            };

            if (dialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            var jsonText = File.ReadAllText(dialog.FileName);
            dynamic obj = JObject.Parse(jsonText);

            txtRuc.Text = obj.Ruc;
            txtRsz.Text = obj.RzSocial;
            txtNomComercial.Text = obj.NComercial;
            txtUbigueo.Text = obj.Ubigueo;
            txtDirecion.Text = obj.Direccion;
            txtUrbanizacion.Text = obj.Urbanizacion;
            txtDepartment.Text = obj.Departamento;
            txtProvincia.Text = obj.Provincia;
            txtDistrito.Text = obj.Distrito;
            txtUser.Text = obj.Usuario;
            txtClave.Text = obj.Clave;
            txtClaveCert.Text = obj.ClaveCert;
            chkProveedor.Checked = obj.EsProveedor;
            if (!string.IsNullOrEmpty(obj.Certificado))
            {
                txtPathCertify.Tag = obj.Certificado;
                txtPathCertify.Text = @"Certificado Cargado";
            }
        }

        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog
            {
                Filter = Resources.FileFilterJson,
                FileName = "homologador_settings.json"
            };

            if (dialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            dynamic obj = new JObject();

            obj.Ruc = txtRuc.Text;
            obj.RzSocial = txtRsz.Text;
            obj.NComercial = txtNomComercial.Text;
            obj.Ubigueo = txtUbigueo.Text;
            obj.Direccion = txtDirecion.Text;
            obj.Urbanizacion = txtUrbanizacion.Text;
            obj.Departamento = txtDepartment.Text;
            obj.Provincia = txtProvincia.Text;
            obj.Distrito = txtDistrito.Text;
            obj.Usuario = txtUser.Text;
            obj.Clave = txtClave.Text;
            obj.ClaveCert = txtClaveCert.Text;
            obj.EsProveedor = chkProveedor.Checked;
            if (!string.IsNullOrEmpty(txtPathCertify.Text) && File.Exists(txtPathCertify.Text))
            {
                var bytes = File.ReadAllBytes(txtPathCertify.Text);
                obj.Certificado = Convert.ToBase64String(bytes);
            }
            else if (txtPathCertify.Tag != null && (string)txtPathCertify.Tag != string.Empty)
            {
                obj.Certificado = txtPathCertify.Tag;
            }

            File.WriteAllText(dialog.FileName, obj.ToString());
            MetroMessageBox.Show(this, "Configuracion Guardada", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
