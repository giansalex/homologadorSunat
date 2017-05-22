using System;
using System.Data;
using System.Drawing;
using MetroFramework;
using MetroFramework.Forms;

namespace Homologador
{
    public partial class MainForm : MetroForm
    {
        public MainForm()
        {
            InitializeComponent();
            Theme = MetroThemeStyle.Dark;
            Load += MainForm_Load;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //tbDocs.Enabled = false;
        }

        private void LoadFacturas()
        {
            gridFacturas.Rows.Add("1", "FACTURA 1", "F001-11", 1,"APROBADO");
            gridFacturas.Rows.Add("2", "FACTURA 2", "F001-11", 2,"APROBADO");
            gridFacturas.Rows.Add("3", "FACTURA 3", "F001-11", 3,"APROBADO");
            gridFacturas.Rows.Add("4", "FACTURA 4", "F001-11", 4,"APROBADO");
        }

        private void LoadBoletas()
        {

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

        public void Factura_Run()
        {
            
        }

        public void Boleta_Run()
        {

        }

        public void Resumen_Run()
        {

        }

        public void Baja_Run()
        {

        }
    }
}
