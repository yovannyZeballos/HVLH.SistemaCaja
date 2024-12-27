using AutoMapper;
using HVLH.SistemaCaja.Modelo;
using HVLH.SistemaCaja.Repositorio.Contextos;
using HVLH.SistemaCaja.Servicio.Contratos;
using HVLH.SistemaCaja.Servicio.DTO;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Servicio.Impl
{
	public class ServicioPaciente : IServicioPaciente
	{
		private readonly ISiheContexto _siheContexto;
		private readonly IMapper _mapper;

		public ServicioPaciente(ISiheContexto siheContexto, IMapper mapper)
		{
			_siheContexto = siheContexto;
			_mapper = mapper;
		}

		public async Task InsertarCliente(string nroDocumento, string tipoDocumento, string apellidoPaterno, string apellidoMaterno, string nombres, string razonSocial, string direccion)
		{
			try
			{
				await _siheContexto.RepositorioPaciente.InsertarCliente(nroDocumento, tipoDocumento, apellidoPaterno, apellidoMaterno, nombres, razonSocial, direccion);
				await _siheContexto.CommitAsync();
			}
			catch (System.Exception)
			{
			}
		}

		public async Task<PacienteDTO> Obtener(string nroDocumento, string tipoDocumento)
		{
			Paciente paciente = null;
			if (tipoDocumento == "6")
				paciente = await _siheContexto.RepositorioPaciente.Obtener(x => x.Ruc == nroDocumento);
			else
				paciente = await _siheContexto.RepositorioPaciente.Obtener(x => x.NroDocumento == nroDocumento);

			return _mapper.Map<PacienteDTO>(paciente);
		}

		public async Task<string> ObtenerDireccion(string nroDocumento, string tipoDocumento)
		{
			var direccion = await _siheContexto.RepositorioPaciente.ObtenerDireccion(nroDocumento, tipoDocumento);
			return direccion ?? "";
		}
	}
}
