using HVLH.SistemaCaja.Modelo;
using HVLH.SistemaCaja.Repositorio.Contextos;
using HVLH.SistemaCaja.Repositorio.Contratos;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Repositorio.Impl
{
	public class RepositorioUsuario : RepositorioGenerico<SiheContexto, Usuario>, IRepositorioUsuario
	{
		public RepositorioUsuario(SiheContexto siheContexto) : base(siheContexto)
		{
		}

		public SiheContexto SiheContexto
		{
			get { return _siheContexto; }
		}

		public async Task<Usuario> Obtener(int id)
		{
			return await _siheContexto.Usuarios
				.Include(x => x.UsuarioRoles)
				.ThenInclude(x => x.Rol)
				.FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<Usuario> Obtener(string login)
		{
			return await _siheContexto.Usuarios
				.Include(x => x.UsuarioRoles)
				.ThenInclude(x => x.Rol)
				.ThenInclude(x => x.RolMenus)
				.ThenInclude(x => x.Menu)
				.FirstOrDefaultAsync(x => x.Login == login);
		}
	}
}
