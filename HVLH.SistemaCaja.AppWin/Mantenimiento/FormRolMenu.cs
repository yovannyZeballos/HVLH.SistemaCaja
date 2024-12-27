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
	public partial class FormRolMenu : FormBase
	{
		#region . Variables .
		private readonly IServicioMenu _servicioMenu;
		private readonly IServicioRol _servicioRol;
		private List<ListarMenuDTO> _menus;
		#endregion

		#region . Propiedades .
		public int IdRol { get; set; }
		#endregion

		#region . Constructor .
		public FormRolMenu()
		{
			InitializeComponent();
			_servicioMenu = InstanceFactory.GetInstance<IServicioMenu>();
			_servicioRol = InstanceFactory.GetInstance<IServicioRol>();
		}
		#endregion

		#region . Metodos .
		private async Task ListarMenus()
		{
			_menus = await _servicioMenu.Listar();
			var menusAsociados = await _servicioRol.ListarMenusAsociados(IdRol);
			_menus.Select(x => { x.Marcado = (menusAsociados.Any(m => m.Id == x.Id)); return x; }).ToList();

			var menusPadres = _menus.Where(x => x.IdMenuPadre == 0);

			foreach (var item in menusPadres)
			{
				var node = new TreeNode { Text = item.Descripcion, Checked = item.Marcado, Tag = item };
				tvMenus.Nodes.Add(node);
				CargarSubmenus(node, item.Id);
			}

		}

		private void CargarSubmenus(TreeNode node, int idPadre)
		{
			var submenus = _menus.Where(x => x.IdMenuPadre == idPadre).ToList();

			if (submenus.Count > 0)
			{
				foreach (var item in submenus)
				{
					var subNode = new TreeNode { Text = item.Descripcion, Checked = item.Marcado, Tag = item };
					node.Nodes.Add(subNode);
					CargarSubmenus(subNode, item.Id);
				}
			}

		}


		private async Task AsociarMenus()
		{
			try
			{
				var menus = ObtenerMenusMarcados();
				var menusAsociados = new List<int>();
				foreach (var menu in menus)
				{
					menusAsociados.Add(menu.Id);
				}

				Loading.Mostrar();
				await _servicioRol.AsociarMenus(new AsociarMenusDTO { IdRol = IdRol, IdMenus = menusAsociados });
				Loading.Cerrar();

				MostrarMensajes.Informacion("Menus asociados exitosamente");

			}
			catch (Exception ex)
			{
				Loading.Cerrar();
				MostrarMensajes.DetalleError(ex);
			}

		}

		private List<ListarMenuDTO> ObtenerMenusMarcados()
		{
			var menus = new List<ListarMenuDTO>();
			foreach (TreeNode node in tvMenus.Nodes)
			{
				if (node.Checked)
					menus.Add(node.Tag as ListarMenuDTO);

				ObtenerSubmenusMarcados(node, ref menus);
			}

			return menus;
		}

		private void ObtenerSubmenusMarcados(TreeNode node, ref List<ListarMenuDTO> menus)
		{
			if (node.Nodes.Count > 0)
			{
				foreach (TreeNode subNode in node.Nodes)
				{
					if (subNode.Checked)
						menus.Add(subNode.Tag as ListarMenuDTO);

					ObtenerSubmenusMarcados(subNode, ref menus);
				}
			}
		}
		#endregion

		#region . Eventos .
		private async void FormRolMenu_Load(object sender, EventArgs e)
		{
			await ListarMenus();
			tvMenus.ExpandAll();
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
			await AsociarMenus();
		}

		private void BtnSalir_Click(object sender, EventArgs e)
		{
			Close();
		}
		#endregion


	}
}
