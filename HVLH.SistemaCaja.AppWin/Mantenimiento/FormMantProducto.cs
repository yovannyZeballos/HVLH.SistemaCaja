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

namespace HVLH.SistemaCaja.AppWin.Mantenimiento
{
	public partial class FormMantProducto : FormBase
	{
		#region . Variables .
		private readonly IServicioProducto _servicioProducto;
		private readonly IServicioTipoAfectacionIgv _servicioTipoAfectacionIgv;
		private readonly IServicioUnidadMedida _servicioUnidadMedida;
		#endregion

		#region . Propiedades .
		public int Id { private get; set; }

		private string Codigo
		{
			get { return txtCodigo.Text; }
			set { txtCodigo.Text = value; }
		}

		private string Descripcion
		{
			get { return txtDescripcion.Text; }
			set { txtDescripcion.Text = value; }
		}

		private decimal Precio
		{
			get { return txtPrecio.Value; }
			set { txtPrecio.Value = value; }
		}

		private int TipoafectacionIgv
		{
			get { return Convert.ToInt32(cboTipoIgv.SelectedValue); }
			set { cboTipoIgv.SelectedValue = value; }
		}

		private int UnidadMedida
		{
			get { return Convert.ToInt32(cboUnidadMedida.SelectedValue); }
			set { cboUnidadMedida.SelectedValue = value; }
		}

		#endregion

		#region . Constructor .
		public FormMantProducto()
		{
			InitializeComponent();
			_servicioProducto = InstanceFactory.GetInstance<IServicioProducto>();
			_servicioTipoAfectacionIgv = InstanceFactory.GetInstance<IServicioTipoAfectacionIgv>();
			_servicioUnidadMedida = InstanceFactory.GetInstance<IServicioUnidadMedida>();
		}
		#endregion

		#region . Metodos .
		private async Task CargarTipoAfectacionIgv()
		{
			try
			{
				var tipos = await _servicioTipoAfectacionIgv.Listar();
				cboTipoIgv.DisplayMember = "Descripcion";
				cboTipoIgv.ValueMember = "Id";
				cboTipoIgv.DataSource = tipos;
			}
			catch (Exception ex) { MostrarMensajes.DetalleError(ex); }

		}

		private async Task CargarUnidadMedida()
		{
			try
			{
				var unidades = await _servicioUnidadMedida.Listar();
				cboUnidadMedida.DisplayMember = "Descripcion";
				cboUnidadMedida.ValueMember = "Id";
				cboUnidadMedida.DataSource = unidades;
			}
			catch (Exception ex) { MostrarMensajes.DetalleError(ex); }
		}

		private async Task ObtenerDatos()
		{
			try
			{
				var producto = await _servicioProducto.Obtener(Id);
				Codigo = producto.Codigo;
				Descripcion = producto.Descripcion;
				Precio = producto.Precio;
				TipoafectacionIgv = producto.IdTipoAfectacionIgv;
				UnidadMedida = producto.IdUnidadMedida;
			}
			catch (Exception ex) { MostrarMensajes.DetalleError(ex); }

		}

		private async Task Guardar()
		{
			try
			{
				await _servicioProducto.Guardar(new GuardarProductoDTO
				{
					Codigo = Codigo,
					Descripcion = Descripcion,
					Id = Id,
					IdTipoAfectacionIgv = TipoafectacionIgv,
					IdUnidadMedida = UnidadMedida,
					Precio = Precio,
					Usuario = AppInfo.Usuario
				});

				MostrarMensajes.Informacion(Constantes.MENSAJE_REGISTRO_EXITOSO);
				Limpiar();
			}
			catch (Exception ex) { MostrarMensajes.DetalleError(ex); }
		}

		private void Limpiar()
		{
			Codigo = string.Empty;
			Descripcion = string.Empty;
			Precio = 0;
			cboTipoIgv.SelectedIndex = 0;
			cboUnidadMedida.SelectedIndex = 0;
			txtCodigo.Enabled = true; 
			Id = 0;
		}
		#endregion

		#region . Eventos .
		private async void FormMantProducto_Load(object sender, EventArgs e)
		{
			await CargarTipoAfectacionIgv();
			await CargarUnidadMedida();

			if (Id > 0)
			{
				await ObtenerDatos();
				txtCodigo.Enabled = false;
			}

		}

		private async void BtnGuardar_Click(object sender, EventArgs e)
		{
			btnGuardar.Enabled = false;
			await Guardar();
			btnGuardar.Enabled = true;
		}

		private void BtnLimpiar_Click(object sender, EventArgs e)
		{
			Limpiar();
		}

		private void BtnSalir_Click(object sender, EventArgs e)
		{
			Close();
		}
		#endregion


	}
}
