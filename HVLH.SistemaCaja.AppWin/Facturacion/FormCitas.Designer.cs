namespace HVLH.SistemaCaja.AppWin.Facturacion
{
	partial class FormCitas
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.btnTransferir = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.btnSalir = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.txtPaciente = new System.Windows.Forms.ToolStripTextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtNroCita = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtNroDocumento = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtNroHistoria = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtFechaDel = new System.Windows.Forms.DateTimePicker();
			this.txtFechaAl = new System.Windows.Forms.DateTimePicker();
			this.btnBuscar = new System.Windows.Forms.Button();
			this.dgvCitas = new System.Windows.Forms.DataGridView();
			this.ColSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.ColIdCita = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColMedico = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColConcepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.panel1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvCitas)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.toolStrip1);
			this.panel1.Controls.Add(this.groupBox1);
			this.panel1.Controls.Add(this.dgvCitas);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1051, 435);
			this.panel1.TabIndex = 10;
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnTransferir,
            this.toolStripSeparator2,
            this.btnSalir,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.txtPaciente});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(1051, 38);
			this.toolStrip1.TabIndex = 5;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// btnTransferir
			// 
			this.btnTransferir.Image = global::HVLH.SistemaCaja.AppWin.Properties.Resources.ok;
			this.btnTransferir.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnTransferir.Name = "btnTransferir";
			this.btnTransferir.Size = new System.Drawing.Size(88, 35);
			this.btnTransferir.Text = "Transferir Citas";
			this.btnTransferir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnTransferir.Click += new System.EventHandler(this.BtnTransferir_Click);
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
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(62, 35);
			this.toolStripLabel1.Text = "PACIENTE:";
			// 
			// txtPaciente
			// 
			this.txtPaciente.Enabled = false;
			this.txtPaciente.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.txtPaciente.Name = "txtPaciente";
			this.txtPaciente.Size = new System.Drawing.Size(400, 38);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.txtNroCita);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.txtNroDocumento);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.txtNroHistoria);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.txtFechaDel);
			this.groupBox1.Controls.Add(this.txtFechaAl);
			this.groupBox1.Controls.Add(this.btnBuscar);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(10, 304);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(1032, 120);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Filtros";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(299, 56);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(45, 17);
			this.label6.TabIndex = 46;
			this.label6.Text = "Hasta";
			// 
			// txtNroCita
			// 
			this.txtNroCita.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtNroCita.Location = new System.Drawing.Point(131, 81);
			this.txtNroCita.Name = "txtNroCita";
			this.txtNroCita.Size = new System.Drawing.Size(128, 23);
			this.txtNroCita.TabIndex = 45;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(66, 84);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(59, 17);
			this.label5.TabIndex = 44;
			this.label5.Text = "Nro Cita";
			// 
			// txtNroDocumento
			// 
			this.txtNroDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtNroDocumento.Location = new System.Drawing.Point(131, 52);
			this.txtNroDocumento.Name = "txtNroDocumento";
			this.txtNroDocumento.Size = new System.Drawing.Size(128, 23);
			this.txtNroDocumento.TabIndex = 43;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(18, 55);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(107, 17);
			this.label2.TabIndex = 42;
			this.label2.Text = "Nro Documento";
			// 
			// txtNroHistoria
			// 
			this.txtNroHistoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtNroHistoria.Location = new System.Drawing.Point(131, 23);
			this.txtNroHistoria.Name = "txtNroHistoria";
			this.txtNroHistoria.Size = new System.Drawing.Size(128, 23);
			this.txtNroHistoria.TabIndex = 41;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(42, 27);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(83, 17);
			this.label1.TabIndex = 40;
			this.label1.Text = "Nro Historia";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(828, 36);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(13, 17);
			this.label4.TabIndex = 39;
			this.label4.Text = "-";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(295, 27);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(49, 17);
			this.label3.TabIndex = 38;
			this.label3.Text = "Desde";
			// 
			// txtFechaDel
			// 
			this.txtFechaDel.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.txtFechaDel.Location = new System.Drawing.Point(349, 24);
			this.txtFechaDel.Name = "txtFechaDel";
			this.txtFechaDel.Size = new System.Drawing.Size(118, 23);
			this.txtFechaDel.TabIndex = 37;
			// 
			// txtFechaAl
			// 
			this.txtFechaAl.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.txtFechaAl.Location = new System.Drawing.Point(350, 53);
			this.txtFechaAl.Name = "txtFechaAl";
			this.txtFechaAl.Size = new System.Drawing.Size(116, 23);
			this.txtFechaAl.TabIndex = 36;
			// 
			// btnBuscar
			// 
			this.btnBuscar.Image = global::HVLH.SistemaCaja.AppWin.Properties.Resources.busqueda;
			this.btnBuscar.Location = new System.Drawing.Point(499, 23);
			this.btnBuscar.Name = "btnBuscar";
			this.btnBuscar.Size = new System.Drawing.Size(120, 31);
			this.btnBuscar.TabIndex = 35;
			this.btnBuscar.Text = "Buscar";
			this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnBuscar.UseVisualStyleBackColor = true;
			this.btnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
			// 
			// dgvCitas
			// 
			this.dgvCitas.AllowUserToAddRows = false;
			this.dgvCitas.AllowUserToDeleteRows = false;
			this.dgvCitas.AllowUserToResizeRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.dgvCitas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvCitas.BackgroundColor = System.Drawing.SystemColors.HighlightText;
			this.dgvCitas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvCitas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColSelect,
            this.ColIdCita,
            this.ColFecha,
            this.ColHora,
            this.ColMedico,
            this.ColConcepto,
            this.ColPrecio,
            this.ColEstado});
			this.dgvCitas.Location = new System.Drawing.Point(6, 43);
			this.dgvCitas.MultiSelect = false;
			this.dgvCitas.Name = "dgvCitas";
			this.dgvCitas.ReadOnly = true;
			this.dgvCitas.RowHeadersWidth = 20;
			this.dgvCitas.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
			this.dgvCitas.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.Highlight;
			this.dgvCitas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvCitas.Size = new System.Drawing.Size(1040, 253);
			this.dgvCitas.TabIndex = 4;
			this.dgvCitas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvDocumentos_CellClick);
			// 
			// ColSelect
			// 
			this.ColSelect.HeaderText = "";
			this.ColSelect.Name = "ColSelect";
			this.ColSelect.ReadOnly = true;
			this.ColSelect.Width = 30;
			// 
			// ColIdCita
			// 
			this.ColIdCita.HeaderText = "ID CITA";
			this.ColIdCita.Name = "ColIdCita";
			this.ColIdCita.ReadOnly = true;
			// 
			// ColFecha
			// 
			this.ColFecha.HeaderText = "FECHA";
			this.ColFecha.Name = "ColFecha";
			this.ColFecha.ReadOnly = true;
			this.ColFecha.Width = 80;
			// 
			// ColHora
			// 
			dataGridViewCellStyle2.NullValue = null;
			this.ColHora.DefaultCellStyle = dataGridViewCellStyle2;
			this.ColHora.HeaderText = "HORA";
			this.ColHora.Name = "ColHora";
			this.ColHora.ReadOnly = true;
			// 
			// ColMedico
			// 
			this.ColMedico.HeaderText = "MÉDICO";
			this.ColMedico.Name = "ColMedico";
			this.ColMedico.ReadOnly = true;
			this.ColMedico.Width = 250;
			// 
			// ColConcepto
			// 
			this.ColConcepto.HeaderText = "CONCEPTO";
			this.ColConcepto.Name = "ColConcepto";
			this.ColConcepto.ReadOnly = true;
			this.ColConcepto.Width = 250;
			// 
			// ColPrecio
			// 
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.ColPrecio.DefaultCellStyle = dataGridViewCellStyle3;
			this.ColPrecio.HeaderText = "PRECIO";
			this.ColPrecio.Name = "ColPrecio";
			this.ColPrecio.ReadOnly = true;
			this.ColPrecio.Width = 80;
			// 
			// ColEstado
			// 
			this.ColEstado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.ColEstado.HeaderText = "ESTADO";
			this.ColEstado.Name = "ColEstado";
			this.ColEstado.ReadOnly = true;
			// 
			// FormCitas
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1051, 435);
			this.Controls.Add(this.panel1);
			this.Name = "FormCitas";
			this.Text = "CONSULTA DE CITAS";
			this.Load += new System.EventHandler(this.FormCitas_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvCitas)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton btnTransferir;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton btnSalir;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private System.Windows.Forms.ToolStripTextBox txtPaciente;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtNroCita;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtNroDocumento;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtNroHistoria;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		public System.Windows.Forms.DateTimePicker txtFechaDel;
		public System.Windows.Forms.DateTimePicker txtFechaAl;
		private System.Windows.Forms.Button btnBuscar;
		private System.Windows.Forms.DataGridView dgvCitas;
		private System.Windows.Forms.DataGridViewCheckBoxColumn ColSelect;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColIdCita;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColFecha;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColHora;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColMedico;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColConcepto;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColPrecio;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColEstado;
	}
}