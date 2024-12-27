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
	public class ServicioResumen : IServicioResumen
	{
		private readonly ISiheContexto _siheContexto;
		private readonly IMapper _mapper;

		public ServicioResumen(ISiheContexto siheContexto, IMapper mapper)
		{
			_siheContexto = siheContexto;
			_mapper = mapper;
		}

		public async Task<(int, string)> GuardarResumen(GuardarResumenDTO guardarResumenDTO)
		{
			string numeroResumen = "";
			if (guardarResumenDTO.Id == 0)
			{
				var resumen = _mapper.Map<Resumen>(guardarResumenDTO);
				resumen.Detalles = new List<ResumenDetalle>();

				foreach (var detalle in guardarResumenDTO.Detalles)
				{
					resumen.Detalles.Add(new ResumenDetalle { IdDocumento = detalle.IdDocumento, Estado = detalle.Estado });
				}

				resumen.Numero = $"{guardarResumenDTO.FechaResumen:yyyyMMdd}";

				int correlativo = await _siheContexto.RepositorioResumen.ObtenerCorrelativo(resumen.Numero);
				resumen.Correlativo = correlativo;
				resumen.FechaCreacion = DateTime.Now;
				resumen.Estado = Comun.EstadoResumen.Generado;
				var resumenAgregado = await _siheContexto.RepositorioResumen.Agregar(resumen);
				await _siheContexto.CommitAsync();
				guardarResumenDTO.Id = resumenAgregado.Id;
				numeroResumen = $"{resumen.Numero}-{resumen.Correlativo}";
			}
			else
			{
				var resumen = await _siheContexto.RepositorioResumen.Obtener(guardarResumenDTO.Id);
				resumen.Detalles.Clear();
				foreach (var detalle in guardarResumenDTO.Detalles)
				{
					resumen.Detalles.Add(new ResumenDetalle { IdDocumento = detalle.IdDocumento, Estado = detalle.Estado });
				}
				numeroResumen = $"{resumen.Numero}-{resumen.Correlativo}";
				await _siheContexto.CommitAsync();
			}

			return (guardarResumenDTO.Id, numeroResumen);
		}

		public async Task<List<ListarResumenDTO>> LustarResumenes(DateTime fechaInicio, DateTime fechaFin)
		{
			_siheContexto.RefreshAll();
			var resumenes = await _siheContexto.RepositorioResumen.Listar(x => x.FechaResumen.Date >= fechaInicio && x.FechaResumen.Date <= fechaFin);
			return _mapper.Map<List<ListarResumenDTO>>(resumenes);
		}

		public async Task<int> ObtenerCorrelativo(string numeroResumen)
		{
			return await _siheContexto.RepositorioResumen.ObtenerCorrelativo(numeroResumen);
		}

		public async Task<ObtenerResumenDTO> ObtenerResumen(int id)
		{
			var tiposDocumentos = await _siheContexto.RepositorioTipoDocumento.Listar();
			var resumen = await _siheContexto.RepositorioResumen.Obtener(id);
			var resumenDTO = _mapper.Map<ObtenerResumenDTO>(resumen);
			resumenDTO.Detalles = new List<ObtenerResumenDetalleDTO>();
			foreach (var item in resumen.Detalles)
			{
				var codigoTipoDocumento = tiposDocumentos.FirstOrDefault(x => x.Id == item.Documento.IdTipoDocumento).Codigo;
				var detalleDTO = _mapper.Map<ObtenerResumenDetalleDTO>(item);
				detalleDTO.TipoDocumento = codigoTipoDocumento;
				resumenDTO.Detalles.Add(detalleDTO);
			}
			return resumenDTO;
		}
	}
}
