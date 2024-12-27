using HVLH.SistemaCaja.Repositorio.Contratos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Repositorio.Impl
{
	public class RepositorioGenerico<TContexto, TEntidad> : IRepositorioGenerico<TEntidad>
		 where TEntidad : class
		 where TContexto : DbContext
	{
		protected readonly TContexto _siheContexto;

		protected RepositorioGenerico(TContexto context)
		{
			_siheContexto = context;
		}

		/// <summary>
		/// OBTENER REGISTROS DE CUALQUIER ENTIDAD.
		/// </summary>
		/// <param name="predicado"></param>
		/// <param name="paginacion"></param>
		/// <param name="pagina"></param>
		/// <param name="filas"></param>
		/// <returns></returns>
		public async Task<IList<TEntidad>> Listar(Expression<Func<TEntidad, bool>> predicado = null, bool paginacion = false, int pagina = 0, int filas = 0)
		{
			IQueryable<TEntidad> query = _siheContexto.Set<TEntidad>();
			if (predicado != null) query = query.Where(predicado);
			if (paginacion)
			{
				//var pageCount = (double)query.Count() / filas;
				//var PageCount1 = (int)Math.Ceiling(pageCount);

				var skip = (pagina - 1) * filas;
				query = query.Skip(skip).Take(filas);
			}
			return await query.ToListAsync();
		}

		public async Task<TEntidad> Obtener(Expression<Func<TEntidad, bool>> predicado = null)
		{
			IQueryable<TEntidad> query = _siheContexto.Set<TEntidad>();
			if (predicado != null) query = query.Where(predicado);
			return await query.FirstOrDefaultAsync();
		}

		public async Task<TEntidad> Agregar(TEntidad entity)
		{
			await _siheContexto.Set<TEntidad>().AddAsync(entity);
			return entity;
		}

		public void Actualizar(TEntidad entidad)
		{
			_siheContexto.Entry(entidad).State = EntityState.Modified;
		}

		public void Eliminar(TEntidad entidad)
		{
			_siheContexto.Set<TEntidad>().Remove(entidad);
		}

		//INT(YZM) GDVID-2433 (ALM) 2022-11-10 Agregar por rango - INICIO
		public async Task AgregarRango(IEnumerable<TEntidad> entities)
		{
			await _siheContexto.Set<TEntidad>().AddRangeAsync(entities);
		}
		//INT(YZM) GDVID-2433 (ALM) 2022-11-10 Agregar por rango - FIN

		/// <summary>
		/// Realizar rollback a un solo objeto 
		/// </summary>
		/// <param name="entidad"></param>
		public void Rollback(TEntidad entidad)
		{
			_siheContexto.ChangeTracker
				.Entries<TEntidad>()
				.Where(f => f.Entity == entidad)
				.ToList()
				.ForEach(x => x.Reload());
		}

		#region IDisposable Support
		private bool disposedValue; // To detect redundant calls

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					_siheContexto.Dispose();
				}

				disposedValue = true;
			}
		}

		RepositorioGenerico()
		{
			// Do not change this code. Put cleanup code in Dispose(bool disposing) above.
			Dispose(false);
		}

		// This code added to correctly implement the disposable pattern.
		public void Dispose()
		{
			// Do not change this code. Put cleanup code in Dispose(bool disposing) above.
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		#endregion
	}
}
