namespace HVLH.SistemaCaja.AppWin.Facturacion
{
	partial class FormListadoDocumentosComunicacionBaja
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.btnSeleccionar = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.btnSalir = new System.Windows.Forms.ToolStripButton();
			this.panel2 = new System.Windows.Forms.Panel();
			this.dgvDocumentos = new System.Windows.Forms.DataGridView();
			this.ColId = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.ColCodigoTipoDoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColTipoDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColNroDoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
			this.btnBuscar = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.cboTipoDocumento = new System.Windows.Forms.ComboBox();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvDocumentos)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.splitContainer1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1051, 518);
			this.panel1.TabIndex = 10;
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
			this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
			this.splitContainer1.Panel1.Controls.Add(this.panel2);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
			this.splitContainer1.Size = new System.Drawing.Size(1051, 518);
			this.splitContainer1.SplitterDistance = 433;
			this.splitContainer1.TabIndex = 6;
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSeleccionar,
            this.toolStripSeparator2,
            this.btnSalir});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(1051, 38);
			this.toolStrip1.TabIndex = 5;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// btnSeleccionar
			// 
			this.btnSeleccionar.Image = global::HVLH.SistemaCaja.AppWin.Properties.Resources.comprobar;
			this.btnSeleccionar.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnSeleccionar.Name = "btnSeleccionar";
			this.btnSeleccionar.Size = new System.Drawing.Size(71, 35);
			this.btnSeleccionar.Text = "Seleccionar";
			this.btnSeleccionar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnSeleccionar.Click += new System.EventHandler(this.BtnSeleccionar_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
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
			// panel2
			// 
			this.panel2.Controls.Add(this.dgvDocumentos);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(0, 40);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1051, 393);
			this.panel2.TabIndex = 5;
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
            this.ColSelect,
            this.ColCodigoTipoDoc,
            this.ColTipoDocumento,
            this.ColNroDoc,
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
			this.dgvDocumentos.Size = new System.Drawing.Size(1051, 393);
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
			// ColSelect
			// 
			this.ColSelect.HeaderText = "";
			this.ColSelect.Name = "ColSelect";
			this.ColSelect.ReadOnly = true;
			this.ColSelect.Width = 30;
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
			// ColGravadas
			// 
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.ColGravadas.DefaultCellStyle = dataGridViewCellStyle3;
			this.ColGravadas.HeaderText = "Gravadas";
			this.ColGravadas.Name = "ColGravadas";
			this.ColGravadas.ReadOnly = true;
			this.ColGravadas.Width = 80;
			// 
			// ColInafectas
			// 
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.ColInafectas.DefaultCellStyle = dataGridViewCellStyle4;
			this.ColInafectas.HeaderText = "Inafectas";
			this.ColInafectas.Name = "ColInafectas";
			this.ColInafectas.ReadOnly = true;
			this.ColInafectas.Width = 80;
			// 
			// ColIgv
			// 
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.ColIgv.DefaultCellStyle = dataGridViewCellStyle5;
			this.ColIgv.HeaderText = "Igv";
			this.ColIgv.Name = "ColIgv";
			this.ColIgv.ReadOnly = true;
			this.ColIgv.Width = 80;
			// 
			// ColTotal
			// 
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.ColTotal.DefaultCellStyle = dataGridViewCellStyle6;
			this.ColTotal.HeaderText = "Total";
			this.ColTotal.Name = "ColTotal";
			this.ColTotal.ReadOnly = true;
			this.ColTotal.Width = 80;
			// 
			// ColEstado
			// 
			this.ColEstado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.ColEstado.HeaderText = "Estado";
			this.ColEstado.Name = "ColEstado";
			this.ColEstado.ReadOnly = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.cboSerie);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.btnBuscar);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.cboTipoDocumento);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(1051, 81);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Filtros";
			// 
			// cboSerie
			// 
			this.cboSerie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboSerie.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cboSerie.FormattingEnabled = true;
			this.cboSerie.Location = new System.Drawing.Point(360, 37);
			this.cboSerie.Name = "cboSerie";
			this.cboSerie.Size = new System.Drawing.Size(56, 21);
			this.cboSerie.TabIndex = 41;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(321, 42);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(31, 13);
			this.label2.TabIndex = 40;
			this.label2.Text = "Serie";
			// 
			// btnBuscar
			// 
			this.btnBuscar.Image = global::HVLH.SistemaCaja.AppWin.Properties.Resources.busqueda;
			this.btnBuscar.Location = new System.Drawing.Point(496, 32);
			this.btnBuscar.Name = "btnBuscar";
			this.btnBuscar.Size = new System.Drawing.Size(80, 31);
			this.btnBuscar.TabIndex = 35;
			this.btnBuscar.Text = "Buscar";
			this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnBuscar.UseVisualStyleBackColor = true;
			this.btnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(21, 42);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(84, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Tipo documento";
			// 
			// cboTipoDocumento
			// 
			this.cboTipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboTipoDocumento.FormattingEnabled = true;
			this.cboTipoDocumento.Location = new System.Drawing.Point(110, 37);
			this.cboTipoDocumento.Name = "cboTipoDocumento";
			this.cboTipoDocumento.Size = new System.Drawing.Size(168, 21);
			this.cboTipoDocumento.TabIndex = 0;
			this.cboTipoDocumento.SelectedIndexChanged += new System.EventHandler(this.CboTipoDocumento_SelectedIndexChanged);
			// 
			// FormListadoDocumentosResumen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1051, 518);
			this.Controls.Add(this.panel1);
			this.Name = "FormListadoDocumentosResumen";
			this.Text = "Documentos";
			this.Load += new System.EventHandler(this.FormReporteVentas_Load);
			this.panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvDocumentos)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.DataGridView dgvDocumentos;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnBuscar;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cboTipoDocumento;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton btnSeleccionar;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton btnSalir;
		private System.Windows.Forms.ComboBox cboSerie;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColId;
		private System.Windows.Forms.DataGridViewCheckBoxColumn ColSelect;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColCodigoTipoDoc;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColTipoDocumento;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColNroDoc;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColFechaEmision;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColCliente;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColMoneda;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColGravadas;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColInafectas;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColIgv;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColTotal;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColEstado;
	}
}