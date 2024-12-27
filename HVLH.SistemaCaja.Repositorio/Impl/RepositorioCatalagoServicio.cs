using HVLH.SistemaCaja.Modelo;
using HVLH.SistemaCaja.Repositorio.Contextos;
using HVLH.SistemaCaja.Repositorio.Contratos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Repositorio.Impl
{
	public class RepositorioCatalagoServicio : RepositorioGenerico<SiheContexto, CatalogoServicioResult>, IRepositorioCatalagoServicio
	{
		public RepositorioCatalagoServicio(SiheContexto siheContexto) : base(siheContexto)
		{
		}

		public SiheContexto SiheContexto
		{
			get { return _siheContexto; }
		}

		public async Task<List<CatalogoServicioResult>> Listar(string codigo, string descripcion)
		{
			return await _siheContexto.CatalogoServicioResult.FromSqlInterpolated($"EXEC usp_Caja_Obtener_Catalogo_Servicio {codigo}, {descripcion}").ToListAsync();
		}
	}
}
