using HVLH.SistemaCaja.Modelo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Repositorio.Contratos
{
	public interface IRepositorioProducto : IRepositorioGenerico<Producto>
	{
		Task<List<Producto>> Listar();
	}
}
