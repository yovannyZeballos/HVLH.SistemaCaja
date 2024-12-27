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
	public partial class FormReporteVentas : FormBase
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
		public bool PorCajero { get; set; }

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


		private string Cajero
		{
			get
			{
				var cajero = cboCajero.SelectedItem as ListarUsuarioDTO;
				return cajero == null ? "" : cajero.Login;
			}

		}

		private int IdTipoMedioPago
		{
			get { return Convert.ToInt32(cboTipoMedioPago.SelectedValue); }
			set { cboTipoMedioPago.SelectedValue = value; }

		}

		private string DescTipoMedioPago
		{
			get { return cboTipoMedioPago.Text; }

		}
		#endregion

		#region . Constructor .
		public FormReporteVentas()
		{
			InitializeComponent();
			_servicioDocumento = InstanceFactory.GetInstance<IServicioDocumento>();
			_servicioImpresion = InstanceFactory.GetInstance<IServicioImpresion>();
			_servicioTipoDocumento = InstanceFactory.GetInstance<IServicioTipoDocumento>();
			_servicioTipoDocumentoSerie = InstanceFactory.GetInstance<IServicioTipoDocumentoSerie>();
			_servicioUsuario = InstanceFactory.GetInstance<IServicioUsuario>();
			_servicioTipoMedioPago = InstanceFactory.GetInstance<IServicioTipoMedioPago>();
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
				var tipoDocumentoEnum = (TipoDocumento)Enum.Parse(typeof(TipoDocumento), TipoDocumento);

				var documentos = await ListarDocumentos();

				if (documentos == null) return;

				dgvDocumentos.Rows.Clear();

				foreach (var item in documentos)
				{
					dgvDocumentos.Rows.Add(item.Id, item.TipoDocumento, Enum.Parse(typeof(TipoDocumento), item.TipoDocumento).ToString().Replace("_", " "), $"{item.Serie}-{item.Numero}", item.Fecha,
						$"{item.NumeroDocumentoCliente} - {item.RazonSocialCliente}", item.Moneda, item.Gravadas, item.Inafecto, item.Igv, item.MontoTotal, item.DescMedioPago ,Enum.Parse(typeof(EstadoDocumento), item.Estado).ToString());
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
				var documentos = await _servicioDocumento.Listar(tipoDocumentoEnum, Serie, FechaInicio, FechaFin, Cajero, IdTipoMedioPago);
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

		private async Task ListarCajeros()
		{
			try
			{
				var usuarios = await _servicioUsuario.Listar();
				usuarios = usuarios.Where(x => x.EsCajero).ToList();

				usuarios.Add(new ListarUsuarioDTO
				{
					Login = "0",
					Nombres = "TODOS"
				});

				cboCajero.DisplayMember = "Nombres";
				cboCajero.ValueMember = "Login";
				cboCajero.DataSource = usuarios;

				if (PorCajero)
					cboCajero.SelectedValue = AppInfo.Usuario;
				else
					cboCajero.SelectedValue = "0";

			}
			catch (Exception ex)
			{
				MostrarMensajes.DetalleError(ex);
			}

		}

		private void EstablecerControles()
		{
			var enabled = true;

			txtFechaAl.Enabled = enabled;
			txtFechaDel.Enabled = enabled;

			if (PorCajero)
				enabled = false;

			cboCajero.Enabled = enabled;
			
			btnExcel.Enabled = enabled;
			btnPdf.Enabled = enabled;
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
			await ListarCajeros();
			EstablecerControles();
		}

		private async void BtnBuscar_Click(object sender, EventArgs e)
		{
			btnBuscar.Enabled = false;
			await LLenarGrilla();
			btnBuscar.Enabled = true;
		}

		private async void BtnImprimir_Click(object sender, EventArgs e)
		{
			await _servicioImpresion.ReporteVenta(await ListarDocumentos(), FechaInicio, FechaFin, AppInfo.Usuario, DescTipoMedioPago);
		}

		private async void CboTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
		{
			await ListarSeries();
		}

		#endregion

		private async void BtnPdf_Click(object sender, EventArgs e)
		{
			await Exportar("PDF");
		}

		private string ObtenerDescripciontipoDocumento(string tipoDocumento)
		{
			return _tipoDocumento.FirstOrDefault(x => x.Codigo == tipoDocumento).DescripcionCorta;
		}

		private async void BtnExcel_Click(object sender, EventArgs e)
		{
			await Exportar("EXCEL");
		}

		private async Task Exportar(string formato)
		{
			var documentos = await ListarDocumentos();
			var reporteVentas = new List<ReporteVentas>();

			foreach (var item in documentos.OrderBy(x => x.TipoDocumento).ThenBy(x => x.Serie).ThenBy(x => x.Numero))
			{
				reporteVentas.Add(new ReporteVentas
				{
					Fecha = item.Fecha.ToString("dd/MM/yyyy"),
					Gravadas = item.Estado == ((int)EstadoDocumento.Anulado).ToString() || item.Estado == ((int)EstadoDocumento.Baja_Aceptada).ToString() ? 0 : item.Gravadas,
					Igv = item.Estado == ((int)EstadoDocumento.Anulado).ToString() || item.Estado == ((int)EstadoDocumento.Baja_Aceptada).ToString() ? 0 : item.Igv,
					Inafectas = item.Estado == ((int)EstadoDocumento.Anulado).ToString() || item.Estado == ((int)EstadoDocumento.Baja_Aceptada).ToString() ? 0 : item.Inafecto,
					Moneda = item.Moneda == "S" ? "S/" : "$",
					NroDocumento = $"{item.Serie}-{item.Numero}",
					RazonSocialCliente = item.RazonSocialCliente,
					Referencia = item.NroPreventa,
					RucCliente = item.NumeroDocumentoCliente,
					TipoDocumento = ObtenerDescripciontipoDocumento(item.TipoDocumento),
					Total = item.Estado == ((int)EstadoDocumento.Anulado).ToString() || item.Estado == ((int)EstadoDocumento.Baja_Aceptada).ToString() ? 0 : item.MontoTotal,
					MedioPago = item.DescMedioPago
				});
			}

			ReportDataSource rs = new ReportDataSource();
			rs.Name = "DsReporteVenta";
			rs.Value = reporteVentas;

			var parameters = new List<ReportParameter>
			{
				new ReportParameter ("FechaInicio",  FechaInicio.ToString("dd/MM/yyyy")),
				new ReportParameter ("FechaFin", FechaFin.ToString("dd/MM/yyyy")) ,
			};

			var pathReport = $"Reportes/rptVentas.rdlc";

			string deviceInfo = "";
			string[] streamIds;
			Warning[] warnings;

			string mimeType = string.Empty;
			string encoding = string.Empty;
			string extension = string.Empty;

			ReportViewer reportViewer = new ReportViewer();
			reportViewer.ProcessingMode = ProcessingMode.Local;
			reportViewer.LocalReport.ReportPath = pathReport;
			reportViewer.LocalReport.DataSources.Add(rs);
			reportViewer.LocalReport.SetParameters(parameters);
			var bytes = reportViewer.LocalReport.Render(formato, deviceInfo, out mimeType, out encoding,
				out extension, out streamIds, out warnings);

			var fileNane = $"{Path.GetTempPath()}ReporteVenta_{DateTime.Now.Ticks}.{(formato == "PDF" ? "pdf" : "xls")}";
			File.WriteAllBytes(fileNane, bytes);
			System.Diagnostics.Process.Start(fileNane);
		}

		private void BtnSalir_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
