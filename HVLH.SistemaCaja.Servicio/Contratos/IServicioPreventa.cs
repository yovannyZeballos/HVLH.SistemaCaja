using HVLH.SistemaCaja.Servicio.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Servicio.Contratos
{
	public interface IServicioPreventa
	{
		Task<List<ObtenerPreventaDTO>> Obtener(string numPreventa);
	}
}
