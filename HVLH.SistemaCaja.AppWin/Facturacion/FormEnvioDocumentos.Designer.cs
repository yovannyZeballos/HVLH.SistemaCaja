namespace HVLH.SistemaCaja.AppWin.Facturacion
{
	partial class FormEnvioDocumentos
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.btnEnviar = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.btnSalir = new System.Windows.Forms.ToolStripButton();
			this.dgvDocumentos = new System.Windows.Forms.DataGridView();
			this.ColId = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColSeleccionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.ColCodigoTipoDoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColTipoDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColSerie = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColNumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColFechaEmision = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColMoneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColGravadas = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColInafectas = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColIgv = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cboSerie = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtFechaDel = new System.Windows.Forms.DateTimePicker();
			this.txtFechaAl = new System.Windows.Forms.DateTimePicker();
			this.btnBuscar = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.cboTipoDocumento = new System.Windows.Forms.ComboBox();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label5 = new System.Windows.Forms.Label();
			this.cboTipoMedioPago = new System.Windows.Forms.ComboBox();
			this.toolStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvDocumentos)).BeginInit();
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
            this.btnEnviar,
            this.toolStripSeparator1,
            this.btnSalir});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Padding = new System.Windows.Forms.Padding(5);
			this.toolStrip1.Size = new System.Drawing.Size(1132, 48);
			this.toolStrip1.TabIndex = 3;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// btnEnviar
			// 
			this.btnEnviar.Image = global::HVLH.SistemaCaja.AppWin.Properties.Resources.logo_sunat;
			this.btnEnviar.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnEnviar.Name = "btnEnviar";
			this.btnEnviar.Size = new System.Drawing.Size(84, 35);
			this.btnEnviar.Text = "Enviar a sunat";
			this.btnEnviar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnEnviar.Click += new System.EventHandler(this.BtnEnviar_Click);
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
            this.ColSeleccionar,
            this.ColCodigoTipoDoc,
            this.ColTipoDocumento,
            this.ColSerie,
            this.ColNumero,
            this.ColFechaEmision,
            this.ColCliente,
            this.ColMoneda,
            this.ColGravadas,
            this.ColInafectas,
            this.ColIgv,
            this.ColTotal,
            this.ColEstado});
			this.dgvDocumentos.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvDocumentos.Location = new System.Drawing.Point(0, 0);
			this.dgvDocumentos.MultiSelect = false;
			this.dgvDocumentos.Name = "dgvDocumentos";
			this.dgvDocumentos.ReadOnly = true;
			this.dgvDocumentos.RowHeadersWidth = 20;
			this.dgvDocumentos.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
			this.dgvDocumentos.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.Highlight;
			this.dgvDocumentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvDocumentos.Size = new System.Drawing.Size(1132, 384);
			this.dgvDocumentos.TabIndex = 4;
			this.dgvDocumentos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvDocumentos_CellClick);
			// 
			// ColId
			// 
			this.ColId.HeaderText = "Id";
			this.ColId.Name = "ColId";
			this.ColId.ReadOnly = true;
			this.ColId.Visible = false;
			// 
			// ColSeleccionar
			// 
			this.ColSeleccionar.HeaderText = "";
			this.ColSeleccionar.Name = "ColSeleccionar";
			this.ColSeleccionar.ReadOnly = true;
			this.ColSeleccionar.Width = 30;
			// 
			// ColCodigoTipoDoc
			// 
			this.ColCodigoTipoDoc.HeaderText = "CodigoTipoDoc";
			this.ColCodigoTipoDoc.Name = "ColCodigoTipoDoc";
			this.ColCodigoTipoDoc.ReadOnly = true;
			this.ColCodigoTipoDoc.Visible = false;
			// 
			// ColTipoDocumento
			// 
			this.ColTipoDocumento.HeaderText = "Tipo Doc.";
			this.ColTipoDocumento.Name = "ColTipoDocumento";
			this.ColTipoDocumento.ReadOnly = true;
			// 
			// ColSerie
			// 
			this.ColSerie.HeaderText = "Serie";
			this.ColSerie.Name = "ColSerie";
			this.ColSerie.ReadOnly = true;
			this.ColSerie.Width = 70;
			// 
			// ColNumero
			// 
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.ColNumero.DefaultCellStyle = dataGridViewCellStyle2;
			this.ColNumero.HeaderText = "Numero";
			this.ColNumero.Name = "ColNumero";
			this.ColNumero.ReadOnly = true;
			this.ColNumero.Width = 70;
			// 
			// ColFechaEmision
			// 
			dataGridViewCellStyle3.Format = "d";
			dataGridViewCellStyle3.NullValue = null;
			this.ColFechaEmision.DefaultCellStyle = dataGridViewCellStyle3;
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
			// ColGravadas
			// 
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.ColGravadas.DefaultCellStyle = dataGridViewCellStyle4;
			this.ColGravadas.HeaderText = "Gravadas";
			this.ColGravadas.Name = "ColGravadas";
			this.ColGravadas.ReadOnly = true;
			this.ColGravadas.Width = 80;
			// 
			// ColInafectas
			// 
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.ColInafectas.DefaultCellStyle = dataGridViewCellStyle5;
			this.ColInafectas.HeaderText = "Inafectas";
			this.ColInafectas.Name = "ColInafectas";
			this.ColInafectas.ReadOnly = true;
			this.ColInafectas.Width = 80;
			// 
			// ColIgv
			// 
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.ColIgv.DefaultCellStyle = dataGridViewCellStyle6;
			this.ColIgv.HeaderText = "Igv";
			this.ColIgv.Name = "ColIgv";
			this.ColIgv.ReadOnly = true;
			this.ColIgv.Width = 80;
			// 
			// ColTotal
			// 
			dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.ColTotal.DefaultCellStyle = dataGridViewCellStyle7;
			this.ColTotal.HeaderText = "Total";
			this.ColTotal.Name = "ColTotal";
			this.ColTotal.ReadOnly = true;
			this.ColTotal.Width = 80;
			// 
			// ColEstado
			// 
			this.ColEstado.HeaderText = "Estado";
			this.ColEstado.Name = "ColEstado";
			this.ColEstado.ReadOnly = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.cboTipoMedioPago);
			this.groupBox1.Controls.Add(this.cboSerie);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.txtFechaDel);
			this.groupBox1.Controls.Add(this.txtFechaAl);
			this.groupBox1.Controls.Add(this.btnBuscar);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.cboTipoDocumento);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(1132, 77);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Filtros";
			// 
			// cboSerie
			// 
			this.cboSerie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboSerie.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cboSerie.FormattingEnabled = true;
			this.cboSerie.Location = new System.Drawing.Point(350, 37);
			this.cboSerie.Name = "cboSerie";
			this.cboSerie.Size = new System.Drawing.Size(56, 21);
			this.cboSerie.TabIndex = 52;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(311, 42);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(31, 13);
			this.label2.TabIndex = 51;
			this.label2.Text = "Serie";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(574, 42);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(10, 13);
			this.label4.TabIndex = 50;
			this.label4.Text = "-";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(419, 42);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(42, 13);
			this.label3.TabIndex = 49;
			this.label3.Text = "Fechas";
			// 
			// txtFechaDel
			// 
			this.txtFechaDel.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.txtFechaDel.Location = new System.Drawing.Point(466, 38);
			this.txtFechaDel.Name = "txtFechaDel";
			this.txtFechaDel.Size = new System.Drawing.Size(104, 20);
			this.txtFechaDel.TabIndex = 48;
			// 
			// txtFechaAl
			// 
			this.txtFechaAl.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.txtFechaAl.Location = new System.Drawing.Point(587, 38);
			this.txtFechaAl.Name = "txtFechaAl";
			this.txtFechaAl.Size = new System.Drawing.Size(104, 20);
			this.txtFechaAl.TabIndex = 47;
			// 
			// btnBuscar
			// 
			this.btnBuscar.Image = global::HVLH.SistemaCaja.AppWin.Properties.Resources.busqueda;
			this.btnBuscar.Location = new System.Drawing.Point(1006, 32);
			this.btnBuscar.Name = "btnBuscar";
			this.btnBuscar.Size = new System.Drawing.Size(80, 31);
			this.btnBuscar.TabIndex = 46;
			this.btnBuscar.Text = "Buscar";
			this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnBuscar.UseVisualStyleBackColor = true;
			this.btnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(37, 42);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(84, 13);
			this.label1.TabIndex = 45;
			this.label1.Text = "Tipo documento";
			// 
			// cboTipoDocumento
			// 
			this.cboTipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboTipoDocumento.FormattingEnabled = true;
			this.cboTipoDocumento.Location = new System.Drawing.Point(126, 37);
			this.cboTipoDocumento.Name = "cboTipoDocumento";
			this.cboTipoDocumento.Size = new System.Drawing.Size(168, 21);
			this.cboTipoDocumento.TabIndex = 44;
			this.cboTipoDocumento.SelectedIndexChanged += new System.EventHandler(this.CboTipoDocumento_SelectedIndexChanged);
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
			this.splitContainer1.Panel1.Controls.Add(this.dgvDocumentos);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
			this.splitContainer1.Size = new System.Drawing.Size(1132, 465);
			this.splitContainer1.SplitterDistance = 384;
			this.splitContainer1.TabIndex = 6;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.splitContainer1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 48);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1132, 465);
			this.panel1.TabIndex = 7;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(717, 40);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(63, 13);
			this.label5.TabIndex = 54;
			this.label5.Text = "Medio pago";
			// 
			// cboTipoMedioPago
			// 
			this.cboTipoMedioPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboTipoMedioPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cboTipoMedioPago.FormattingEnabled = true;
			this.cboTipoMedioPago.Location = new System.Drawing.Point(786, 36);
			this.cboTipoMedioPago.Name = "cboTipoMedioPago";
			this.cboTipoMedioPago.Size = new System.Drawing.Size(196, 21);
			this.cboTipoMedioPago.TabIndex = 53;
			// 
			// FormEnvioDocumentos
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1132, 513);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.toolStrip1);
			this.Name = "FormEnvioDocumentos";
			this.Text = "Envío de documentos";
			this.Load += new System.EventHandler(this.FormEnvioDocumentos_Load);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvDocumentos)).EndInit();
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
		private System.Windows.Forms.ToolStripButton btnEnviar;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton btnSalir;
		private System.Windows.Forms.DataGridView dgvDocumentos;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColId;
		private System.Windows.Forms.DataGridViewCheckBoxColumn ColSeleccionar;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColCodigoTipoDoc;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColTipoDocumento;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColSerie;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColNumero;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColFechaEmision;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColCliente;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColMoneda;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColGravadas;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColInafectas;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColIgv;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColTotal;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColEstado;
		private System.Windows.Forms.ComboBox cboSerie;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		public System.Windows.Forms.DateTimePicker txtFechaDel;
		public System.Windows.Forms.DateTimePicker txtFechaAl;
		private System.Windows.Forms.Button btnBuscar;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cboTipoDocumento;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox cboTipoMedioPago;
	}
}