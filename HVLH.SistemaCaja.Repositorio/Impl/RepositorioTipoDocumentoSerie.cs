using HVLH.SistemaCaja.Modelo;
using HVLH.SistemaCaja.Repositorio.Contextos;
using HVLH.SistemaCaja.Repositorio.Contratos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Repositorio.Impl
{
	public class RepositorioTipoDocumentoSerie : RepositorioGenerico<SiheContexto, TipoDocumentoSerie>, IRepositorioTipoDocumentoSerie
	{
		public RepositorioTipoDocumentoSerie(SiheContexto siheContexto) : base(siheContexto)
		{
		}

		public SiheContexto SiheContexto
		{
			get { return _siheContexto; }
		}

		public async Task<bool> Existe(int idTipoDocumento, string serie)
		{
			return await _siheContexto.TipoDocumentoSeries.AnyAsync(x => x.IdTipoDocumento == idTipoDocumento && x.Serie == serie);
		}
	}
}
