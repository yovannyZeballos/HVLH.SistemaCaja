using AutoMapper;
using HVLH.SistemaCaja.Modelo;
using HVLH.SistemaCaja.Repositorio.Contextos;
using HVLH.SistemaCaja.Servicio.Contratos;
using HVLH.SistemaCaja.Servicio.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Servicio.Impl
{
	public class ServicioComunicacionBaja : IServicioComunicacionBaja
	{
		private readonly ISiheContexto _siheContexto;
		private readonly IMapper _mapper;

		public ServicioComunicacionBaja(ISiheContexto siheContexto, IMapper mapper)
		{
			_siheContexto = siheContexto;
			_mapper = mapper;
		}

		public async Task<(int, string)> GuardarComunicacion(GuardarComunicacionBajaDTO guardarComunicacionBajaDTO)
		{
			string numeroBaja = "";
			if (guardarComunicacionBajaDTO.Id == 0)
			{
				var baja = _mapper.Map<ComunicacionBaja>(guardarComunicacionBajaDTO);
				baja.Detalles = new List<ComunicacionBajaDetalle>();

				foreach (var detalle in guardarComunicacionBajaDTO.Detalles)
				{
					baja.Detalles.Add(new ComunicacionBajaDetalle { IdDocumento = detalle.IdDocumento, Motivo = detalle.Motivo });
				}

				baja.Numero = $"{guardarComunicacionBajaDTO.FechaBaja:yyyyMMdd}";

				int correlativo = await _siheContexto.RepositorioComunicacionBaja.ObtenerCorrelativo(baja.Numero);
				baja.Correlativo = correlativo;
				baja.FechaCreacion = DateTime.Now;
				baja.Estado = Comun.EstadoResumen.Generado;
				var bajaAgregado = await _siheContexto.RepositorioComunicacionBaja.Agregar(baja);
				await _siheContexto.CommitAsync();
				guardarComunicacionBajaDTO.Id = bajaAgregado.Id;
				numeroBaja = $"{baja.Numero}-{baja.Correlativo}";
			}
			else
			{
				var baja = await _siheContexto.RepositorioComunicacionBaja.Obtener(guardarComunicacionBajaDTO.Id);
				baja.Detalles.Clear();
				foreach (var detalle in guardarComunicacionBajaDTO.Detalles)
				{
					baja.Detalles.Add(new ComunicacionBajaDetalle { IdDocumento = detalle.IdDocumento, Motivo = detalle.Motivo });
				}
				numeroBaja = $"{baja.Numero}-{baja.Correlativo}";
				await _siheContexto.CommitAsync();
			}

			return (guardarComunicacionBajaDTO.Id, numeroBaja);
		}

		public async Task<List<ListarComunicacionBajaDTO>> ListarComunicaciones(DateTime fechaInicio, DateTime fechaFin)
		{
			_siheContexto.RefreshAll();
			var bajas = await _siheContexto.RepositorioComunicacionBaja.Listar(x => x.FechaBaja.Date >= fechaInicio && x.FechaBaja.Date <= fechaFin);
			return _mapper.Map<List<ListarComunicacionBajaDTO>>(bajas);
		}

		public async Task<int> ObtenerCorrelativo(string numeroResumen)
		{
			return await _siheContexto.RepositorioComunicacionBaja.ObtenerCorrelativo(numeroResumen);
		}

		public async Task<ObtenerComunicacionBajaDTO> ObtenerComunicacion(int id)
		{
			var tiposDocumentos = await _siheContexto.RepositorioTipoDocumento.Listar();
			var baja = await _siheContexto.RepositorioComunicacionBaja.Obtener(id);
			var bajaDTO = _mapper.Map<ObtenerComunicacionBajaDTO>(baja);
			bajaDTO.Detalles = new List<ObtenerComunicacionBajaDetalleDTO>();
			foreach (var item in baja.Detalles)
			{
				var codigoTipoDocumento = tiposDocumentos.FirstOrDefault(x => x.Id == item.Documento.IdTipoDocumento).Codigo;
				var detalleDTO = _mapper.Map<ObtenerComunicacionBajaDetalleDTO>(item);
				detalleDTO.TipoDocumento = codigoTipoDocumento;
				bajaDTO.Detalles.Add(detalleDTO);
			}
			return bajaDTO;
		}
	}
}
