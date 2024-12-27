namespace HVLH.SistemaCaja.AppWin.Inicio
{
	partial class FormPrincipal
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
			this.mnuPrincipal = new System.Windows.Forms.MenuStrip();
			this.mantenimientoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuVentasElectronico = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuFacturaElectronico = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuBoletaElectronico = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuNotaCreditoElectronico = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuVentasManual = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuFacturaManual = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuBoletaManual = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuNotaCreditoManual = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuAnulacion = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuConsultaDocumentos = new System.Windows.Forms.ToolStripMenuItem();
			this.facturaciónElectrónicaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuEnvioDocumentos = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuEnvioResumen = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuComunicacionBaja = new System.Windows.Forms.ToolStripMenuItem();
			this.facturacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuTipoDocumento = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuSeries = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuConfiguracion = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuUsuario = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuRoles = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuProductos = new System.Windows.Forms.ToolStripMenuItem();
			this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuVentasDia = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuVentas = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuSalir = new System.Windows.Forms.ToolStripMenuItem();
			this.stPrincipal = new System.Windows.Forms.StatusStrip();
			this.tssUser = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.mnuMediosPago = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuPrincipal.SuspendLayout();
			this.stPrincipal.SuspendLayout();
			this.SuspendLayout();
			// 
			// mnuPrincipal
			// 
			this.mnuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mantenimientoToolStripMenuItem,
            this.facturaciónElectrónicaToolStripMenuItem,
            this.facturacionToolStripMenuItem,
            this.reportesToolStripMenuItem,
            this.mnuSalir});
			this.mnuPrincipal.Location = new System.Drawing.Point(0, 0);
			this.mnuPrincipal.Name = "mnuPrincipal";
			this.mnuPrincipal.Size = new System.Drawing.Size(800, 27);
			this.mnuPrincipal.TabIndex = 1;
			this.mnuPrincipal.Text = "menuStrip1";
			// 
			// mantenimientoToolStripMenuItem
			// 
			this.mantenimientoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuVentasElectronico,
            this.mnuVentasManual,
            this.mnuAnulacion,
            this.mnuConsultaDocumentos});
			this.mantenimientoToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.mantenimientoToolStripMenuItem.Name = "mantenimientoToolStripMenuItem";
			this.mantenimientoToolStripMenuItem.Size = new System.Drawing.Size(77, 23);
			this.mantenimientoToolStripMenuItem.Text = "1. Ventas";
			// 
			// mnuVentasElectronico
			// 
			this.mnuVentasElectronico.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFacturaElectronico,
            this.mnuBoletaElectronico,
            this.mnuNotaCreditoElectronico});
			this.mnuVentasElectronico.Name = "mnuVentasElectronico";
			this.mnuVentasElectronico.Size = new System.Drawing.Size(237, 24);
			this.mnuVentasElectronico.Text = "Electrónico";
			// 
			// mnuFacturaElectronico
			// 
			this.mnuFacturaElectronico.Name = "mnuFacturaElectronico";
			this.mnuFacturaElectronico.Size = new System.Drawing.Size(154, 24);
			this.mnuFacturaElectronico.Text = "Factura";
			this.mnuFacturaElectronico.Click += new System.EventHandler(this.MnuFacturaElectronico_Click);
			// 
			// mnuBoletaElectronico
			// 
			this.mnuBoletaElectronico.Name = "mnuBoletaElectronico";
			this.mnuBoletaElectronico.Size = new System.Drawing.Size(154, 24);
			this.mnuBoletaElectronico.Text = "Boleta";
			this.mnuBoletaElectronico.Click += new System.EventHandler(this.MnuBoletaElectronica_Click);
			// 
			// mnuNotaCreditoElectronico
			// 
			this.mnuNotaCreditoElectronico.Name = "mnuNotaCreditoElectronico";
			this.mnuNotaCreditoElectronico.Size = new System.Drawing.Size(154, 24);
			this.mnuNotaCreditoElectronico.Text = "Nota crédito";
			this.mnuNotaCreditoElectronico.Click += new System.EventHandler(this.MnuNotaCreditoElectronica_Click);
			// 
			// mnuVentasManual
			// 
			this.mnuVentasManual.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFacturaManual,
            this.mnuBoletaManual,
            this.mnuNotaCreditoManual});
			this.mnuVentasManual.Name = "mnuVentasManual";
			this.mnuVentasManual.Size = new System.Drawing.Size(237, 24);
			this.mnuVentasManual.Text = "Manual";
			// 
			// mnuFacturaManual
			// 
			this.mnuFacturaManual.Name = "mnuFacturaManual";
			this.mnuFacturaManual.Size = new System.Drawing.Size(154, 24);
			this.mnuFacturaManual.Text = "Factura";
			this.mnuFacturaManual.Click += new System.EventHandler(this.MnuFacturaManual_Click);
			// 
			// mnuBoletaManual
			// 
			this.mnuBoletaManual.Name = "mnuBoletaManual";
			this.mnuBoletaManual.Size = new System.Drawing.Size(154, 24);
			this.mnuBoletaManual.Text = "Boleta";
			this.mnuBoletaManual.Click += new System.EventHandler(this.MnuBoletaManual_Click);
			// 
			// mnuNotaCreditoManual
			// 
			this.mnuNotaCreditoManual.Name = "mnuNotaCreditoManual";
			this.mnuNotaCreditoManual.Size = new System.Drawing.Size(154, 24);
			this.mnuNotaCreditoManual.Text = "Nota crédito";
			this.mnuNotaCreditoManual.Click += new System.EventHandler(this.MnuNotaCreditoManual_Click);
			// 
			// mnuAnulacion
			// 
			this.mnuAnulacion.Name = "mnuAnulacion";
			this.mnuAnulacion.Size = new System.Drawing.Size(237, 24);
			this.mnuAnulacion.Text = "Anulacion de documentos";
			this.mnuAnulacion.Click += new System.EventHandler(this.MnuAnulacion_Click);
			// 
			// mnuConsultaDocumentos
			// 
			this.mnuConsultaDocumentos.Name = "mnuConsultaDocumentos";
			this.mnuConsultaDocumentos.Size = new System.Drawing.Size(237, 24);
			this.mnuConsultaDocumentos.Text = "Consulta documentos";
			this.mnuConsultaDocumentos.Click += new System.EventHandler(this.MnuConsultaDocumentos_Click);
			// 
			// facturaciónElectrónicaToolStripMenuItem
			// 
			this.facturaciónElectrónicaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEnvioDocumentos,
            this.mnuEnvioResumen,
            this.mnuComunicacionBaja});
			this.facturaciónElectrónicaToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.facturaciónElectrónicaToolStripMenuItem.Name = "facturaciónElectrónicaToolStripMenuItem";
			this.facturaciónElectrónicaToolStripMenuItem.Size = new System.Drawing.Size(175, 23);
			this.facturaciónElectrónicaToolStripMenuItem.Text = "2. Facturación Electrónica";
			// 
			// mnuEnvioDocumentos
			// 
			this.mnuEnvioDocumentos.Name = "mnuEnvioDocumentos";
			this.mnuEnvioDocumentos.Size = new System.Drawing.Size(430, 24);
			this.mnuEnvioDocumentos.Text = "Envío de documentos (Facturas y NC asociados)";
			this.mnuEnvioDocumentos.Click += new System.EventHandler(this.EnvíoDeDocumentosToolStripMenuItem_Click);
			// 
			// mnuEnvioResumen
			// 
			this.mnuEnvioResumen.Name = "mnuEnvioResumen";
			this.mnuEnvioResumen.Size = new System.Drawing.Size(430, 24);
			this.mnuEnvioResumen.Text = "Resumenes diarios y anulaciones (Boletas y NC asociados)";
			this.mnuEnvioResumen.Click += new System.EventHandler(this.MnuEnvioResumen_Click);
			// 
			// mnuComunicacionBaja
			// 
			this.mnuComunicacionBaja.Name = "mnuComunicacionBaja";
			this.mnuComunicacionBaja.Size = new System.Drawing.Size(430, 24);
			this.mnuComunicacionBaja.Text = "Comunicaciones de baja (Facturas y NC asociados)";
			this.mnuComunicacionBaja.Click += new System.EventHandler(this.MnuComunicacionBaja_Click);
			// 
			// facturacionToolStripMenuItem
			// 
			this.facturacionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTipoDocumento,
            this.mnuSeries,
            this.mnuConfiguracion,
            this.mnuUsuario,
            this.mnuRoles,
            this.mnuProductos,
            this.mnuMediosPago});
			this.facturacionToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.facturacionToolStripMenuItem.Name = "facturacionToolStripMenuItem";
			this.facturacionToolStripMenuItem.Size = new System.Drawing.Size(136, 23);
			this.facturacionToolStripMenuItem.Text = "3. Mantenimientos";
			// 
			// mnuTipoDocumento
			// 
			this.mnuTipoDocumento.Name = "mnuTipoDocumento";
			this.mnuTipoDocumento.Size = new System.Drawing.Size(180, 24);
			this.mnuTipoDocumento.Text = "Tipo documento";
			this.mnuTipoDocumento.Click += new System.EventHandler(this.MnuTipoDocumento_Click);
			// 
			// mnuSeries
			// 
			this.mnuSeries.Name = "mnuSeries";
			this.mnuSeries.Size = new System.Drawing.Size(180, 24);
			this.mnuSeries.Text = "Series";
			this.mnuSeries.Click += new System.EventHandler(this.MnuSeries_Click);
			// 
			// mnuConfiguracion
			// 
			this.mnuConfiguracion.Name = "mnuConfiguracion";
			this.mnuConfiguracion.Size = new System.Drawing.Size(180, 24);
			this.mnuConfiguracion.Text = "Configuracion";
			this.mnuConfiguracion.Click += new System.EventHandler(this.MnuConfiguracion_Click);
			// 
			// mnuUsuario
			// 
			this.mnuUsuario.Name = "mnuUsuario";
			this.mnuUsuario.Size = new System.Drawing.Size(180, 24);
			this.mnuUsuario.Text = "Usuarios";
			this.mnuUsuario.Click += new System.EventHandler(this.MnuUsuario_Click);
			// 
			// mnuRoles
			// 
			this.mnuRoles.Name = "mnuRoles";
			this.mnuRoles.Size = new System.Drawing.Size(180, 24);
			this.mnuRoles.Text = "Roles";
			this.mnuRoles.Click += new System.EventHandler(this.MnuRoles_Click);
			// 
			// mnuProductos
			// 
			this.mnuProductos.Name = "mnuProductos";
			this.mnuProductos.Size = new System.Drawing.Size(180, 24);
			this.mnuProductos.Text = "Productos";
			this.mnuProductos.Click += new System.EventHandler(this.MnuProductos_Click);
			// 
			// reportesToolStripMenuItem
			// 
			this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuVentasDia,
            this.mnuVentas});
			this.reportesToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
			this.reportesToolStripMenuItem.Size = new System.Drawing.Size(90, 23);
			this.reportesToolStripMenuItem.Text = "4. Reportes";
			// 
			// mnuVentasDia
			// 
			this.mnuVentasDia.Name = "mnuVentasDia";
			this.mnuVentasDia.Size = new System.Drawing.Size(163, 24);
			this.mnuVentasDia.Text = "Ventas del día";
			this.mnuVentasDia.Click += new System.EventHandler(this.MnuVentasDia_Click);
			// 
			// mnuVentas
			// 
			this.mnuVentas.Name = "mnuVentas";
			this.mnuVentas.Size = new System.Drawing.Size(163, 24);
			this.mnuVentas.Text = "Ventas";
			this.mnuVentas.Click += new System.EventHandler(this.MnuVentas_Click);
			// 
			// mnuSalir
			// 
			this.mnuSalir.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.mnuSalir.Name = "mnuSalir";
			this.mnuSalir.Size = new System.Drawing.Size(46, 23);
			this.mnuSalir.Text = "Salir";
			this.mnuSalir.Click += new System.EventHandler(this.MnuSalir_Click);
			// 
			// stPrincipal
			// 
			this.stPrincipal.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.stPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssUser,
            this.toolStripStatusLabel1});
			this.stPrincipal.Location = new System.Drawing.Point(0, 421);
			this.stPrincipal.Name = "stPrincipal";
			this.stPrincipal.Size = new System.Drawing.Size(800, 29);
			this.stPrincipal.TabIndex = 3;
			this.stPrincipal.Text = "statusStrip1";
			// 
			// tssUser
			// 
			this.tssUser.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
			this.tssUser.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
			this.tssUser.Image = global::HVLH.SistemaCaja.AppWin.Properties.Resources.group;
			this.tssUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.tssUser.Name = "tssUser";
			this.tssUser.Size = new System.Drawing.Size(24, 24);
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(761, 24);
			this.toolStripStatusLabel1.Spring = true;
			// 
			// mnuMediosPago
			// 
			this.mnuMediosPago.Name = "mnuMediosPago";
			this.mnuMediosPago.Size = new System.Drawing.Size(180, 24);
			this.mnuMediosPago.Text = "Medios de Pago";
			this.mnuMediosPago.Click += new System.EventHandler(this.mediosDePagoToolStripMenuItem_Click);
			// 
			// FormPrincipal
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.stPrincipal);
			this.Controls.Add(this.mnuPrincipal);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.IsMdiContainer = true;
			this.MainMenuStrip = this.mnuPrincipal;
			this.Name = "FormPrincipal";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "FormPrincipal";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.FormPrincipal_Load);
			this.mnuPrincipal.ResumeLayout(false);
			this.mnuPrincipal.PerformLayout();
			this.stPrincipal.ResumeLayout(false);
			this.stPrincipal.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip mnuPrincipal;
		private System.Windows.Forms.ToolStripMenuItem mantenimientoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem facturacionToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem mnuTipoDocumento;
		private System.Windows.Forms.ToolStripMenuItem mnuSeries;
		private System.Windows.Forms.ToolStripMenuItem mnuConfiguracion;
		private System.Windows.Forms.ToolStripMenuItem facturaciónElectrónicaToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem mnuEnvioDocumentos;
		private System.Windows.Forms.ToolStripMenuItem mnuEnvioResumen;
		private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem mnuVentasDia;
		private System.Windows.Forms.ToolStripMenuItem mnuUsuario;
		private System.Windows.Forms.ToolStripMenuItem mnuRoles;
		private System.Windows.Forms.StatusStrip stPrincipal;
		private System.Windows.Forms.ToolStripStatusLabel tssUser;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.ToolStripMenuItem mnuVentas;
		private System.Windows.Forms.ToolStripMenuItem mnuAnulacion;
		private System.Windows.Forms.ToolStripMenuItem mnuVentasElectronico;
		private System.Windows.Forms.ToolStripMenuItem mnuFacturaElectronico;
		private System.Windows.Forms.ToolStripMenuItem mnuBoletaElectronico;
		private System.Windows.Forms.ToolStripMenuItem mnuNotaCreditoElectronico;
		private System.Windows.Forms.ToolStripMenuItem mnuVentasManual;
		private System.Windows.Forms.ToolStripMenuItem mnuFacturaManual;
		private System.Windows.Forms.ToolStripMenuItem mnuBoletaManual;
		private System.Windows.Forms.ToolStripMenuItem mnuNotaCreditoManual;
		private System.Windows.Forms.ToolStripMenuItem mnuComunicacionBaja;
		private System.Windows.Forms.ToolStripMenuItem mnuConsultaDocumentos;
		private System.Windows.Forms.ToolStripMenuItem mnuSalir;
		private System.Windows.Forms.ToolStripMenuItem mnuProductos;
		private System.Windows.Forms.ToolStripMenuItem mnuMediosPago;
	}
}