using AutoMapper;
using HVLH.SistemaCaja.Modelo;
using HVLH.SistemaCaja.Repositorio.Contextos;
using HVLH.SistemaCaja.Repositorio.Impl;
using HVLH.SistemaCaja.Servicio.Contratos;
using HVLH.SistemaCaja.Servicio.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Servicio.Impl
{
	public class ServicioRol : IServicioRol
	{
		private readonly ISiheContexto _siheContexto;
		private readonly IMapper _mapper;

		public ServicioRol(ISiheContexto siheContexto, IMapper mapper)
		{
			_siheContexto = siheContexto;
			_mapper = mapper;
		}

		public async Task AsociarMenus(AsociarMenusDTO menus)
		{
			var rol = await _siheContexto.RepositorioRol.Obtener(menus.IdRol);
			rol.RolMenus.Clear();
			foreach (var idMenu in menus.IdMenus)
			{
				rol.RolMenus.Add(new RolMenu { IdMenu = idMenu, IdRol = menus.IdRol, UsuarioCreacion = menus.Usuario, FechaCreacion = DateTime.Now });
			}
			await _siheContexto.CommitAsync();
		}

		public async Task Eliminar(int id)
		{
			var rol = await _siheContexto.RepositorioRol.Obtener(id);
			_siheContexto.RepositorioRol.Eliminar(rol);
			await _siheContexto.CommitAsync();
		}

		public async Task Guardar(GuardarRolDTO guardarRolDTO)
		{
			if(guardarRolDTO.Id == 0)
			{
				await _siheContexto.RepositorioRol.Agregar(new Rol
				{
					Descripcion = guardarRolDTO.Descripcion,
					FechaCreacion = DateTime.Now,
					UsuarioCreacion = guardarRolDTO.Usuario
				});
			}
			else
			{
				var rol = await _siheContexto.RepositorioRol.Obtener(x => x.Id == guardarRolDTO.Id);
				rol.Descripcion = guardarRolDTO.Descripcion;
				rol.FechaModificacion = DateTime.Now;
				rol.UsuarioModificacion = guardarRolDTO.Usuario;
			}

			await _siheContexto.CommitAsync();
		}

		public async Task<List<ListarRolDTO>> Listar()
		{
			_siheContexto.RefreshAll();
			var roles = await _siheContexto.RepositorioRol.Listar();
			return _mapper.Map<List<ListarRolDTO>>(roles);
		}

		public async Task<List<MenusAsociadosDTO>> ListarMenusAsociados(int idRol)
		{
			var rol = await _siheContexto.RepositorioRol.Obtener(idRol);
			return _mapper.Map<List<MenusAsociadosDTO>>(rol.RolMenus.Select(x => x.Menu));
		}
	}
}
