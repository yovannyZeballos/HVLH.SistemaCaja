using HVLH.SistemaCaja.Modelo;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Repositorio.Contratos
{
	public interface IRepositorioDocumento : IRepositorioGenerico<Documento>
	{
		Task<Documento> Obtener(int id);
		Task<List<Documento>> ListarxTipo(string[] tipos);
		Task<List<Documento>> Listar(string tipoDocumento, string nroDocumento, DateTime fechaInicio, DateTime fechaFin, string usuario, int IdTipoMedioPago);
		Task<bool> ExisteDocumentoUsuario(string login);
		Task<List<Documento>> ListarDocumentosParaResumen(DateTime fechaEmision);
		Task<List<Documento>> ListarDocumentosParaComunicacionBaja(DateTime fechaEmision);
		Task<bool> ExisteDetalle(Expression<Func<DocumentoDetalle, bool>> predicado);
		Task<Documento> InsertarDocumento(Documento documento);

	}
}
