namespace HVLH.SistemaCaja.AppWin.Facturacion
{
	partial class FormEnvioComunicacionesBaja
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
			this.btnGuardar = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.btnEnviar = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.btnConsultar = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.btnSalir = new System.Windows.Forms.ToolStripButton();
			this.label1 = new System.Windows.Forms.Label();
			this.txtNroComunicación = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtFecha = new System.Windows.Forms.DateTimePicker();
			this.txtFechaDocumentos = new System.Windows.Forms.DateTimePicker();
			this.label3 = new System.Windows.Forms.Label();
			this.txtNroTicket = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtRespuesta = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.dgvDocumentos = new System.Windows.Forms.DataGridView();
			this.ColId = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColTipoDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColNroDoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColFechaEmision = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColMoneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.toolStrip2 = new System.Windows.Forms.ToolStrip();
			this.btnAgregar = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.btnEliminar = new System.Windows.Forms.ToolStripButton();
			this.txtEstado = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtMotivo = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.toolStrip1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvDocumentos)).BeginInit();
			this.toolStrip2.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGuardar,
            this.toolStripSeparator2,
            this.btnEnviar,
            this.toolStripSeparator3,
            this.btnConsultar,
            this.toolStripSeparator4,
            this.btnSalir});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(740, 38);
			this.toolStrip1.TabIndex = 6;
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
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
			// 
			// btnEnviar
			// 
			this.btnEnviar.Enabled = false;
			this.btnEnviar.Image = global::HVLH.SistemaCaja.AppWin.Properties.Resources.logo_sunat;
			this.btnEnviar.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnEnviar.Name = "btnEnviar";
			this.btnEnviar.Size = new System.Drawing.Size(76, 35);
			this.btnEnviar.Text = "Enviar Sunat";
			this.btnEnviar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnEnviar.Click += new System.EventHandler(this.BtnEnviar_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 38);
			// 
			// btnConsultar
			// 
			this.btnConsultar.Enabled = false;
			this.btnConsultar.Image = global::HVLH.SistemaCaja.AppWin.Properties.Resources.ok;
			this.btnConsultar.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnConsultar.Name = "btnConsultar";
			this.btnConsultar.Size = new System.Drawing.Size(94, 35);
			this.btnConsultar.Text = "Consultar ticket";
			this.btnConsultar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnConsultar.Click += new System.EventHandler(this.BtnConsultar_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 38);
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
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(16, 60);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(97, 13);
			this.label1.TabIndex = 7;
			this.label1.Text = "Nro. Comunicación";
			// 
			// txtNroComunicación
			// 
			this.txtNroComunicación.Enabled = false;
			this.txtNroComunicación.Location = new System.Drawing.Point(120, 56);
			this.txtNroComunicación.Name = "txtNroComunicación";
			this.txtNroComunicación.Size = new System.Drawing.Size(168, 20);
			this.txtNroComunicación.TabIndex = 8;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(336, 59);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(61, 13);
			this.label2.TabIndex = 9;
			this.label2.Text = "Fecha Baja";
			// 
			// txtFecha
			// 
			this.txtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.txtFecha.Location = new System.Drawing.Point(408, 56);
			this.txtFecha.Name = "txtFecha";
			this.txtFecha.Size = new System.Drawing.Size(96, 20);
			this.txtFecha.TabIndex = 10;
			// 
			// txtFechaDocumentos
			// 
			this.txtFechaDocumentos.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.txtFechaDocumentos.Location = new System.Drawing.Point(408, 80);
			this.txtFechaDocumentos.Name = "txtFechaDocumentos";
			this.txtFechaDocumentos.Size = new System.Drawing.Size(96, 20);
			this.txtFechaDocumentos.TabIndex = 12;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(302, 83);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 13);
			this.label3.TabIndex = 11;
			this.label3.Text = "Fecha Documentos";
			// 
			// txtNroTicket
			// 
			this.txtNroTicket.Enabled = false;
			this.txtNroTicket.Location = new System.Drawing.Point(120, 80);
			this.txtNroTicket.Name = "txtNroTicket";
			this.txtNroTicket.Size = new System.Drawing.Size(168, 20);
			this.txtNroTicket.TabIndex = 14;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(54, 84);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(60, 13);
			this.label4.TabIndex = 13;
			this.label4.Text = "Nro. Ticket";
			// 
			// txtRespuesta
			// 
			this.txtRespuesta.Enabled = false;
			this.txtRespuesta.Location = new System.Drawing.Point(120, 104);
			this.txtRespuesta.Multiline = true;
			this.txtRespuesta.Name = "txtRespuesta";
			this.txtRespuesta.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtRespuesta.Size = new System.Drawing.Size(608, 48);
			this.txtRespuesta.TabIndex = 16;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(56, 108);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(58, 13);
			this.label5.TabIndex = 15;
			this.label5.Text = "Respuesta";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.panel1);
			this.groupBox1.Controls.Add(this.toolStrip2);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(8, 200);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(728, 272);
			this.groupBox1.TabIndex = 17;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "DOCUMENTOS A INFORMAR";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.dgvDocumentos);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(3, 54);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(722, 215);
			this.panel1.TabIndex = 18;
			// 
			// dgvDocumentos
			// 
			this.dgvDocumentos.AllowUserToAddRows = false;
			this.dgvDocumentos.AllowUserToDeleteRows = false;
			this.dgvDocumentos.AllowUserToResizeRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.dgvDocumentos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvDocumentos.BackgroundColor = System.Drawing.SystemColors.HighlightText;
			this.dgvDocumentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvDocumentos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColId,
            this.ColTipoDocumento,
            this.ColNroDoc,
            this.ColFechaEmision,
            this.ColCliente,
            this.ColMoneda,
            this.ColTotal});
			this.dgvDocumentos.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvDocumentos.Location = new System.Drawing.Point(0, 0);
			this.dgvDocumentos.MultiSelect = false;
			this.dgvDocumentos.Name = "dgvDocumentos";
			this.dgvDocumentos.ReadOnly = true;
			this.dgvDocumentos.RowHeadersWidth = 20;
			this.dgvDocumentos.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
			this.dgvDocumentos.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.Highlight;
			this.dgvDocumentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvDocumentos.Size = new System.Drawing.Size(722, 215);
			this.dgvDocumentos.TabIndex = 5;
			// 
			// ColId
			// 
			this.ColId.HeaderText = "Id";
			this.ColId.Name = "ColId";
			this.ColId.ReadOnly = true;
			this.ColId.Visible = false;
			// 
			// ColTipoDocumento
			// 
			this.ColTipoDocumento.HeaderText = "Tipo Doc.";
			this.ColTipoDocumento.Name = "ColTipoDocumento";
			this.ColTipoDocumento.ReadOnly = true;
			// 
			// ColNroDoc
			// 
			this.ColNroDoc.HeaderText = "Nro. Doc.";
			this.ColNroDoc.Name = "ColNroDoc";
			this.ColNroDoc.ReadOnly = true;
			// 
			// ColFechaEmision
			// 
			dataGridViewCellStyle2.Format = "d";
			dataGridViewCellStyle2.NullValue = null;
			this.ColFechaEmision.DefaultCellStyle = dataGridViewCellStyle2;
			this.ColFechaEmision.HeaderText = "Fecha Emision";
			this.ColFechaEmision.Name = "ColFechaEmision";
			this.ColFechaEmision.ReadOnly = true;
			// 
			// ColCliente
			// 
			this.ColCliente.HeaderText = "Cliente";
			this.ColCliente.Name = "ColCliente";
			this.ColCliente.ReadOnly = true;
			this.ColCliente.Width = 250;
			// 
			// ColMoneda
			// 
			this.ColMoneda.HeaderText = "Moneda";
			this.ColMoneda.Name = "ColMoneda";
			this.ColMoneda.ReadOnly = true;
			this.ColMoneda.Width = 70;
			// 
			// ColTotal
			// 
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.ColTotal.DefaultCellStyle = dataGridViewCellStyle3;
			this.ColTotal.HeaderText = "Total";
			this.ColTotal.Name = "ColTotal";
			this.ColTotal.ReadOnly = true;
			this.ColTotal.Width = 80;
			// 
			// toolStrip2
			// 
			this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAgregar,
            this.toolStripSeparator5,
            this.btnEliminar});
			this.toolStrip2.Location = new System.Drawing.Point(3, 16);
			this.toolStrip2.Name = "toolStrip2";
			this.toolStrip2.Size = new System.Drawing.Size(722, 38);
			this.toolStrip2.TabIndex = 18;
			this.toolStrip2.Text = "toolStrip2";
			// 
			// btnAgregar
			// 
			this.btnAgregar.Image = global::HVLH.SistemaCaja.AppWin.Properties.Resources._new;
			this.btnAgregar.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnAgregar.Name = "btnAgregar";
			this.btnAgregar.Size = new System.Drawing.Size(118, 35);
			this.btnAgregar.Text = "Agregar documento";
			this.btnAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(6, 38);
			// 
			// btnEliminar
			// 
			this.btnEliminar.Image = global::HVLH.SistemaCaja.AppWin.Properties.Resources.Remove;
			this.btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnEliminar.Name = "btnEliminar";
			this.btnEliminar.Size = new System.Drawing.Size(118, 35);
			this.btnEliminar.Text = "Elimina  documento";
			this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
			// 
			// txtEstado
			// 
			this.txtEstado.Enabled = false;
			this.txtEstado.Location = new System.Drawing.Point(568, 80);
			this.txtEstado.Name = "txtEstado";
			this.txtEstado.Size = new System.Drawing.Size(128, 20);
			this.txtEstado.TabIndex = 19;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(520, 84);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(40, 13);
			this.label6.TabIndex = 18;
			this.label6.Text = "Estado";
			// 
			// txtMotivo
			// 
			this.txtMotivo.Location = new System.Drawing.Point(120, 157);
			this.txtMotivo.MaxLength = 100;
			this.txtMotivo.Name = "txtMotivo";
			this.txtMotivo.Size = new System.Drawing.Size(608, 20);
			this.txtMotivo.TabIndex = 21;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(72, 161);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(39, 13);
			this.label7.TabIndex = 20;
			this.label7.Text = "Motivo";
			// 
			// FormEnvioComunicacionesBaja
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(740, 475);
			this.Controls.Add(this.txtMotivo);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.txtEstado);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.txtRespuesta);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtNroTicket);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtFechaDocumentos);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtFecha);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtNroComunicación);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.toolStrip1);
			this.Name = "FormEnvioComunicacionesBaja";
			this.Text = "COMUNICACION DE BAJA";
			this.Load += new System.EventHandler(this.FormEnvioResumenes_Load);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvDocumentos)).EndInit();
			this.toolStrip2.ResumeLayout(false);
			this.toolStrip2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton btnGuardar;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton btnSalir;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtNroComunicación;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker txtFecha;
		private System.Windows.Forms.DateTimePicker txtFechaDocumentos;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtNroTicket;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtRespuesta;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.DataGridView dgvDocumentos;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ToolStrip toolStrip2;
		private System.Windows.Forms.ToolStripButton btnEliminar;
		private System.Windows.Forms.ToolStripButton btnEnviar;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripButton btnConsultar;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripButton btnAgregar;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.TextBox txtEstado;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtMotivo;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColId;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColTipoDocumento;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColNroDoc;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColFechaEmision;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColCliente;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColMoneda;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColTotal;
	}
}