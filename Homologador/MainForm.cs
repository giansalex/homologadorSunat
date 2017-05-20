using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            gridFacturas.Rows.Add("1", "FACTURA 1", "F001-11", "APROBADO");
            gridFacturas.Rows.Add("2", "FACTURA 2", "F001-11", "APROBADO");
            gridFacturas.Rows.Add("3", "FACTURA 3", "F001-11", "APROBADO");
            gridFacturas.Rows.Add("4", "FACTURA 4", "F001-11", "APROBADO");
            //gridFacturas.DataSource = LoadFacturas();
        }

        private DataTable LoadFacturas()
        {
            DataTable table = new DataTable();
            table.Columns.Add("codigo");
            table.Columns.Add("caso");
            table.Columns.Add("documento");
            table.Columns.Add("estado");

            table.Rows.Add("1", "FACTURA 1", "F001-11", "APROBADO");
            table.Rows.Add("2", "FACTURA 2", "F001-11", "APROBADO");
            table.Rows.Add("3", "FACTURA 3", "F001-11", "APROBADO");
            table.Rows.Add("4", "FACTURA 4", "F001-11", "APROBADO");
            return table;
        }
    }
}
