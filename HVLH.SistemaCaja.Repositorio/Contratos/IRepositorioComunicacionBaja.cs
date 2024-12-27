using HVLH.SistemaCaja.Modelo;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Repositorio.Contratos
{
	public interface IRepositorioComunicacionBaja : IRepositorioGenerico<ComunicacionBaja>
	{
		Task<ComunicacionBaja> Obtener(int id);
		Task<int> ObtenerCorrelativo(string numero);
	}
}
