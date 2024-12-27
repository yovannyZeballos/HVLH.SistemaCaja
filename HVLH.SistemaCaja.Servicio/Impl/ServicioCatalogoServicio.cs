using AutoMapper;
using HVLH.SistemaCaja.Repositorio.Contextos;
using HVLH.SistemaCaja.Servicio.Contratos;
using HVLH.SistemaCaja.Servicio.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Servicio.Impl
{
	public class ServicioCatalogoServicio : IServicioCatalogoServicio
	{
		private readonly ISiheContexto _siheContexto;
		private readonly IMapper _mapper;

		public ServicioCatalogoServicio(ISiheContexto siheContexto, IMapper mapper)
		{
			_siheContexto = siheContexto;
			_mapper = mapper;
		}

		public async Task<List<CatalogoServicioDTO>> Listar(string codigo, string descripcion)
		{
			var catalogo = await _siheContexto.RepositorioCatalagoServicio.Listar(codigo, descripcion);
			return _mapper.Map<List<CatalogoServicioDTO>>(catalogo);
		}

		public async Task<CatalogoServicioDTO> Obtener(string codigo)
		{
			var catalogo = await _siheContexto.RepositorioCatalagoServicio.Listar(codigo, "");
			return _mapper.Map<CatalogoServicioDTO>(catalogo.FirstOrDefault());
		}
	}
}
