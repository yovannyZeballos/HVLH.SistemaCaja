using HVLH.SistemaCaja.Modelo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Repositorio.Contratos
{
	public interface IRepositorioTipoDocumento : IRepositorioGenerico<TipoDocumento>
	{
		Task<bool> Existe(string codigo);
	}
}
