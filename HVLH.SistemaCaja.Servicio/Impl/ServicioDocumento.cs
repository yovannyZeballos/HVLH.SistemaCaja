using AutoMapper;
using AutoMapper.Internal;
using HVLH.SistemaCaja.Comun;
using HVLH.SistemaCaja.Modelo;
using HVLH.SistemaCaja.Repositorio.Contextos;
using HVLH.SistemaCaja.Servicio.Contratos;
using HVLH.SistemaCaja.Servicio.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Servicio.Impl
{
	public class ServicioDocumento : IServicioDocumento
	{
		private readonly ISiheContexto _siheContexto;
		private readonly IMapper _mapper;

		public ServicioDocumento(ISiheContexto siheContexto, IMapper mapper)
		{
			_siheContexto = siheContexto;
			_mapper = mapper;
		}

		public async Task<List<ListarDocumentoDTO>> Listar(EstadoDocumento[] estados)
		{
			var documentosDTO = new List<ListarDocumentoDTO>();
			var est = estados.Select(x => ((int)x).ToString()).ToArray();
			var documwntos = await _siheContexto.RepositorioDocumento.Listar(x => est.Contains(x.Estado));
			var tipoDocumentos = await _siheContexto.RepositorioTipoDocumento.Listar();


			foreach (var item in documwntos)
			{
				var codigoTipoDocumento = tipoDocumentos.FirstOrDefault(x => x.Id == item.IdTipoDocumento).Codigo;
				var documentoDTO = _mapper.Map<ListarDocumentoDTO>(item);
				documentoDTO.TipoDocumento = codigoTipoDocumento;
				documentosDTO.Add(documentoDTO);
			}

			return documentosDTO;
		}

		public async Task<ObtenerDocumentoDTO> Obtener(int id)
		{
			var documento = await _siheContexto.RepositorioDocumento.Obtener(id);
			var tipoDocumentos = await _siheContexto.RepositorioTipoDocumento.Listar();
			var documentoDTO = _mapper.Map<ObtenerDocumentoDTO>(documento);
			documentoDTO.TipoDocumento = tipoDocumentos.FirstOrDefault(x => x.Id == documento.IdTipoDocumento).Codigo;
			return documentoDTO;
		}

		public async Task<List<ObtenerDocumentoDTO>> ListarXTipo(Comun.TipoDocumento[] tiposEnum)
		{
			var documentosDTO = new List<ObtenerDocumentoDTO>();
			var tipos = tiposEnum.Select(x => ((int)x).ToString().PadLeft(2, '0')).ToArray();
			var documwentos = await _siheContexto.RepositorioDocumento.ListarxTipo(tipos);
			var tipoDocumentos = await _siheContexto.RepositorioTipoDocumento.Listar();


			foreach (var item in documwentos)
			{
				var codigoTipoDocumento = tipoDocumentos.FirstOrDefault(x => x.Id == item.IdTipoDocumento).Codigo;
				var documentoDTO = _mapper.Map<ObtenerDocumentoDTO>(item);
				documentoDTO.TipoDocumento = codigoTipoDocumento;
				documentosDTO.Add(documentoDTO);
			}

			return documentosDTO;
		}

		public async Task<List<ObtenerDocumentoDTO>> Listar(Comun.TipoDocumento tipoDocumento, string nroDocumento, DateTime fechaInicio, DateTime fechaFin, string usuario, int idTipoMedioPago)
		{
			var documentosDTO = new List<ObtenerDocumentoDTO>();
			var tipo = ((int)tipoDocumento).ToString().PadLeft(2, '0');
			var documentos = await _siheContexto.RepositorioDocumento.Listar(tipo, nroDocumento, fechaInicio, fechaFin, usuario, idTipoMedioPago);
			var tipoDocumentos = await _siheContexto.RepositorioTipoDocumento.Listar();
			var medioPagos = await _siheContexto.RepositorioTipoMedioPago.Listar();


			foreach (var item in documentos)
			{
				var codigoTipoDocumento = tipoDocumentos.FirstOrDefault(x => x.Id == item.IdTipoDocumento).Codigo;
				var documentoDTO = _mapper.Map<ObtenerDocumentoDTO>(item);
				documentoDTO.TipoDocumento = codigoTipoDocumento;
				documentoDTO.DescMedioPago = medioPagos.FirstOrDefault(x => x.Id == item.MedioPagoDocumento.IdTipoMedioPago).Descripcion;
				documentosDTO.Add(documentoDTO);
			}

			return documentosDTO;
		}

		public Task<bool> ExisteDocumentoUsuario(string login)
		{
			return _siheContexto.RepositorioDocumento.ExisteDocumentoUsuario(login);
		}

		public async Task AnularDocumento(List<int> ids)
		{
			var documentos = await _siheContexto.RepositorioDocumento.Listar(x => ids.Contains(x.Id));

			foreach (var doc in documentos)
			{
				doc.Estado = ((int)EstadoDocumento.Anulado).ToString();

				if (!string.IsNullOrEmpty(doc.NroPreventa))
				{
					await _siheContexto.RepositorioPreventa.Actualizar(doc.NroPreventa, ((int)EstadoPreventa.Anulado).ToString());
				}

				var citas = await _siheContexto.RepositorioDocumentoCita.Listar(x => x.IdDocumento == doc.Id);
				foreach (var cita in citas)
				{
					await _siheContexto.RepositorioCita.ActualizarCita(cita.IdCita, ((int)EstadoPreventa.Anulado).ToString(), 0, null, null);
					await _siheContexto.RepositorioCita.ActualizarAtencion(cita.IdCita, ((int)EstadoPreventa.Anulado).ToString(), 0);
				}
			}

			await _siheContexto.CommitAsync();
		}

		public async Task<List<ListarDocumentoDTO>> ListarDocumentosParaResumen(DateTime fechaEmision)
		{
			var documentosDTO = new List<ListarDocumentoDTO>();
			var documwntos = await _siheContexto.RepositorioDocumento.ListarDocumentosParaResumen(fechaEmision);
			var tipoDocumentos = await _siheContexto.RepositorioTipoDocumento.Listar();


			foreach (var item in documwntos)
			{
				var codigoTipoDocumento = tipoDocumentos.FirstOrDefault(x => x.Id == item.IdTipoDocumento).Codigo;
				var documentoDTO = _mapper.Map<ListarDocumentoDTO>(item);
				documentoDTO.TipoDocumento = codigoTipoDocumento;
				documentosDTO.Add(documentoDTO);
			}

			return documentosDTO;
		}

		public async Task<List<ListarDocumentoDTO>> ListarDocumentosParaComunicacionBaja(DateTime fechaEmision)
		{
			var documentosDTO = new List<ListarDocumentoDTO>();
			var documwntos = await _siheContexto.RepositorioDocumento.ListarDocumentosParaComunicacionBaja(fechaEmision);
			var tipoDocumentos = await _siheContexto.RepositorioTipoDocumento.Listar();


			foreach (var item in documwntos)
			{
				var codigoTipoDocumento = tipoDocumentos.FirstOrDefault(x => x.Id == item.IdTipoDocumento).Codigo;
				var documentoDTO = _mapper.Map<ListarDocumentoDTO>(item);
				documentoDTO.TipoDocumento = codigoTipoDocumento;
				documentosDTO.Add(documentoDTO);
			}

			return documentosDTO;
		}

	}
}
