using System;
using System.IO;
using System.Windows.Forms;
using Homologador.Properties;
using MetroFramework.Forms;

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
            txtDirecion.Text = sett.Distrito;
            txtUser.Text = sett.Usuario;
            txtClave.Text = sett.Clave;
            txtClaveCert.Text = sett.ClaveCert;
        }

        private void btnCertificate_Click(object sender, EventArgs e)
        {
            var open = new OpenFileDialog {Filter = @"Pfx Files (*.pfx)|*.pfx"};
            if (open.ShowDialog() != DialogResult.OK)
                return;

            txtPathCertify.Text = open.FileName;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var sett = Settings.Default;

            sett.Ruc = txtRuc.Text;
            sett.RzSocial = txtRsz.Text;
            sett.NComercial = txtNomComercial.Text;
            sett.Ubigueo = txtUbigueo.Text;
            sett.Direccion = txtDirecion.Text;
            sett.Urbanizacion = txtUrbanizacion.Text;
            sett.Departamento = txtDepartment.Text;
            sett.Provincia = txtProvincia.Text;
            sett.Direccion = txtDistrito.Text;
            sett.Usuario = txtUser.Text;
            sett.Clave = txtClave.Text;
            sett.ClaveCert = txtClaveCert.Text;
            var pathCert = txtPathCertify.Text;
            if (!string.IsNullOrWhiteSpace(pathCert) && File.Exists(pathCert))
            {
                var bytes = File.ReadAllBytes(pathCert);
                sett.Ceritificado = Convert.ToBase64String(bytes);
            }
            Settings.Default.Save();
        }
    }
}
