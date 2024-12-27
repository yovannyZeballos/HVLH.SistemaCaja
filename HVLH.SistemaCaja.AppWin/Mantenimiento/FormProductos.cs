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
	public partial class FormProductos : FormBase
	{

		#region . Variables .
		private readonly IServicioProducto _servicioProducto;
		#endregion

		#region . Propiedades .

		#endregion

		#region . Constructor .
		public FormProductos()
		{
			InitializeComponent();
			_servicioProducto = InstanceFactory.GetInstance<IServicioProducto>();
		}
		#endregion

		#region . Metodos .
		private async Task ListarProductos()
		{
			try
			{
				Loading.Mostrar();
				var productos = await _servicioProducto.Listar();
				dgvProductos.Rows.Clear();

				foreach (var item in productos)
				{
					dgvProductos.Rows.Add(item.Id, item.Codigo, item.Descripcion, item.UnidadMedida, item.Precio, item.TipoIgv);
				}
			}
			catch (Exception ex) { MostrarMensajes.DetalleError(ex); }
			finally { Loading.Cerrar(); }

		}

		private async Task AbrirFormEditar()
		{
			var fila = dgvProductos.CurrentRow;
			if (fila == null)
			{
				MostrarMensajes.Advertencia(Constantes.MENSAJE_SELECCIONAR_REGISTRO);
				return;
			}
			var id = Convert.ToInt32(fila.Cells["ColId"].Value);
			var form = new FormMantProducto { Id = id };
			form.ShowDialog();
			await ListarProductos();
		}
		#endregion

		#region . Eventos .
		private async void FormProductos_Load(object sender, EventArgs e)
		{
			await ListarProductos();
		}

		private async void BtnNuevo_Click(object sender, EventArgs e)
		{
			var form = new FormMantProducto { Id = 0 };
			form.ShowDialog();
			await ListarProductos();
		}

		private async void BtnEditar_Click(object sender, EventArgs e)
		{
			await AbrirFormEditar();
		}

		private async void BtnEliminar_Click(object sender, EventArgs e)
		{
			var fila = dgvProductos.CurrentRow;
			if (fila == null)
			{
				MostrarMensajes.Advertencia(Constantes.MENSAJE_SELECCIONAR_REGISTRO);
				return;
			}

			var id = Convert.ToInt32(fila.Cells["ColId"].Value);

			if (MostrarMensajes.Pregunta(Constantes.MENSAJE_PREGUNTA_ELIMINACION) == DialogResult.Cancel) return;

			try
			{
				Loading.Mostrar();
				await _servicioProducto.Eliminar(id);
				MostrarMensajes.Informacion(Constantes.MENSAJE_REGISTRO_ELIMINADO);
			}
			catch (Exception ex) { MostrarMensajes.DetalleError(ex); }
			finally { Loading.Cerrar(); }

		}

		private void BtnSalir_Click(object sender, EventArgs e)
		{
			Close();
		}

		private async void DgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			await AbrirFormEditar();
		}
		#endregion


	}
}
