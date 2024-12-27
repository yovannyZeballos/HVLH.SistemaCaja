
using HVLH.SistemaCaja.Modelo;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Repositorio.Contratos
{
	public interface IRepositorioRol : IRepositorioGenerico<Rol>
	{
		Task<Rol> Obtener(int id);
	}
}
