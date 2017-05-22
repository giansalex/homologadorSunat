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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tbDocs = new MetroFramework.Controls.MetroTabControl();
            this.mtabFacturas = new MetroFramework.Controls.MetroTabPage();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.gridFacturas = new MetroFramework.Controls.MetroGrid();
            this.mtabBajas = new MetroFramework.Controls.MetroTabPage();
            this.mtxtBajaCant = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.mtabBoletas = new MetroFramework.Controls.MetroTabPage();
            this.mtabResumen = new MetroFramework.Controls.MetroTabPage();
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.lblStatus = new MetroFramework.Controls.MetroLabel();
            this.btnRun = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.spinner = new MetroFramework.Controls.MetroProgressSpinner();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.caso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.documento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Items = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbDocs.SuspendLayout();
            this.mtabFacturas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridFacturas)).BeginInit();
            this.mtabBajas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRun)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbDocs
            // 
            this.tbDocs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDocs.Controls.Add(this.mtabFacturas);
            this.tbDocs.Controls.Add(this.mtabBajas);
            this.tbDocs.Controls.Add(this.mtabBoletas);
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
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(2, 13);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(56, 19);
            this.metroLabel1.TabIndex = 3;
            this.metroLabel1.Text = "Facturas";
            // 
            // gridFacturas
            // 
            this.gridFacturas.AllowUserToResizeRows = false;
            this.gridFacturas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridFacturas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridFacturas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridFacturas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gridFacturas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridFacturas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gridFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridFacturas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigo,
            this.caso,
            this.documento,
            this.Items,
            this.estado});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridFacturas.DefaultCellStyle = dataGridViewCellStyle5;
            this.gridFacturas.EnableHeadersVisualStyles = false;
            this.gridFacturas.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridFacturas.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridFacturas.Location = new System.Drawing.Point(0, 40);
            this.gridFacturas.Name = "gridFacturas";
            this.gridFacturas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridFacturas.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gridFacturas.RowHeadersVisible = false;
            this.gridFacturas.RowHeadersWidth = 20;
            this.gridFacturas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridFacturas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridFacturas.Size = new System.Drawing.Size(611, 228);
            this.gridFacturas.TabIndex = 2;
            // 
            // mtabBajas
            // 
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
            this.mtxtBajaCant.Location = new System.Drawing.Point(67, 10);
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
            this.metroLabel2.Location = new System.Drawing.Point(13, 10);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(40, 19);
            this.metroLabel2.TabIndex = 2;
            this.metroLabel2.Text = "Items";
            // 
            // mtabBoletas
            // 
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
            // mtabResumen
            // 
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
            // btnRun
            // 
            this.btnRun.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRun.Image = global::Homologador.Properties.Resources.play;
            this.btnRun.Location = new System.Drawing.Point(265, 17);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(40, 37);
            this.btnRun.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnRun.TabIndex = 3;
            this.btnRun.TabStop = false;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::Homologador.Properties.Resources.Factura50;
            this.pictureBox1.Location = new System.Drawing.Point(589, 33);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(55, 50);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // spinner
            // 
            this.spinner.Location = new System.Drawing.Point(523, 7);
            this.spinner.Maximum = 100;
            this.spinner.Name = "spinner";
            this.spinner.Size = new System.Drawing.Size(60, 50);
            this.spinner.TabIndex = 4;
            this.spinner.UseSelectable = true;
            this.spinner.Visible = false;
            // 
            // codigo
            // 
            this.codigo.HeaderText = "Codigo";
            this.codigo.Name = "codigo";
            this.codigo.ReadOnly = true;
            // 
            // caso
            // 
            this.caso.HeaderText = "Caso";
            this.caso.Name = "caso";
            this.caso.ReadOnly = true;
            // 
            // documento
            // 
            this.documento.HeaderText = "Documento";
            this.documento.Name = "documento";
            // 
            // Items
            // 
            this.Items.HeaderText = "Cantidad";
            this.Items.Name = "Items";
            // 
            // estado
            // 
            this.estado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.estado.HeaderText = "Estado";
            this.estado.Name = "estado";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 436);
            this.Controls.Add(this.spinner);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.tbDocs);
            this.Name = "MainForm";
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "Facturacion Electronica";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.tbDocs.ResumeLayout(false);
            this.mtabFacturas.ResumeLayout(false);
            this.mtabFacturas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridFacturas)).EndInit();
            this.mtabBajas.ResumeLayout(false);
            this.mtabBajas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRun)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox btnRun;
        private MetroFramework.Controls.MetroProgressSpinner spinner;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn caso;
        private System.Windows.Forms.DataGridViewTextBoxColumn documento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Items;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado;
    }
}