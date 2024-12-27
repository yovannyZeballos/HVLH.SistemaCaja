using AutoMapper;
using HVLH.SistemaCaja.Repositorio.Contextos;
using HVLH.SistemaCaja.Servicio.Contratos;
using HVLH.SistemaCaja.Servicio.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Servicio.Impl
{
	public class ServicioTipoAfectacionIgv : IServicioTipoAfectacionIgv
	{
		private readonly ISiheContexto _siheContexto;
		private readonly IMapper _mapper;

		public ServicioTipoAfectacionIgv(ISiheContexto siheContexto, IMapper mapper)
		{
			_siheContexto = siheContexto;
			_mapper = mapper;
		}

		public async Task<List<TipoAfectacionIgvDTO>> Listar()
		{
			var tipos = await _siheContexto.RepositorioTipoAfectacionIgv.Listar();
			return _mapper.Map<List<TipoAfectacionIgvDTO>>(tipos);
		}
	}
}
