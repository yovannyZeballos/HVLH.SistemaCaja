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
	public partial class FormMantRol : FormBase
	{
		#region . Variables .
		private readonly IServicioRol _servicioRol;
		#endregion

		#region . Propiedades .
		public int Id { private get; set; }
		public string DescripcionActualizar { private get; set; }

		private string Descripcion
		{
			get { return txtDescripcion.Text; }
			set { txtDescripcion.Text = value; }
		}
		#endregion

		#region . Constructor .
		public FormMantRol()
		{
			InitializeComponent();
			_servicioRol = InstanceFactory.GetInstance<IServicioRol>();
		}
		#endregion

		#region . Metodos .
		private async Task Guardar()
		{
			try
			{
				await _servicioRol.Guardar(new GuardarRolDTO 
				{ 
					Usuario = AppInfo.Usuario,
					Descripcion = Descripcion,
					Id = Id
				});

				MostrarMensajes.Informacion(Constantes.MENSAJE_REGISTRO_EXITOSO);
				Limpiar();
			}
			catch (Exception ex) { MostrarMensajes.DetalleError(ex); }
		}

		private void Limpiar()
		{
			Descripcion = string.Empty;
			Id = 0;
			DescripcionActualizar = string.Empty;
		}
		#endregion

		#region . Eventos .
		private void FormMantProducto_Load(object sender, EventArgs e)
		{

			if (Id > 0)
			{
				Descripcion = DescripcionActualizar;
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
