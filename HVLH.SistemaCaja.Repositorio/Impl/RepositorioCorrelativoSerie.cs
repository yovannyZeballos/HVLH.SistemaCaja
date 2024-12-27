using HVLH.SistemaCaja.Modelo;
using HVLH.SistemaCaja.Repositorio.Contextos;
using HVLH.SistemaCaja.Repositorio.Contratos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Repositorio.Impl
{
	public class RepositorioCorrelativoSerie : RepositorioGenerico<SiheContexto, CorrelativoSerie>, IRepositorioCorrelativoSerie
	{
		public RepositorioCorrelativoSerie(SiheContexto siheContexto) : base(siheContexto)
		{
		}

		public SiheContexto SiheContexto
		{
			get { return _siheContexto; }
		}

		public async Task<bool> Existe(int idTipoDocumentoSerie)
		{
			return await _siheContexto.CorrelativoSeries.AsNoTracking().AnyAsync(x => x.IdTipoDocumentoSerie == idTipoDocumentoSerie);
		}
	}
}
