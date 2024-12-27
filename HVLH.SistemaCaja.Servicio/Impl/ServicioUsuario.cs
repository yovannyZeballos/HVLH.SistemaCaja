using AutoMapper;
using HVLH.SistemaCaja.Modelo;
using HVLH.SistemaCaja.Repositorio.Contextos;
using HVLH.SistemaCaja.Servicio.Contratos;
using HVLH.SistemaCaja.Servicio.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Servicio.Impl
{
	internal class ServicioUsuario : IServicioUsuario
	{
		private readonly ISiheContexto _siheContexto;
		private readonly IMapper _mapper;

		public ServicioUsuario(ISiheContexto siheContexto, IMapper mapper)
		{
			_siheContexto = siheContexto;
			_mapper = mapper;
		}

		public async Task Crear(CrearUsuarioDTO usuarioDTO)
		{
			await ValidarCreacion(usuarioDTO);

			var usuario = new Usuario();

			CrearPasswordHash(usuarioDTO.Clave, out byte[] passwordHash, out byte[] passwordSalt);

			usuario.PasswordSalt = passwordSalt;
			usuario.PasswordHash = passwordHash;
			usuario.Login = usuarioDTO.Login;
			usuario.Nombres = usuarioDTO.Nombres;
			usuario.EsCajero = usuarioDTO.EsCajero;
			usuario.UsuarioCreacion = usuarioDTO.Usuario;
			usuario.FechaCreacion = DateTime.Now;
			usuario.CambioClave = true;
			usuario.Estado = Comun.Estado.Activo;
			await _siheContexto.RepositorioUsuario.Agregar(usuario);
			await _siheContexto.CommitAsync();
		}


		private async Task ValidarCreacion(CrearUsuarioDTO usuarioDTO)
		{
			var usuario = await _siheContexto.RepositorioUsuario.Obtener(x => x.Login == usuarioDTO.Login);
			if (usuario != null) throw new Exception($"El usuario {usuario.Login} ya existe");
		}

		public async Task<List<ListarUsuarioDTO>> Listar()
		{
			_siheContexto.RefreshAll();
			var usuarios = await _siheContexto.RepositorioUsuario.Listar();
			return _mapper.Map<List<ListarUsuarioDTO>>(usuarios);
		}

		public async Task<ListarUsuarioDTO> Obtener(int id)
		{
			var usuario = await _siheContexto.RepositorioUsuario.Obtener(x => x.Id == id);
			return _mapper.Map<ListarUsuarioDTO>(usuario);
		}

		public async Task Eliminar(int id)
		{
			var usuario = await _siheContexto.RepositorioUsuario.Obtener(x => x.Id == id);
			_siheContexto.RepositorioUsuario.Eliminar(usuario);
			await _siheContexto.CommitAsync();
		}

		public async Task Actualizar(ActualizarUsuarioDTO usuarioDTO)
		{
			var usuario = await _siheContexto.RepositorioUsuario.Obtener(x => x.Id == usuarioDTO.Id);
			usuario.Nombres = usuarioDTO.Nombres;
			usuario.EsCajero = usuarioDTO.EsCajero;
			usuario.Estado = usuarioDTO.Estado;
			usuario.FechaModificacion = DateTime.Now;
			usuario.UsuarioModificacion = usuarioDTO.Usuario;
			await _siheContexto.CommitAsync();
		}

		public async Task AsociarRoles(AsociarRolesDTO roles)
		{
			var usuario = await _siheContexto.RepositorioUsuario.Obtener(roles.IdUsuario);
			usuario.UsuarioRoles.Clear();
			foreach (var idRol in roles.IdRoles)
			{
				usuario.UsuarioRoles.Add(new UsuarioRol { IdRol = idRol, IdUsuario = roles.IdUsuario, UsuarioCreacion = roles.Usuario, FechaCreacion = DateTime.Now });
			}
			await _siheContexto.CommitAsync();
		}

		public async Task<List<RolesAsociadosDTO>> ListarRolesAsociados(int idUsuario)
		{
			var usuario = await _siheContexto.RepositorioUsuario.Obtener(idUsuario);
			return _mapper.Map<List<RolesAsociadosDTO>>(usuario.UsuarioRoles.Select(x => x.Rol));
		}

		private void CrearPasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
		{
			using (var hmac = new System.Security.Cryptography.HMACSHA512())
			{
				passwordSalt = hmac.Key;
				passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

			}
		}

		public async Task<string> ResetearClave(int id, string usuarioModifica)
		{
			var usuario = await _siheContexto.RepositorioUsuario.Obtener(x => x.Id == id);
			usuario.CambioClave = true;

			var clave = $"{usuario.Login}{DateTime.Now.Year}";

			CrearPasswordHash(clave, out byte[] passwordHash, out byte[] passwordSalt);

			usuario.PasswordSalt = passwordSalt;
			usuario.PasswordHash = passwordHash;
			usuario.FechaModificacion = DateTime.Now;
			usuario.UsuarioModificacion = usuarioModifica;
			await _siheContexto.CommitAsync();

			return clave;

		}
	}
}
