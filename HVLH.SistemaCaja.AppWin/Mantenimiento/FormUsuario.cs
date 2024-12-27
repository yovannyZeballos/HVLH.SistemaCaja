using HVLH.SistemaCaja.AppWin.Helpers;
using HVLH.SistemaCaja.AppWin.IoC;
using HVLH.SistemaCaja.Comun;
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

namespace HVLH.SistemaCaja.AppWin.Mantenimiento
{
	public partial class FormUsuario : FormBase
	{
		#region Variables
		private readonly IServicioUsuario _servicioUsuario;
		private readonly IServicioDocumento _servicioDocumento;
		private int _id;
		#endregion

		#region Propiedades

		#endregion


		#region Constructor
		public FormUsuario()
		{
			InitializeComponent();
			_servicioUsuario = InstanceFactory.GetInstance<IServicioUsuario>();
			_servicioDocumento = InstanceFactory.GetInstance<IServicioDocumento>();
		}

		#endregion


		#region Eventos

		private async void FormUsuario_Load(object sender, EventArgs e)
		{
			await Listar();
		}

		private async void DgvUsuariosCellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			var fila = dgvUsuarios.Rows[dgvUsuarios.CurrentCell.RowIndex];
			_id = Convert.ToInt32(fila.Cells[0].Value);
			AbrirFormMantenimiento();
			await Listar();
		}

		private async void BtnNuevoClick(object sender, EventArgs e)
		{
			_id = 0;
			AbrirFormMantenimiento();
			await Listar();
		}

		private void BtnCancelarClick(object sender, EventArgs e)
		{
			Close();
		}

		private async void BtnEliminarClick(object sender, EventArgs e)
		{

			if (dgvUsuarios.CurrentCell == null)
			{
				MostrarMensajes.Advertencia("Debe seleccionar un registro");
				return;
			}

			if (MostrarMensajes.Pregunta(Constantes.MENSAJE_PREGUNTA_ELIMINACION) == DialogResult.Cancel) return;

			await Eliminar();
			await Listar();
		}

		private async void BtnEditarClick(object sender, EventArgs e)
		{
			if (!ValidarSeleccion())
				return;

			var fila = dgvUsuarios.Rows[dgvUsuarios.CurrentCell.RowIndex];
			_id = Convert.ToInt32(fila.Cells[0].Value);

			AbrirFormMantenimiento();
			await Listar();
		}

		private void BtnRoles_Click(object sender, EventArgs e)
		{
			if (!ValidarSeleccion())
				return;

			_id = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells[0].Value);
			AbrirFormRoles();
		}
		#endregion

		#region Metodos

		private bool ValidarSeleccion()
		{
			if (dgvUsuarios.CurrentCell == null)
			{
				MostrarMensajes.Advertencia(Constantes.MENSAJE_SELECCIONAR_REGISTRO);
				return false;
			}
			return true;
		}
		private async Task Listar()
		{
			try
			{
				Loading.Mostrar();
				var usuarios = await _servicioUsuario.Listar();
				Loading.Cerrar();


				if (usuarios != null)
				{
					dgvUsuarios.Rows.Clear();
					foreach (var item in usuarios)
					{
						dgvUsuarios.Rows.Add(item.Id, item.Login, item.Nombres, item.EsCajero, item.Estado.ToString());
					}
				}
			}
			catch (Exception ex)
			{
				Loading.Cerrar();
				MostrarMensajes.DetalleError(ex);
			}

		}

		private void AbrirFormMantenimiento()
		{
			var formMant = new FormMantUsuario();
			formMant.Id = _id;
			formMant.ShowDialog();
		}

		private async Task Eliminar()
		{
			try
			{
				if (!await ValidarEliminacion())
				{
					MostrarMensajes.Advertencia("El usuario tiene documentos asociados, no puede eliminar el usuario");
					return;
				}

				var fila = dgvUsuarios.Rows[dgvUsuarios.CurrentCell.RowIndex];
				_id = Convert.ToInt32(fila.Cells[0].Value);

				Loading.Mostrar();
				await _servicioUsuario.Eliminar(_id);
				Loading.Cerrar();

				MostrarMensajes.Informacion(Constantes.MENSAJE_REGISTRO_ELIMINADO);
			}
			catch (Exception ex)
			{
				Loading.Cerrar();
				MostrarMensajes.DetalleError(ex);
			}

		}

		private void AbrirFormRoles()
		{
			var form = new FormUsuarioRol();
			form.IdUsuario = _id;
			form.ShowDialog();
		}

		private async Task<bool> ValidarEliminacion()
		{
			var login = dgvUsuarios.CurrentRow.Cells["ColLogin"].Value.ToString();
			return !(await _servicioDocumento.ExisteDocumentoUsuario(login));
		}

		#endregion

		private async void BtnResetearClave_Click(object sender, EventArgs e)
		{
			try
			{
				var fila = dgvUsuarios.Rows[dgvUsuarios.CurrentCell.RowIndex];
				int id = Convert.ToInt32(fila.Cells[0].Value);

				var clave = await _servicioUsuario.ResetearClave(id, AppInfo.Usuario);

				MostrarMensajes.Informacion($"Se reestableció la clave, la nueva claves es: {clave}\n Recordar que al ingreso del usuario al sistema se le pedirá el cambio de clave.");
			}
			catch (Exception ex)
			{
				Loading.Cerrar();
				MostrarMensajes.DetalleError(ex);
			}



		}
	}
}
