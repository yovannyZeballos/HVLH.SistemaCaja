using HVLH.SistemaCaja.Servicio.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Servicio.Contratos
{
	public interface IServicioRol
	{
		Task<List<ListarRolDTO>> Listar();
		Task AsociarMenus(AsociarMenusDTO menus);
		Task<List<MenusAsociadosDTO>> ListarMenusAsociados(int idRol);
		Task Guardar(GuardarRolDTO guardarRolDTO);
		Task Eliminar(int id);
	}
}
