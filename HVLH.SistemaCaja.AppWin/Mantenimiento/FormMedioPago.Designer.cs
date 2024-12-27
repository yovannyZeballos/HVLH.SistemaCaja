namespace HVLH.SistemaCaja.AppWin.Mantenimiento
{
	partial class FormMedioPago
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
			this.btnNuevo = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.btnEditar = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.btnEliminar = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.btnSalir = new System.Windows.Forms.ToolStripButton();
			this.dgvTipoDocumento = new System.Windows.Forms.DataGridView();
			this.ColId = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColFormaPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.toolStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvTipoDocumento)).BeginInit();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNuevo,
            this.toolStripSeparator1,
            this.btnEditar,
            this.toolStripSeparator2,
            this.btnEliminar,
            this.toolStripSeparator3,
            this.btnSalir});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(493, 38);
			this.toolStrip1.TabIndex = 1;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// btnNuevo
			// 
			this.btnNuevo.Image = global::HVLH.SistemaCaja.AppWin.Properties.Resources.archivo;
			this.btnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnNuevo.Name = "btnNuevo";
			this.btnNuevo.Size = new System.Drawing.Size(46, 35);
			this.btnNuevo.Text = "Nuevo";
			this.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
			// 
			// btnEditar
			// 
			this.btnEditar.Image = global::HVLH.SistemaCaja.AppWin.Properties.Resources.editar;
			this.btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnEditar.Name = "btnEditar";
			this.btnEditar.Size = new System.Drawing.Size(41, 35);
			this.btnEditar.Text = "Editar";
			this.btnEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
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
            this.ColDescripcion,
            this.ColFormaPago});
			this.dgvTipoDocumento.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvTipoDocumento.Location = new System.Drawing.Point(0, 38);
			this.dgvTipoDocumento.MultiSelect = false;
			this.dgvTipoDocumento.Name = "dgvTipoDocumento";
			this.dgvTipoDocumento.ReadOnly = true;
			this.dgvTipoDocumento.RowHeadersWidth = 20;
			this.dgvTipoDocumento.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
			this.dgvTipoDocumento.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.Highlight;
			this.dgvTipoDocumento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvTipoDocumento.Size = new System.Drawing.Size(493, 281);
			this.dgvTipoDocumento.TabIndex = 2;
			// 
			// ColId
			// 
			this.ColId.HeaderText = "Id";
			this.ColId.Name = "ColId";
			this.ColId.ReadOnly = true;
			this.ColId.Visible = false;
			this.ColId.Width = 160;
			// 
			// ColDescripcion
			// 
			this.ColDescripcion.HeaderText = "Descripcion";
			this.ColDescripcion.Name = "ColDescripcion";
			this.ColDescripcion.ReadOnly = true;
			this.ColDescripcion.Width = 250;
			// 
			// ColFormaPago
			// 
			this.ColFormaPago.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.ColFormaPago.HeaderText = "FormaPago";
			this.ColFormaPago.Name = "ColFormaPago";
			this.ColFormaPago.ReadOnly = true;
			// 
			// FormMedioPago
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(493, 319);
			this.Controls.Add(this.dgvTipoDocumento);
			this.Controls.Add(this.toolStrip1);
			this.Name = "FormMedioPago";
			this.Text = "Medios de pago";
			this.Load += new System.EventHandler(this.FormMedioPago_Load);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvTipoDocumento)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton btnNuevo;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton btnEditar;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton btnEliminar;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripButton btnSalir;
		private System.Windows.Forms.DataGridView dgvTipoDocumento;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColId;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColDescripcion;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColFormaPago;
	}
}