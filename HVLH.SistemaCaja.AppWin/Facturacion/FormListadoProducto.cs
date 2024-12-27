using HVLH.SistemaCaja.AppWin.Helpers;
using HVLH.SistemaCaja.AppWin.IoC;
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
	public partial class FormListadoProducto : FormBase
	{
		#region . Variables .
		private readonly IServicioCatalogoServicio _servicioCatalogoServicio;
		private List<CatalogoServicioDTO> _productos;
		#endregion

		#region . Propiedades .
		public CatalogoServicioDTO Producto { get; set; }
		private string Busqueda
		{
			get { return txtBusqueda.Text; }
			set { txtBusqueda.Text = value; }
		}
		private bool BuscarxCodigo
		{
			get { return rbCodigo.Checked; }
		}

		private string Cantidad
		{
			set { txtxCantidad.Text = value; }
		}
		#endregion

		#region . Constructor .
		public FormListadoProducto()
		{
			InitializeComponent();
			_servicioCatalogoServicio = InstanceFactory.GetInstance<IServicioCatalogoServicio>();
		}
		#endregion

		#region . Metodos .
		private async Task ListarProductos()
		{
			try
			{
				string codigo = "", descripcion = "";

				if (BuscarxCodigo)
					codigo = Busqueda;
				else
					descripcion = Busqueda;

				Loading.Mostrar();
				_productos = await _servicioCatalogoServicio.Listar(codigo, descripcion);
				Loading.Cerrar();

				dgvProductos.Rows.Clear();

				foreach (var producto in _productos)
				{
					dgvProductos.Rows.Add(producto.IdProducto, producto.Codigo, producto.Descripcion, producto.Precio,
						producto.UnidadMedida, producto.TipoIgv, producto.Estado);
				}

				Cantidad = _productos.Count.ToString();
			}
			catch (Exception ex)
			{
				MostrarMensajes.DetalleError(ex);
				Loading.Cerrar();
			}

		}
		#endregion

		#region . Eventos .
		private async void FormListadoProducto_Load(object sender, EventArgs e)
		{
			await ListarProductos();
		}

		private async void TxtBusqueda_TextChanged(object sender, EventArgs e)
		{
			await ListarProductos();
		}

		private async void RbCodigo_CheckedChanged(object sender, EventArgs e)
		{
			await ListarProductos();
		}

		private void DgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			var id = Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value);
			Producto = _productos.FirstOrDefault(x => x.IdProducto == id);
			Close();
		}
		#endregion


	}
}
