using HVLH.SistemaCaja.AppWin.Helpers;
using HVLH.SistemaCaja.AppWin.IoC;
using HVLH.SistemaCaja.AppWin.Validaciones;
using HVLH.SistemaCaja.Comun;
using HVLH.SistemaCaja.Servicio.Contratos;
using HVLH.SistemaCaja.Servicio.DTO;
using HVLH.SistemaCaja.Servicio.Impl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HVLH.SistemaCaja.AppWin.Mantenimiento
{
	public partial class FormMantMedioPago : FormBase
	{

		#region Variables
		private readonly IServicioTipoMedioPago _servicioTipoMedioPago;
		#endregion

		#region Propiedades

		public int Id { get; set; }

		private string Descripcion
		{
			get { return txtDescripcion.Text; }
			set { txtDescripcion.Text = value; }
		}

		private int FormaPago
		{
			get { return Convert.ToInt32(cboFormaPago.SelectedValue); }
			set { cboFormaPago.SelectedValue = value.ToString(); }
		}

		#endregion

		#region Constructor
		public FormMantMedioPago()
		{
			InitializeComponent();
			_servicioTipoMedioPago = InstanceFactory.GetInstance<IServicioTipoMedioPago>();

		}
		#endregion

		#region Metodos
		private async Task Guardar(ListarTipoMedioPagoDTO medioPago)
		{
			try
			{
				Loading.Mostrar();
				await _servicioTipoMedioPago.Insertar(medioPago);
				Loading.Cerrar();

				MostrarMensajes.Informacion(Constantes.MENSAJE_REGISTRO_EXITOSO);
			}
			catch (Exception ex)
			{
				Loading.Cerrar();
				MostrarMensajes.DetalleError(ex);
			}

		}

		private bool Validar(ListarTipoMedioPagoDTO medioPagoDto)
		{
			var ok = true;
			var validator = new InsertarMedioPagoValidator();
			var results = validator.Validate(medioPagoDto);
			var failures = results.Errors;

			if (!results.IsValid)
			{
				foreach (var failure in failures)
				{
					MostrarMensajes.Advertencia(failure.ErrorMessage);
					return false;
				}
			}

			return ok;
		}

		private async Task SetearDatos()
		{
			if (Id == 0) return;

			var medioPagoDto = await _servicioTipoMedioPago.Obtener(Id);

			Descripcion = medioPagoDto.Descripcion;
			FormaPago = medioPagoDto.FormaPago;
		}

		private ListarTipoMedioPagoDTO ObtenerDatos()
		{
			return new ListarTipoMedioPagoDTO
			{
				FormaPago = FormaPago,
				Descripcion = Descripcion,
				Id = Id
			};
		}

		private void Limpiar()
		{
			Descripcion = "";
			FormaPago = 1;
			Id = 0;
		}

		private void CargarFormaPago()
		{
			cboFormaPago.DisplayMember = "Text";
			cboFormaPago.ValueMember = "Value";

			var items = new[] {
				new { Text = "Contado", Value = "1" },
				new { Text = "Crédito", Value = "2" }
			};

			cboFormaPago.DataSource = items;
		}

		#endregion

		#region Eventos

		private async void FormMantMedioPago_Load(object sender, EventArgs e)
		{
			CargarFormaPago();
			await SetearDatos();
		}


		private async void btnGuardar_Click(object sender, EventArgs e)
		{
			var insertarMedioPago = ObtenerDatos();
			if (!Validar(insertarMedioPago)) return;
			await Guardar(insertarMedioPago);
			Limpiar();
		}

		private void btnSalir_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnLimpiar_Click(object sender, EventArgs e)
		{
			Limpiar();
		}
		#endregion

	}
}
