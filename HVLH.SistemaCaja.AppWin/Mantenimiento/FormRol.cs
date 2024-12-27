using HVLH.SistemaCaja.AppWin.Helpers;
using HVLH.SistemaCaja.AppWin.IoC;
using HVLH.SistemaCaja.Comun;
using HVLH.SistemaCaja.Servicio.Contratos;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HVLH.SistemaCaja.AppWin.Mantenimiento
{
	public partial class FormRol : FormBase
	{
		#region . Variables .
		private readonly IServicioRol _servicioRol;
		private int _idRol;
		#endregion

		#region . Propiedades .

		#endregion

		#region . Constructor .
		public FormRol()
		{
			InitializeComponent();
			_servicioRol = InstanceFactory.GetInstance<IServicioRol>();

		}
		#endregion

		#region . Metodos .
		private async Task ListarRoles()
		{
			try
			{
				Loading.Mostrar();
				var roles = await _servicioRol.Listar();
				Loading.Cerrar();

				dgvRoles.Rows.Clear();

				foreach (var role in roles)
				{
					dgvRoles.Rows.Add(role.Id, role.Descripcion);
				}
			}
			catch (Exception ex)
			{
				Loading.Cerrar();
				MostrarMensajes.DetalleError(ex);

			}
		}

		private void AbrirFormMenus()
		{
			var form = new FormRolMenu();
			form.IdRol = _idRol;
			form.ShowDialog();
		}
		#endregion

		#region . Eventos .
		private async void FormRol_Load(object sender, EventArgs e)
		{
			await ListarRoles();
		}

		private void BtnMenus_Click(object sender, EventArgs e)
		{
			if (dgvRoles.CurrentRow == null)
			{
				MostrarMensajes.Advertencia(Constantes.MENSAJE_SELECCIONAR_REGISTRO);
				return;
			}

			_idRol = Convert.ToInt32(dgvRoles.CurrentRow.Cells[0].Value);
			AbrirFormMenus();
		}

		private async void DgvRoles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (dgvRoles.CurrentRow == null)
			{
				MostrarMensajes.Advertencia(Constantes.MENSAJE_SELECCIONAR_REGISTRO);
				return;
			}

			_idRol = Convert.ToInt32(dgvRoles.CurrentRow.Cells[0].Value);
			var descripcion = dgvRoles.CurrentRow.Cells[1].Value.ToString();

			var form = new FormMantRol();
			form.Id = _idRol;
			form.DescripcionActualizar = descripcion;
			form.ShowDialog();
			await ListarRoles();
		}

		private void BtnSalir_Click(object sender, EventArgs e)
		{
			Close();
		}

		private async void BtnEditar_Click(object sender, EventArgs e)
		{
			if (dgvRoles.CurrentRow == null)
			{
				MostrarMensajes.Advertencia(Constantes.MENSAJE_SELECCIONAR_REGISTRO);
				return;
			}

			_idRol = Convert.ToInt32(dgvRoles.CurrentRow.Cells[0].Value);
			var descripcion = dgvRoles.CurrentRow.Cells[1].Value.ToString();

			var form = new FormMantRol();
			form.Id = _idRol;
			form.DescripcionActualizar = descripcion;
			form.ShowDialog();
			await ListarRoles();
		}

		private async void BtnNuevo_Click(object sender, EventArgs e)
		{
			var form = new FormMantRol();
			form.Id = 0;
			form.DescripcionActualizar = "";
			form.ShowDialog();
			await ListarRoles();
		}

		#endregion

		private async void BtnEliminar_Click(object sender, EventArgs e)
		{
			try
			{
				if (dgvRoles.CurrentRow == null)
				{
					MostrarMensajes.Advertencia(Constantes.MENSAJE_SELECCIONAR_REGISTRO);
					return;
				}

				if (MostrarMensajes.Pregunta(Constantes.MENSAJE_PREGUNTA_ELIMINACION) == DialogResult.Cancel) return;

				_idRol = Convert.ToInt32(dgvRoles.CurrentRow.Cells[0].Value);
				_servicioRol.Equals(_idRol);
				MostrarMensajes.Informacion(Constantes.MENSAJE_REGISTRO_ELIMINADO);
				await ListarRoles();
			}
			catch (Exception ex)
			{
				MostrarMensajes.DetalleError(ex);
			}
			

		}
	}
}
