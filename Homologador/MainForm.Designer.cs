namespace Homologador
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tbDocs = new MetroFramework.Controls.MetroTabControl();
            this.mtabFacturas = new MetroFramework.Controls.MetroTabPage();
            this.lblCountFact = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.gridFacturas = new MetroFramework.Controls.MetroGrid();
            this.fgroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fcodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fdescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fdocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fcantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fnotacr = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.fnotadb = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.festado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mtcontextMenu = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.menuNcr = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNdb = new System.Windows.Forms.ToolStripMenuItem();
            this.mtabBoletas = new MetroFramework.Controls.MetroTabPage();
            this.lblCountBoletas = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.gridBoletas = new MetroFramework.Controls.MetroGrid();
            this.bgroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bcodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bdescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bdocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bcantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bnotacr = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bnotadb = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bestado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mtabBajas = new MetroFramework.Controls.MetroTabPage();
            this.lblStateBaja = new MetroFramework.Controls.MetroLabel();
            this.mtxtBajaCant = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.mtabResumen = new MetroFramework.Controls.MetroTabPage();
            this.lblStateResumen = new MetroFramework.Controls.MetroLabel();
            this.mtxtItemsRes = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.lblStatus = new MetroFramework.Controls.MetroLabel();
            this.spinner = new MetroFramework.Controls.MetroProgressSpinner();
            this.btnSync = new System.Windows.Forms.PictureBox();
            this.btnSetting = new System.Windows.Forms.PictureBox();
            this.btnRun = new System.Windows.Forms.PictureBox();
            this.tbDocs.SuspendLayout();
            this.mtabFacturas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridFacturas)).BeginInit();
            this.mtcontextMenu.SuspendLayout();
            this.mtabBoletas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridBoletas)).BeginInit();
            this.mtabBajas.SuspendLayout();
            this.mtabResumen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSync)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSetting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRun)).BeginInit();
            this.SuspendLayout();
            // 
            // tbDocs
            // 
            this.tbDocs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDocs.Controls.Add(this.mtabFacturas);
            this.tbDocs.Controls.Add(this.mtabBoletas);
            this.tbDocs.Controls.Add(this.mtabBajas);
            this.tbDocs.Controls.Add(this.mtabResumen);
            this.tbDocs.Location = new System.Drawing.Point(23, 63);
            this.tbDocs.Name = "tbDocs";
            this.tbDocs.SelectedIndex = 0;
            this.tbDocs.Size = new System.Drawing.Size(615, 350);
            this.tbDocs.TabIndex = 0;
            this.tbDocs.UseSelectable = true;
            // 
            // mtabFacturas
            // 
            this.mtabFacturas.Controls.Add(this.lblCountFact);
            this.mtabFacturas.Controls.Add(this.metroLabel1);
            this.mtabFacturas.Controls.Add(this.gridFacturas);
            this.mtabFacturas.HorizontalScrollbarBarColor = true;
            this.mtabFacturas.HorizontalScrollbarHighlightOnWheel = false;
            this.mtabFacturas.HorizontalScrollbarSize = 10;
            this.mtabFacturas.Location = new System.Drawing.Point(4, 38);
            this.mtabFacturas.Name = "mtabFacturas";
            this.mtabFacturas.Size = new System.Drawing.Size(607, 308);
            this.mtabFacturas.TabIndex = 0;
            this.mtabFacturas.Text = "Facturas";
            this.mtabFacturas.VerticalScrollbarBarColor = true;
            this.mtabFacturas.VerticalScrollbarHighlightOnWheel = false;
            this.mtabFacturas.VerticalScrollbarSize = 10;
            // 
            // lblCountFact
            // 
            this.lblCountFact.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCountFact.Location = new System.Drawing.Point(431, 290);
            this.lblCountFact.Name = "lblCountFact";
            this.lblCountFact.Size = new System.Drawing.Size(177, 19);
            this.lblCountFact.TabIndex = 4;
            this.lblCountFact.Text = "0 Registros";
            this.lblCountFact.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(2, 4);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(56, 19);
            this.metroLabel1.TabIndex = 3;
            this.metroLabel1.Text = "Facturas";
            // 
            // gridFacturas
            // 
            this.gridFacturas.AllowUserToAddRows = false;
            this.gridFacturas.AllowUserToDeleteRows = false;
            this.gridFacturas.AllowUserToResizeRows = false;
            this.gridFacturas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridFacturas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridFacturas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridFacturas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gridFacturas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridFacturas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridFacturas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fgroup,
            this.fcodigo,
            this.fdescripcion,
            this.fdocumento,
            this.fcantidad,
            this.fnotacr,
            this.fnotadb,
            this.festado});
            this.gridFacturas.ContextMenuStrip = this.mtcontextMenu;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridFacturas.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridFacturas.EnableHeadersVisualStyles = false;
            this.gridFacturas.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridFacturas.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridFacturas.Location = new System.Drawing.Point(-2, 27);
            this.gridFacturas.Name = "gridFacturas";
            this.gridFacturas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridFacturas.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridFacturas.RowHeadersVisible = false;
            this.gridFacturas.RowHeadersWidth = 20;
            this.gridFacturas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridFacturas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridFacturas.Size = new System.Drawing.Size(611, 263);
            this.gridFacturas.TabIndex = 2;
            // 
            // fgroup
            // 
            this.fgroup.HeaderText = "Grupo";
            this.fgroup.Name = "fgroup";
            this.fgroup.ReadOnly = true;
            this.fgroup.Width = 40;
            // 
            // fcodigo
            // 
            this.fcodigo.HeaderText = "Codigo";
            this.fcodigo.Name = "fcodigo";
            this.fcodigo.ReadOnly = true;
            this.fcodigo.Width = 50;
            // 
            // fdescripcion
            // 
            this.fdescripcion.HeaderText = "Descripción";
            this.fdescripcion.Name = "fdescripcion";
            this.fdescripcion.ReadOnly = true;
            this.fdescripcion.Width = 160;
            // 
            // fdocumento
            // 
            this.fdocumento.HeaderText = "Documento";
            this.fdocumento.Name = "fdocumento";
            this.fdocumento.ReadOnly = true;
            // 
            // fcantidad
            // 
            this.fcantidad.HeaderText = "Cantidad";
            this.fcantidad.Name = "fcantidad";
            this.fcantidad.Width = 55;
            // 
            // fnotacr
            // 
            this.fnotacr.HeaderText = "Ncr";
            this.fnotacr.Name = "fnotacr";
            this.fnotacr.ReadOnly = true;
            this.fnotacr.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.fnotacr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.fnotacr.Width = 30;
            // 
            // fnotadb
            // 
            this.fnotadb.HeaderText = "Ndb";
            this.fnotadb.Name = "fnotadb";
            this.fnotadb.ReadOnly = true;
            this.fnotadb.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.fnotadb.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.fnotadb.Width = 30;
            // 
            // festado
            // 
            this.festado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.festado.HeaderText = "Estado";
            this.festado.Name = "festado";
            this.festado.ReadOnly = true;
            // 
            // mtcontextMenu
            // 
            this.mtcontextMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mtcontextMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mtcontextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNcr,
            this.menuNdb});
            this.mtcontextMenu.Name = "mtcontextMenu";
            this.mtcontextMenu.Size = new System.Drawing.Size(195, 48);
            this.mtcontextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.mtcontextMenu_Opening);
            // 
            // menuNcr
            // 
            this.menuNcr.Name = "menuNcr";
            this.menuNcr.Size = new System.Drawing.Size(194, 22);
            this.menuNcr.Text = "Enviar Nota De Crédito";
            this.menuNcr.Click += new System.EventHandler(this.menuNcr_Click);
            // 
            // menuNdb
            // 
            this.menuNdb.Name = "menuNdb";
            this.menuNdb.Size = new System.Drawing.Size(194, 22);
            this.menuNdb.Text = "Enviar Nota de Débito";
            this.menuNdb.Click += new System.EventHandler(this.menuNdb_Click);
            // 
            // mtabBoletas
            // 
            this.mtabBoletas.Controls.Add(this.lblCountBoletas);
            this.mtabBoletas.Controls.Add(this.metroLabel5);
            this.mtabBoletas.Controls.Add(this.gridBoletas);
            this.mtabBoletas.HorizontalScrollbarBarColor = true;
            this.mtabBoletas.HorizontalScrollbarHighlightOnWheel = false;
            this.mtabBoletas.HorizontalScrollbarSize = 10;
            this.mtabBoletas.Location = new System.Drawing.Point(4, 38);
            this.mtabBoletas.Name = "mtabBoletas";
            this.mtabBoletas.Size = new System.Drawing.Size(607, 308);
            this.mtabBoletas.TabIndex = 1;
            this.mtabBoletas.Text = "Boletas";
            this.mtabBoletas.VerticalScrollbarBarColor = true;
            this.mtabBoletas.VerticalScrollbarHighlightOnWheel = false;
            this.mtabBoletas.VerticalScrollbarSize = 10;
            // 
            // lblCountBoletas
            // 
            this.lblCountBoletas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCountBoletas.Location = new System.Drawing.Point(431, 290);
            this.lblCountBoletas.Name = "lblCountBoletas";
            this.lblCountBoletas.Size = new System.Drawing.Size(177, 19);
            this.lblCountBoletas.TabIndex = 7;
            this.lblCountBoletas.Text = "0 Registros";
            this.lblCountBoletas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(2, 4);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(51, 19);
            this.metroLabel5.TabIndex = 6;
            this.metroLabel5.Text = "Boletas";
            // 
            // gridBoletas
            // 
            this.gridBoletas.AllowUserToAddRows = false;
            this.gridBoletas.AllowUserToDeleteRows = false;
            this.gridBoletas.AllowUserToResizeRows = false;
            this.gridBoletas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridBoletas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridBoletas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridBoletas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gridBoletas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridBoletas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gridBoletas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridBoletas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.bgroup,
            this.bcodigo,
            this.bdescripcion,
            this.bdocumento,
            this.bcantidad,
            this.bnotacr,
            this.bnotadb,
            this.bestado});
            this.gridBoletas.ContextMenuStrip = this.mtcontextMenu;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridBoletas.DefaultCellStyle = dataGridViewCellStyle5;
            this.gridBoletas.EnableHeadersVisualStyles = false;
            this.gridBoletas.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridBoletas.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridBoletas.Location = new System.Drawing.Point(-2, 27);
            this.gridBoletas.Name = "gridBoletas";
            this.gridBoletas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridBoletas.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gridBoletas.RowHeadersVisible = false;
            this.gridBoletas.RowHeadersWidth = 20;
            this.gridBoletas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridBoletas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridBoletas.Size = new System.Drawing.Size(611, 259);
            this.gridBoletas.TabIndex = 5;
            // 
            // bgroup
            // 
            this.bgroup.HeaderText = "Grupo";
            this.bgroup.Name = "bgroup";
            this.bgroup.ReadOnly = true;
            this.bgroup.Width = 40;
            // 
            // bcodigo
            // 
            this.bcodigo.HeaderText = "Codigo";
            this.bcodigo.Name = "bcodigo";
            this.bcodigo.ReadOnly = true;
            this.bcodigo.Width = 50;
            // 
            // bdescripcion
            // 
            this.bdescripcion.HeaderText = "Descripción";
            this.bdescripcion.Name = "bdescripcion";
            this.bdescripcion.ReadOnly = true;
            this.bdescripcion.Width = 160;
            // 
            // bdocumento
            // 
            this.bdocumento.HeaderText = "Documento";
            this.bdocumento.Name = "bdocumento";
            this.bdocumento.ReadOnly = true;
            // 
            // bcantidad
            // 
            this.bcantidad.HeaderText = "Cantidad";
            this.bcantidad.Name = "bcantidad";
            this.bcantidad.Width = 55;
            // 
            // bnotacr
            // 
            this.bnotacr.HeaderText = "Ncr";
            this.bnotacr.Name = "bnotacr";
            this.bnotacr.ReadOnly = true;
            this.bnotacr.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.bnotacr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.bnotacr.Width = 30;
            // 
            // bnotadb
            // 
            this.bnotadb.HeaderText = "Ndb";
            this.bnotadb.Name = "bnotadb";
            this.bnotadb.ReadOnly = true;
            this.bnotadb.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.bnotadb.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.bnotadb.Width = 30;
            // 
            // bestado
            // 
            this.bestado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.bestado.HeaderText = "Estado";
            this.bestado.Name = "bestado";
            this.bestado.ReadOnly = true;
            // 
            // mtabBajas
            // 
            this.mtabBajas.Controls.Add(this.lblStateBaja);
            this.mtabBajas.Controls.Add(this.mtxtBajaCant);
            this.mtabBajas.Controls.Add(this.metroLabel2);
            this.mtabBajas.HorizontalScrollbarBarColor = true;
            this.mtabBajas.HorizontalScrollbarHighlightOnWheel = false;
            this.mtabBajas.HorizontalScrollbarSize = 10;
            this.mtabBajas.Location = new System.Drawing.Point(4, 38);
            this.mtabBajas.Name = "mtabBajas";
            this.mtabBajas.Size = new System.Drawing.Size(607, 308);
            this.mtabBajas.TabIndex = 3;
            this.mtabBajas.Text = "C. de Baja";
            this.mtabBajas.VerticalScrollbarBarColor = true;
            this.mtabBajas.VerticalScrollbarHighlightOnWheel = false;
            this.mtabBajas.VerticalScrollbarSize = 10;
            // 
            // lblStateBaja
            // 
            this.lblStateBaja.AutoSize = true;
            this.lblStateBaja.Location = new System.Drawing.Point(11, 55);
            this.lblStateBaja.Name = "lblStateBaja";
            this.lblStateBaja.Size = new System.Drawing.Size(80, 19);
            this.lblStateBaja.Style = MetroFramework.MetroColorStyle.Green;
            this.lblStateBaja.TabIndex = 4;
            this.lblStateBaja.Text = "No Definido";
            // 
            // mtxtBajaCant
            // 
            // 
            // 
            // 
            this.mtxtBajaCant.CustomButton.Image = null;
            this.mtxtBajaCant.CustomButton.Location = new System.Drawing.Point(53, 1);
            this.mtxtBajaCant.CustomButton.Name = "";
            this.mtxtBajaCant.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.mtxtBajaCant.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mtxtBajaCant.CustomButton.TabIndex = 1;
            this.mtxtBajaCant.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtxtBajaCant.CustomButton.UseSelectable = true;
            this.mtxtBajaCant.CustomButton.Visible = false;
            this.mtxtBajaCant.Lines = new string[] {
        "5"};
            this.mtxtBajaCant.Location = new System.Drawing.Point(65, 16);
            this.mtxtBajaCant.MaxLength = 32767;
            this.mtxtBajaCant.Name = "mtxtBajaCant";
            this.mtxtBajaCant.PasswordChar = '\0';
            this.mtxtBajaCant.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mtxtBajaCant.SelectedText = "";
            this.mtxtBajaCant.SelectionLength = 0;
            this.mtxtBajaCant.SelectionStart = 0;
            this.mtxtBajaCant.ShortcutsEnabled = true;
            this.mtxtBajaCant.Size = new System.Drawing.Size(75, 23);
            this.mtxtBajaCant.TabIndex = 3;
            this.mtxtBajaCant.Text = "5";
            this.mtxtBajaCant.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mtxtBajaCant.UseSelectable = true;
            this.mtxtBajaCant.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mtxtBajaCant.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(11, 16);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(40, 19);
            this.metroLabel2.TabIndex = 2;
            this.metroLabel2.Text = "Items";
            // 
            // mtabResumen
            // 
            this.mtabResumen.Controls.Add(this.lblStateResumen);
            this.mtabResumen.Controls.Add(this.mtxtItemsRes);
            this.mtabResumen.Controls.Add(this.metroLabel3);
            this.mtabResumen.HorizontalScrollbarBarColor = true;
            this.mtabResumen.HorizontalScrollbarHighlightOnWheel = false;
            this.mtabResumen.HorizontalScrollbarSize = 10;
            this.mtabResumen.Location = new System.Drawing.Point(4, 38);
            this.mtabResumen.Name = "mtabResumen";
            this.mtabResumen.Size = new System.Drawing.Size(607, 308);
            this.mtabResumen.TabIndex = 2;
            this.mtabResumen.Text = "Resumen";
            this.mtabResumen.VerticalScrollbarBarColor = true;
            this.mtabResumen.VerticalScrollbarHighlightOnWheel = false;
            this.mtabResumen.VerticalScrollbarSize = 10;
            // 
            // lblStateResumen
            // 
            this.lblStateResumen.AutoSize = true;
            this.lblStateResumen.Location = new System.Drawing.Point(11, 55);
            this.lblStateResumen.Name = "lblStateResumen";
            this.lblStateResumen.Size = new System.Drawing.Size(80, 19);
            this.lblStateResumen.Style = MetroFramework.MetroColorStyle.Green;
            this.lblStateResumen.TabIndex = 6;
            this.lblStateResumen.Text = "No Definido";
            // 
            // mtxtItemsRes
            // 
            // 
            // 
            // 
            this.mtxtItemsRes.CustomButton.Image = null;
            this.mtxtItemsRes.CustomButton.Location = new System.Drawing.Point(53, 1);
            this.mtxtItemsRes.CustomButton.Name = "";
            this.mtxtItemsRes.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.mtxtItemsRes.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mtxtItemsRes.CustomButton.TabIndex = 1;
            this.mtxtItemsRes.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtxtItemsRes.CustomButton.UseSelectable = true;
            this.mtxtItemsRes.CustomButton.Visible = false;
            this.mtxtItemsRes.Lines = new string[] {
        "5"};
            this.mtxtItemsRes.Location = new System.Drawing.Point(65, 16);
            this.mtxtItemsRes.MaxLength = 32767;
            this.mtxtItemsRes.Name = "mtxtItemsRes";
            this.mtxtItemsRes.PasswordChar = '\0';
            this.mtxtItemsRes.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mtxtItemsRes.SelectedText = "";
            this.mtxtItemsRes.SelectionLength = 0;
            this.mtxtItemsRes.SelectionStart = 0;
            this.mtxtItemsRes.ShortcutsEnabled = true;
            this.mtxtItemsRes.Size = new System.Drawing.Size(75, 23);
            this.mtxtItemsRes.TabIndex = 5;
            this.mtxtItemsRes.Text = "5";
            this.mtxtItemsRes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mtxtItemsRes.UseSelectable = true;
            this.mtxtItemsRes.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mtxtItemsRes.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(11, 16);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(40, 19);
            this.metroLabel3.TabIndex = 4;
            this.metroLabel3.Text = "Items";
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            this.metroStyleManager1.Style = MetroFramework.MetroColorStyle.Green;
            this.metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(2, 416);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(35, 19);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Listo";
            // 
            // spinner
            // 
            this.spinner.Location = new System.Drawing.Point(385, 7);
            this.spinner.Maximum = 100;
            this.spinner.Name = "spinner";
            this.spinner.Size = new System.Drawing.Size(60, 50);
            this.spinner.TabIndex = 4;
            this.spinner.UseSelectable = true;
            this.spinner.Visible = false;
            // 
            // btnSync
            // 
            this.btnSync.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSync.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSync.Image = global::Homologador.Properties.Resources.Sincronizar;
            this.btnSync.Location = new System.Drawing.Point(570, 39);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(32, 33);
            this.btnSync.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnSync.TabIndex = 6;
            this.btnSync.TabStop = false;
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
            // 
            // btnSetting
            // 
            this.btnSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSetting.Image = global::Homologador.Properties.Resources.ajustes;
            this.btnSetting.Location = new System.Drawing.Point(608, 39);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(32, 33);
            this.btnSetting.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnSetting.TabIndex = 5;
            this.btnSetting.TabStop = false;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // btnRun
            // 
            this.btnRun.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRun.Image = global::Homologador.Properties.Resources.play;
            this.btnRun.Location = new System.Drawing.Point(281, 19);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(40, 37);
            this.btnRun.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnRun.TabIndex = 3;
            this.btnRun.TabStop = false;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 436);
            this.Controls.Add(this.btnSync);
            this.Controls.Add(this.btnSetting);
            this.Controls.Add(this.spinner);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.tbDocs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "Facturación Electrónica";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.tbDocs.ResumeLayout(false);
            this.mtabFacturas.ResumeLayout(false);
            this.mtabFacturas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridFacturas)).EndInit();
            this.mtcontextMenu.ResumeLayout(false);
            this.mtabBoletas.ResumeLayout(false);
            this.mtabBoletas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridBoletas)).EndInit();
            this.mtabBajas.ResumeLayout(false);
            this.mtabBajas.PerformLayout();
            this.mtabResumen.ResumeLayout(false);
            this.mtabResumen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSync)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSetting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRun)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl tbDocs;
        private MetroFramework.Controls.MetroTabPage mtabFacturas;
        private MetroFramework.Controls.MetroTabPage mtabBoletas;
        private MetroFramework.Controls.MetroTabPage mtabResumen;
        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroGrid gridFacturas;
        private MetroFramework.Controls.MetroTabPage mtabBajas;
        private MetroFramework.Controls.MetroTextBox mtxtBajaCant;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel lblStatus;
        private System.Windows.Forms.PictureBox btnRun;
        private MetroFramework.Controls.MetroProgressSpinner spinner;
        private System.Windows.Forms.PictureBox btnSetting;
        private MetroFramework.Controls.MetroLabel lblCountFact;
        private MetroFramework.Controls.MetroTextBox mtxtItemsRes;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel lblCountBoletas;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroGrid gridBoletas;
        private MetroFramework.Controls.MetroContextMenu mtcontextMenu;
        private System.Windows.Forms.ToolStripMenuItem menuNcr;
        private MetroFramework.Controls.MetroLabel lblStateBaja;
        private MetroFramework.Controls.MetroLabel lblStateResumen;
        private System.Windows.Forms.ToolStripMenuItem menuNdb;
        private System.Windows.Forms.DataGridViewTextBoxColumn fgroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn fcodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn fdescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn fdocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn fcantidad;
        private System.Windows.Forms.DataGridViewCheckBoxColumn fnotacr;
        private System.Windows.Forms.DataGridViewCheckBoxColumn fnotadb;
        private System.Windows.Forms.DataGridViewTextBoxColumn festado;
        private System.Windows.Forms.PictureBox btnSync;
        private System.Windows.Forms.DataGridViewTextBoxColumn bgroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn bcodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn bdescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn bdocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn bcantidad;
        private System.Windows.Forms.DataGridViewCheckBoxColumn bnotacr;
        private System.Windows.Forms.DataGridViewCheckBoxColumn bnotadb;
        private System.Windows.Forms.DataGridViewTextBoxColumn bestado;
    }
}