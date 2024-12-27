using HVLH.SistemaCaja.Servicio.DTO;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Servicio.Contratos
{
	public interface IServicioSunat
	{
		Task<DatosRucDTO> ObtenerDatosRuc(string ruc);
	}
}
