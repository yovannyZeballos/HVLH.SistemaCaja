using HVLH.SistemaCaja.Servicio.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Servicio.Contratos
{
	public interface IServicioTipoDocumento
	{
		Task<List<ListarTipoDocumentoDTO>> Listar();
		Task<ObtenerTipoDocumentoDTO> Obtener(int id);
		Task Insertar(InsertarTipoDocumentoDTO tipoDocumentoDTO);
		Task Eliminar(int id);
	}
}
