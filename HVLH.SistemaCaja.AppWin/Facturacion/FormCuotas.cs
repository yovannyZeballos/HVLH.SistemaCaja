using HVLH.SistemaCaja.AppWin.Helpers;
using HVLH.SistemaCaja.Comun;
using HVLH.SistemaCaja.Servicio.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HVLH.SistemaCaja.AppWin.Facturacion
{
	public partial class FormCuotas : Form
	{
		public List<CuotaDTO> Cuotas { get; set; } = new List<CuotaDTO>();
		public decimal TotalFactura { get; set; }
		public bool EsSoloConsulta { get; set; }
		private DateTime Fecha
		{
			get { return txtFecha.Value; }
			set { txtFecha.Value = value; }
		}

		private decimal Monto
		{
			get { return txtMonto.Value; }
			set { txtMonto.Value = value; }
		}

		private decimal Total
		{
			get { return txtTotal.Value; }
			set { txtTotal.Value = value; }
		}

		public FormCuotas()
		{
			InitializeComponent();
		}

		private void ReordenarItems()
		{
			Total = 0;
			if (dgvDetalle.Rows.Count == 0) return;

			int item = 1;

			foreach (DataGridViewRow row in dgvDetalle.Rows)
			{
				row.Cells[0].Value = item;
				Total += Convert.ToDecimal(row.Cells[2].Value);
				item++;
			}
		}

		private void BtnAgregar_Click(object sender, EventArgs e)
		{
			dgvDetalle.Rows.Add(0, Fecha.ToString("dd/MM/yyyy"), Monto);
			ReordenarItems();
			Monto = 0;
		}

		private void ObtenerCuotas()
		{
			Cuotas = new List<CuotaDTO>();
			foreach (DataGridViewRow row in dgvDetalle.Rows)
			{
				Cuotas.Add(new CuotaDTO
				{
					Numero = Convert.ToInt32(row.Cells[0].Value),
					Fecha = DateTime.ParseExact(row.Cells[1].Value.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture),
					Monto = Convert.ToDecimal(row.Cells[2].Value)
				});
			}
		}

		private void BtnSalir_Click(object sender, EventArgs e)
		{
			if (!Validar())
			{
				return;
			}

			ObtenerCuotas();
			Close();
		}

		private void FormCuotas_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!Validar())
			{
				e.Cancel = true;
			}

			ObtenerCuotas();

		}

		private void BtnEliminar_Click(object sender, EventArgs e)
		{
			if (dgvDetalle.CurrentRow == null)
			{
				MostrarMensajes.Advertencia(Constantes.MENSAJE_SELECCIONAR_REGISTRO);
				return;
			}

			Monto = 0;
			dgvDetalle.Rows.Remove(dgvDetalle.CurrentRow);
			ReordenarItems();
		}

		private bool Validar()
		{
			if (Total > TotalFactura)
			{
				MostrarMensajes.Advertencia("El total de las cuotas no puede ser mayor al total de la factura");
				return false;
			}
			return true;
		}

		private void FormCuotas_Load(object sender, EventArgs e)
		{
			Monto = TotalFactura;
			ListarCuotas();
			if (EsSoloConsulta) panel1.Enabled = false;

		}

		private void ListarCuotas()
		{
			if (Cuotas == null || Cuotas.Count == 0) return;
			foreach (var cuota in Cuotas)
			{
				dgvDetalle.Rows.Add(cuota.Numero, cuota.Fecha.ToString("dd/MM/yyyy"), cuota.Monto);
			}

			Total = Cuotas.Sum(x => x.Monto);
		}
	}
}
