using HVLH.SistemaCaja.AppWin.Helpers;
using HVLH.SistemaCaja.AppWin.IoC;
using HVLH.SistemaCaja.Servicio.Contratos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HVLH.SistemaCaja.AppWin.Inicio
{
	public partial class FormCambioClave : FormBase
	{
		#region . Variables .
		private readonly IServicioAutenticacion _servicioAutenticacion;
		#endregion

		#region . Propiedades .
		private string Clave
		{
			get { return txtNuevaClave.Text; }
			set { txtNuevaClave.Text = value; }
		}

		private string RepetirClave
		{
			get { return txtRepetirClave.Text; }
			set { txtRepetirClave.Text = value; }
		}
		#endregion

		#region . Constructor .
		public FormCambioClave()
		{
			InitializeComponent();
			_servicioAutenticacion = InstanceFactory.GetInstance<IServicioAutenticacion>();
		}
		#endregion

		#region . Metodos .
		private bool ValidarClaves()
		{
			if (Clave != RepetirClave)
			{
				MostrarMensajes.Advertencia("Las claves no coinciden");
				return false;
			}

			return true;
		}

		private async Task CambiarClave()
		{
			try
			{
				Loading.Mostrar();
				await _servicioAutenticacion.CambiarClave(new Servicio.DTO.CambiarClaveDTO
				{
					Clave = Clave,
					IdUsuario = AppInfo.IdUsuario,
					Usuario = AppInfo.Usuario
				});
				Loading.Cerrar();

				MostrarMensajes.Informacion("Se cambió la clave correctamente");

				var formPrincipal = new FormPrincipal();
				Hide();
				formPrincipal.ShowDialog();
				Close();

			}
			catch (Exception)
			{
				Loading.Cerrar();
				throw;
			}
		
		}
		#endregion

		#region . Eventos .
		private async void BtnCambiar_Click(object sender, EventArgs e)
		{
			if (!ValidarClaves()) return;

			await CambiarClave();
		}

		private void LnkCancelar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Close();
		}
		#endregion


	}
}
