using HVLH.SistemaCaja.Servicio.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Servicio.Contratos
{
	public interface IServicioUsuario
	{
		Task Crear(CrearUsuarioDTO usuarioDTO);
		Task Actualizar(ActualizarUsuarioDTO usuarioDTO);
		Task<List<ListarUsuarioDTO>> Listar();
		Task<ListarUsuarioDTO> Obtener(int id);
		Task Eliminar(int id);
		Task AsociarRoles(AsociarRolesDTO roles);
		Task<List<RolesAsociadosDTO>> ListarRolesAsociados(int idRol);
		Task<string> ResetearClave(int id, string usuarioModifica);
	}
}
