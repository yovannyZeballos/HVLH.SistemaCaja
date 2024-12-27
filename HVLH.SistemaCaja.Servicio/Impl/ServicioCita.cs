using AutoMapper;
using HVLH.SistemaCaja.Repositorio.Contextos;
using HVLH.SistemaCaja.Servicio.Contratos;
using HVLH.SistemaCaja.Servicio.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Servicio.Impl
{
	public class ServicioCita : IServicioCita
	{
		private readonly ISiheContexto _siheContexto;
		private readonly IMapper _mapper;

		public ServicioCita(ISiheContexto siheContexto, IMapper mapper)
		{
			_siheContexto = siheContexto;
			_mapper = mapper;
		}

		public async Task<List<ListarCitasDTO>> Listar(string idCita, string nroHistoria, DateTime fechaInicio, DateTime fechaFin, string nroDocumento)
		{
			var citas = await _siheContexto.RepositorioCita.Listar(idCita, nroHistoria, fechaInicio, fechaFin, nroDocumento);
			return _mapper.Map<List<ListarCitasDTO>>(citas);
		}
	}
}
