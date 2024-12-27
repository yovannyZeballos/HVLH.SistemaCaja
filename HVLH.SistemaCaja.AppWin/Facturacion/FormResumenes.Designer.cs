namespace HVLH.SistemaCaja.AppWin.Facturacion
{
	partial class FormResumenes
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
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.btnNuevo = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.btnEditar = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.btnSalir = new System.Windows.Forms.ToolStripButton();
			this.dgvResumenes = new System.Windows.Forms.DataGridView();
			this.ColId = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColNroResumen = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColFechaResumen = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColFechaDocumentos = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColTicket = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtFechaDel = new System.Windows.Forms.DateTimePicker();
			this.txtFechaAl = new System.Windows.Forms.DateTimePicker();
			this.btnBuscar = new System.Windows.Forms.Button();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.panel1 = new System.Windows.Forms.Panel();
			this.toolStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvResumenes)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNuevo,
            this.toolStripSeparator2,
            this.btnEditar,
            this.toolStripSeparator1,
            this.btnSalir});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Padding = new System.Windows.Forms.Padding(5);
			this.toolStrip1.Size = new System.Drawing.Size(774, 48);
			this.toolStrip1.TabIndex = 3;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// btnNuevo
			// 
			this.btnNuevo.Image = global::HVLH.SistemaCaja.AppWin.Properties.Resources.archivo;
			this.btnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnNuevo.Name = "btnNuevo";
			this.btnNuevo.Size = new System.Drawing.Size(95, 35);
			this.btnNuevo.Text = "Nuevo resumen";
			this.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnNuevo.Click += new System.EventHandler(this.BtnEnviar_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
			// 
			// btnEditar
			// 
			this.btnEditar.Image = global::HVLH.SistemaCaja.AppWin.Properties.Resources.editar;
			this.btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnEditar.Name = "btnEditar";
			this.btnEditar.Size = new System.Drawing.Size(41, 35);
			this.btnEditar.Text = "Editar";
			this.btnEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnEditar.Click += new System.EventHandler(this.BtnEditar_Click);
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
			// dgvResumenes
			// 
			this.dgvResumenes.AllowUserToAddRows = false;
			this.dgvResumenes.AllowUserToDeleteRows = false;
			this.dgvResumenes.AllowUserToResizeRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.dgvResumenes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvResumenes.BackgroundColor = System.Drawing.SystemColors.HighlightText;
			this.dgvResumenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvResumenes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColId,
            this.ColNroResumen,
            this.ColFechaResumen,
            this.ColFechaDocumentos,
            this.ColTicket,
            this.ColEstado});
			this.dgvResumenes.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvResumenes.Location = new System.Drawing.Point(0, 0);
			this.dgvResumenes.MultiSelect = false;
			this.dgvResumenes.Name = "dgvResumenes";
			this.dgvResumenes.ReadOnly = true;
			this.dgvResumenes.RowHeadersWidth = 20;
			this.dgvResumenes.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
			this.dgvResumenes.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.Highlight;
			this.dgvResumenes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvResumenes.Size = new System.Drawing.Size(774, 384);
			this.dgvResumenes.TabIndex = 4;
			// 
			// ColId
			// 
			this.ColId.HeaderText = "Id";
			this.ColId.Name = "ColId";
			this.ColId.ReadOnly = true;
			this.ColId.Visible = false;
			// 
			// ColNroResumen
			// 
			this.ColNroResumen.HeaderText = "Nro. Resumen";
			this.ColNroResumen.Name = "ColNroResumen";
			this.ColNroResumen.ReadOnly = true;
			this.ColNroResumen.Width = 200;
			// 
			// ColFechaResumen
			// 
			dataGridViewCellStyle2.Format = "d";
			dataGridViewCellStyle2.NullValue = null;
			this.ColFechaResumen.DefaultCellStyle = dataGridViewCellStyle2;
			this.ColFechaResumen.HeaderText = "Fecha Resumen";
			this.ColFechaResumen.Name = "ColFechaResumen";
			this.ColFechaResumen.ReadOnly = true;
			this.ColFechaResumen.Width = 150;
			// 
			// ColFechaDocumentos
			// 
			this.ColFechaDocumentos.HeaderText = "Fecha Doc.";
			this.ColFechaDocumentos.Name = "ColFechaDocumentos";
			this.ColFechaDocumentos.ReadOnly = true;
			// 
			// ColTicket
			// 
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.ColTicket.DefaultCellStyle = dataGridViewCellStyle3;
			this.ColTicket.HeaderText = "Ticket";
			this.ColTicket.Name = "ColTicket";
			this.ColTicket.ReadOnly = true;
			this.ColTicket.Width = 200;
			// 
			// ColEstado
			// 
			this.ColEstado.HeaderText = "Estado";
			this.ColEstado.Name = "ColEstado";
			this.ColEstado.ReadOnly = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.txtFechaDel);
			this.groupBox1.Controls.Add(this.txtFechaAl);
			this.groupBox1.Controls.Add(this.btnBuscar);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(774, 77);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Filtros";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(174, 34);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(10, 13);
			this.label4.TabIndex = 50;
			this.label4.Text = "-";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(19, 34);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(42, 13);
			this.label3.TabIndex = 49;
			this.label3.Text = "Fechas";
			// 
			// txtFechaDel
			// 
			this.txtFechaDel.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.txtFechaDel.Location = new System.Drawing.Point(66, 30);
			this.txtFechaDel.Name = "txtFechaDel";
			this.txtFechaDel.Size = new System.Drawing.Size(104, 20);
			this.txtFechaDel.TabIndex = 48;
			// 
			// txtFechaAl
			// 
			this.txtFechaAl.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.txtFechaAl.Location = new System.Drawing.Point(187, 30);
			this.txtFechaAl.Name = "txtFechaAl";
			this.txtFechaAl.Size = new System.Drawing.Size(104, 20);
			this.txtFechaAl.TabIndex = 47;
			// 
			// btnBuscar
			// 
			this.btnBuscar.Image = global::HVLH.SistemaCaja.AppWin.Properties.Resources.busqueda;
			this.btnBuscar.Location = new System.Drawing.Point(296, 24);
			this.btnBuscar.Name = "btnBuscar";
			this.btnBuscar.Size = new System.Drawing.Size(80, 31);
			this.btnBuscar.TabIndex = 46;
			this.btnBuscar.Text = "Buscar";
			this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnBuscar.UseVisualStyleBackColor = true;
			this.btnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
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
			this.splitContainer1.Panel1.Controls.Add(this.dgvResumenes);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
			this.splitContainer1.Size = new System.Drawing.Size(774, 465);
			this.splitContainer1.SplitterDistance = 384;
			this.splitContainer1.TabIndex = 6;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.splitContainer1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 48);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(774, 465);
			this.panel1.TabIndex = 7;
			// 
			// FormResumenes
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(774, 513);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.toolStrip1);
			this.Name = "FormResumenes";
			this.Text = "Envío de documentos";
			this.Load += new System.EventHandler(this.FormEnvioDocumentos_Load);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvResumenes)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton btnNuevo;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton btnSalir;
		private System.Windows.Forms.DataGridView dgvResumenes;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		public System.Windows.Forms.DateTimePicker txtFechaDel;
		public System.Windows.Forms.DateTimePicker txtFechaAl;
		private System.Windows.Forms.Button btnBuscar;
		private System.Windows.Forms.ToolStripButton btnEditar;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColId;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColNroResumen;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColFechaResumen;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColFechaDocumentos;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColTicket;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColEstado;
	}
}