namespace HVLH.SistemaCaja.AppWin.Mantenimiento
{
	partial class FormMantTipoDocumentoSerie
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
			this.btnGuardar = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.btnLimpiar = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.btnEliminar = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.btnSalir = new System.Windows.Forms.ToolStripButton();
			this.panel1 = new System.Windows.Forms.Panel();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.label1 = new System.Windows.Forms.Label();
			this.chkAfecto = new System.Windows.Forms.CheckBox();
			this.cboTipo = new System.Windows.Forms.ComboBox();
			this.txtSerie = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.dgvSeries = new System.Windows.Forms.DataGridView();
			this.ColId = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColSerie = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColAfecto = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.toolStrip1.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvSeries)).BeginInit();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGuardar,
            this.toolStripSeparator1,
            this.btnLimpiar,
            this.toolStripSeparator2,
            this.btnEliminar,
            this.toolStripSeparator3,
            this.btnSalir});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(322, 38);
			this.toolStrip1.TabIndex = 2;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// btnGuardar
			// 
			this.btnGuardar.Image = global::HVLH.SistemaCaja.AppWin.Properties.Resources.guardar;
			this.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnGuardar.Name = "btnGuardar";
			this.btnGuardar.Size = new System.Drawing.Size(53, 35);
			this.btnGuardar.Text = "Guardar";
			this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
			// 
			// btnLimpiar
			// 
			this.btnLimpiar.Image = global::HVLH.SistemaCaja.AppWin.Properties.Resources.archivo;
			this.btnLimpiar.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnLimpiar.Name = "btnLimpiar";
			this.btnLimpiar.Size = new System.Drawing.Size(51, 35);
			this.btnLimpiar.Text = "Limpiar";
			this.btnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
			// 
			// btnEliminar
			// 
			this.btnEliminar.Image = global::HVLH.SistemaCaja.AppWin.Properties.Resources.Remove;
			this.btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnEliminar.Name = "btnEliminar";
			this.btnEliminar.Size = new System.Drawing.Size(54, 35);
			this.btnEliminar.Text = "Eliminar";
			this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 38);
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
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.splitContainer1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 38);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(322, 294);
			this.panel1.TabIndex = 3;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.label1);
			this.splitContainer1.Panel1.Controls.Add(this.chkAfecto);
			this.splitContainer1.Panel1.Controls.Add(this.cboTipo);
			this.splitContainer1.Panel1.Controls.Add(this.txtSerie);
			this.splitContainer1.Panel1.Controls.Add(this.label2);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.dgvSeries);
			this.splitContainer1.Size = new System.Drawing.Size(320, 292);
			this.splitContainer1.SplitterDistance = 94;
			this.splitContainer1.TabIndex = 5;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(56, 42);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(28, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "Tipo";
			// 
			// chkAfecto
			// 
			this.chkAfecto.AutoSize = true;
			this.chkAfecto.Location = new System.Drawing.Point(104, 64);
			this.chkAfecto.Name = "chkAfecto";
			this.chkAfecto.Size = new System.Drawing.Size(78, 17);
			this.chkAfecto.TabIndex = 5;
			this.chkAfecto.Text = "Afecto IGV";
			this.chkAfecto.UseVisualStyleBackColor = true;
			// 
			// cboTipo
			// 
			this.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboTipo.FormattingEnabled = true;
			this.cboTipo.Location = new System.Drawing.Point(104, 38);
			this.cboTipo.Name = "cboTipo";
			this.cboTipo.Size = new System.Drawing.Size(136, 21);
			this.cboTipo.TabIndex = 4;
			// 
			// txtSerie
			// 
			this.txtSerie.Location = new System.Drawing.Point(104, 13);
			this.txtSerie.MaxLength = 4;
			this.txtSerie.Name = "txtSerie";
			this.txtSerie.Size = new System.Drawing.Size(75, 20);
			this.txtSerie.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(56, 17);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(31, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Serie";
			// 
			// dgvSeries
			// 
			this.dgvSeries.AllowUserToAddRows = false;
			this.dgvSeries.AllowUserToDeleteRows = false;
			this.dgvSeries.AllowUserToResizeRows = false;
			this.dgvSeries.BackgroundColor = System.Drawing.SystemColors.HighlightText;
			this.dgvSeries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvSeries.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColId,
            this.ColSerie,
            this.ColTipo,
            this.ColAfecto});
			this.dgvSeries.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvSeries.Location = new System.Drawing.Point(0, 0);
			this.dgvSeries.MultiSelect = false;
			this.dgvSeries.Name = "dgvSeries";
			this.dgvSeries.ReadOnly = true;
			this.dgvSeries.RowHeadersWidth = 20;
			this.dgvSeries.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
			this.dgvSeries.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.Highlight;
			this.dgvSeries.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvSeries.Size = new System.Drawing.Size(320, 194);
			this.dgvSeries.TabIndex = 3;
			this.dgvSeries.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvSeries_CellDoubleClick);
			// 
			// ColId
			// 
			this.ColId.HeaderText = "Id";
			this.ColId.Name = "ColId";
			this.ColId.ReadOnly = true;
			this.ColId.Visible = false;
			// 
			// ColSerie
			// 
			this.ColSerie.HeaderText = "Serie";
			this.ColSerie.Name = "ColSerie";
			this.ColSerie.ReadOnly = true;
			this.ColSerie.Width = 60;
			// 
			// ColTipo
			// 
			this.ColTipo.HeaderText = "Tipo";
			this.ColTipo.Name = "ColTipo";
			this.ColTipo.ReadOnly = true;
			this.ColTipo.Width = 160;
			// 
			// ColAfecto
			// 
			this.ColAfecto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.ColAfecto.HeaderText = "Afecto IGV";
			this.ColAfecto.Name = "ColAfecto";
			this.ColAfecto.ReadOnly = true;
			// 
			// FormMantTipoDocumentoSerie
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(322, 332);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.toolStrip1);
			this.Name = "FormMantTipoDocumentoSerie";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Serie por tipo documento";
			this.Load += new System.EventHandler(this.FormMantTipoDocumentoSerie_Load);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvSeries)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton btnGuardar;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton btnLimpiar;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripButton btnSalir;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton btnEliminar;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.CheckBox chkAfecto;
		private System.Windows.Forms.ComboBox cboTipo;
		private System.Windows.Forms.TextBox txtSerie;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGridView dgvSeries;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColId;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColSerie;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColTipo;
		private System.Windows.Forms.DataGridViewCheckBoxColumn ColAfecto;
	}
}