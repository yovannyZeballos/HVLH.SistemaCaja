using HVLH.SistemaCaja.Modelo;
using HVLH.SistemaCaja.Repositorio.Contextos;
using HVLH.SistemaCaja.Repositorio.Contratos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Repositorio.Impl
{
	public class RepositorioProducto : RepositorioGenerico<SiheContexto, Producto>, IRepositorioProducto
	{
		public RepositorioProducto(SiheContexto siheContexto) : base(siheContexto)
		{
		}

		public async Task<List<Producto>> Listar()
		{
			return await _siheContexto.Productos
				.Include(x => x.UnidadMedida)
				.Include(x => x.TipoAfectacionIgv)
				.ToListAsync();
		}
	}
}
