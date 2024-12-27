using AutoMapper;
using HVLH.SistemaCaja.Repositorio.Contextos;
using HVLH.SistemaCaja.Servicio.Contratos;
using HVLH.SistemaCaja.Servicio.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Servicio.Impl
{
	public class ServicioPreventa : IServicioPreventa
	{
		private readonly ISiheContexto _siheContexto;
		private readonly IMapper _mapper;

		public ServicioPreventa(ISiheContexto siheContexto, IMapper mapper)
		{
			_siheContexto = siheContexto;
			_mapper = mapper;
		}

		public async Task<List<ObtenerPreventaDTO>> Obtener(string numPreventa)
		{
			var preventa = await _siheContexto.RepositorioPreventa.Obtener(numPreventa);
			return _mapper.Map<List<ObtenerPreventaDTO>>(preventa);
		}
	}
}
