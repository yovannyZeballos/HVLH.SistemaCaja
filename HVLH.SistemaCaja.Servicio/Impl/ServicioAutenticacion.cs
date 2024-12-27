using HVLH.SistemaCaja.Repositorio.Contextos;
using HVLH.SistemaCaja.Servicio.Contratos;
using HVLH.SistemaCaja.Servicio.DTO;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Servicio.Impl
{
	public class ServicioAutenticacion : IServicioAutenticacion
	{
		private readonly ISiheContexto _siheContexto;

		public ServicioAutenticacion(ISiheContexto siheContexto)
		{
			_siheContexto = siheContexto;
		}

		public async Task CambiarClave(CambiarClaveDTO cambiarClaveDTO)
		{
			var usuario = await _siheContexto.RepositorioUsuario.Obtener(cambiarClaveDTO.IdUsuario);
			CrearPasswordHash(cambiarClaveDTO.Clave, out byte[] passwordHash, out byte[] passwordSalt);
			usuario.CambioClave = false;
			usuario.PasswordHash = passwordHash;
			usuario.PasswordSalt = passwordSalt;
			usuario.UsuarioModificacion = cambiarClaveDTO.Usuario;
			usuario.FechaModificacion = DateTime.Now;
			await _siheContexto.CommitAsync();	
		}

		public async Task<LoginDTO> Login(string login, string clave)
		{
			var usuario = await _siheContexto.RepositorioUsuario.Obtener(login);

			if (usuario == null)
				throw new Exception("El usuario no existe");

			if (!VerificarPasswordHash(clave, usuario.PasswordHash, usuario.PasswordSalt))
				throw new Exception("Clave ingresada no es correcta");

			var menus = usuario.UsuarioRoles.Select(x => x.Rol).SelectMany(x => x.RolMenus).Select(x => x.Menu);

			return new LoginDTO
			{
				CambioClave = usuario.CambioClave,
				IdUsuario = usuario.Id,
				Nombres = usuario.Nombres,
				Usuario = usuario.Login,
				Menus = menus.Select(x => new MenusAsociadosDTO
				{
					Id = x.Id,
					Descripcion = x.Descripcion,
					Nombre = x.Nombre
				}).ToList()
			};
		}

		private bool VerificarPasswordHash(string password, byte[] passwordHashAlmacenado, byte[] passwordsalt)
		{
			using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordsalt))
			{
				var passwordHashNuevo = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
				return new ReadOnlySpan<byte>(passwordHashAlmacenado).SequenceEqual(new ReadOnlySpan<byte>(passwordHashNuevo));
			}

		}

		private void CrearPasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
		{
			using (var hmac = new System.Security.Cryptography.HMACSHA512())
			{
				passwordSalt = hmac.Key;
				passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

			}
		}
	}
}
