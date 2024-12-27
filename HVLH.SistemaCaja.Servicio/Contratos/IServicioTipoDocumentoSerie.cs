using HVLH.SistemaCaja.Servicio.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Servicio.Contratos
{
	public interface IServicioTipoDocumentoSerie
	{
		Task<List<ListarTipoDocumentoSerieDTO>> Listar(int idTipoDocumento);
		Task<ObtenerTipoDocumentoSerieDTO> Obtener(int idTipoDocumento);
		Task Insertar(InsertarTipoDocumentoSerieDTO tipoDocumentoSerie);
		Task Eliminar(int id);
	}
}
