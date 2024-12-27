using HVLH.SistemaCaja.Modelo;
using HVLH.SistemaCaja.Repositorio.Contextos;
using HVLH.SistemaCaja.Repositorio.Contratos;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Repositorio.Impl
{
	public class RepositorioResumen : RepositorioGenerico<SiheContexto, Resumen>, IRepositorioResumen
	{
		public RepositorioResumen(SiheContexto siheContexto) : base(siheContexto)
		{
		}

		public SiheContexto SiheContexto
		{
			get { return _siheContexto; }
		}

		public async Task<Resumen> Obtener(int id)
		{
			return await _siheContexto.Resumenes
				.Include(x => x.Detalles)
				.ThenInclude(x => x.Documento)
				.FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<int> ObtenerCorrelativo(string numero)
		{
			var correlativo = (await _siheContexto.Resumenes.Where(x => x.Numero == numero).MaxAsync(x => (int?)x.Correlativo)) ?? 0;
			return correlativo + 1;
		}
	}
}
