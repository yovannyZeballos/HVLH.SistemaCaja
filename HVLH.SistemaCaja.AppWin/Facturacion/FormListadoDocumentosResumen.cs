using HVLH.SistemaCaja.AppWin.Helpers;
using HVLH.SistemaCaja.AppWin.IoC;
using HVLH.SistemaCaja.Comun;
using HVLH.SistemaCaja.Servicio.Contratos;
using HVLH.SistemaCaja.Servicio.DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HVLH.SistemaCaja.AppWin.Facturacion
{
	public partial class FormListadoDocumentosResumen : FormBase
	{
		#region . Variables .
		private readonly IServicioDocumento _servicioDocumento;
		private readonly IServicioTipoDocumento _servicioTipoDocumento;
		private readonly IServicioTipoDocumentoSerie _servicioTipoDocumentoSerie;
		private List<ListarDocumentoDTO> _documentos;
		private CheckBox headerCheckBox = new CheckBox();
		#endregion

		#region . Propiedades .
		public int Id { private get; set; }
		public DateTime Fecha { private get; set; }
		public List<ListarDocumentoDTO> DocumentosSeleccionados { get; private set; }

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

		#endregion

		#region . Constructor .
		public FormListadoDocumentosResumen()
		{
			InitializeComponent();
			_servicioDocumento = InstanceFactory.GetInstance<IServicioDocumento>();
			_servicioTipoDocumento = InstanceFactory.GetInstance<IServicioTipoDocumento>();
			_servicioTipoDocumentoSerie = InstanceFactory.GetInstance<IServicioTipoDocumentoSerie>();
		}
		#endregion

		#region . Metodos .
		private async Task CargarTipoDocumento()
		{
			cboTipoDocumento.DisplayMember = "Descripcion";
			cboTipoDocumento.ValueMember = "Id";

			var tipoDocumento = await _servicioTipoDocumento.Listar();
			tipoDocumento = tipoDocumento.Where(x => x.Codigo == "03" || x.Codigo == "07").OrderBy(x => x.Id).ToList();
			tipoDocumento.Add(new ListarTipoDocumentoDTO
			{
				Codigo = "00",
				Id = 0,
				Descripcion = "TODOS"
			});

			cboTipoDocumento.DataSource = tipoDocumento.OrderBy(x => x.Id).ToList();
		}

		private async Task LLenarGrilla()
		{
			try
			{
				headerCheckBox.Checked = false;
				var tipoDocumentoEnum = (TipoDocumento)Enum.Parse(typeof(TipoDocumento), TipoDocumento);

				_documentos = await ListarDocumentos();

				if (_documentos == null) return;

				dgvDocumentos.Rows.Clear();

				foreach (var item in _documentos)
				{
					dgvDocumentos.Rows.Add(item.Id, false, item.TipoDocumento, Enum.Parse(typeof(TipoDocumento), item.TipoDocumento).ToString().Replace("_", " "), $"{item.Serie}-{item.Numero}", item.Fecha,
						$"{item.NumeroDocumentoCliente} - {item.RazonSocialCliente}", item.Moneda, item.Gravadas, item.Inafecto, item.Igv, item.MontoTotal, Enum.Parse(typeof(EstadoDocumento), item.Estado).ToString());
				}
			}
			catch (Exception ex)
			{
				MostrarMensajes.DetalleError(ex);
			}

		}

		private async Task<List<ListarDocumentoDTO>> ListarDocumentos()
		{
			try
			{
				Loading.Mostrar();
				var documentos = await _servicioDocumento.ListarDocumentosParaResumen(Fecha);
				documentos = documentos.Where(x => ((x.TipoDocumento == TipoDocumento && TipoDocumento != "00") || TipoDocumento == "00") &&
												   ((x.Serie == Serie && Serie != "") || Serie == "")).ToList();
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

		private void Seleccionar()
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

				DocumentosSeleccionados = _documentos.Where(x => ids.Contains(x.Id)).ToList();
				Close();
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
			Point headerCellLocation = dgvDocumentos.GetCellDisplayRectangle(1, -1, true).Location;

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
		#endregion

		#region . Eventos .
		private async void FormReporteVentas_Load(object sender, EventArgs e)
		{
			await CargarTipoDocumento();
			await LLenarGrilla();
			Text = $"Documentos del {Fecha:dd/MM/yyyy}";
			AgregarCheckGrid();

		}

		private async void BtnBuscar_Click(object sender, EventArgs e)
		{

			await LLenarGrilla();

		}

		private void BtnSeleccionar_Click(object sender, EventArgs e)
		{
			Seleccionar();
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
