using Autofac.Core;
using HVLH.Facturacion.Comun.Datos.Intercambio;
using HVLH.Facturacion.Comun.Datos.Modelos;
using HVLH.SistemaCaja.AppWin.Helpers;
using HVLH.SistemaCaja.AppWin.IoC;
using HVLH.SistemaCaja.Comun;
using HVLH.SistemaCaja.Servicio.Contratos;
using HVLH.SistemaCaja.Servicio.DTO;
using HVLH.SistemaCaja.Servicio.Impl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HVLH.SistemaCaja.AppWin.Facturacion
{
	public partial class FormComunicacionBaja : FormBase
	{
		#region . Variables .
		private readonly IServicioComunicacionBaja _servicioComunicacionBaja;
		#endregion

		#region . Propiedades .
		private DateTime FechaInicio
		{
			get { return txtFechaDel.Value.Date; }
			set { txtFechaDel.Value = value; }

		}

		private DateTime FechaFin
		{
			get { return txtFechaAl.Value.Date; }
			set { txtFechaAl.Value = value; }

		}

		#endregion

		#region . Constructor .
		public FormComunicacionBaja()
		{
			InitializeComponent();
			_servicioComunicacionBaja = InstanceFactory.GetInstance<IServicioComunicacionBaja>();
		}
		#endregion

		#region . Metodos .
		private async Task LLenarGrilla()
		{
			try
			{

				var resumenes = await ListarBajas();

				if (resumenes == null) return;

				dgvBajas.Rows.Clear();

				foreach (var item in resumenes)
				{
					dgvBajas.Rows.Add(item.Id, $"{item.Numero}-{item.Correlativo}", item.FechaBaja, item.FechaDocumentos, item.Ticket, item.Estado.ToString());
				}
			}
			catch (Exception ex)
			{
				MostrarMensajes.DetalleError(ex);
			}

		}

		private async Task<List<ListarComunicacionBajaDTO>> ListarBajas()
		{
			try
			{

				Loading.Mostrar();
				var resumenes = await _servicioComunicacionBaja.ListarComunicaciones(FechaInicio, FechaFin);
				Loading.Cerrar();

				return resumenes;
			}
			catch (Exception ex)
			{

				MostrarMensajes.DetalleError(ex);
				Loading.Cerrar();
			}

			return null;

		}

		#endregion

		#region . Eventos .
		private async void FormEnvioDocumentos_Load(object sender, EventArgs e)
		{
			await LLenarGrilla();
		}

		private async void BtnEnviar_Click(object sender, EventArgs e)
		{
			var form = new FormEnvioComunicacionesBaja();
			form.IdComunicacion = 0;
			form.ShowDialog();
			await LLenarGrilla();
		}

		private void BtnSalir_Click(object sender, EventArgs e)
		{
			Close();
		}

		private async void BtnBuscar_Click(object sender, EventArgs e)
		{
			await LLenarGrilla();
		}

		private async void BtnEditar_Click(object sender, EventArgs e)
		{
			if (dgvBajas.CurrentRow == null)
			{
				MostrarMensajes.Advertencia(Constantes.MENSAJE_SELECCIONAR_REGISTRO);
				return;
			}

			int id = Convert.ToInt32(dgvBajas.CurrentRow.Cells["ColId"].Value);

			var form = new FormEnvioComunicacionesBaja();
			form.IdComunicacion = id;
			form.ShowDialog();
			await LLenarGrilla();

		}
		#endregion


	}
}
