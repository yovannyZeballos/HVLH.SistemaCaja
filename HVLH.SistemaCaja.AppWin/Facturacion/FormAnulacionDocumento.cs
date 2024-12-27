using HVLH.SistemaCaja.AppWin.Helpers;
using HVLH.SistemaCaja.AppWin.IoC;
using HVLH.SistemaCaja.AppWin.Modelos;
using HVLH.SistemaCaja.Comun;
using HVLH.SistemaCaja.Servicio.Contratos;
using HVLH.SistemaCaja.Servicio.DTO;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HVLH.SistemaCaja.AppWin.Facturacion
{
	public partial class FormAnulacionDocumento : FormBase
	{
		#region . Variables .
		private readonly IServicioDocumento _servicioDocumento;
		private readonly IServicioTipoDocumento _servicioTipoDocumento;
		private readonly IServicioTipoDocumentoSerie _servicioTipoDocumentoSerie;
		private readonly IServicioUsuario _servicioUsuario;
		private readonly IServicioTipoMedioPago _servicioTipoMedioPago;
		private List<ListarTipoDocumentoDTO> _tipoDocumento;
		private CheckBox headerCheckBox = new CheckBox();
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

		private int IdTipoMedioPago
		{
			get { return Convert.ToInt32(cboTipoMedioPago.SelectedValue); }
			set { cboTipoMedioPago.SelectedValue = value; }

		}
		#endregion

		#region . Constructor .
		public FormAnulacionDocumento()
		{
			InitializeComponent();
			_servicioDocumento = InstanceFactory.GetInstance<IServicioDocumento>();
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
				headerCheckBox.Checked = false;
				var tipoDocumentoEnum = (TipoDocumento)Enum.Parse(typeof(TipoDocumento), TipoDocumento);

				var documentos = await ListarDocumentos();

				if (documentos == null) return;

				dgvDocumentos.Rows.Clear();

				foreach (var item in documentos)
				{
					dgvDocumentos.Rows.Add(item.Id, false, item.TipoDocumento, Enum.Parse(typeof(TipoDocumento), item.TipoDocumento).ToString().Replace("_", " "), $"{item.Serie}-{item.Numero}", item.Fecha,
						$"{item.NumeroDocumentoCliente} - {item.RazonSocialCliente}", item.Moneda, item.Gravadas, item.Inafecto, item.Igv, item.MontoTotal, item.DescMedioPago, Enum.Parse(typeof(EstadoDocumento), item.Estado).ToString());
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
				documentos = documentos.Where(x => x.Estado != ((int)EstadoDocumento.Anulado).ToString() && x.Estado != ((int)EstadoDocumento.Baja_Aceptada).ToString()).ToList();
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

	
		private async Task Anular()
		{
			try
			{
				Loading.Mostrar();
				var ids = dgvDocumentos.Rows.Cast<DataGridViewRow>().Where(x => Convert.ToBoolean(x.Cells["ColSelect"].Value)).Select(x => Convert.ToInt32(x.Cells["ColId"].Value)).ToList();

				if (ids.Count == 0)
				{
					MostrarMensajes.Advertencia("Debe seleccionar como mínimo un documento");
					return;
				}

				await _servicioDocumento.AnularDocumento(ids);
				MostrarMensajes.Informacion("Los documentos seleccionados han sido anulados");
			}
			catch (Exception ex)
			{
				MostrarMensajes.DetalleError(ex);
			}
			finally
			{
				Loading.Cerrar();
			}

		}

		public void AgregarCheckGrid()
		{
			//Find the Location of Header Cell.
			Point headerCellLocation = this.dgvDocumentos.GetCellDisplayRectangle(1, -1, true).Location;

			//Place the Header CheckBox in the Location of the Header Cell.
			headerCheckBox.Location = new Point(headerCellLocation.X + 8, headerCellLocation.Y + 2);
			headerCheckBox.BackColor = Color.White;
			headerCheckBox.Size = new Size(18, 18);

			//Assign Click event to the Header CheckBox.
			headerCheckBox.Click += new EventHandler(HeaderCheckBox_Clicked);
			dgvDocumentos.Controls.Add(headerCheckBox);

			//Assign Click event to the DataGridView Cell.
			//dgvDocumentos.CellContentClick += new DataGridViewCellEventHandler(DataGridView_CellClick);
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
			AgregarCheckGrid();
		}

		private async void BtnBuscar_Click(object sender, EventArgs e)
		{
			btnBuscar.Enabled = false;
			await LLenarGrilla();
			btnBuscar.Enabled = true;
		}

		private async void BtnAnular_Click(object sender, EventArgs e)
		{
			if (MostrarMensajes.Pregunta("¿Está seguro de anular los documentos seleccionados?") == DialogResult.OK)
			{
				btnAnular.Enabled = false;
				await Anular();
				await LLenarGrilla();
				btnAnular.Enabled = true;
			}
		}

		private async void CboTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
		{
			await ListarSeries();
		}

		private void BtnSalir_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void DgvDocumentos_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0 && e.ColumnIndex == 1)
			{
				dgvDocumentos.CurrentCell.Value = !(bool)dgvDocumentos.CurrentCell.Value;

				bool isChecked = true;
				foreach (DataGridViewRow row in dgvDocumentos.Rows)
				{
					if (Convert.ToBoolean(row.Cells["ColSelect"].EditedFormattedValue) == false)
					{
						isChecked = false;
						break;
					}
				}
				headerCheckBox.Checked = isChecked;
			}
		}

		private void HeaderCheckBox_Clicked(object sender, EventArgs e)
		{
			//Necessary to end the edit mode of the Cell.
			dgvDocumentos.EndEdit();

			//Loop and check and uncheck all row CheckBoxes based on Header Cell CheckBox.
			foreach (DataGridViewRow row in dgvDocumentos.Rows)
			{
				DataGridViewCheckBoxCell checkBox = (row.Cells["ColSelect"] as DataGridViewCheckBoxCell);
				checkBox.Value = headerCheckBox.Checked;
			}
		}
		#endregion

	}
}
