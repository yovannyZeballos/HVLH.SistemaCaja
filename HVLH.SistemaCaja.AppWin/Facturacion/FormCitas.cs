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
	public partial class FormCitas : FormBase
	{
		#region . Variables .
		private readonly IServicioCita _servicioCita;
		private List<ListarCitasDTO> _citas;
		private CheckBox headerCheckBox = new CheckBox();
		#endregion

		#region . Propiedades .
		public List<ListarCitasDTO> CitasSeleccionadas { get; private set; }
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

		private string Paciente
		{
			get { return txtPaciente.Text; }
			set { txtPaciente.Text = value; }
		}

		private string NroDocumento
		{
			get { return txtNroDocumento.Text; }
			set { txtNroDocumento.Text = value; }
		}

		private string NroCita
		{
			get { return txtNroCita.Text; }
			set { txtNroCita.Text = value; }
		}

		private string NroHistoria
		{
			get { return txtNroHistoria.Text; }
			set { txtNroHistoria.Text = value; }
		}
		#endregion

		#region . Constructor .
		public FormCitas()
		{
			InitializeComponent();
			_servicioCita = InstanceFactory.GetInstance<IServicioCita>();
		}
		#endregion

		#region . Metodos .
		private async Task LLenarGrilla()
		{
			try
			{
				headerCheckBox.Checked = false;
				_citas = await ListarDocumentos();
				dgvCitas.Rows.Clear();

				if (_citas == null || _citas.Count == 0) return;

				Paciente = _citas.First().NombresPaciente;

				foreach (var item in _citas)
				{
					dgvCitas.Rows.Add(false, item.IdCita, item.FechaCita, item.HoraCita, item.Medico, item.DescripcionProducto, item.Precio, item.DescripcionFinan);
				}
			}
			catch (Exception ex)
			{
				MostrarMensajes.DetalleError(ex);
			}

		}

		private async Task<List<ListarCitasDTO>> ListarDocumentos()
		{
			try
			{
				Loading.Mostrar();
				var citas = await _servicioCita.Listar(NroCita, NroHistoria, FechaInicio, FechaFin, NroDocumento);
				Loading.Cerrar();
				return citas;
			}
			catch (Exception ex)
			{

				MostrarMensajes.DetalleError(ex);
				Loading.Cerrar();
			}

			return null;

		}

		private void AgregarCheckGrid()
		{
			//Find the Location of Header Cell.
			Point headerCellLocation = this.dgvCitas.GetCellDisplayRectangle(0, -1, true).Location;

			//Place the Header CheckBox in the Location of the Header Cell.
			headerCheckBox.Location = new Point(headerCellLocation.X + 8, headerCellLocation.Y + 2);
			headerCheckBox.BackColor = Color.White;
			headerCheckBox.Size = new Size(18, 18);

			//Assign Click event to the Header CheckBox.
			headerCheckBox.Click += new EventHandler(HeaderCheckBox_Clicked);
			dgvCitas.Controls.Add(headerCheckBox);

			//Assign Click event to the DataGridView Cell.
			//dgvDocumentos.CellContentClick += new DataGridViewCellEventHandler(DataGridView_CellClick);
		}

		private bool Validar()
		{
			if (NroDocumento == "" && NroCita == "" && NroHistoria == "")
			{
				MostrarMensajes.Advertencia("Debe ingresar al menos un criterio de busqueda");
				return false;
			}
			return true;
		}
		#endregion

		#region . Eventos .
		private void FormCitas_Load(object sender, EventArgs e)
		{
			AgregarCheckGrid();
		}

		private async void BtnBuscar_Click(object sender, EventArgs e)
		{
			if (!Validar()) return;

			btnBuscar.Enabled = false;
			await LLenarGrilla();
			btnBuscar.Enabled = true;
		}

		private void BtnTransferir_Click(object sender, EventArgs e)
		{
			btnTransferir.Enabled = false;
			try
			{
				var idCitas = dgvCitas.Rows.Cast<DataGridViewRow>().Where(x => Convert.ToBoolean(x.Cells["ColSelect"].Value)).Select(x => x.Cells["ColIdCita"].Value.ToString()).ToList();
				if(idCitas.Count == 0)
				{
					MostrarMensajes.Advertencia(Constantes.MENSAJE_SELECCIONAR_REGISTRO);
					return;
				}

				if(idCitas.Count > 1)
				{
					MostrarMensajes.Advertencia(Constantes.MENSAJE_SELECCIONAR_CITA);
					return;
				}

				CitasSeleccionadas = _citas.Where(x => idCitas.Contains(x.IdCita)).ToList();

				if(CitasSeleccionadas.Any(x => x.IdFinanciador == 2))
				{
					MostrarMensajes.Advertencia("No puede seleccionar citas SIS");
					CitasSeleccionadas = null;
					return;
				}

				Close();
			}
			catch (Exception ex)
			{
				MostrarMensajes.DetalleError(ex);
			}
			finally { btnTransferir.Enabled = true; }

		}

		private void BtnSalir_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void DgvDocumentos_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0 && e.ColumnIndex == 0)
			{
				dgvCitas.CurrentCell.Value = !(bool)dgvCitas.CurrentCell.Value;

				bool isChecked = true;
				foreach (DataGridViewRow row in dgvCitas.Rows)
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
			dgvCitas.EndEdit();

			//Loop and check and uncheck all row CheckBoxes based on Header Cell CheckBox.
			foreach (DataGridViewRow row in dgvCitas.Rows)
			{
				DataGridViewCheckBoxCell checkBox = (row.Cells["ColSelect"] as DataGridViewCheckBoxCell);
				checkBox.Value = headerCheckBox.Checked;
			}
		}

		#endregion


	}
}
