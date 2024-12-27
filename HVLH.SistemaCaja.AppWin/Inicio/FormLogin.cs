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
	public partial class FormLogin : Form
	{
		#region . Variables .
		private readonly IServicioAutenticacion _servicioAutenticacion;
		#endregion

		#region . Propiedades .
		private string Usuario
		{
			get { return txtUsuario.Text; }
			set { txtUsuario.Text = value; }
		}

		private string Clave
		{
			get { return txtClave.Text; }
			set { txtClave.Text = value; }
		}
		#endregion

		#region . Constructor .
		public FormLogin()
		{
			InitializeComponent();
			_servicioAutenticacion = InstanceFactory.GetInstance<IServicioAutenticacion>();
			ActiveControl = txtUsuario;
		}
		#endregion

		#region . Metodos .
		private async Task Ingresar()
		{
			try
			{
				btnIngresar.Enabled = false;
				Loading.Mostrar();
				var login = await _servicioAutenticacion.Login(Usuario, Clave);
				Loading.Cerrar();

				AppInfo.Usuario = login.Usuario;
				AppInfo.IdUsuario = login.IdUsuario;
				AppInfo.Menus = login.Menus;
				AppInfo.Nombres = login.Nombres;


				Form form;

				if (login.CambioClave)
					form = new FormCambioClave();
				else
					form = new FormPrincipal();

				Hide();
				form.ShowDialog();
				Close();
			}
			catch (Exception ex)
			{
				MostrarMensajes.DetalleError(ex);
			}
			finally
			{
				btnIngresar.Enabled = true;
				Loading.Cerrar();
			}
		}
		#endregion

		#region . Eventos .

		private async void BtnIngresar_Click(object sender, EventArgs e)
		{
			await Ingresar();
		}

		private void LnkCancelar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Close();

		}

		#endregion

		private void TxtClave_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				btnIngresar.PerformClick();
			}
		}
	}
}
