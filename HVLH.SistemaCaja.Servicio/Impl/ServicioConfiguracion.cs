using AutoMapper;
using HVLH.SistemaCaja.Modelo;
using HVLH.SistemaCaja.Repositorio.Contextos;
using HVLH.SistemaCaja.Repositorio.Contratos;
using HVLH.SistemaCaja.Servicio.Contratos;
using HVLH.SistemaCaja.Servicio.DTO;
using System;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Servicio.Impl
{
	public class ServicioConfiguracion : IServicioConfiguracion
	{
		private readonly ISiheContexto _siheContexto;
		private readonly IMapper _mapper;

		public ServicioConfiguracion(ISiheContexto siheContexto, IMapper mapper)
		{
			_siheContexto = siheContexto;
			_mapper = mapper;
		}

		public async Task Guardar(GuardarConfiguracionDTO guardarConfiguracionDTO)
		{
			if (guardarConfiguracionDTO.Id == 0)
			{
				var configuracion = _mapper.Map<Configuracion>(guardarConfiguracionDTO);
				configuracion.FechaCreacion = DateTime.Now;
				configuracion.UsuarioCreacion = guardarConfiguracionDTO.Usuario;
				await _siheContexto.RepositorioConfiguracion.Agregar(configuracion);
			}
			else
			{
				var configuracion = await _siheContexto.RepositorioConfiguracion.Obtener(x => x.Id == guardarConfiguracionDTO.Id);
				configuracion.CarpetaDocumentos = guardarConfiguracionDTO.CarpetaDocumentos;
				configuracion.ClaveCertificado = guardarConfiguracionDTO.ClaveCertificado;
				configuracion.ClaveCorreo = guardarConfiguracionDTO.ClaveCorreo;
				configuracion.ClaveSol = guardarConfiguracionDTO.ClaveSol;
				configuracion.Correo = guardarConfiguracionDTO.Correo;
				configuracion.Departamento = guardarConfiguracionDTO.Departamento;
				configuracion.Direccion = guardarConfiguracionDTO.Direccion;
				configuracion.Distrito = guardarConfiguracionDTO.Distrito;
				configuracion.IGV = guardarConfiguracionDTO.IGV;
				configuracion.Provincia = guardarConfiguracionDTO.Provincia;
				configuracion.Puerto = guardarConfiguracionDTO.Puerto;
				configuracion.RazonSocial = guardarConfiguracionDTO.RazonSocial;
				configuracion.Ruc = guardarConfiguracionDTO.Ruc;
				configuracion.RutaCertificado = guardarConfiguracionDTO.RutaCertificado;
				configuracion.Smtp = guardarConfiguracionDTO.Smtp;
				configuracion.Telefono = guardarConfiguracionDTO.Telefono;
				configuracion.TipoOperacion = guardarConfiguracionDTO.TipoOperacion;
				configuracion.Ubigeo = guardarConfiguracionDTO.Ubigeo;
				configuracion.UrlConsulta = guardarConfiguracionDTO.UrlConsulta;
				configuracion.UrlEnvio = guardarConfiguracionDTO.UrlEnvio;
				configuracion.UsuarioSol = guardarConfiguracionDTO.UsuarioSol;
				configuracion.UsuarioModificacion = guardarConfiguracionDTO.Usuario;
				configuracion.FechaModificacion = DateTime.Now;
			}
			await _siheContexto.CommitAsync();

			
		}

		public async Task<ObtenerConfiguracionDTO> Obtener()
		{
			var configuracion = await _siheContexto.RepositorioConfiguracion.Obtener();
			return _mapper.Map<ObtenerConfiguracionDTO>(configuracion);
		}
	}
}
