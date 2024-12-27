namespace HVLH.SistemaCaja.AppWin.Mantenimiento
{
	partial class FormTipoDocumentoSerie
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
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.btnSeries = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.btnSalir = new System.Windows.Forms.ToolStripButton();
			this.dgvTipoDocumento = new System.Windows.Forms.DataGridView();
			this.ColId = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.toolStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvTipoDocumento)).BeginInit();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSeries,
            this.toolStripSeparator1,
            this.btnSalir});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(357, 38);
			this.toolStrip1.TabIndex = 1;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// btnSeries
			// 
			this.btnSeries.Image = global::HVLH.SistemaCaja.AppWin.Properties.Resources.archivo;
			this.btnSeries.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnSeries.Name = "btnSeries";
			this.btnSeries.Size = new System.Drawing.Size(41, 35);
			this.btnSeries.Text = "Series";
			this.btnSeries.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnSeries.Click += new System.EventHandler(this.BtnSeries_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
			// 
			// btnSalir
			// 
			this.btnSalir.Image = global::HVLH.SistemaCaja.AppWin.Properties.Resources.logout__1_;
			this.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnSalir.Name = "btnSalir";
			this.btnSalir.Size = new System.Drawing.Size(33, 35);
			this.btnSalir.Text = "Salir";
			this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
			// 
			// dgvTipoDocumento
			// 
			this.dgvTipoDocumento.AllowUserToAddRows = false;
			this.dgvTipoDocumento.AllowUserToDeleteRows = false;
			this.dgvTipoDocumento.AllowUserToResizeRows = false;
			this.dgvTipoDocumento.BackgroundColor = System.Drawing.SystemColors.HighlightText;
			this.dgvTipoDocumento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvTipoDocumento.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColId,
            this.ColCodigo,
            this.ColDescripcion});
			this.dgvTipoDocumento.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvTipoDocumento.Location = new System.Drawing.Point(0, 38);
			this.dgvTipoDocumento.MultiSelect = false;
			this.dgvTipoDocumento.Name = "dgvTipoDocumento";
			this.dgvTipoDocumento.ReadOnly = true;
			this.dgvTipoDocumento.RowHeadersWidth = 20;
			this.dgvTipoDocumento.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
			this.dgvTipoDocumento.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.Highlight;
			this.dgvTipoDocumento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvTipoDocumento.Size = new System.Drawing.Size(357, 293);
			this.dgvTipoDocumento.TabIndex = 2;
			this.dgvTipoDocumento.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvTipoDocumento_CellDoubleClick);
			// 
			// ColId
			// 
			this.ColId.HeaderText = "Id";
			this.ColId.Name = "ColId";
			this.ColId.ReadOnly = true;
			this.ColId.Visible = false;
			// 
			// ColCodigo
			// 
			this.ColCodigo.HeaderText = "Codigo";
			this.ColCodigo.Name = "ColCodigo";
			this.ColCodigo.ReadOnly = true;
			// 
			// ColDescripcion
			// 
			this.ColDescripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.ColDescripcion.HeaderText = "Descripción";
			this.ColDescripcion.Name = "ColDescripcion";
			this.ColDescripcion.ReadOnly = true;
			// 
			// FormTipoDocumentoSerie
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(357, 331);
			this.Controls.Add(this.dgvTipoDocumento);
			this.Controls.Add(this.toolStrip1);
			this.Name = "FormTipoDocumentoSerie";
			this.Text = "Series por tipo de documento";
			this.Load += new System.EventHandler(this.FormTipoDocumentoSerie_Load);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvTipoDocumento)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton btnSeries;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton btnSalir;
		private System.Windows.Forms.DataGridView dgvTipoDocumento;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColId;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColCodigo;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColDescripcion;
	}
}