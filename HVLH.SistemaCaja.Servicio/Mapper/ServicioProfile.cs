using AutoMapper;
using HVLH.SistemaCaja.Comun;
using HVLH.SistemaCaja.Modelo;
using HVLH.SistemaCaja.Servicio.DTO;
using System;

namespace HVLH.SistemaCaja.Servicio.Mapper
{
	public class ServicioProfile : Profile
	{
		public ServicioProfile()
		{
			CreateMap<Modelo.TipoDocumento, ListarTipoDocumentoDTO>();
			CreateMap<InsertarTipoDocumentoDTO, Modelo.TipoDocumento>();
			CreateMap<Modelo.TipoDocumento, ObtenerTipoDocumentoDTO>();
			CreateMap<TipoDocumentoSerie, ListarTipoDocumentoSerieDTO>();
			CreateMap<InsertarTipoDocumentoSerieDTO, TipoDocumentoSerie>();
			CreateMap<TipoDocumentoSerie, ObtenerTipoDocumentoSerieDTO>();
			CreateMap<PreventaResult, ObtenerPreventaDTO>();
			CreateMap<InsertarDocumentoDTO, Documento>()
				.ForMember(a => a.Detalles, map => map.MapFrom(src => src.Detalle))
				.ForMember(a => a.MedioPagoDocumento, map => map.MapFrom(src => src.MedioPago))
				.ForMember(a => a.Citas, map => map.MapFrom(src => src.Citas));
			CreateMap<DocumentoDetalleDTO, DocumentoDetalle>();
			CreateMap<CuotaDTO, Cuota>();
			CreateMap<DocumentoCitaDTO, DocumentoCita>();
			CreateMap<MedioPagoDocumentoDTO, MedioPagoDocumento>();
			CreateMap<Configuracion, ObtenerConfiguracionDTO>();
			CreateMap<TipoOperacion, ListarTipoOperacionDTO>();
			CreateMap<TipoMedioPago, ListarTipoMedioPagoDTO>();
			CreateMap<CatalogoServicioResult, CatalogoServicioDTO>();
			CreateMap<Documento, ListarDocumentoDTO>();
			CreateMap<Documento, ObtenerDocumentoDTO>()
				.ForMember(a => a.Detalles, map => map.MapFrom(src => src.Detalles))
				.ForMember(a => a.MedioPagoDocumento, map => map.MapFrom(src => src.MedioPagoDocumento))
				.ForMember(a => a.Cuotas, map => map.MapFrom(src => src.Cuotas));
			CreateMap<Cuota, CuotaDTO>();
			CreateMap<DocumentoDetalle, DocumentoDetalleDTO>();
			CreateMap<MedioPagoDocumento, MedioPagoDocumentoDTO>();
			CreateMap<Usuario, ListarUsuarioDTO>();
			CreateMap<Rol, ListarRolDTO>();
			CreateMap<Menu, ListarMenuDTO>();
			CreateMap<Menu, MenusAsociadosDTO>();
			CreateMap<Rol, RolesAsociadosDTO>();
			CreateMap<Paciente, PacienteDTO>();
			CreateMap<Resumen, ObtenerResumenDTO>();
			CreateMap<ResumenDetalle, ObtenerResumenDetalleDTO>()
				.ForMember(a => a.Inafecto, map => map.MapFrom(src => src.Documento.Inafecto))
				.ForMember(a => a.IdDocumento, map => map.MapFrom(src => src.Documento.Id))
				.ForMember(a => a.Exportacion, map => map.MapFrom(src => src.Documento.Exportacion))
				.ForMember(a => a.Numero, map => map.MapFrom(src => src.Documento.Numero))
				.ForMember(a => a.Exonerado, map => map.MapFrom(src => src.Documento.Exonerado))
				.ForMember(a => a.Fecha, map => map.MapFrom(src => src.Documento.Fecha))
				.ForMember(a => a.Gratuito, map => map.MapFrom(src => src.Documento.Gratuito))
				.ForMember(a => a.Gravadas, map => map.MapFrom(src => src.Documento.Gravadas))
				.ForMember(a => a.Igv, map => map.MapFrom(src => src.Documento.Igv))
				.ForMember(a => a.Moneda, map => map.MapFrom(src => src.Documento.Moneda))
				.ForMember(a => a.MontoTotal, map => map.MapFrom(src => src.Documento.MontoTotal))
				.ForMember(a => a.TipoDocumentoCliente, map => map.MapFrom(src => src.Documento.TipoDocumentoCliente))
				.ForMember(a => a.NumeroDocumentoCliente, map => map.MapFrom(src => src.Documento.NumeroDocumentoCliente))
				.ForMember(a => a.RazonSocialCliente, map => map.MapFrom(src => src.Documento.RazonSocialCliente))
				.ForMember(a => a.Enviado, map => map.MapFrom(src => src.Documento.Enviado))
				.ForMember(a => a.NroDocumentoReferencia, map => map.MapFrom(src => src.Documento.NroDocumentoReferencia))
				.ForMember(a => a.TipoDocumentoReferencia, map => map.MapFrom(src => src.Documento.TipoDocumentoReferencia))
				.ForMember(a => a.Estado, map => map.MapFrom(src => Enum.Parse(typeof(EstadoDocumento), src.Documento.Estado)))
				.ForMember(a => a.EstadoResumenDetalle, map => map.MapFrom(src => src.Estado))
				.ForMember(a => a.Serie, map => map.MapFrom(src => src.Documento.Serie));
			CreateMap<GuardarResumenDTO, Resumen>();
			CreateMap<GuardarResumenDetalleDTO, ResumenDetalle>();
			CreateMap<Resumen, ListarResumenDTO>();

			CreateMap<GuardarComunicacionBajaDTO, ComunicacionBaja>();
			CreateMap<GuardarComunicacionBajaDetalleDTO, ComunicacionBajaDetalle>();
			CreateMap<ComunicacionBaja, ListarComunicacionBajaDTO>();
			CreateMap<ComunicacionBaja, ObtenerComunicacionBajaDTO>();
			CreateMap<ComunicacionBajaDetalle, ObtenerComunicacionBajaDetalleDTO>()
				.ForMember(a => a.IdDocumento, map => map.MapFrom(src => src.Documento.Id))
				.ForMember(a => a.Numero, map => map.MapFrom(src => src.Documento.Numero))
				.ForMember(a => a.Motivo, map => map.MapFrom(src => src.Motivo))
				.ForMember(a => a.Fecha, map => map.MapFrom(src => src.Documento.Fecha))
				.ForMember(a => a.Moneda, map => map.MapFrom(src => src.Documento.Moneda))
				.ForMember(a => a.MontoTotal, map => map.MapFrom(src => src.Documento.MontoTotal))
				.ForMember(a => a.NumeroDocumentoCliente, map => map.MapFrom(src => src.Documento.NumeroDocumentoCliente))
				.ForMember(a => a.RazonSocialCliente, map => map.MapFrom(src => src.Documento.RazonSocialCliente))
				.ForMember(a => a.Serie, map => map.MapFrom(src => src.Documento.Serie));
			CreateMap<CitasResult, ListarCitasDTO>();
			CreateMap<GuardarProductoDTO, Producto>();
			CreateMap<Producto, ListarProductoDTO>()
			.ForMember(a => a.UnidadMedida, map => map.MapFrom(src => src.UnidadMedida.Codigo))
			.ForMember(a => a.TipoIgv, map => map.MapFrom(src => src.TipoAfectacionIgv.Codigo));
			CreateMap<Producto, ObtenerProductoDTO>();
			CreateMap<UnidadMedida, UnidadMedidaDTO>()
			.ForMember(a => a.Descripcion, map => map.MapFrom(src => $"{src.Codigo} - {src.Descripcion}"));
			CreateMap<TipoAfectacionIgv, TipoAfectacionIgvDTO>();
			CreateMap<Modelo.TipoMedioPago, ListarTipoMedioPagoDTO>().ReverseMap();



		}
	}
}
