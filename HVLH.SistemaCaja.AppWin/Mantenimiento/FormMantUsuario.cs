using HVLH.SistemaCaja.AppWin.Helpers;
using HVLH.SistemaCaja.AppWin.IoC;
using HVLH.SistemaCaja.AppWin.Validaciones;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace HVLH.SistemaCaja.AppWin.Mantenimiento
{
	public partial class FormMantUsuario : FormBase
	{

		#region Variables
		private readonly IServicioUsuario _servicioUsuario;
		private readonly IServicioDocumento _servicioDocumento;
		#endregion

		#region Propiedades

		public int Id { get; set; }
		private string Login
		{
			get { return txtLogin.Text; }
			set { txtLogin.Text = value; }
		}

		private string Nombres
		{
			get { return txtNombres.Text; }
			set { txtNombres.Text = value; }
		}

		private string Clave
		{
			get { return txtClave.Text; }
			set { txtClave.Text = value; }
		}

		private bool Cajero
		{
			get { return chkCajero.Checked; }
			set { chkCajero.Checked = value; }
		}

		private Estado Estado
		{
			get { return (Estado)Enum.Parse(typeof(Estado), cboEstado.SelectedValue.ToString()); }
			set { cboEstado.SelectedItem = value; }
		}
		#endregion

		#region Constructor
		public FormMantUsuario()
		{
			InitializeComponent();
			_servicioUsuario = InstanceFactory.GetInstance<IServicioUsuario>();
			_servicioDocumento = InstanceFactory.GetInstance<IServicioDocumento>();
		}
		#endregion

		#region Metodos
		private async Task Guardar(CrearUsuarioDTO usuario)
		{
			try
			{
				Loading.Mostrar();
				await _servicioUsuario.Crear(usuario);
				Loading.Cerrar();

				MostrarMensajes.Informacion(Constantes.MENSAJE_REGISTRO_EXITOSO);
			}
			catch (Exception ex)
			{
				Loading.Cerrar();
				MostrarMensajes.DetalleError(ex);
			}

		}

		private async Task Actualizar(ActualizarUsuarioDTO usuario)
		{
			try
			{
				Loading.Mostrar();
				await _servicioUsuario.Actualizar(usuario);
				Loading.Cerrar();

				MostrarMensajes.Informacion(Constantes.MENSAJE_REGISTRO_EXITOSO);
			}
			catch (Exception ex)
			{
				Loading.Cerrar();
				MostrarMensajes.DetalleError(ex);
			}

		}

		private bool ValidarCrear(CrearUsuarioDTO usuario)
		{
			var ok = true;
			var validator = new CrearUsuarioValidator();
			var results = validator.Validate(usuario);
			var failures = results.Errors;
			var mensajes = new StringBuilder();

			if (!results.IsValid)
			{
				foreach (var failure in failures)
				{
					mensajes.AppendLine(failure.ErrorMessage);
					ok = false;
				}
			}

			if (!ok)
				MostrarMensajes.Advertencia(mensajes.ToString());

			return ok;
		}

		private bool ValidarActualizar(ActualizarUsuarioDTO usuario)
		{
			var ok = true;
			var validator = new ActualizarUsuarioValidator();
			var results = validator.Validate(usuario);
			var failures = results.Errors;
			var mensajes = new StringBuilder();

			if (!results.IsValid)
			{
				foreach (var failure in failures)
				{
					mensajes.AppendLine(failure.ErrorMessage);
					ok = false;
				}
			}

			if (!ok)
				MostrarMensajes.Advertencia(mensajes.ToString());

			return ok;
		}

		private async Task SetearDatos()
		{
			if (Id == 0) return;

			var usuario = await _servicioUsuario.Obtener(Id);

			Login = usuario.Login;
			Nombres = usuario.Nombres;
			Cajero = usuario.EsCajero;
			Estado = usuario.Estado;
			BloquearControlesEditar();
		}

		private async void BloquearControlesEditar()
		{
			txtClave.Enabled = false;
			cboEstado.Enabled = true;
			txtLogin.Enabled = false;
			chkCajero.Enabled = !(await _servicioDocumento.ExisteDocumentoUsuario(Login));
		}

		private CrearUsuarioDTO ObtenerDatosCrear()
		{
			return new CrearUsuarioDTO
			{
				Nombres = Nombres,
				Login = Login,
				EsCajero = Cajero,
				Usuario = AppInfo.Usuario,
				Clave = Clave
			};
		}

		private ActualizarUsuarioDTO ObtenerDatosActualizar()
		{
			return new ActualizarUsuarioDTO
			{
				Nombres = Nombres,
				EsCajero = Cajero,
				Usuario = AppInfo.Usuario,
				Estado = Estado,
				Id = Id
			};
		}

		private void Limpiar()
		{
			Login = "";
			Nombres = "";
			Estado = Estado.Activo;
			Id = 0;
			txtClave.Enabled = true;
			cboEstado.Enabled = false;
			chkCajero.Checked = false;
			txtLogin.Enabled = true;
			chkCajero.Enabled = true;
		}

		private void CargarEstados()
		{
			cboEstado.DisplayMember = "Value";
			cboEstado.ValueMember = "Key";
			cboEstado.DataSource = Enum.GetValues(typeof(Estado));

		}
		#endregion

		#region Eventos
		private async void FormMantUsuario_Load(object sender, EventArgs e)
		{
			CargarEstados();
			await SetearDatos();
		}

		private async void BtnGuardar_Click(object sender, EventArgs e)
		{
			if (Id == 0)
			{
				var usuario = ObtenerDatosCrear();
				if (!ValidarCrear(usuario)) return;
				await Guardar(usuario);
			}
			else
			{
				var usuario = ObtenerDatosActualizar();
				if (!ValidarActualizar(usuario)) return;
				await Actualizar(usuario);
			}

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
