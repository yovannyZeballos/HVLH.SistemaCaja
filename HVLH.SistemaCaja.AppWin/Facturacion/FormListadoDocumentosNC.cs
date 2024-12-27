using Autofac.Core;
using HVLH.SistemaCaja.AppWin.Helpers;
using HVLH.SistemaCaja.AppWin.IoC;
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

namespace HVLH.SistemaCaja.AppWin.Facturacion
{
	public partial class FormListadoDocumentosNC : FormBase
	{

		#region . Variables .
		private readonly IServicioDocumento _servicioDocumento;
		private readonly IServicioTipoMedioPago _servicioTipoMedioPago;
		private List<ObtenerDocumentoDTO> documentos;
		#endregion

		#region . Propiedades .
		public ObtenerDocumentoDTO Documento { get; set; }
		public string TipoDocSeleccionado { get; set; }

		private string NumeroDocumento
		{
			get { return txtNroDocumento.Text; }
			set { txtNroDocumento.Text = value; }
		}

		private string TipoDocumento
		{
			get { return cboTipoDocumento.SelectedValue?.ToString(); }
			set { cboTipoDocumento.SelectedValue = value; }

		}

		private DateTime FechaInicio
		{
			get { return txtFechaDel.Value.Date; }
			set { txtFechaDel.Value = value; }

		}

		private DateTime FechaFin
		{
			get { return txtFechaAl.Value.Date; }
			set { txtFechaAl.Value = value; }

		}

		private int IdTipoMedioPago
		{
			get { return Convert.ToInt32(cboTipoMedioPago.SelectedValue); }
			set { cboTipoMedioPago.SelectedValue = value; }

		}
		#endregion

		#region . Constructor .
		public FormListadoDocumentosNC()
		{
			InitializeComponent();
			_servicioDocumento = InstanceFactory.GetInstance<IServicioDocumento>();
			_servicioTipoMedioPago = InstanceFactory.GetInstance<IServicioTipoMedioPago>();
		}
		#endregion

		#region . Metodos .
		private void CargarTipoDocumento()
		{
			cboTipoDocumento.DisplayMember = "Text";
			cboTipoDocumento.ValueMember = "Value";

			var items = new[] {
				new { Text = "TODOS", Value = "0" },
				new { Text = "FACTURA", Value = "01" },
				new { Text = "BOLETA", Value = "03" }
			};

			cboTipoDocumento.DataSource = items;
		}

		private async Task LLenarGrilla()
		{
			try
			{
				var tipoDocumentoEnum = (TipoDocumento)Enum.Parse(typeof(TipoDocumento), TipoDocumento);

				var documentos = await ListarDocumentos();

				if (documentos == null) return;

				dgvDocumentos.Rows.Clear();

				foreach (var item in documentos)
				{
					dgvDocumentos.Rows.Add(item.Id, item.TipoDocumento, Enum.Parse(typeof(TipoDocumento), item.TipoDocumento).ToString().Replace("_", " "), $"{item.Serie}-{item.Numero}", item.Fecha,
						$"{item.NumeroDocumentoCliente} - {item.RazonSocialCliente}", item.Moneda, item.Gravadas, item.Inafecto, item.Igv, item.MontoTotal, Enum.Parse(typeof(EstadoDocumento), item.Estado).ToString());
				}
			}
			catch (Exception ex)
			{
				MostrarMensajes.DetalleError(ex);
			}

		}

		private async Task<List<ObtenerDocumentoDTO>> ListarDocumentos()
		{
			try
			{
				var tipoDocumentoEnum = (TipoDocumento)Enum.Parse(typeof(TipoDocumento), TipoDocumento);

				Loading.Mostrar();
				documentos = await _servicioDocumento.Listar(tipoDocumentoEnum, NumeroDocumento, FechaInicio, FechaFin, "0", IdTipoMedioPago);
				documentos = documentos.Where(x => x.Estado == ((int)EstadoDocumento.Aceptado).ToString()).ToList();
				Loading.Cerrar();

				return documentos;
			}
			catch (Exception ex)
			{

				MostrarMensajes.DetalleError(ex);
				Loading.Cerrar();
			}

			return null;

		}

		private async Task ListarTiposMedioPago()
		{
			try
			{

				var tipos = await _servicioTipoMedioPago.Listar();
				tipos.Add(new ListarTipoMedioPagoDTO
				{
					Id = 0,
					Descripcion = "TODOS"
				});

				cboTipoMedioPago.DisplayMember = "Descripcion";
				cboTipoMedioPago.ValueMember = "Id";
				cboTipoMedioPago.DataSource = tipos.OrderBy(x => x.Id).ToList();
			}
			catch (Exception ex)
			{
				MostrarMensajes.DetalleError(ex);
			}

		}
		#endregion

		#region . Eventos .
		private async void FormListadoDocumentosNC_Load(object sender, EventArgs e)
		{
			try
			{
				CargarTipoDocumento();
				await ListarTiposMedioPago();
				await LLenarGrilla();
			}
			catch (Exception ex)
			{
				MostrarMensajes.DetalleError(ex);
				Loading.Cerrar();
			}

		}

		private void DgvDocumentos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			int id = Convert.ToInt32(dgvDocumentos.Rows[e.RowIndex].Cells["ColId"].Value);
			Documento = documentos.FirstOrDefault(x => x.Id == id);
			Close();
		}

		private async void BtnBuscar_Click(object sender, EventArgs e)
		{
			await LLenarGrilla();
		}
		#endregion




	}
}
