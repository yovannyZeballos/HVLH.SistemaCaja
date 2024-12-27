using AutoMapper;
using HVLH.SistemaCaja.Modelo;
using HVLH.SistemaCaja.Repositorio;
using HVLH.SistemaCaja.Repositorio.Contextos;
using HVLH.SistemaCaja.Repositorio.Contratos;
using HVLH.SistemaCaja.Servicio.Contratos;
using HVLH.SistemaCaja.Servicio.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Servicio.Impl
{
	public class ServicioTipoDocumentoSerie : IServicioTipoDocumentoSerie
	{
		private readonly ISiheContexto _siheContexto;
		private readonly IMapper _mapper;

		public ServicioTipoDocumentoSerie(ISiheContexto siheContexto, IMapper mapper)
		{
			_siheContexto = siheContexto;
			_mapper = mapper;
		}

		public async Task Eliminar(int id)
		{
			var serie = await _siheContexto.RepositorioTipoDocumentoSerie.Obtener(x => x.Id == id);
			_siheContexto.RepositorioTipoDocumentoSerie.Eliminar(serie);
			await _siheContexto.CommitAsync();
		}

		public async Task Insertar(InsertarTipoDocumentoSerieDTO tipoDocumentoSerieDTO)
		{
			if (tipoDocumentoSerieDTO.Id == 0)
			{
				var tipoDocumentoSerie = _mapper.Map<TipoDocumentoSerie>(tipoDocumentoSerieDTO);
				var existe = await _siheContexto.RepositorioTipoDocumentoSerie.Existe(tipoDocumentoSerie.IdTipoDocumento,tipoDocumentoSerie.Serie);
				if (existe) throw new Exception($"La serie {tipoDocumentoSerie.Serie} ya existe");
				tipoDocumentoSerie.FechaCreacion = DateTime.Now;
				tipoDocumentoSerie.UsuarioCreacion = tipoDocumentoSerieDTO.Usuario;
				await _siheContexto.RepositorioTipoDocumentoSerie.Agregar(tipoDocumentoSerie);
			}
			else
			{
				var tipoDocumentoSerie = await _siheContexto.RepositorioTipoDocumentoSerie.Obtener(x => x.Id == tipoDocumentoSerieDTO.Id);
				tipoDocumentoSerie.Serie = tipoDocumentoSerieDTO.Serie;
				tipoDocumentoSerie.Tipo = tipoDocumentoSerieDTO.Tipo;
				tipoDocumentoSerie.AfectoIGV = tipoDocumentoSerieDTO.AfectoIGV;
				tipoDocumentoSerie.FechaModificacion = DateTime.Now;
				tipoDocumentoSerie.UsuarioModificacion = tipoDocumentoSerieDTO.Usuario;
				_siheContexto.RepositorioTipoDocumentoSerie.Actualizar(tipoDocumentoSerie);
			}

			await _siheContexto.CommitAsync();
		}

		public async Task<List<ListarTipoDocumentoSerieDTO>> Listar(int idTipoDocumento)
		{
			var series = await _siheContexto.RepositorioTipoDocumentoSerie.Listar(x => x.IdTipoDocumento == idTipoDocumento);
			return _mapper.Map<List<ListarTipoDocumentoSerieDTO>>(series);
		}

		public async Task<ObtenerTipoDocumentoSerieDTO> Obtener(int id)
		{
			var serie = await _siheContexto.RepositorioTipoDocumentoSerie.Obtener(x => x.Id == id);
			return _mapper.Map<ObtenerTipoDocumentoSerieDTO>(serie);

		}
	}
}
