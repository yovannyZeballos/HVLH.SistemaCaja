using HVLH.SistemaCaja.Servicio.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Servicio.Contratos
{
	public interface IServicioCatalogoServicio
	{
		Task<CatalogoServicioDTO> Obtener(string codigo);
		Task<List<CatalogoServicioDTO>> Listar(string codigo, string descripcion);
	}
}
