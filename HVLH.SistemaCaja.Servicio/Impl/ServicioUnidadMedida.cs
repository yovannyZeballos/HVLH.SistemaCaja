using AutoMapper;
using HVLH.SistemaCaja.Repositorio.Contextos;
using HVLH.SistemaCaja.Servicio.Contratos;
using HVLH.SistemaCaja.Servicio.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Servicio.Impl
{
	public class ServicioUnidadMedida : IServicioUnidadMedida
	{
		private readonly ISiheContexto _siheContexto;
		private readonly IMapper _mapper;

		public ServicioUnidadMedida(ISiheContexto siheContexto, IMapper mapper)
		{
			_siheContexto = siheContexto;
			_mapper = mapper;
		}
		public async Task<List<UnidadMedidaDTO>> Listar()
		{
			var unidades = await _siheContexto.RepositorioUnidadMedida.Listar();
			return _mapper.Map<List<UnidadMedidaDTO>>(unidades);
		}
	}
}
