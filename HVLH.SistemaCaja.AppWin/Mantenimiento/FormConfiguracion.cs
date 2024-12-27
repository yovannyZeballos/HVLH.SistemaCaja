using HVLH.Facturacion.Comun.Datos.Modelos;
using HVLH.SistemaCaja.AppWin.Helpers;
using HVLH.SistemaCaja.AppWin.IoC;
using HVLH.SistemaCaja.Comun;
using HVLH.SistemaCaja.Servicio.Contratos;
using HVLH.SistemaCaja.Servicio.DTO;
using HVLH.SistemaCaja.Servicio.Impl;
using System;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.AppWin.Mantenimiento
{
	public partial class FormConfiguracion : FormBase
	{
		#region . Variables .
		private readonly IServicioConfiguracion _servicioConfiguracion;
		private readonly IServicioTipoOperacion _servicioTipoOperacion;

		private int _id;
		#endregion

		#region . Propiedades .
		private string Ruc
		{
			get { return txtRuc.Text; }
			set { txtRuc.Text = value; }
		}

		private string RazonSocial
		{
			get { return txtRazonSocial.Text; }
			set { txtRazonSocial.Text = value; }
		}

		private string Direccion
		{
			get { return txtDireccion.Text; }
			set { txtDireccion.Text = value; }
		}

		private string Departamento
		{
			get { return txtDepartamento.Text; }
			set { txtDepartamento.Text = value; }
		}

		private string Provincia
		{
			get { return txtProvincia.Text; }
			set { txtProvincia.Text = value; }
		}

		private string Distrito
		{
			get { return txtDistrito.Text; }
			set { txtDistrito.Text = value; }
		}

		private string Ubigeo
		{
			get { return txtUbigeo.Text; }
			set { txtUbigeo.Text = value; }
		}

		private string Telefono
		{
			get { return txtTelefono.Text; }
			set { txtTelefono.Text = value; }
		}

		private decimal Igv
		{
			get { return txtIgv.Value; }
			set { txtIgv.Value = value; }
		}

		private string TipoOperacion
		{
			get { return cboTipoOperacion.SelectedValue.ToString(); }
			set { cboTipoOperacion.SelectedValue = value; }
		}

		private string UsuarioSol
		{
			get { return txtUsuarioSol.Text; }
			set { txtUsuarioSol.Text = value; }
		}

		private string ClaveSol
		{
			get { return txtClaveSol.Text; }
			set { txtClaveSol.Text = value; }
		}

		private string ClaveCertificado
		{
			get { return txtClaveCertificado.Text; }
			set { txtClaveCertificado.Text = value; }
		}

		private string RutaCertificado
		{
			get { return txtRutaCertificado.Text; }
			set { txtRutaCertificado.Text = value; }
		}

		private string RutaCarpeta
		{
			get { return txtCarpetaDocumentos.Text; }
			set { txtCarpetaDocumentos.Text = value; }
		}

		private string UrlEnvio
		{
			get { return txtUrlEnvio.Text; }
			set { txtUrlEnvio.Text = value; }
		}

		private string UrlConsulta
		{
			get { return txtUrlConsulta.Text; }
			set { txtUrlConsulta.Text = value; }
		}

		private string Correo
		{
			get { return txtCorreo.Text; }
			set { txtCorreo.Text = value; }
		}

		private string ClaveCorreo
		{
			get { return txtClaveCorreo.Text; }
			set { txtClaveCorreo.Text = value; }
		}

		private int Puerto
		{
			get { return Convert.ToInt32(txtPuerto.Value); }
			set { txtPuerto.Value = value; }
		}

		private string Smtp
		{
			get { return txtSmtp.Text; }
			set { txtSmtp.Text = value; }
		}
		#endregion

		#region . Constructor .
		public FormConfiguracion()
		{
			InitializeComponent();
			_servicioConfiguracion = InstanceFactory.GetInstance<IServicioConfiguracion>();
			_servicioTipoOperacion = InstanceFactory.GetInstance<IServicioTipoOperacion>();
		}
		#endregion

		#region . Metodos .
		private async Task ObtenerDatos()
		{
			try
			{
				var configuracion = await _servicioConfiguracion.Obtener();
				if (configuracion == null) return;

				Ruc = configuracion.Ruc;
				RazonSocial = configuracion.RazonSocial;
				Direccion = configuracion.Direccion;
				Departamento = configuracion.Departamento;
				Provincia = configuracion.Provincia;
				Distrito = configuracion.Distrito;
				Ubigeo = configuracion.Ubigeo;
				Telefono = configuracion.Telefono;
				Igv = configuracion.IGV;
				TipoOperacion = configuracion.TipoOperacion;
				UsuarioSol = configuracion.UsuarioSol;
				ClaveSol = configuracion.ClaveSol;
				ClaveCertificado = configuracion.ClaveCertificado;
				RutaCertificado = configuracion.RutaCertificado;
				RutaCarpeta = configuracion.CarpetaDocumentos;
				UrlEnvio = configuracion.UrlEnvio;
				UrlConsulta = configuracion.UrlConsulta;
				Correo = configuracion.Correo;
				ClaveCorreo = configuracion.ClaveCorreo;
				Puerto = configuracion.Puerto.Value;
				Smtp = configuracion.Smtp;
				_id = configuracion.Id;
			}
			catch (Exception ex) { MostrarMensajes.DetalleError(ex); }

		}

		private async Task ListarTipoOperacion()
		{
			try
			{
				var tipoOperacion = await _servicioTipoOperacion.Listar();
				cboTipoOperacion.DisplayMember = "Descripcion";
				cboTipoOperacion.ValueMember = "Codigo";
				cboTipoOperacion.DataSource = tipoOperacion;
			}
			catch (Exception ex)
			{
				MostrarMensajes.DetalleError(ex);
			}

		}
		#endregion

		#region . Eventos .
		private async void FormConfiguracion_Load(object sender, EventArgs e)
		{
			await ListarTipoOperacion();
			await ObtenerDatos();
		}


		#endregion

		private async void BtnGuardar_Click(object sender, EventArgs e)
		{
			try
			{
				await _servicioConfiguracion.Guardar(new GuardarConfiguracionDTO
				{
					Smtp = Smtp,
					Puerto = Puerto,
					ClaveCorreo = ClaveCorreo,
					UrlEnvio = UrlEnvio,
					UrlConsulta = UrlConsulta,
					Correo = Correo,
					CarpetaDocumentos = RutaCarpeta,
					ClaveCertificado = ClaveCertificado,
					ClaveSol = ClaveSol,
					Departamento = Departamento,
					Direccion = Direccion,
					Distrito = Distrito,
					IGV = Igv,
					Provincia = Provincia,
					RazonSocial = RazonSocial,
					Ruc = Ruc,
					RutaCertificado = RutaCertificado,
					Telefono = Telefono,
					TipoOperacion = TipoOperacion,
					Ubigeo = Ubigeo,
					Usuario = AppInfo.Usuario,
					UsuarioSol = UsuarioSol,
					Id = _id
				});
				MostrarMensajes.Informacion(Constantes.MENSAJE_REGISTRO_EXITOSO);
			}
			catch (Exception ex) { MostrarMensajes.DetalleError(ex); }
		}
	}
}
