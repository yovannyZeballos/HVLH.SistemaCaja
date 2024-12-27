using HVLH.SistemaCaja.AppWin.Helpers;
using HVLH.SistemaCaja.AppWin.IoC;
using HVLH.SistemaCaja.Comun;
using HVLH.SistemaCaja.Servicio.Contratos;
using HVLH.SistemaCaja.Servicio.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HVLH.SistemaCaja.AppWin.Facturacion
{
	public partial class FormEnvioResumenes : FormBase
	{
		#region . Variables .
		private readonly IServicioResumen _servicioResumen;
		private readonly IServicioEnvioDocumento _servicioEnvioDocumento;
		#endregion

		#region . Propiedades .
		public int IdResumen { private get; set; }

		private string NroResumen
		{
			get { return txtNroResumen.Text; }
			set { txtNroResumen.Text = value; }
		}

		private string Ticket
		{
			get { return txtNroTicket.Text; }
			set { txtNroTicket.Text = value; }
		}

		private string Respuesta
		{
			get { return txtRespuesta.Text; }
			set { txtRespuesta.Text = value; }
		}

		private DateTime Fecha
		{
			get { return txtFecha.Value; }
			set { txtFecha.Value = value; }
		}

		private DateTime FechaDocumentos
		{
			get { return txtFechaDocumentos.Value; }
			set { txtFechaDocumentos.Value = value; }
		}

		private string Estado
		{
			get { return txtEstado.Text; }
			set { txtEstado.Text = value; }
		}
		#endregion

		#region . Constructor .
		public FormEnvioResumenes()
		{
			InitializeComponent();
			_servicioResumen = InstanceFactory.GetInstance<IServicioResumen>();
			_servicioEnvioDocumento = InstanceFactory.GetInstance<IServicioEnvioDocumento>();
		}
		#endregion

		#region . Metodos .
		private async Task ObtenerDatos()
		{
			try
			{
				Loading.Mostrar();
				var resumen = await _servicioResumen.ObtenerResumen(IdResumen);
				NroResumen = $"{resumen.Numero}-{resumen.Correlativo}";
				Ticket = resumen.Ticket;
				Respuesta = resumen.Respuesta;
				FechaDocumentos = resumen.FechaDocumentos;
				Fecha = resumen.FechaResumen;
				Estado = resumen.Estado.ToString();

				dgvDocumentos.Rows.Clear();
				foreach (var item in resumen.Detalles)
				{
					dgvDocumentos.Rows.Add(item.IdDocumento, item.EstadoResumenDetalle.ToString(), item.TipoDocumento, $"{item.Serie}-{item.Numero}", item.Fecha,
						$"{item.NumeroDocumentoCliente} - {item.RazonSocialCliente}", item.Moneda, item.MontoTotal);
				}

				if (resumen.Estado == Comun.EstadoResumen.Aceptado || resumen.Estado == Comun.EstadoResumen.Rechazado)
				{
					btnGuardar.Enabled = false;
					btnEnviar.Enabled = false;
					btnAgregar.Enabled = false;
					btnEliminar.Enabled = false;
					btnConsultar.Enabled = false;
					txtFecha.Enabled = false;
					txtFechaDocumentos.Enabled = false;
				}

				if (resumen.Estado == Comun.EstadoResumen.Enviado)
				{
					btnGuardar.Enabled = false;
					btnEnviar.Enabled = false;
					btnAgregar.Enabled = false;
					btnEliminar.Enabled = false;
					btnConsultar.Enabled = true;
					txtFecha.Enabled = false;
					txtFechaDocumentos.Enabled = false;
				}

				if (resumen.Estado == Comun.EstadoResumen.Generado)
				{
					btnGuardar.Enabled = true;
					btnEnviar.Enabled = true;
					btnAgregar.Enabled = true;
					btnEliminar.Enabled = true;
					btnConsultar.Enabled = false;
					txtFecha.Enabled = true;
					txtFechaDocumentos.Enabled = true;
				}
			}
			catch (Exception ex)
			{
				MostrarMensajes.DetalleError(ex);
			}
			finally
			{
				Loading.Cerrar();
			}

		}


		private async Task Guardar()
		{
			try
			{
				if (!ValidarGuardar()) return;

				Loading.Mostrar();
				var detalles = dgvDocumentos.Rows
					.Cast<DataGridViewRow>()
					.Select(x => new GuardarResumenDetalleDTO
					{
						IdDocumento = Convert.ToInt32(x.Cells["ColId"].Value),
						Estado = (EstadoResumenDetalle)Enum.Parse(typeof(EstadoResumenDetalle), x.Cells["ColEstado"].Value.ToString())
					}).ToList();

				(IdResumen, NroResumen) = await _servicioResumen.GuardarResumen(new GuardarResumenDTO
				{
					FechaResumen = Fecha,
					FechaDocumentos = FechaDocumentos,
					Numero = NroResumen,
					Respuesta = Respuesta,
					Ticket = Ticket,
					UsuarioCreacion = AppInfo.Usuario,
					Detalles = detalles,
					Id = IdResumen
				});

				MostrarMensajes.Informacion(Constantes.MENSAJE_REGISTRO_EXITOSO);

				btnGuardar.Enabled = true;
				btnEnviar.Enabled = true;
				btnAgregar.Enabled = true;
				btnEliminar.Enabled = true;
				btnConsultar.Enabled = false;
				txtFecha.Enabled = false;
				txtFechaDocumentos.Enabled = false;
				Estado = EstadoResumen.Generado.ToString();

			}
			catch (Exception ex)
			{
				MostrarMensajes.DetalleError(ex);
			}
			finally
			{
				Loading.Cerrar();
			}
		}


		private bool ValidarGuardar()
		{
			bool ok = true;
			var mensajes = new StringBuilder();

			if (dgvDocumentos.Rows.Count == 0)
			{
				ok = false;
				mensajes.AppendLine("Debe ingresar los documentos a informar");
			}

			if (Fecha.Date > DateTime.Now)
			{
				ok = false;
				mensajes.AppendLine("La fecha del resumen no debe ser mayor al día de hoy");
			}

			if (FechaDocumentos.Date > Fecha.Date)
			{
				ok = false;
				mensajes.AppendLine("La fecha de los documentos no debe ser mayor a la fecha de resumen");
			}

			if (!ok)
				MostrarMensajes.Advertencia(mensajes.ToString());

			return ok;

		}
		#endregion

		#region . Eventos .
		private async void FormEnvioResumenes_Load(object sender, EventArgs e)
		{
			if (IdResumen > 0)
			{
				await ObtenerDatos();
				Text = $"RESUMEN DE BOLETAS N° {NroResumen}";
			}
		}

		private async void BtnGuardar_Click(object sender, EventArgs e)
		{
			await Guardar();
		}

		private void BtnAgregar_Click(object sender, EventArgs e)
		{
			var form = new FormListadoDocumentosResumen();
			form.Fecha = FechaDocumentos;
			form.Id = IdResumen;
			form.ShowDialog();

			var documentosSeleccionados = form.DocumentosSeleccionados;

			if (documentosSeleccionados == null) return;

			foreach (var item in documentosSeleccionados)
			{
				dgvDocumentos.Rows.Add(item.Id, item.Estado == "5" ? EstadoResumenDetalle.Anular.ToString() : EstadoResumenDetalle.Adicionar.ToString(),
					item.TipoDocumento, $"{item.Serie}-{item.Numero}", item.Fecha, $"{item.NumeroDocumentoCliente} - {item.RazonSocialCliente}",
					item.Moneda, item.MontoTotal);
			}
		}

		private async void BtnEnviar_Click(object sender, EventArgs e)
		{
			try
			{
				Loading.Mostrar();
				var response = await _servicioEnvioDocumento.EnviarResumen(new EnvioResumenDocumentoDTO
				{
					IdResumen = IdResumen,
					NumeroResumen = NroResumen,
					TipoResumen = "RC",
					Usuario = AppInfo.Usuario
				});
				Loading.Cerrar();


				if (!response.Exito)
				{
					MostrarMensajes.Advertencia(response.MensajeError);
					Respuesta = response.MensajeError;
					Estado = EstadoResumen.Rechazado.ToString();
					btnGuardar.Enabled = false;
					btnEnviar.Enabled = false;
					btnAgregar.Enabled = false;
					btnEliminar.Enabled = false;
					btnConsultar.Enabled = false;
					txtFecha.Enabled = false;
					txtFechaDocumentos.Enabled = false;
					return;
				}

				MostrarMensajes.Informacion($"Número de Ticket: {response.NroTicket}");
				Ticket = response.NroTicket;
				Estado = EstadoResumen.Enviado.ToString();
				Respuesta = "";


				btnGuardar.Enabled = false;
				btnEnviar.Enabled = false;
				btnAgregar.Enabled = false;
				btnEliminar.Enabled = false;
				btnConsultar.Enabled = true;
				txtFecha.Enabled = false;
				txtFechaDocumentos.Enabled = false;

			}
			catch (Exception ex)
			{
				MostrarMensajes.DetalleError(ex);
			}
			finally
			{
				Loading.Cerrar();
			}

		}

		private async void BtnConsultar_Click(object sender, EventArgs e)
		{
			try
			{
				Loading.Mostrar();
				var response = await _servicioEnvioDocumento.ConsultarTicketResumen(new ConsultarTicketDTO
				{
					Id = IdResumen,
					Numero = NroResumen,
					Ticket = Ticket,
					Tipo = "RC",
					Usuario = AppInfo.Usuario
				});
				Loading.Cerrar();

				if (!response.Exito)
				{
					MostrarMensajes.Advertencia(response.MensajeError);
					Respuesta = response.MensajeError;
					Estado = EstadoResumen.Rechazado.ToString();
					return;
				}

				Respuesta = response.MensajeRespuesta;
				Estado = EstadoResumen.Aceptado.ToString();

				MostrarMensajes.Informacion(Respuesta);


				btnGuardar.Enabled = false;
				btnEnviar.Enabled = false;
				btnAgregar.Enabled = false;
				btnEliminar.Enabled = false;
				btnConsultar.Enabled = false;
				txtFecha.Enabled = false;
				txtFechaDocumentos.Enabled = false;

			}
			catch (Exception ex)
			{
				MostrarMensajes.DetalleError(ex);
			}
			finally { Loading.Cerrar(); }
		}

		private void BtnSalir_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void BtnEliminar_Click(object sender, EventArgs e)
		{
			var currentRow = dgvDocumentos.CurrentRow;
			if (currentRow == null)
			{
				MostrarMensajes.Advertencia(Constantes.MENSAJE_SELECCIONAR_REGISTRO);
				return;
			}

			if (MostrarMensajes.Pregunta(Constantes.MENSAJE_PREGUNTA_ELIMINACION) == DialogResult.Cancel)
				return;

			dgvDocumentos.Rows.Remove(currentRow);
		}
		#endregion


	}
}
