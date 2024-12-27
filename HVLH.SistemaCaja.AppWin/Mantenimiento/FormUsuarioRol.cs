using HVLH.SistemaCaja.AppWin.Helpers;
using HVLH.SistemaCaja.AppWin.IoC;
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
	public partial class FormUsuarioRol : FormBase
	{
		#region . Variables .
		private readonly IServicioUsuario _servicioUsuario;
		private readonly IServicioRol _servicioRol;
		private List<ListarRolDTO> _roles;
		#endregion

		#region . Propiedades .
		public int IdUsuario { get; set; }
		#endregion

		#region . Constructor .
		public FormUsuarioRol()
		{
			InitializeComponent();
			_servicioUsuario = InstanceFactory.GetInstance<IServicioUsuario>();
			_servicioRol = InstanceFactory.GetInstance<IServicioRol>();
		}
		#endregion

		#region . Metodos .
		private async Task ListarRoles()
		{
			_roles = await _servicioRol.Listar();
			var rolesAsociados = await _servicioUsuario.ListarRolesAsociados(IdUsuario);
			_roles.Select(x => { x.Marcado = (rolesAsociados.Any(m => m.Id == x.Id)); return x; }).ToList();

			foreach (var item in _roles)
			{
				var node = new TreeNode { Text = item.Descripcion, Checked = item.Marcado, Tag = item };
				tvRoles.Nodes.Add(node);
			}

		}

		private async Task AsociarRoles()
		{
			try
			{
				var roles = ObtenerRolesMarcados();
				var rolesAsociados = new List<int>();
				foreach (var rol in roles)
				{
					rolesAsociados.Add(rol.Id);
				}

				Loading.Mostrar();
				await _servicioUsuario.AsociarRoles(new AsociarRolesDTO { IdUsuario = IdUsuario, IdRoles = rolesAsociados, Usuario = AppInfo.Usuario });
				Loading.Cerrar();

				MostrarMensajes.Informacion("Roles asociados exitosamente");

			}
			catch (Exception ex)
			{
				Loading.Cerrar();
				MostrarMensajes.DetalleError(ex);
			}

		}

		private List<ListarRolDTO> ObtenerRolesMarcados()
		{
			var menus = new List<ListarRolDTO>();
			foreach (TreeNode node in tvRoles.Nodes)
			{
				if (node.Checked)
					menus.Add(node.Tag as ListarRolDTO);
			}

			return menus;
		}
	
		#endregion

		#region . Eventos .
		private async void FormRolMenu_Load(object sender, EventArgs e)
		{
			await ListarRoles();
			tvRoles.ExpandAll();
		}

		private void TvMenus_AfterCheck(object sender, TreeViewEventArgs e)
		{
			var node = e.Node;
			if (node.Nodes.Count > 0)
			{
				foreach (TreeNode item in node.Nodes)
					item.Checked = node.Checked;
			}
		}

		private async void BtnAsociar_Click(object sender, EventArgs e)
		{
			await AsociarRoles();
		}

		private void BtnSalir_Click(object sender, EventArgs e)
		{
			Close();
		}
		#endregion


	}
}
