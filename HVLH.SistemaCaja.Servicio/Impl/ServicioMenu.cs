using AutoMapper;
using HVLH.SistemaCaja.Repositorio.Contextos;
using HVLH.SistemaCaja.Servicio.Contratos;
using HVLH.SistemaCaja.Servicio.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Servicio.Impl
{
	public class ServicioMenu : IServicioMenu
	{
		private readonly ISiheContexto _siheContexto;
		private readonly IMapper _mapper;

		public ServicioMenu(ISiheContexto siheContexto, IMapper mapper)
		{
			_siheContexto = siheContexto;
			_mapper = mapper;
		}

		public async Task<List<ListarMenuDTO>> Listar()
		{
			var menus = await _siheContexto.RepositorioMenu.Listar();
			return _mapper.Map<List<ListarMenuDTO>>(menus);
		}
	}
}
