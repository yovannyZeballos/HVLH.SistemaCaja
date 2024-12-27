namespace HVLH.SistemaCaja.AppWin.Facturacion
{
	partial class FormCuotas
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
			this.dgvDetalle = new System.Windows.Forms.DataGridView();
			this.NroCuota = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.FechaVencimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.MontoCuota = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.txtFecha = new System.Windows.Forms.DateTimePicker();
			this.label17 = new System.Windows.Forms.Label();
			this.txtMonto = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.btnAgregar = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.btnEliminar = new System.Windows.Forms.Button();
			this.btnSalir = new System.Windows.Forms.Button();
			this.txtTotal = new System.Windows.Forms.NumericUpDown();
			this.panel1 = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtMonto)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtTotal)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// dgvDetalle
			// 
			this.dgvDetalle.AllowUserToAddRows = false;
			this.dgvDetalle.AllowUserToDeleteRows = false;
			this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NroCuota,
            this.FechaVencimiento,
            this.MontoCuota});
			this.dgvDetalle.Location = new System.Drawing.Point(9, 99);
			this.dgvDetalle.MultiSelect = false;
			this.dgvDetalle.Name = "dgvDetalle";
			this.dgvDetalle.ReadOnly = true;
			this.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvDetalle.Size = new System.Drawing.Size(296, 192);
			this.dgvDetalle.TabIndex = 0;
			// 
			// NroCuota
			// 
			this.NroCuota.HeaderText = "Nro Cuota";
			this.NroCuota.Name = "NroCuota";
			this.NroCuota.ReadOnly = true;
			this.NroCuota.Width = 50;
			// 
			// FechaVencimiento
			// 
			this.FechaVencimiento.HeaderText = "Fecha Vencimiento";
			this.FechaVencimiento.Name = "FechaVencimiento";
			this.FechaVencimiento.ReadOnly = true;
			// 
			// MontoCuota
			// 
			this.MontoCuota.HeaderText = "Monto Cuota";
			this.MontoCuota.Name = "MontoCuota";
			this.MontoCuota.ReadOnly = true;
			// 
			// txtFecha
			// 
			this.txtFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.txtFecha.Location = new System.Drawing.Point(153, 11);
			this.txtFecha.Name = "txtFecha";
			this.txtFecha.Size = new System.Drawing.Size(120, 22);
			this.txtFecha.TabIndex = 18;
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label17.Location = new System.Drawing.Point(30, 15);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(120, 16);
			this.label17.TabIndex = 19;
			this.label17.Text = "Fecha vencimiento";
			// 
			// txtMonto
			// 
			this.txtMonto.DecimalPlaces = 2;
			this.txtMonto.Location = new System.Drawing.Point(153, 39);
			this.txtMonto.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
			this.txtMonto.Name = "txtMonto";
			this.txtMonto.Size = new System.Drawing.Size(120, 20);
			this.txtMonto.TabIndex = 20;
			this.txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(69, 41);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 16);
			this.label1.TabIndex = 21;
			this.label1.Text = "Monto cuota";
			// 
			// btnAgregar
			// 
			this.btnAgregar.Location = new System.Drawing.Point(57, 67);
			this.btnAgregar.Name = "btnAgregar";
			this.btnAgregar.Size = new System.Drawing.Size(96, 23);
			this.btnAgregar.TabIndex = 32;
			this.btnAgregar.TabStop = false;
			this.btnAgregar.Text = "Agregar";
			this.btnAgregar.UseVisualStyleBackColor = true;
			this.btnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(153, 303);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(38, 16);
			this.label2.TabIndex = 33;
			this.label2.Text = "Total";
			// 
			// btnEliminar
			// 
			this.btnEliminar.Location = new System.Drawing.Point(161, 67);
			this.btnEliminar.Name = "btnEliminar";
			this.btnEliminar.Size = new System.Drawing.Size(96, 23);
			this.btnEliminar.TabIndex = 34;
			this.btnEliminar.TabStop = false;
			this.btnEliminar.Text = "Eliminar";
			this.btnEliminar.UseVisualStyleBackColor = true;
			this.btnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
			// 
			// btnSalir
			// 
			this.btnSalir.Location = new System.Drawing.Point(9, 299);
			this.btnSalir.Name = "btnSalir";
			this.btnSalir.Size = new System.Drawing.Size(72, 23);
			this.btnSalir.TabIndex = 36;
			this.btnSalir.TabStop = false;
			this.btnSalir.Text = "Salir";
			this.btnSalir.UseVisualStyleBackColor = true;
			this.btnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
			// 
			// txtTotal
			// 
			this.txtTotal.DecimalPlaces = 2;
			this.txtTotal.Enabled = false;
			this.txtTotal.Location = new System.Drawing.Point(201, 300);
			this.txtTotal.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
			this.txtTotal.Name = "txtTotal";
			this.txtTotal.Size = new System.Drawing.Size(104, 20);
			this.txtTotal.TabIndex = 37;
			this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.txtTotal);
			this.panel1.Controls.Add(this.dgvDetalle);
			this.panel1.Controls.Add(this.btnSalir);
			this.panel1.Controls.Add(this.label17);
			this.panel1.Controls.Add(this.btnEliminar);
			this.panel1.Controls.Add(this.txtFecha);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.txtMonto);
			this.panel1.Controls.Add(this.btnAgregar);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(316, 335);
			this.panel1.TabIndex = 38;
			// 
			// FormCuotas
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(316, 335);
			this.Controls.Add(this.panel1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormCuotas";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Cuotas del crédito";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCuotas_FormClosing);
			this.Load += new System.EventHandler(this.FormCuotas_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtMonto)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtTotal)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dgvDetalle;
		private System.Windows.Forms.DataGridViewTextBoxColumn NroCuota;
		private System.Windows.Forms.DataGridViewTextBoxColumn FechaVencimiento;
		private System.Windows.Forms.DataGridViewTextBoxColumn MontoCuota;
		private System.Windows.Forms.DateTimePicker txtFecha;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.NumericUpDown txtMonto;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnAgregar;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnEliminar;
		private System.Windows.Forms.Button btnSalir;
		private System.Windows.Forms.NumericUpDown txtTotal;
		private System.Windows.Forms.Panel panel1;
	}
}