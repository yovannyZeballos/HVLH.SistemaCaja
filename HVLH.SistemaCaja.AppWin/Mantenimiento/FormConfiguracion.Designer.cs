namespace HVLH.SistemaCaja.AppWin.Mantenimiento
{
	partial class FormConfiguracion
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
			this.btnSalir = new System.Windows.Forms.ToolStripButton();
			this.btnGuardar = new System.Windows.Forms.ToolStripButton();
			this.panel1 = new System.Windows.Forms.Panel();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.txtPuerto = new System.Windows.Forms.NumericUpDown();
			this.txtSmtp = new System.Windows.Forms.TextBox();
			this.label19 = new System.Windows.Forms.Label();
			this.label20 = new System.Windows.Forms.Label();
			this.txtClaveCorreo = new System.Windows.Forms.TextBox();
			this.label22 = new System.Windows.Forms.Label();
			this.txtCorreo = new System.Windows.Forms.TextBox();
			this.label23 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.txtUrlConsulta = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.txtUrlEnvio = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.txtCarpetaDocumentos = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.txtRutaCertificado = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.txtClaveCertificado = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.txtClaveSol = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.txtUsuarioSol = new System.Windows.Forms.TextBox();
			this.label17 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.cboTipoOperacion = new System.Windows.Forms.ComboBox();
			this.lblTipoOperacion = new System.Windows.Forms.Label();
			this.txtIgv = new System.Windows.Forms.NumericUpDown();
			this.label16 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtTelefono = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.txtUbigeo = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txtDistrito = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtProvincia = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtDepartamento = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtDireccion = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtRazonSocial = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtRuc = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.panel1.SuspendLayout();
			this.groupBox4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtPuerto)).BeginInit();
			this.groupBox3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtIgv)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
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
			// panel1
			// 
			this.panel1.Controls.Add(this.groupBox4);
			this.panel1.Controls.Add(this.groupBox3);
			this.panel1.Controls.Add(this.groupBox2);
			this.panel1.Controls.Add(this.groupBox1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.panel1.Location = new System.Drawing.Point(0, 38);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(800, 532);
			this.panel1.TabIndex = 5;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.txtPuerto);
			this.groupBox4.Controls.Add(this.txtSmtp);
			this.groupBox4.Controls.Add(this.label19);
			this.groupBox4.Controls.Add(this.label20);
			this.groupBox4.Controls.Add(this.txtClaveCorreo);
			this.groupBox4.Controls.Add(this.label22);
			this.groupBox4.Controls.Add(this.txtCorreo);
			this.groupBox4.Controls.Add(this.label23);
			this.groupBox4.Location = new System.Drawing.Point(8, 408);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(784, 112);
			this.groupBox4.TabIndex = 17;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Correo";
			// 
			// txtPuerto
			// 
			this.txtPuerto.Location = new System.Drawing.Point(115, 59);
			this.txtPuerto.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
			this.txtPuerto.Name = "txtPuerto";
			this.txtPuerto.Size = new System.Drawing.Size(93, 23);
			this.txtPuerto.TabIndex = 22;
			this.txtPuerto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtSmtp
			// 
			this.txtSmtp.Location = new System.Drawing.Point(320, 60);
			this.txtSmtp.MaxLength = 20;
			this.txtSmtp.Name = "txtSmtp";
			this.txtSmtp.Size = new System.Drawing.Size(208, 23);
			this.txtSmtp.TabIndex = 9;
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Location = new System.Drawing.Point(216, 64);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(97, 17);
			this.label19.TabIndex = 8;
			this.label19.Text = "Servidor Smtp";
			// 
			// label20
			// 
			this.label20.AutoSize = true;
			this.label20.Location = new System.Drawing.Point(62, 63);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(50, 17);
			this.label20.TabIndex = 6;
			this.label20.Text = "Puerto";
			// 
			// txtClaveCorreo
			// 
			this.txtClaveCorreo.Location = new System.Drawing.Point(629, 32);
			this.txtClaveCorreo.MaxLength = 20;
			this.txtClaveCorreo.Name = "txtClaveCorreo";
			this.txtClaveCorreo.Size = new System.Drawing.Size(144, 23);
			this.txtClaveCorreo.TabIndex = 3;
			// 
			// label22
			// 
			this.label22.AutoSize = true;
			this.label22.Location = new System.Drawing.Point(538, 35);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(88, 17);
			this.label22.TabIndex = 2;
			this.label22.Text = "Clave correo";
			// 
			// txtCorreo
			// 
			this.txtCorreo.Location = new System.Drawing.Point(114, 32);
			this.txtCorreo.MaxLength = 100;
			this.txtCorreo.Name = "txtCorreo";
			this.txtCorreo.Size = new System.Drawing.Size(414, 23);
			this.txtCorreo.TabIndex = 1;
			// 
			// label23
			// 
			this.label23.AutoSize = true;
			this.label23.Location = new System.Drawing.Point(61, 35);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(51, 17);
			this.label23.TabIndex = 0;
			this.label23.Text = "Correo";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.txtUrlConsulta);
			this.groupBox3.Controls.Add(this.label13);
			this.groupBox3.Controls.Add(this.txtUrlEnvio);
			this.groupBox3.Controls.Add(this.label12);
			this.groupBox3.Controls.Add(this.txtCarpetaDocumentos);
			this.groupBox3.Controls.Add(this.label11);
			this.groupBox3.Controls.Add(this.txtRutaCertificado);
			this.groupBox3.Controls.Add(this.label10);
			this.groupBox3.Controls.Add(this.txtClaveCertificado);
			this.groupBox3.Controls.Add(this.label9);
			this.groupBox3.Controls.Add(this.txtClaveSol);
			this.groupBox3.Controls.Add(this.label15);
			this.groupBox3.Controls.Add(this.txtUsuarioSol);
			this.groupBox3.Controls.Add(this.label17);
			this.groupBox3.Location = new System.Drawing.Point(8, 248);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(784, 152);
			this.groupBox3.TabIndex = 16;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Facturacón electrónica";
			// 
			// txtUrlConsulta
			// 
			this.txtUrlConsulta.Location = new System.Drawing.Point(114, 116);
			this.txtUrlConsulta.MaxLength = 250;
			this.txtUrlConsulta.Name = "txtUrlConsulta";
			this.txtUrlConsulta.Size = new System.Drawing.Size(662, 23);
			this.txtUrlConsulta.TabIndex = 13;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(28, 119);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(83, 17);
			this.label13.TabIndex = 12;
			this.label13.Text = "Url consulta";
			// 
			// txtUrlEnvio
			// 
			this.txtUrlEnvio.Location = new System.Drawing.Point(114, 88);
			this.txtUrlEnvio.MaxLength = 250;
			this.txtUrlEnvio.Name = "txtUrlEnvio";
			this.txtUrlEnvio.Size = new System.Drawing.Size(662, 23);
			this.txtUrlEnvio.TabIndex = 11;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(47, 91);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(64, 17);
			this.label12.TabIndex = 10;
			this.label12.Text = "Url envío";
			// 
			// txtCarpetaDocumentos
			// 
			this.txtCarpetaDocumentos.Location = new System.Drawing.Point(495, 60);
			this.txtCarpetaDocumentos.MaxLength = 200;
			this.txtCarpetaDocumentos.Name = "txtCarpetaDocumentos";
			this.txtCarpetaDocumentos.Size = new System.Drawing.Size(280, 23);
			this.txtCarpetaDocumentos.TabIndex = 9;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(355, 63);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(137, 17);
			this.label11.TabIndex = 8;
			this.label11.Text = "Carpeta (XML, CDR)";
			// 
			// txtRutaCertificado
			// 
			this.txtRutaCertificado.Location = new System.Drawing.Point(114, 60);
			this.txtRutaCertificado.MaxLength = 100;
			this.txtRutaCertificado.Name = "txtRutaCertificado";
			this.txtRutaCertificado.Size = new System.Drawing.Size(232, 23);
			this.txtRutaCertificado.TabIndex = 7;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(4, 63);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(107, 17);
			this.label10.TabIndex = 6;
			this.label10.Text = "Ruta certificado";
			// 
			// txtClaveCertificado
			// 
			this.txtClaveCertificado.Location = new System.Drawing.Point(632, 32);
			this.txtClaveCertificado.MaxLength = 20;
			this.txtClaveCertificado.Name = "txtClaveCertificado";
			this.txtClaveCertificado.Size = new System.Drawing.Size(144, 23);
			this.txtClaveCertificado.TabIndex = 5;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(518, 35);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(112, 17);
			this.label9.TabIndex = 4;
			this.label9.Text = "Clave certificado";
			// 
			// txtClaveSol
			// 
			this.txtClaveSol.Location = new System.Drawing.Point(352, 32);
			this.txtClaveSol.MaxLength = 20;
			this.txtClaveSol.Name = "txtClaveSol";
			this.txtClaveSol.Size = new System.Drawing.Size(144, 23);
			this.txtClaveSol.TabIndex = 3;
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(284, 35);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(65, 17);
			this.label15.TabIndex = 2;
			this.label15.Text = "Clave sol";
			// 
			// txtUsuarioSol
			// 
			this.txtUsuarioSol.Location = new System.Drawing.Point(114, 32);
			this.txtUsuarioSol.MaxLength = 20;
			this.txtUsuarioSol.Name = "txtUsuarioSol";
			this.txtUsuarioSol.Size = new System.Drawing.Size(144, 23);
			this.txtUsuarioSol.TabIndex = 1;
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(32, 35);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(79, 17);
			this.label17.TabIndex = 0;
			this.label17.Text = "Usuario sol";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.cboTipoOperacion);
			this.groupBox2.Controls.Add(this.lblTipoOperacion);
			this.groupBox2.Controls.Add(this.txtIgv);
			this.groupBox2.Controls.Add(this.label16);
			this.groupBox2.Location = new System.Drawing.Point(8, 164);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(784, 80);
			this.groupBox2.TabIndex = 16;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "General";
			// 
			// cboTipoOperacion
			// 
			this.cboTipoOperacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboTipoOperacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cboTipoOperacion.FormattingEnabled = true;
			this.cboTipoOperacion.Location = new System.Drawing.Point(480, 32);
			this.cboTipoOperacion.Name = "cboTipoOperacion";
			this.cboTipoOperacion.Size = new System.Drawing.Size(288, 24);
			this.cboTipoOperacion.TabIndex = 21;
			// 
			// lblTipoOperacion
			// 
			this.lblTipoOperacion.AutoSize = true;
			this.lblTipoOperacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTipoOperacion.Location = new System.Drawing.Point(330, 36);
			this.lblTipoOperacion.Name = "lblTipoOperacion";
			this.lblTipoOperacion.Size = new System.Drawing.Size(147, 16);
			this.lblTipoOperacion.TabIndex = 20;
			this.lblTipoOperacion.Text = "Tipo operación defecto";
			// 
			// txtIgv
			// 
			this.txtIgv.DecimalPlaces = 4;
			this.txtIgv.Location = new System.Drawing.Point(120, 32);
			this.txtIgv.Name = "txtIgv";
			this.txtIgv.Size = new System.Drawing.Size(120, 23);
			this.txtIgv.TabIndex = 1;
			this.txtIgv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtIgv.Value = new decimal(new int[] {
            18,
            0,
            0,
            0});
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(80, 35);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(31, 17);
			this.label16.TabIndex = 0;
			this.label16.Text = "IGV";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtTelefono);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.txtUbigeo);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.txtDistrito);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.txtProvincia);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.txtDepartamento);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.txtDireccion);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.txtRazonSocial);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.txtRuc);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(8, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(784, 152);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Empresa";
			// 
			// txtTelefono
			// 
			this.txtTelefono.Location = new System.Drawing.Point(334, 113);
			this.txtTelefono.MaxLength = 250;
			this.txtTelefono.Name = "txtTelefono";
			this.txtTelefono.Size = new System.Drawing.Size(154, 23);
			this.txtTelefono.TabIndex = 15;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(264, 116);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(64, 17);
			this.label8.TabIndex = 14;
			this.label8.Text = "Telefono";
			// 
			// txtUbigeo
			// 
			this.txtUbigeo.Location = new System.Drawing.Point(120, 113);
			this.txtUbigeo.MaxLength = 250;
			this.txtUbigeo.Name = "txtUbigeo";
			this.txtUbigeo.Size = new System.Drawing.Size(136, 23);
			this.txtUbigeo.TabIndex = 13;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(61, 117);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(53, 17);
			this.label7.TabIndex = 12;
			this.label7.Text = "Ubigeo";
			// 
			// txtDistrito
			// 
			this.txtDistrito.Location = new System.Drawing.Point(564, 87);
			this.txtDistrito.MaxLength = 250;
			this.txtDistrito.Name = "txtDistrito";
			this.txtDistrito.Size = new System.Drawing.Size(212, 23);
			this.txtDistrito.TabIndex = 11;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(504, 89);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(52, 17);
			this.label6.TabIndex = 10;
			this.label6.Text = "Distrito";
			// 
			// txtProvincia
			// 
			this.txtProvincia.Location = new System.Drawing.Point(333, 86);
			this.txtProvincia.MaxLength = 250;
			this.txtProvincia.Name = "txtProvincia";
			this.txtProvincia.Size = new System.Drawing.Size(155, 23);
			this.txtProvincia.TabIndex = 9;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(262, 88);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(66, 17);
			this.label5.TabIndex = 8;
			this.label5.Text = "Provincia";
			// 
			// txtDepartamento
			// 
			this.txtDepartamento.Location = new System.Drawing.Point(120, 86);
			this.txtDepartamento.MaxLength = 250;
			this.txtDepartamento.Name = "txtDepartamento";
			this.txtDepartamento.Size = new System.Drawing.Size(136, 23);
			this.txtDepartamento.TabIndex = 7;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(16, 90);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(98, 17);
			this.label4.TabIndex = 6;
			this.label4.Text = "Departamento";
			// 
			// txtDireccion
			// 
			this.txtDireccion.Location = new System.Drawing.Point(120, 59);
			this.txtDireccion.MaxLength = 250;
			this.txtDireccion.Name = "txtDireccion";
			this.txtDireccion.Size = new System.Drawing.Size(656, 23);
			this.txtDireccion.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(47, 63);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(67, 17);
			this.label3.TabIndex = 4;
			this.label3.Text = "Dirección";
			// 
			// txtRazonSocial
			// 
			this.txtRazonSocial.Location = new System.Drawing.Point(376, 32);
			this.txtRazonSocial.MaxLength = 250;
			this.txtRazonSocial.Name = "txtRazonSocial";
			this.txtRazonSocial.Size = new System.Drawing.Size(400, 23);
			this.txtRazonSocial.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(282, 35);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(89, 17);
			this.label2.TabIndex = 2;
			this.label2.Text = "Razon social";
			// 
			// txtRuc
			// 
			this.txtRuc.Location = new System.Drawing.Point(120, 32);
			this.txtRuc.MaxLength = 11;
			this.txtRuc.Name = "txtRuc";
			this.txtRuc.Size = new System.Drawing.Size(144, 23);
			this.txtRuc.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(77, 35);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(37, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "RUC";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGuardar,
            this.toolStripSeparator1,
            this.btnSalir});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(800, 38);
			this.toolStrip1.TabIndex = 4;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// FormConfiguracion
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 570);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.toolStrip1);
			this.Name = "FormConfiguracion";
			this.Text = "CONFIGURACION GENERAL";
			this.Load += new System.EventHandler(this.FormConfiguracion_Load);
			this.panel1.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtPuerto)).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtIgv)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStripButton btnSalir;
		private System.Windows.Forms.ToolStripButton btnGuardar;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtRazonSocial;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtRuc;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtTelefono;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtUbigeo;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtDistrito;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtProvincia;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtDepartamento;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtDireccion;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.TextBox txtUsuarioSol;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.ComboBox cboTipoOperacion;
		private System.Windows.Forms.Label lblTipoOperacion;
		private System.Windows.Forms.NumericUpDown txtIgv;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.TextBox txtSmtp;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.TextBox txtClaveCorreo;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.TextBox txtCorreo;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.TextBox txtUrlConsulta;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox txtUrlEnvio;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox txtCarpetaDocumentos;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox txtRutaCertificado;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox txtClaveCertificado;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtClaveSol;
		private System.Windows.Forms.NumericUpDown txtPuerto;
	}
}