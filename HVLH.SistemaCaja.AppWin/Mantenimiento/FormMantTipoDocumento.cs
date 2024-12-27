using HVLH.SistemaCaja.AppWin.Helpers;
using HVLH.SistemaCaja.AppWin.IoC;
using HVLH.SistemaCaja.AppWin.Validaciones;
using HVLH.SistemaCaja.Comun;
using HVLH.SistemaCaja.Servicio.Contratos;
using HVLH.SistemaCaja.Servicio.DTO;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HVLH.SistemaCaja.AppWin.Mantenimiento
{
	public partial class FormMantTipoDocumento : FormBase
	{
		#region Variables
		private readonly IServicioTipoDocumento _servicioTipoDocumento;
		#endregion

		#region Propiedades

		public int Id { get; set; }
		private string Codigo
		{
			get { return txtCodigo.Text; }
			set { txtCodigo.Text = value; }
		}

		private string Descripcion
		{
			get { return txtDescripcion.Text; }
			set { txtDescripcion.Text = value; }
		}

		private string DescripcionCorta
		{
			get { return txtDescripcionCorta.Text; }
			set { txtDescripcionCorta.Text = value; }
		}
		#endregion

		#region Constructor
		public FormMantTipoDocumento()
		{
			InitializeComponent();
			_servicioTipoDocumento = InstanceFactory.GetInstance<IServicioTipoDocumento>();
		}
		#endregion

		#region Metodos
		private async Task Guardar(InsertarTipoDocumentoDTO tipoDocumento)
		{
			try
			{
				Loading.Mostrar();
				await _servicioTipoDocumento.Insertar(tipoDocumento);
				Loading.Cerrar();

				MostrarMensajes.Informacion(Constantes.MENSAJE_REGISTRO_EXITOSO);
			}
			catch (Exception ex)
			{
				Loading.Cerrar();
				MostrarMensajes.DetalleError(ex);
			}

		}

		private bool Validar(InsertarTipoDocumentoDTO insertarTipoDocumentoDTO)
		{
			var ok = true;
			var validator = new InsertarTipoDocumentoValidator();
			var results = validator.Validate(insertarTipoDocumentoDTO);
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

			var obtenerTipoDocumentoDTO = await _servicioTipoDocumento.Obtener(Id);

			Codigo = obtenerTipoDocumentoDTO.Codigo;
			Descripcion = obtenerTipoDocumentoDTO.Descripcion;
			DescripcionCorta = obtenerTipoDocumentoDTO.DescripcionCorta;
			txtCodigo.Enabled = false;
		}

		private InsertarTipoDocumentoDTO ObtenerDatos()
		{
			return new InsertarTipoDocumentoDTO
			{
				Codigo = Codigo,
				Descripcion = Descripcion,
				DescripcionCorta = DescripcionCorta,
				Id = Id,
				Usuario = AppInfo.Usuario
			};
		}

		private void Limpiar()
		{
			Codigo = "";
			Descripcion = "";
			DescripcionCorta = "";
			Id = 0;
			txtCodigo.Enabled = true;
		}

	
		#endregion

		#region Eventos
		private async void FormMantTipoDocumento_Load(object sender, EventArgs e)
		{
			await SetearDatos();
		}

		private async void btnGuardar_Click(object sender, EventArgs e)
		{
			var insertarTipoDocumento = ObtenerDatos();
			if (!Validar(insertarTipoDocumento)) return;
			await Guardar(insertarTipoDocumento);
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
