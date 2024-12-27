using HVLH.SistemaCaja.Modelo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Repositorio.Contratos
{
	public interface IRepositorioCatalagoServicio : IRepositorioGenerico<CatalogoServicioResult>
	{
		Task<List<CatalogoServicioResult>> Listar(string codigo, string descripcion);
	}
}
