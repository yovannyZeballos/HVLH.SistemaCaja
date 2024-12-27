using HVLH.SistemaCaja.AppWin.Helpers;
using HVLH.SistemaCaja.AppWin.IoC;
using HVLH.SistemaCaja.Comun;
using HVLH.SistemaCaja.Servicio.Contratos;
using HVLH.SistemaCaja.Servicio.DTO;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HVLH.SistemaCaja.AppWin.Mantenimiento
{
	public partial class FormTipoDocumento : FormBase
	{
		#region Variables
		private readonly IServicioTipoDocumento _servicioTipoDocumento;
		private int id;
		#endregion

		#region Propiedades

		#endregion

		public FormTipoDocumento()
		{
			_servicioTipoDocumento = InstanceFactory.GetInstance<IServicioTipoDocumento>();
			InitializeComponent();
			InitializeEvent();
		}

		#region Eventos

		private async void FormTipoDocumento_Load(object sender, EventArgs e)
		{
			await Listar();
		}

		private async void DgvTipoDocumentoCellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			var fila = dgvTipoDocumento.Rows[dgvTipoDocumento.CurrentCell.RowIndex];
			id = Convert.ToInt32(fila.Cells[0].Value);
			AbrirFormMantenimiento();
			await Listar();
		}

		private async void BtnNuevoClick(object sender, EventArgs e)
		{
			AbrirFormMantenimiento();
			await Listar();
		}

		private void BtnCancelarClick(object sender, EventArgs e)
		{
			Close();
		}

		private async void BtnEliminarClick(object sender, EventArgs e)
		{

			if (dgvTipoDocumento.CurrentCell == null)
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
			if (dgvTipoDocumento.CurrentCell == null)
			{
				MostrarMensajes.Advertencia("Debe seleccionar un registro");
				return;
			}

			var fila = dgvTipoDocumento.Rows[dgvTipoDocumento.CurrentCell.RowIndex];
			id = Convert.ToInt32(fila.Cells[0].Value);

			AbrirFormMantenimiento();
			await Listar();
		}
		#endregion

		#region Metodos

		private void InitializeEvent()
		{
			btnNuevo.Click += new EventHandler(BtnNuevoClick);
			btnEditar.Click += new EventHandler(BtnEditarClick);
			btnEliminar.Click += new EventHandler(BtnEliminarClick);
			btnSalir.Click += new EventHandler(BtnCancelarClick);
			dgvTipoDocumento.CellDoubleClick += new DataGridViewCellEventHandler(DgvTipoDocumentoCellDoubleClick);

		}

		private async Task Listar()
		{
			try
			{
				Loading.Mostrar();
				var tipoDocumentos = await _servicioTipoDocumento.Listar();
				Loading.Cerrar();


				if (tipoDocumentos != null)
				{
					dgvTipoDocumento.Rows.Clear();
					foreach (var item in tipoDocumentos)
					{
						dgvTipoDocumento.Rows.Add(item.Id, item.Codigo, item.Descripcion);
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
			var formMantTipoDocumento = new FormMantTipoDocumento();
			formMantTipoDocumento.Id = id;
			formMantTipoDocumento.ShowDialog();
		}

		private async Task Eliminar()
		{
			try
			{
				var fila = dgvTipoDocumento.Rows[dgvTipoDocumento.CurrentCell.RowIndex];
				id = Convert.ToInt32(fila.Cells[0].Value);

				Loading.Mostrar();
				await _servicioTipoDocumento.Eliminar(id);
				Loading.Cerrar();

				MostrarMensajes.Informacion(Constantes.MENSAJE_REGISTRO_ELIMINADO);
			}
			catch (Exception ex)
			{
				Loading.Cerrar();
				MostrarMensajes.DetalleError(ex);
			}

		}
		#endregion
	}
}
