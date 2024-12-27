using HVLH.SistemaCaja.Servicio.DTO;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Servicio.Contratos
{
	public interface IServicioAutenticacion
	{
		Task<LoginDTO> Login(string usuario, string clave);
		Task CambiarClave(CambiarClaveDTO cambiarClaveDTO);
	}
}
