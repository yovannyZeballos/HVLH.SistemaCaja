using HVLH.SistemaCaja.Modelo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Repositorio.Contratos
{
	public interface IRepositorioPreventa : IRepositorioGenerico<PreventaResult>
	{
		Task<List<PreventaResult>> Obtener(string numPreventa);
		Task Actualizar(string numPreventa, string estado);
	}
}
