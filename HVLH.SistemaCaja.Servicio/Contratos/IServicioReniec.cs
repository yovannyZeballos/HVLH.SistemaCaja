using HVLH.SistemaCaja.Servicio.DTO;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Servicio.Contratos
{
	public interface IServicioReniec
	{
		Task<DatosDniDTO> Obtener(string dni);
	}
}
