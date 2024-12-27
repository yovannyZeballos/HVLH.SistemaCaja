using HVLH.SistemaCaja.Modelo;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Repositorio.Contratos
{
	public interface IRepositorioUsuario : IRepositorioGenerico<Usuario>
	{
		Task<Usuario> Obtener(int id);
		Task<Usuario> Obtener(string login);
	}
}
