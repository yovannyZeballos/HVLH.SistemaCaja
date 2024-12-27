namespace HVLH.SistemaCaja.AppWin.Mantenimiento
{
	partial class FormMantUsuario
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
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.btnSalir = new System.Windows.Forms.ToolStripButton();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lblEstado = new System.Windows.Forms.Label();
			this.cboEstado = new System.Windows.Forms.ComboBox();
			this.chkCajero = new System.Windows.Forms.CheckBox();
			this.txtClave = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtNombres = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtLogin = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.toolStrip1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGuardar,
            this.toolStripSeparator1,
            this.btnLimpiar,
            this.toolStripSeparator3,
            this.btnSalir});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(431, 38);
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
			this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
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
			this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.lblEstado);
			this.panel1.Controls.Add(this.cboEstado);
			this.panel1.Controls.Add(this.chkCajero);
			this.panel1.Controls.Add(this.txtClave);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.txtNombres);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.txtLogin);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 38);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(431, 171);
			this.panel1.TabIndex = 3;
			// 
			// lblEstado
			// 
			this.lblEstado.AutoSize = true;
			this.lblEstado.Location = new System.Drawing.Point(40, 110);
			this.lblEstado.Name = "lblEstado";
			this.lblEstado.Size = new System.Drawing.Size(40, 13);
			this.lblEstado.TabIndex = 8;
			this.lblEstado.Text = "Estado";
			// 
			// cboEstado
			// 
			this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboEstado.Enabled = false;
			this.cboEstado.FormattingEnabled = true;
			this.cboEstado.Location = new System.Drawing.Point(96, 107);
			this.cboEstado.Name = "cboEstado";
			this.cboEstado.Size = new System.Drawing.Size(121, 21);
			this.cboEstado.TabIndex = 7;
			// 
			// chkCajero
			// 
			this.chkCajero.AutoSize = true;
			this.chkCajero.Location = new System.Drawing.Point(249, 86);
			this.chkCajero.Name = "chkCajero";
			this.chkCajero.Size = new System.Drawing.Size(56, 17);
			this.chkCajero.TabIndex = 6;
			this.chkCajero.Text = "Cajero";
			this.chkCajero.UseVisualStyleBackColor = true;
			// 
			// txtClave
			// 
			this.txtClave.Location = new System.Drawing.Point(96, 82);
			this.txtClave.MaxLength = 15;
			this.txtClave.Name = "txtClave";
			this.txtClave.PasswordChar = '*';
			this.txtClave.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtClave.Size = new System.Drawing.Size(126, 20);
			this.txtClave.TabIndex = 5;
			this.txtClave.Text = "123456";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(40, 85);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(34, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Clave";
			// 
			// txtNombres
			// 
			this.txtNombres.Location = new System.Drawing.Point(96, 57);
			this.txtNombres.MaxLength = 250;
			this.txtNombres.Name = "txtNombres";
			this.txtNombres.Size = new System.Drawing.Size(293, 20);
			this.txtNombres.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(40, 60);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(49, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Nombres";
			// 
			// txtLogin
			// 
			this.txtLogin.Location = new System.Drawing.Point(96, 32);
			this.txtLogin.MaxLength = 20;
			this.txtLogin.Name = "txtLogin";
			this.txtLogin.Size = new System.Drawing.Size(133, 20);
			this.txtLogin.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(40, 36);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(33, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Login";
			// 
			// FormMantUsuario
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(431, 209);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.toolStrip1);
			this.Name = "FormMantUsuario";
			this.Text = "Usuarios";
			this.Load += new System.EventHandler(this.FormMantUsuario_Load);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
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
		private System.Windows.Forms.Label lblEstado;
		private System.Windows.Forms.ComboBox cboEstado;
		private System.Windows.Forms.CheckBox chkCajero;
		private System.Windows.Forms.TextBox txtClave;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtNombres;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtLogin;
		private System.Windows.Forms.Label label1;
	}
}