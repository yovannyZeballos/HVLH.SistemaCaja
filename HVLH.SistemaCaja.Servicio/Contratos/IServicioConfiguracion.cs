using HVLH.SistemaCaja.Servicio.DTO;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Servicio.Contratos
{
	public interface IServicioConfiguracion
	{
		Task<ObtenerConfiguracionDTO> Obtener();
		Task Guardar(GuardarConfiguracionDTO guardarConfiguracionDTO);
	}
}
