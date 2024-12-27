using HVLH.SistemaCaja.Modelo;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Repositorio.Contratos
{
	public interface IRepositorioCorrelativoSerie : IRepositorioGenerico<CorrelativoSerie>
	{
		Task<bool> Existe(int idTipoDocumentoSerie);
	}
}
