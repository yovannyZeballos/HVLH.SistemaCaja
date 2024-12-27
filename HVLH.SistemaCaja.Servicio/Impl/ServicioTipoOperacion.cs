using AutoMapper;
using HVLH.SistemaCaja.Repositorio.Contextos;
using HVLH.SistemaCaja.Servicio.Contratos;
using HVLH.SistemaCaja.Servicio.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Servicio.Impl
{
	public class ServicioTipoOperacion : IServicioTipoOperacion
	{
		private readonly ISiheContexto _siheContexto;
		private readonly IMapper _mapper;

		public ServicioTipoOperacion(ISiheContexto siheContexto, IMapper mapper)
		{
			_siheContexto = siheContexto;
			_mapper = mapper;
		}

		public async Task<List<ListarTipoOperacionDTO>> Listar(string tipoDocumento)
		{
			var tipoOperacion = await _siheContexto.RepositorioTipoOperacion.Listar(x => x.TipoDocumento == tipoDocumento);
			return _mapper.Map<List<ListarTipoOperacionDTO>>(tipoOperacion);
		}

		public async Task<List<ListarTipoOperacionDTO>> Listar()
		{
			var tipoOperacion = await _siheContexto.RepositorioTipoOperacion.Listar();
			return _mapper.Map<List<ListarTipoOperacionDTO>>(tipoOperacion.Select(x => new ListarTipoOperacionDTO { Descripcion = x.Descripcion, Codigo = x.Codigo }).Distinct());
		}
	}
}
