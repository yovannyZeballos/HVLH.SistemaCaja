using Autofac.Core;
using HVLH.Facturacion.Comun.Datos.Intercambio;
using HVLH.Facturacion.Comun.Datos.Modelos;
using HVLH.SistemaCaja.AppWin.Helpers;
using HVLH.SistemaCaja.AppWin.IoC;
using HVLH.SistemaCaja.Comun;
using HVLH.SistemaCaja.Servicio.Contratos;
using HVLH.SistemaCaja.Servicio.DTO;
using HVLH.SistemaCaja.Servicio.Impl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HVLH.SistemaCaja.AppWin.Facturacion
{
	public partial class FormEnvioDocumentos : FormBase
	{
		#region . Variables .
		private readonly IServicioDocumento _servicioDocumento;
		private readonly IServicioConfiguracion _servicioConfiguracion;
		private readonly IServicioXml _servicioXml;
		private readonly IServicioEnvioDocumento _servicioEnvioDocumento;
		private readonly IServicioTipoDocumento _servicioTipoDocumento;
		private readonly IServicioTipoDocumentoSerie _servicioTipoDocumentoSerie;
		private readonly IServicioUsuario _servicioUsuario;
		private readonly IServicioTipoMedioPago _servicioTipoMedioPago;
		private ObtenerConfiguracionDTO _configuracion;
		private string _certificadoDigital;
		private List<ListarTipoDocumentoDTO> _tipoDocumento;
		private CheckBox headerCheckBox = new CheckBox();
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
		public FormEnvioDocumentos()
		{
			InitializeComponent();
			_servicioDocumento = InstanceFactory.GetInstance<IServicioDocumento>();
			_servicioXml = InstanceFactory.GetInstance<IServicioXml>();
			_servicioConfiguracion = InstanceFactory.GetInstance<IServicioConfiguracion>();
			_servicioEnvioDocumento = InstanceFactory.GetInstance<IServicioEnvioDocumento>();
			_servicioTipoDocumento = InstanceFactory.GetInstance<IServicioTipoDocumento>();
			_servicioTipoDocumentoSerie = InstanceFactory.GetInstance<IServicioTipoDocumentoSerie>();
			_servicioUsuario = InstanceFactory.GetInstance<IServicioUsuario>();
			_servicioTipoMedioPago = InstanceFactory.GetInstance<IServicioTipoMedioPago>();

		}
		#endregion

		#region . Metodos .
		private async Task ObtenerConfiguracion()
		{
			try
			{
				_configuracion = await _servicioConfiguracion.Obtener();
				_certificadoDigital = Convert.ToBase64String(File.ReadAllBytes(_configuracion.RutaCertificado));
			}
			catch (Exception ex)
			{
				Loading.Cerrar();
				MostrarMensajes.DetalleError(ex);
			}
		}

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

			cboTipoDocumento.DataSource = _tipoDocumento.Where(x => x.Codigo != "03").OrderBy(x => x.Id).ToList();
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
					dgvDocumentos.Rows.Add(item.Id, false, item.TipoDocumento, Enum.Parse(typeof(TipoDocumento), item.TipoDocumento).ToString().Replace("_", " "), item.Serie, item.Numero, item.Fecha,
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
				var documentos = await _servicioDocumento.Listar(tipoDocumentoEnum, Serie, FechaInicio, FechaFin, "0", IdTipoMedioPago);
				documentos = documentos.Where(x => (x.Estado == ((int)EstadoDocumento.Generado).ToString() ||
												   x.Estado == ((int)EstadoDocumento.Impreso).ToString()) &&
												   (x.TipoDocumento == "01" || x.TipoDocumento == "07")).ToList();
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

		public async Task EviarDocumento()
		{
			try
			{
				Loading.Mostrar();

				var sb = new StringBuilder();

				foreach (DataGridViewRow item in dgvDocumentos.Rows)
				{
					if (Convert.ToBoolean(item.Cells["ColSeleccionar"].Value))
					{
						var tipoDocumento = item.Cells["ColCodigoTipoDoc"].Value.ToString();
						var serie = item.Cells["ColSerie"].Value.ToString();
						var numero = Convert.ToInt32(item.Cells["ColNumero"].Value);
						var id = Convert.ToInt32(item.Cells["ColId"].Value);
						var tipoSerieNumero = $"{tipoDocumento}-{serie}-{numero}";

						var nombreArchivo = $"{_configuracion.Ruc}-{tipoDocumento}-{serie}-{numero}.xml";
						try
						{
							var documentoResponse = await _servicioEnvioDocumento.Enviar(new EnvioDocumentoDTO
							{
								IdDoumento = id,
								Serie = serie,
								Numero = numero,
								TipoDocumento = tipoDocumento,
								Usuario = AppInfo.Usuario
							});

							sb.AppendLine($"{tipoSerieNumero}: {documentoResponse.MensajeRespuesta} {documentoResponse.MensajeError}");
						}
						catch (Exception ex)
						{
							sb.AppendLine($"{tipoSerieNumero}: {ex.Message}");
						}
					}
				}

				if (sb.Length > 0)
					MostrarMensajes.Informacion(sb.ToString());

				Loading.Cerrar();
			}
			catch (Exception ex)
			{
				Loading.Cerrar();
				MostrarMensajes.DetalleError(ex);
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
		private async void FormEnvioDocumentos_Load(object sender, EventArgs e)
		{
			await CargarTipoDocumento();
			await ListarTiposMedioPago();
			await LLenarGrilla();
			await ObtenerConfiguracion();
			AgregarCheckGrid();
		}

		private async void BtnEnviar_Click(object sender, EventArgs e)
		{
			btnEnviar.Enabled = false;
			await EviarDocumento();
			await LLenarGrilla();
			btnEnviar.Enabled = true;
		}

		private void BtnSalir_Click(object sender, EventArgs e)
		{
			Close();
		}

		private async void CboTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
		{
			await ListarSeries();
		}

		private async void BtnBuscar_Click(object sender, EventArgs e)
		{
			btnBuscar.Enabled = false;
			await LLenarGrilla();
			btnBuscar.Enabled = true;

		}

		private void HeaderCheckBox_Clicked(object sender, EventArgs e)
		{
			//Necessary to end the edit mode of the Cell.
			dgvDocumentos.EndEdit();

			//Loop and check and uncheck all row CheckBoxes based on Header Cell CheckBox.
			foreach (DataGridViewRow row in dgvDocumentos.Rows)
			{
				DataGridViewCheckBoxCell checkBox = (row.Cells["ColSeleccionar"] as DataGridViewCheckBoxCell);
				checkBox.Value = headerCheckBox.Checked;
			}
		}

		private void DgvDocumentos_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0 && e.ColumnIndex == 1)
			{
				dgvDocumentos.CurrentCell.Value = !(bool)dgvDocumentos.CurrentCell.Value;

				bool isChecked = true;
				foreach (DataGridViewRow row in dgvDocumentos.Rows)
				{
					if (Convert.ToBoolean(row.Cells["ColSeleccionar"].EditedFormattedValue) == false)
					{
						isChecked = false;
						break;
					}
				}
				headerCheckBox.Checked = isChecked;
			}

		}

		#endregion


	}
}
