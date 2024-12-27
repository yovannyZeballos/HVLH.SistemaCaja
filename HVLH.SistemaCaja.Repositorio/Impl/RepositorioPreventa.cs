using HVLH.SistemaCaja.Modelo;
using HVLH.SistemaCaja.Repositorio.Contextos;
using HVLH.SistemaCaja.Repositorio.Contratos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Repositorio.Impl
{
	public class RepositorioPreventa : RepositorioGenerico<SiheContexto, PreventaResult>, IRepositorioPreventa
	{
		public RepositorioPreventa(SiheContexto siheContexto) : base(siheContexto)
		{
		}

		public SiheContexto SiheContexto
		{
			get { return _siheContexto; }
		}

		//TODO: Cambiar la temporal
		public async Task Actualizar(string numPreventa, string estado)
		{
			await _siheContexto.Database.ExecuteSqlInterpolatedAsync($"UPDATE T_FARMPREVENTACAB SET PREVCAB_IDESTADO= {estado} WHERE PREVCAB_NUM = {numPreventa}");
		}

		public async Task<List<PreventaResult>> Obtener(string numPreventa)
		{
			return await _siheContexto.PreventaResult.FromSqlInterpolated($"EXEC usp_Caja_Consultar_Preventa {numPreventa}").ToListAsync();
		}
	}
}
