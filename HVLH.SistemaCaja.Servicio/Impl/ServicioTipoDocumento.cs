using AutoMapper;
using HVLH.SistemaCaja.Modelo;
using HVLH.SistemaCaja.Repositorio.Contextos;
using HVLH.SistemaCaja.Repositorio.Contratos;
using HVLH.SistemaCaja.Servicio.Contratos;
using HVLH.SistemaCaja.Servicio.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Servicio.Impl
{
	public class ServicioTipoDocumento : IServicioTipoDocumento
	{
		private readonly ISiheContexto _siheContexto;
		private readonly IMapper _mapper;

		public ServicioTipoDocumento(ISiheContexto siheContexto, IMapper mapper)
		{
			_siheContexto = siheContexto;
			_mapper = mapper;
		}

		public async Task Eliminar(int id)
		{
			var tipoDocumento = await _siheContexto.RepositorioTipoDocumento.Obtener(x => x.Id == id);
			_siheContexto.RepositorioTipoDocumento.Eliminar(tipoDocumento);
			await _siheContexto.CommitAsync();
		}

		public async Task Insertar(InsertarTipoDocumentoDTO tipoDocumentoDTO)
		{

			if (tipoDocumentoDTO.Id == 0)
			{
				var tipoDocumento = _mapper.Map<TipoDocumento>(tipoDocumentoDTO);
				var existe = await _siheContexto.RepositorioTipoDocumento.Existe(tipoDocumento.Codigo);
				if (existe) throw new Exception($"El tipo de documento con código {tipoDocumento.Codigo} ya existe");
				tipoDocumento.FechaCreacion = DateTime.Now;
				tipoDocumento.UsuarioCreacion = tipoDocumentoDTO.Usuario;
				await _siheContexto.RepositorioTipoDocumento.Agregar(tipoDocumento);
			}
			else
			{
				var tipoDocumento = await _siheContexto.RepositorioTipoDocumento.Obtener(x => x.Id == tipoDocumentoDTO.Id);
				tipoDocumento.Descripcion = tipoDocumentoDTO.Descripcion;
				tipoDocumento.DescripcionCorta = tipoDocumentoDTO.DescripcionCorta;
				tipoDocumento.FechaModificacion = DateTime.Now;
				tipoDocumento.UsuarioModificacion = tipoDocumentoDTO.Usuario;
				_siheContexto.RepositorioTipoDocumento.Actualizar(tipoDocumento);
			}

			await _siheContexto.CommitAsync();

		}

		public async Task<List<ListarTipoDocumentoDTO>> Listar()
		{
			var tipoDocumentos = await _siheContexto.RepositorioTipoDocumento.Listar();
			var tipoDocumentosDTO = _mapper.Map<List<ListarTipoDocumentoDTO>>(tipoDocumentos);
			return tipoDocumentosDTO;
		}

		public async Task<ObtenerTipoDocumentoDTO> Obtener(int id)
		{
			var tipoDocumento = await _siheContexto.RepositorioTipoDocumento.Obtener(x => x.Id == id);
			var tipoDocumentoDTO = _mapper.Map<ObtenerTipoDocumentoDTO>(tipoDocumento);
			await _siheContexto.CommitAsync();
			return tipoDocumentoDTO;

		}
	}
}
