namespace HVLH.SistemaCaja.AppWin.Facturacion
{
	partial class FormListadoProducto
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			this.dgvProductos = new System.Windows.Forms.DataGridView();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtxCantidad = new System.Windows.Forms.TextBox();
			this.rbDescripcion = new System.Windows.Forms.RadioButton();
			this.rbCodigo = new System.Windows.Forms.RadioButton();
			this.txtBusqueda = new System.Windows.Forms.TextBox();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.ColId = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColUnidadMedida = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColTipoIgv = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// dgvProductos
			// 
			this.dgvProductos.AllowUserToAddRows = false;
			this.dgvProductos.AllowUserToDeleteRows = false;
			this.dgvProductos.AllowUserToResizeRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.dgvProductos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvProductos.BackgroundColor = System.Drawing.SystemColors.HighlightText;
			this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColId,
            this.ColCodigo,
            this.ColDescripcion,
            this.ColPrecio,
            this.ColUnidadMedida,
            this.ColTipoIgv,
            this.ColEstado});
			this.dgvProductos.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvProductos.Location = new System.Drawing.Point(0, 0);
			this.dgvProductos.MultiSelect = false;
			this.dgvProductos.Name = "dgvProductos";
			this.dgvProductos.ReadOnly = true;
			this.dgvProductos.RowHeadersWidth = 20;
			this.dgvProductos.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
			this.dgvProductos.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.Highlight;
			this.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvProductos.Size = new System.Drawing.Size(791, 394);
			this.dgvProductos.TabIndex = 1;
			this.dgvProductos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvProductos_CellDoubleClick);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.txtxCantidad);
			this.groupBox1.Controls.Add(this.rbDescripcion);
			this.groupBox1.Controls.Add(this.rbCodigo);
			this.groupBox1.Controls.Add(this.txtBusqueda);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(791, 52);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Buscar por";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(600, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(113, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Registros encontrados";
			// 
			// txtxCantidad
			// 
			this.txtxCantidad.Enabled = false;
			this.txtxCantidad.Location = new System.Drawing.Point(720, 21);
			this.txtxCantidad.Name = "txtxCantidad";
			this.txtxCantidad.Size = new System.Drawing.Size(64, 20);
			this.txtxCantidad.TabIndex = 3;
			// 
			// rbDescripcion
			// 
			this.rbDescripcion.AutoSize = true;
			this.rbDescripcion.Location = new System.Drawing.Point(160, 23);
			this.rbDescripcion.Name = "rbDescripcion";
			this.rbDescripcion.Size = new System.Drawing.Size(81, 17);
			this.rbDescripcion.TabIndex = 2;
			this.rbDescripcion.Text = "Descripcion";
			this.rbDescripcion.UseVisualStyleBackColor = true;
			// 
			// rbCodigo
			// 
			this.rbCodigo.AutoSize = true;
			this.rbCodigo.Checked = true;
			this.rbCodigo.Location = new System.Drawing.Point(64, 23);
			this.rbCodigo.Name = "rbCodigo";
			this.rbCodigo.Size = new System.Drawing.Size(58, 17);
			this.rbCodigo.TabIndex = 1;
			this.rbCodigo.TabStop = true;
			this.rbCodigo.Text = "Codigo";
			this.rbCodigo.UseVisualStyleBackColor = true;
			this.rbCodigo.CheckedChanged += new System.EventHandler(this.RbCodigo_CheckedChanged);
			// 
			// txtBusqueda
			// 
			this.txtBusqueda.Location = new System.Drawing.Point(264, 21);
			this.txtBusqueda.Name = "txtBusqueda";
			this.txtBusqueda.Size = new System.Drawing.Size(320, 20);
			this.txtBusqueda.TabIndex = 0;
			this.txtBusqueda.TextChanged += new System.EventHandler(this.TxtBusqueda_TextChanged);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.IsSplitterFixed = true;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.dgvProductos);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
			this.splitContainer1.Size = new System.Drawing.Size(791, 450);
			this.splitContainer1.SplitterDistance = 394;
			this.splitContainer1.TabIndex = 3;
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
			// ColPrecio
			// 
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.ColPrecio.DefaultCellStyle = dataGridViewCellStyle2;
			this.ColPrecio.HeaderText = "Precio";
			this.ColPrecio.Name = "ColPrecio";
			this.ColPrecio.ReadOnly = true;
			this.ColPrecio.Width = 70;
			// 
			// ColUnidadMedida
			// 
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.ColUnidadMedida.DefaultCellStyle = dataGridViewCellStyle3;
			this.ColUnidadMedida.HeaderText = "U.M.";
			this.ColUnidadMedida.Name = "ColUnidadMedida";
			this.ColUnidadMedida.ReadOnly = true;
			this.ColUnidadMedida.Width = 50;
			// 
			// ColTipoIgv
			// 
			this.ColTipoIgv.FillWeight = 70F;
			this.ColTipoIgv.HeaderText = "Tipo IGV";
			this.ColTipoIgv.Name = "ColTipoIgv";
			this.ColTipoIgv.ReadOnly = true;
			// 
			// ColEstado
			// 
			this.ColEstado.HeaderText = "Estado";
			this.ColEstado.Name = "ColEstado";
			this.ColEstado.ReadOnly = true;
			// 
			// FormListadoProducto
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(791, 450);
			this.Controls.Add(this.splitContainer1);
			this.Name = "FormListadoProducto";
			this.Text = "Listado de Productos / Servicios";
			this.Load += new System.EventHandler(this.FormListadoProducto_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dgvProductos;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtxCantidad;
		private System.Windows.Forms.RadioButton rbDescripcion;
		private System.Windows.Forms.RadioButton rbCodigo;
		private System.Windows.Forms.TextBox txtBusqueda;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColId;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColCodigo;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColDescripcion;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColPrecio;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColUnidadMedida;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColTipoIgv;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColEstado;
	}
}