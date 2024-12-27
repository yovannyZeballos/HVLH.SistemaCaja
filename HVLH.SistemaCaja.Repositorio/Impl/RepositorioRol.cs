using HVLH.SistemaCaja.Modelo;
using HVLH.SistemaCaja.Repositorio.Contextos;
using HVLH.SistemaCaja.Repositorio.Contratos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Repositorio.Impl
{
	public class RepositorioRol : RepositorioGenerico<SiheContexto, Rol>, IRepositorioRol
	{
		public RepositorioRol(SiheContexto siheContexto) : base(siheContexto)
		{
		}

		public SiheContexto SiheContexto
		{
			get { return _siheContexto; }
		}

		public async Task<Rol> Obtener(int id)
		{
			return await _siheContexto.Roles
				.Include(x => x.RolMenus)
				.ThenInclude(x => x.Menu)
				.FirstAsync(x => x.Id == id);
		}
	}
}
