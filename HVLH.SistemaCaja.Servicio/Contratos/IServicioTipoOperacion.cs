using HVLH.SistemaCaja.Servicio.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Servicio.Contratos
{
	public interface IServicioTipoOperacion
	{
		Task<List<ListarTipoOperacionDTO>> Listar(string tipoDocumento);
		Task<List<ListarTipoOperacionDTO>> Listar();
	}
}
