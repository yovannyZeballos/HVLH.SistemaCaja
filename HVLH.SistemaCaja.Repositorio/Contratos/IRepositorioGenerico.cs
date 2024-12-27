using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Repositorio.Contratos
{
	public interface IRepositorioGenerico<TEntidad> : IDisposable
	   where TEntidad : class
	{
		Task<IList<TEntidad>> Listar(Expression<Func<TEntidad, bool>> predicado = null, bool paginacion = false, int pagina = 0, int filas = 0);
		Task<TEntidad> Obtener(Expression<Func<TEntidad, bool>> predicado = null);
		Task<TEntidad> Agregar(TEntidad entity);
		void Eliminar(TEntidad entity);
		void Actualizar(TEntidad entity);
		void Rollback(TEntidad entidad);
		Task AgregarRango(IEnumerable<TEntidad> entities); 
	}
}
