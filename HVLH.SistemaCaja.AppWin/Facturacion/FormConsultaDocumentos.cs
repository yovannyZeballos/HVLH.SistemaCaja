using HVLH.SistemaCaja.AppWin.Helpers;
using HVLH.SistemaCaja.AppWin.IoC;
using HVLH.SistemaCaja.AppWin.Modelos;
using HVLH.SistemaCaja.Comun;
using HVLH.SistemaCaja.Servicio.Contratos;
using HVLH.SistemaCaja.Servicio.DTO;
using HVLH.SistemaCaja.Servicio.Impl;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HVLH.SistemaCaja.AppWin.Facturacion
{
	public partial class FormConsultaDocumentos : FormBase
	{
		#region . Variables .
		private readonly IServicioDocumento _servicioDocumento;
		private readonly IServicioImpresion _servicioImpresion;
		private readonly IServicioTipoDocumento _servicioTipoDocumento;
		private readonly IServicioTipoDocumentoSerie _servicioTipoDocumentoSerie;
		private readonly IServicioUsuario _servicioUsuario;
		private readonly IServicioTipoMedioPago _servicioTipoMedioPago;
		private List<ListarTipoDocumentoDTO> _tipoDocumento;
		#endregion

		#region . Propiedades .
		private int IdTipoDocumento
		{
			get
			{
				var tipoDocumento = cboTipoDocumento.SelectedItem as ListarTipoDocumentoDTO;
				return tipoDocumento.Id;
			}
		}

		private string TipoDocumento
		{
			get
			{
				var tipoDocumento = cboTipoDocumento.SelectedItem as ListarTipoDocumentoDTO;
				return tipoDocumento.Codigo;
			}

		}

		private string Serie
		{
			get
			{
				var serie = cboSerie.SelectedItem as ListarTipoDocumentoSerieDTO;
				return serie == null ? "" : serie.Serie;
			}

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
		public FormConsultaDocumentos()
		{
			InitializeComponent();
			_servicioDocumento = InstanceFactory.GetInstance<IServicioDocumento>();
			_servicioImpresion = InstanceFactory.GetInstance<IServicioImpresion>();
			_servicioTipoDocumento = InstanceFactory.GetInstance<IServicioTipoDocumento>();
			_servicioTipoDocumentoSerie = InstanceFactory.GetInstance<IServicioTipoDocumentoSerie>();
			_servicioTipoMedioPago = InstanceFactory.GetInstance<IServicioTipoMedioPago>();
			_servicioUsuario = InstanceFactory.GetInstance<IServicioUsuario>();
		}
		#endregion

		#region . Metodos .
		private async Task CargarTipoDocumento()
		{
			cboTipoDocumento.DisplayMember = "Descripcion";
			cboTipoDocumento.ValueMember = "Id";

			_tipoDocumento = await _servicioTipoDocumento.Listar();
			_tipoDocumento.Add(new ListarTipoDocumentoDTO
			{
				Codigo = "00",
				Id = 0,
				Descripcion = "TODOS"
			});

			cboTipoDocumento.DataSource = _tipoDocumento.OrderBy(x => x.Id).ToList();
		}

		private async Task LLenarGrilla()
		{
			try
			{
				var documentos = await ListarDocumentos();

				if (documentos == null) return;

				dgvDocumentos.Rows.Clear();

				foreach (var item in documentos)
				{
					dgvDocumentos.Rows.Add(item.Id, item.TipoDocumento, Enum.Parse(typeof(TipoDocumento), item.TipoDocumento).ToString().Replace("_", " "), $"{item.Serie}-{item.Numero}", item.Fecha,
						$"{item.NumeroDocumentoCliente} - {item.RazonSocialCliente}", item.Moneda, item.Gravadas, item.Inafecto, item.Igv, item.MontoTotal,item.DescMedioPago, Enum.Parse(typeof(EstadoDocumento), item.Estado).ToString());
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
				var documentos = await _servicioDocumento.Listar(tipoDocumentoEnum, Serie, FechaInicio, FechaFin, "0", IdTipoMedioPago);
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

		private async Task ListarSeries()
		{
			try
			{
				var series = await _servicioTipoDocumentoSerie.Listar(IdTipoDocumento);
				cboSerie.DisplayMember = "Serie";
				cboSerie.ValueMember = "Id";
				cboSerie.DataSource = series;
			}
			catch (Exception ex)
			{
				MostrarMensajes.DetalleError(ex);
			}

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
		private async void FormReporteVentas_Load(object sender, EventArgs e)
		{
			await CargarTipoDocumento();
			await ListarTiposMedioPago();
			await LLenarGrilla();
		}

		private async void BtnBuscar_Click(object sender, EventArgs e)
		{
			btnBuscar.Enabled = false;
			await LLenarGrilla();
			btnBuscar.Enabled = true;
		}

		private async void CboTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
		{
			await ListarSeries();
		}

		private void BtnDetalle_Click(object sender, EventArgs e)
		{
			var fila = dgvDocumentos.CurrentRow;
			if (fila == null)
			{
				MostrarMensajes.Advertencia(Constantes.MENSAJE_SELECCIONAR_REGISTRO);
				return;
			}

			var idDocumento = Convert.ToInt32(fila.Cells["ColId"].Value);
			var nroDoc = fila.Cells["ColNroDoc"].Value.ToString();
			var tipoDoc = fila.Cells["ColCodigoTipoDoc"].Value.ToString();
			var tipoSerie = nroDoc.StartsWith("0") ? TipoSerie.Manual : TipoSerie.Electronico;

			var formFacturacion = new FormFacturacion();
			formFacturacion.IdDocumento = idDocumento;
			formFacturacion.TipoSerie = tipoSerie;
			formFacturacion.TipoDocumento = (TipoDocumento)Enum.Parse(typeof(TipoDocumento), Convert.ToInt32(tipoDoc).ToString());
			formFacturacion.ShowDialog();
		}

		#endregion

		private void BtnSalir_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
