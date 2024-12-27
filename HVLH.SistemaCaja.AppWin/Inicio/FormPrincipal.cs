using HVLH.SistemaCaja.AppWin.Facturacion;
using HVLH.SistemaCaja.AppWin.Helpers;
using HVLH.SistemaCaja.AppWin.Mantenimiento;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HVLH.SistemaCaja.AppWin.Inicio
{
	public partial class FormPrincipal : Form
	{
		public FormPrincipal()
		{
			InitializeComponent();
		}

		private void MnuFacturaElectronico_Click(object sender, EventArgs e)
		{
			var form = new FormFacturacion();
			form.Text = "Nueva Factura Electrónica";
			form.MdiParent = this;
			form.StartPosition = FormStartPosition.CenterParent;
			form.TipoDocumento = Comun.TipoDocumento.Factura;
			form.TipoSerie = Comun.TipoSerie.Electronico;
			form.Show();
		}

		private void FormPrincipal_Load(object sender, EventArgs e)
		{
			Text = "SISTEMA DE CAJAS";
			tssUser.Text = $"{AppInfo.Usuario} - {AppInfo.Nombres}";
			HabilitarMenu();
			mnuSalir.Enabled = true;
		}

		private void MnuBoletaElectronica_Click(object sender, EventArgs e)
		{
			var form = new FormFacturacion();
			form.Text = "Nueva Boleta de venta Electrónica";
			form.MdiParent = this;
			form.StartPosition = FormStartPosition.CenterParent;
			form.TipoDocumento = Comun.TipoDocumento.Boleta;
			form.TipoSerie = Comun.TipoSerie.Electronico;
			form.Show();
		}

		private void MnuSeries_Click(object sender, EventArgs e)
		{

			var form = new FormTipoDocumentoSerie();
			form.MdiParent = this;
			form.StartPosition = FormStartPosition.CenterParent;
			form.Show();
		}

		private void EnvíoDeDocumentosToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var form = new FormEnvioDocumentos();
			form.MdiParent = this;
			form.StartPosition = FormStartPosition.CenterParent;
			form.Show();
		}

		private void MnuNotaCreditoElectronica_Click(object sender, EventArgs e)
		{
			var form = new FormFacturacion();
			form.Text = "Nueva Nota de crédito Electrónica";
			form.MdiParent = this;
			form.StartPosition = FormStartPosition.CenterParent;
			form.TipoDocumento = Comun.TipoDocumento.Nota_de_Credito;
			form.TipoSerie = Comun.TipoSerie.Electronico;
			form.Show();
		}

		private void MnuVentasDia_Click(object sender, EventArgs e)
		{
			var form = new FormReporteVentas();
			form.MdiParent = this;
			form.Text = $"Ventas del día {DateTime.Now:dd/MM/yyyy}";
			form.PorCajero = true;
			form.txtFechaDel.Value = DateTime.Now;
			form.txtFechaAl.Value = DateTime.Now;
			form.StartPosition = FormStartPosition.CenterParent;
			form.Show();
		}

		private void MnuUsuario_Click(object sender, EventArgs e)
		{
			var form = new FormUsuario();
			form.Text = "Listado de usuarios";
			form.MdiParent = this;
			form.Show();
		}

		private void MnuTipoDocumento_Click(object sender, EventArgs e)
		{
			var form = new FormTipoDocumento();
			form.Text = "Tipo de documentos";
			form.MdiParent = this;
			form.StartPosition = FormStartPosition.CenterParent;
			form.Show();
		}

		private void MnuRoles_Click(object sender, EventArgs e)
		{
			var form = new FormRol();
			form.Text = "Roles";
			form.MdiParent = this;
			form.Show();
		}

		private void MnuVentas_Click(object sender, EventArgs e)
		{
			var form = new FormReporteVentas();
			form.MdiParent = this;
			form.Text = $"Reporte de ventas";
			form.PorCajero = false;
			form.txtFechaDel.Value = DateTime.Now;
			form.txtFechaAl.Value = DateTime.Now;
			form.StartPosition = FormStartPosition.CenterParent;
			form.Show();
		}

		private void HabilitarMenu()
		{
			foreach (ToolStripMenuItem menuItem in mnuPrincipal.Items)
			{
				object tag = menuItem.Tag;

				if (menuItem.HasDropDownItems)
					HabilitarSubMenu(menuItem);
				else
					menuItem.Enabled = ValidarMenu(menuItem.Name);
			}
		}

		private void HabilitarSubMenu(ToolStripMenuItem menuItem)
		{
			foreach (ToolStripMenuItem dropDownItem in menuItem.DropDownItems.OfType<ToolStripMenuItem>())
			{
				object tag = dropDownItem.Tag;

				if (dropDownItem.HasDropDownItems)
					HabilitarSubMenu(dropDownItem);
				else
					dropDownItem.Enabled = ValidarMenu(dropDownItem.Name);
			}

		}

		private bool ValidarMenu(string menuName)
		{
			return AppInfo.Menus.Any(x => x.Nombre == menuName);
		}

		private void MnuAnulacion_Click(object sender, EventArgs e)
		{
			var form = new FormAnulacionDocumento();
			form.MdiParent = this;
			form.PorCajero = true;
			form.txtFechaDel.Value = DateTime.Now;
			form.txtFechaAl.Value = DateTime.Now;
			form.StartPosition = FormStartPosition.CenterParent;
			form.Show();
		}

		private void MnuFacturaManual_Click(object sender, EventArgs e)
		{
			var form = new FormFacturacion();
			form.Text = "Nueva Factura Manual";
			form.MdiParent = this;
			form.StartPosition = FormStartPosition.CenterParent;
			form.TipoDocumento = Comun.TipoDocumento.Factura;
			form.TipoSerie = Comun.TipoSerie.Manual;
			form.Show();
		}

		private void MnuBoletaManual_Click(object sender, EventArgs e)
		{
			var form = new FormFacturacion();
			form.Text = "Nueva Boleta de venta Manual";
			form.MdiParent = this;
			form.StartPosition = FormStartPosition.CenterParent;
			form.TipoDocumento = Comun.TipoDocumento.Boleta;
			form.TipoSerie = Comun.TipoSerie.Manual;
			form.Show();
		}

		private void MnuNotaCreditoManual_Click(object sender, EventArgs e)
		{
			var form = new FormFacturacion();
			form.Text = "Nueva Nota de crédito Manual";
			form.MdiParent = this;
			form.StartPosition = FormStartPosition.CenterParent;
			form.TipoDocumento = Comun.TipoDocumento.Nota_de_Credito;
			form.TipoSerie = Comun.TipoSerie.Manual;
			form.Show();
		}

		private void MnuEnvioResumen_Click(object sender, EventArgs e)
		{
			var form = new FormResumenes();
			form.Text = "Resumenes de boletas de venta y NC asociadas";
			form.MdiParent = this;
			form.StartPosition = FormStartPosition.CenterParent;
			form.Show();
		}

		private void MnuComunicacionBaja_Click(object sender, EventArgs e)
		{
			var form = new FormComunicacionBaja();
			form.Text = "Comunicaciones de baja";
			form.MdiParent = this;
			form.StartPosition = FormStartPosition.CenterParent;
			form.Show();
		}

		private void MnuSalir_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void MnuConsultaDocumentos_Click(object sender, EventArgs e)
		{
			var form = new FormConsultaDocumentos();
			form.MdiParent = this;
			form.StartPosition = FormStartPosition.CenterParent;
			form.Show();
		}

		private void MnuProductos_Click(object sender, EventArgs e)
		{
			var form = new FormProductos();
			form.MdiParent = this;
			form.StartPosition = FormStartPosition.CenterParent;
			form.Show();
		}

		private void MnuConfiguracion_Click(object sender, EventArgs e)
		{
			var form = new FormConfiguracion();
			form.MdiParent = this;
			form.StartPosition = FormStartPosition.CenterParent;
			form.Show();
		}

		private void mediosDePagoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var form = new FormMedioPago
			{
				MdiParent = this,
				StartPosition = FormStartPosition.CenterParent
			};
			form.Show();
		}
	}
}
