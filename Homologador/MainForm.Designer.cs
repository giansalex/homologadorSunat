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
            this.tbDocs = new MetroFramework.Controls.MetroTabControl();
            this.mtabFacturas = new MetroFramework.Controls.MetroTabPage();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.gridFacturas = new MetroFramework.Controls.MetroGrid();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.caso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.documento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mtabBoletas = new MetroFramework.Controls.MetroTabPage();
            this.mtabResumen = new MetroFramework.Controls.MetroTabPage();
            this.mtabBaja = new System.Windows.Forms.TabPage();
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.tbDocs.SuspendLayout();
            this.mtabFacturas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridFacturas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbDocs
            // 
            this.tbDocs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDocs.Controls.Add(this.mtabFacturas);
            this.tbDocs.Controls.Add(this.mtabBoletas);
            this.tbDocs.Controls.Add(this.mtabResumen);
            this.tbDocs.Controls.Add(this.mtabBaja);
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
            this.metroLabel1.Location = new System.Drawing.Point(3, 18);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(83, 19);
            this.metroLabel1.TabIndex = 3;
            this.metroLabel1.Text = "metroLabel1";
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
            this.codigo,
            this.caso,
            this.documento,
            this.estado});
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
            this.gridFacturas.Location = new System.Drawing.Point(0, 40);
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
            this.gridFacturas.Size = new System.Drawing.Size(611, 228);
            this.gridFacturas.TabIndex = 2;
            // 
            // codigo
            // 
            this.codigo.HeaderText = "Codigo";
            this.codigo.Name = "codigo";
            // 
            // caso
            // 
            this.caso.HeaderText = "Caso";
            this.caso.Name = "caso";
            // 
            // documento
            // 
            this.documento.HeaderText = "Documento";
            this.documento.Name = "documento";
            // 
            // estado
            // 
            this.estado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.estado.HeaderText = "Estado";
            this.estado.Name = "estado";
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
            // mtabBaja
            // 
            this.mtabBaja.Location = new System.Drawing.Point(4, 38);
            this.mtabBaja.Name = "mtabBaja";
            this.mtabBaja.Size = new System.Drawing.Size(607, 308);
            this.mtabBaja.TabIndex = 3;
            this.mtabBaja.Text = "C. de Baja";
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            this.metroStyleManager1.Style = MetroFramework.MetroColorStyle.Green;
            this.metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 436);
            this.Controls.Add(this.tbDocs);
            this.Name = "MainForm";
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "Facturacion Electronica";
            this.tbDocs.ResumeLayout(false);
            this.mtabFacturas.ResumeLayout(false);
            this.mtabFacturas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridFacturas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl tbDocs;
        private MetroFramework.Controls.MetroTabPage mtabFacturas;
        private MetroFramework.Controls.MetroTabPage mtabBoletas;
        private MetroFramework.Controls.MetroTabPage mtabResumen;
        private System.Windows.Forms.TabPage mtabBaja;
        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroGrid gridFacturas;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn caso;
        private System.Windows.Forms.DataGridViewTextBoxColumn documento;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado;
    }
}