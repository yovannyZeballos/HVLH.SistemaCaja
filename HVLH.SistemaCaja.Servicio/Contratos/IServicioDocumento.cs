using HVLH.SistemaCaja.Comun;
using HVLH.SistemaCaja.Modelo;
using HVLH.SistemaCaja.Servicio.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Servicio.Contratos
{
	public interface IServicioDocumento
	{
		Task<List<ListarDocumentoDTO>> Listar(EstadoDocumento[] estados);
		Task<ObtenerDocumentoDTO> Obtener(int id);
		Task<List<ObtenerDocumentoDTO>> ListarXTipo(Comun.TipoDocumento[] tiposEnum);
		Task<List<ObtenerDocumentoDTO>> Listar(Comun.TipoDocumento tipoDocumento, string nroDocumento, DateTime fechaInicio, DateTime fechaFin, string usuario, int idTipoMedioPago);
		Task<bool> ExisteDocumentoUsuario(string login);
		Task AnularDocumento(List<int> ids);
		Task<List<ListarDocumentoDTO>> ListarDocumentosParaResumen(DateTime fechaEmision);
		Task<List<ListarDocumentoDTO>> ListarDocumentosParaComunicacionBaja(DateTime fechaEmision);
	}
}
