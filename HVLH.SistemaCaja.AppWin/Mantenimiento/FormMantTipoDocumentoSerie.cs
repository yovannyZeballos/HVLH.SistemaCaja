using HVLH.SistemaCaja.AppWin.Helpers;
using HVLH.SistemaCaja.AppWin.IoC;
using HVLH.SistemaCaja.AppWin.Validaciones;
using HVLH.SistemaCaja.Comun;
using HVLH.SistemaCaja.Servicio.Contratos;
using HVLH.SistemaCaja.Servicio.DTO;
using HVLH.SistemaCaja.Servicio.Impl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HVLH.SistemaCaja.AppWin.Mantenimiento
{
	public partial class FormMantTipoDocumentoSerie : FormBase
	{
		#region . Variables .
		private readonly IServicioTipoDocumentoSerie _servicioTipoDocumentoSerie;
		private int _id;
        #endregion

        #region . Propiedades .
        public int IdTipoDocumento { private get; set; }
        private string Serie
		{
			get { return txtSerie.Text; }
			set { txtSerie.Text = value; }
		}

		private string Tipo
		{
			get { return cboTipo.SelectedValue.ToString(); }
			set { cboTipo.SelectedValue = value; }
		}

		private bool AfectoIgv
		{
			get { return chkAfecto.Checked; }
			set { chkAfecto.Checked = value; }
		}


		#endregion
		#region . Constructor .
		public FormMantTipoDocumentoSerie()
		{
			InitializeComponent();
			_servicioTipoDocumentoSerie = InstanceFactory.GetInstance<IServicioTipoDocumentoSerie>();

		}
		#endregion

		#region . Metodos .
		private async Task ListarSeries()
		{
			var series = await _servicioTipoDocumentoSerie.Listar(IdTipoDocumento);
			dgvSeries.Rows.Clear();
			foreach (var serie in series)
			{
				dgvSeries.Rows.Add(serie.Id, serie.Serie, serie.Tipo == "1" ? "ELECTRONICO" : "MANUAL", serie.AfectoIGV);
			}
		}

		private void CargarTipo()
		{
			cboTipo.DisplayMember = "Text";
			cboTipo.ValueMember = "Value";

			var items = new[] {
				new { Text = "ELECTRÓNICO", Value = "1" },
				new { Text = "MANUAL", Value = "0" }
			};

			cboTipo.DataSource = items;
		}

		private async Task Guardar(InsertarTipoDocumentoSerieDTO insertarTipoDocumentoSerieDTO)
		{
			try
			{
				Loading.Mostrar();
				await _servicioTipoDocumentoSerie.Insertar(insertarTipoDocumentoSerieDTO);
				Loading.Cerrar();
				MostrarMensajes.Informacion(Constantes.MENSAJE_REGISTRO_EXITOSO);
				await ListarSeries();
			}
			catch (Exception ex)
			{
				Loading.Cerrar();
				MostrarMensajes.DetalleError(ex);
			}
		}

		private InsertarTipoDocumentoSerieDTO ObtenerDatos()
		{
			return new InsertarTipoDocumentoSerieDTO
			{
				AfectoIGV = AfectoIgv,
				Serie = Serie,
				Tipo = Tipo,
				Id = _id,
				Usuario = AppInfo.Usuario,
				IdTipoDocumento = IdTipoDocumento
			};
		}

		private bool Validar(InsertarTipoDocumentoSerieDTO insertarTipoDocumentoSerieDTO)
		{
			var ok = true;
			var validator = new InsertarTipoDocumentoSerieValidator();
			var results = validator.Validate(insertarTipoDocumentoSerieDTO);
			var failures = results.Errors;

			if (!results.IsValid)
			{
				foreach (var failure in failures)
				{
					MostrarMensajes.Advertencia(failure.ErrorMessage);
					return false;
				}
			}

			return ok;
		}


		private void Limpiar()
		{
			AfectoIgv = false;
			Serie = "";
			cboTipo.SelectedIndex = 0;
			_id = 0;
			txtSerie.Enabled = true;
		}

		private async Task Eliminar()
		{
			var fila = dgvSeries.Rows[dgvSeries.CurrentCell.RowIndex];
			_id = Convert.ToInt32(fila.Cells[0].Value);

			Loading.Mostrar();
			await _servicioTipoDocumentoSerie.Eliminar(_id);
			Loading.Cerrar();

			MostrarMensajes.Informacion(Constantes.MENSAJE_REGISTRO_ELIMINADO);
		}

		private async Task ObtenerSerie()
		{
			var fila = dgvSeries.Rows[dgvSeries.CurrentCell.RowIndex];
			_id = Convert.ToInt32(fila.Cells[0].Value);

			var tipoDocumentoSerie = await _servicioTipoDocumentoSerie.Obtener(_id);
			Serie = tipoDocumentoSerie.Serie;
			Tipo = tipoDocumentoSerie.Tipo;
			AfectoIgv = tipoDocumentoSerie.AfectoIGV;
			txtSerie.Enabled = false;
		}
		#endregion

		#region . Eventos .
		private async void BtnGuardar_Click(object sender, EventArgs e)
		{
			var insertarTipoDocumentoSerie = ObtenerDatos();
			if (!Validar(insertarTipoDocumentoSerie)) return;
			await Guardar(insertarTipoDocumentoSerie);
			Limpiar();
		}

		private void BtnLimpiar_Click(object sender, EventArgs e)
		{
			Limpiar();
		}

		private async void BtnEliminar_Click(object sender, EventArgs e)
		{
			if (dgvSeries.CurrentCell == null)
			{
				MostrarMensajes.Advertencia("Debe seleccionar un registro");
				return;
			}

			if (MostrarMensajes.Pregunta(Constantes.MENSAJE_PREGUNTA_ELIMINACION) == DialogResult.Cancel) return;

			await Eliminar();
			await ListarSeries();
			Limpiar();
		}

		private void BtnSalir_Click(object sender, EventArgs e)
		{
			Close();
		}

		private async void FormMantTipoDocumentoSerie_Load(object sender, EventArgs e)
		{
			await ListarSeries();
			CargarTipo();
		}

		private async void DgvSeries_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				Loading.Mostrar();
				await ObtenerSerie();
				Loading.Cerrar();
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
