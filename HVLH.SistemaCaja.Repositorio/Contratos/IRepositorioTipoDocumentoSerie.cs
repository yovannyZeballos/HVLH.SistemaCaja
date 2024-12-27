using HVLH.SistemaCaja.Modelo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Repositorio.Contratos
{
	public interface IRepositorioTipoDocumentoSerie : IRepositorioGenerico<TipoDocumentoSerie>
	{
		Task<bool> Existe(int idTipoDocumento, string serie);
	}
}
