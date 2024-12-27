using AutoMapper;
using HVLH.SistemaCaja.Comun;
using HVLH.SistemaCaja.Modelo;
using HVLH.SistemaCaja.Repositorio.Contextos;
using HVLH.SistemaCaja.Servicio.Contratos;
using HVLH.SistemaCaja.Servicio.DTO;
using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Servicio.Impl
{
	public class ServicioFacturacion : IServicioFacturacion
	{
		private readonly ISiheContexto _siheContexto;
		private readonly IMapper _mapper;

		public ServicioFacturacion(ISiheContexto siheContexto, IMapper mapper)
		{
			_siheContexto = siheContexto;
			_mapper = mapper;
		}

		public async Task<long> InsertarVenta(InsertarDocumentoDTO insertarDocumentoDTO)
		{

			var documento = _mapper.Map<Documento>(insertarDocumentoDTO);
			documento.UsuarioCreacion = insertarDocumentoDTO.Usuario;
			documento.TotalValorVenta = documento.Inafecto + documento.Gravadas + documento.Exonerado + documento.Exportacion + documento.Gratuito;
			documento.TotalPrecioVenta = documento.MontoTotal;
			documento.FechaCreacion = DateTime.Now;
			var documentoInsertdo = await _siheContexto.RepositorioDocumento.InsertarDocumento(documento);
			documento.Numero = documentoInsertdo.Numero;

			//Detalle
			foreach (var detalle in documento.Detalles)
			{
				detalle.IdDocumento = documentoInsertdo.Id;
				await _siheContexto.RepositorioDocumentoDetalle.Agregar(detalle);
			}

			//Cuotas
			foreach (var cuota in documento.Cuotas)
			{
				cuota.IdDocumento = documentoInsertdo.Id;
				await _siheContexto.RepositorioCuota.Agregar(cuota);
			}

			//Citas
			foreach (var cita in documento.Citas)
			{
				cita.IdDocumento = documentoInsertdo.Id;
				await _siheContexto.RepositorioDocumentoCita.Agregar(cita);
			}

			//Medio pago
			if (documento.MedioPagoDocumento != null)
			{
				documento.MedioPagoDocumento.IdDocumento = documentoInsertdo.Id;
				await _siheContexto.RepositorioMedioPagoDocumento.Agregar(documento.MedioPagoDocumento);
			}

			await _siheContexto.RepositorioPreventa.Actualizar(insertarDocumentoDTO.NroPreventa, ((int)EstadoPreventa.Pagado).ToString());

			foreach (var cita in insertarDocumentoDTO.Citas)
			{
				await _siheContexto.RepositorioCita.ActualizarCita(cita.IdCita, ((int)EstadoPreventa.Pagado).ToString(), documento.MontoTotal, $"{documento.Serie}-{documento.Numero}", documento.Fecha);
				await _siheContexto.RepositorioCita.ActualizarAtencion(cita.IdCita, ((int)EstadoPreventa.Pagado).ToString(), documento.MontoTotal);
			}

			await _siheContexto.CommitAsync();
			return documento.Numero;
		}

		private async Task<CorrelativoSerie> ObtenerNumeroCorrelativo(int idTipoDocumentoSerie, string usuario)
		{
			var existeCorrelativoSerie = await _siheContexto.RepositorioCorrelativoSerie.Existe(idTipoDocumentoSerie);

			if (!existeCorrelativoSerie)
			{
				await _siheContexto.RepositorioCorrelativoSerie.Agregar(new CorrelativoSerie
				{
					FechaCreacion = DateTime.Now,
					IdTipoDocumentoSerie = idTipoDocumentoSerie,
					Numero = 1,
					UsuarioCreacion = usuario,
				});

				await _siheContexto.CommitAsync();

			}

			return await _siheContexto.RepositorioCorrelativoSerie.Obtener(x => x.IdTipoDocumentoSerie == idTipoDocumentoSerie);
		}


	}
}
