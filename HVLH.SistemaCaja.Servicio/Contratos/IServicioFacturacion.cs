using HVLH.SistemaCaja.Servicio.DTO;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Servicio.Contratos
{
	public interface IServicioFacturacion
	{
		Task<long> InsertarVenta(InsertarDocumentoDTO insertarDocumentoDTO);
	}
}
