using HVLH.SistemaCaja.AppWin.Helpers;
using HVLH.SistemaCaja.AppWin.IoC;
using HVLH.SistemaCaja.Servicio.Contratos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HVLH.SistemaCaja.AppWin.Mantenimiento
{
	public partial class FormTipoDocumentoSerie : FormBase	
	{
		#region . Variables .
		private readonly IServicioTipoDocumento _servicioTipoDocumento;
		#endregion

		#region . Propiedades .

		#endregion

		#region . Constructor .
		public FormTipoDocumentoSerie()
		{
			InitializeComponent();
			_servicioTipoDocumento = InstanceFactory.GetInstance<IServicioTipoDocumento>();
		}
		#endregion

		#region . Metodos .
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

		private async Task AbrirFormMantenimiento()
		{

			if (dgvTipoDocumento.CurrentCell == null)
			{
				MostrarMensajes.Advertencia("Debe seleccionar un registro");
				return;
			}
			var fila = dgvTipoDocumento.Rows[dgvTipoDocumento.CurrentCell.RowIndex];
			var id = Convert.ToInt32(fila.Cells[0].Value);

			var formMant = new FormMantTipoDocumentoSerie();
			formMant.IdTipoDocumento = id;
			formMant.ShowDialog();
			await Listar();
		}
		#endregion

		#region . Eventos .
		private void BtnSalir_Click(object sender, EventArgs e)
		{
			Close();
		}

		private async void FormTipoDocumentoSerie_Load(object sender, EventArgs e)
		{
			await Listar();
		}

		private async void BtnSeries_Click(object sender, EventArgs e)
		{

			await AbrirFormMantenimiento();
		}

		private async void DgvTipoDocumento_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			await AbrirFormMantenimiento();
		}
		#endregion


	}
}
