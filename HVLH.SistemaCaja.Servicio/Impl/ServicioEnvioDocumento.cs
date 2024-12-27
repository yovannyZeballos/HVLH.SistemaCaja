using HVLH.Facturacion.Comun.Datos.Intercambio;
using HVLH.Facturacion.Comun.Datos.Modelos;
using HVLH.Facturacion.Firmas;
using HVLH.Facturacion.Servicio;
using HVLH.SistemaCaja.Comun;
using HVLH.SistemaCaja.Repositorio.Contextos;
using HVLH.SistemaCaja.Servicio.Contratos;
using HVLH.SistemaCaja.Servicio.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Servicio.Impl
{
	public class ServicioEnvioDocumento : IServicioEnvioDocumento
	{
		private readonly ISiheContexto _siheContexto;
		private readonly IServicioDocumento _servicioDocumento;
		private readonly IServicioResumen _servicioResumen;
		private readonly IServicioComunicacionBaja _servicioComunicacionBaja;
		private readonly IServicioConfiguracion _servicioConfiguracion;
		private readonly IServicioXml _servicioXml;
		private readonly ISerializador _serializador;
		private readonly IServicioSunatDocumentos _servicioSunatDocumentos;
		private readonly IServicioSunatConsultas _servicioSunatConsultas;
		private ObtenerConfiguracionDTO _configuracion;

		public ServicioEnvioDocumento(IServicioDocumento servicioDocumento, IServicioConfiguracion servicioConfiguracion,
			IServicioXml servicioXml, ISerializador serializador, IServicioSunatDocumentos servicioSunatDocumentos,
			ISiheContexto siheContexto, IServicioResumen servicioResumen, IServicioSunatConsultas servicioSunatConsultas, 
			IServicioComunicacionBaja servicioComunicacionBaja)
		{
			_servicioDocumento = servicioDocumento;
			_servicioConfiguracion = servicioConfiguracion;
			_servicioXml = servicioXml;
			_serializador = serializador;
			_servicioSunatDocumentos = servicioSunatDocumentos;
			_siheContexto = siheContexto;
			_servicioResumen = servicioResumen;
			_servicioSunatConsultas = servicioSunatConsultas;
			_servicioComunicacionBaja = servicioComunicacionBaja;
		}

		public async Task<EnviarDocumentoResponse> Enviar(EnvioDocumentoDTO envioDocumentoDTO)
		{
			var documentoResponse = new EnviarDocumentoResponse
			{
				Exito = true
			};

			_configuracion = await _servicioConfiguracion.Obtener();

			string tramaXml;
			string nombreArchivo = $"{_configuracion.Ruc}-{envioDocumentoDTO.TipoDocumento}-{envioDocumentoDTO.Serie}-{envioDocumentoDTO.Numero}";
			string rutaArchivo = $"{_configuracion.CarpetaDocumentos}/XML/{nombreArchivo}.xml";


			if (File.Exists(rutaArchivo))
				tramaXml = Convert.ToBase64String(File.ReadAllBytes(rutaArchivo));
			else
				tramaXml = await GenerarXml(envioDocumentoDTO.IdDoumento);

			var tramaZip = _serializador.GenerarZip(tramaXml, nombreArchivo);

			_servicioSunatDocumentos.Inicializar(new ParametrosConexion
			{
				EndPointUrl = _configuracion.UrlEnvio,
				Password = _configuracion.ClaveSol,
				Ruc = _configuracion.Ruc,
				UserName = _configuracion.UsuarioSol
			});

			var respuesta = _servicioSunatDocumentos.EnviarDocumento(new DocumentoSunat
			{
				TramaXml = tramaZip,
				NombreArchivo = $"{nombreArchivo}.zip"
			});

			if (!respuesta.Exito)
			{
				documentoResponse.Exito = false;
				documentoResponse.MensajeError = respuesta.MensajeError;
				return documentoResponse;
			}

			if (string.IsNullOrEmpty(respuesta.ConstanciaDeRecepcion))
			{
				documentoResponse.Exito = true;
				documentoResponse.MensajeError = "No se pudo obtener el CDR del documento";
				return documentoResponse;
			}

			File.WriteAllBytes($"{_configuracion.CarpetaDocumentos}/CDR/{nombreArchivo}.zip", Convert.FromBase64String(respuesta.ConstanciaDeRecepcion));
			documentoResponse = _serializador.GenerarDocumentoRespuesta(respuesta.ConstanciaDeRecepcion);

			var documento = await _siheContexto.RepositorioDocumento.Obtener(x => x.Id == envioDocumentoDTO.IdDoumento);
			documento.UsuarioModificacion = envioDocumentoDTO.Usuario;
			documento.FechaModificacion = DateTime.Now;
			documento.Estado = ((int)EstadoDocumento.Aceptado).ToString();
			documento.Enviado = true;
			await _siheContexto.CommitAsync();

			return documentoResponse;
		}

		public async Task<EnviarResumenResponse> EnviarResumen(EnvioResumenDocumentoDTO envioDocumentoDTO)
		{
			var documentoResponse = new EnviarResumenResponse
			{
				Exito = true
			};

			_configuracion = await _servicioConfiguracion.Obtener();

			string tramaXml;
			string nombreArchivo = $"{_configuracion.Ruc}-{envioDocumentoDTO.TipoResumen}-{envioDocumentoDTO.NumeroResumen}";
			string rutaArchivo = $"{_configuracion.CarpetaDocumentos}/XML/{nombreArchivo}.xml";


			tramaXml = await GenerarXmlResumen(envioDocumentoDTO.IdResumen);

			var tramaZip = _serializador.GenerarZip(tramaXml, nombreArchivo);

			_servicioSunatDocumentos.Inicializar(new ParametrosConexion
			{
				EndPointUrl = _configuracion.UrlEnvio,
				Password = _configuracion.ClaveSol,
				Ruc = _configuracion.Ruc,
				UserName = _configuracion.UsuarioSol
			});

			var respuesta = _servicioSunatDocumentos.EnviarResumen(new DocumentoSunat
			{
				TramaXml = tramaZip,
				NombreArchivo = $"{nombreArchivo}.zip"
			});

			var resumen = await _siheContexto.RepositorioResumen.Obtener(x => x.Id == envioDocumentoDTO.IdResumen);

			if (!respuesta.Exito)
			{
				documentoResponse.Exito = false;
				documentoResponse.MensajeError = respuesta.MensajeError;
				resumen.Estado = EstadoResumen.Rechazado;
				resumen.Respuesta = respuesta.MensajeError;
				await _siheContexto.CommitAsync();
				return documentoResponse;
			}

			if (string.IsNullOrEmpty(respuesta.NumeroTicket))
			{
				documentoResponse.Exito = true;
				documentoResponse.MensajeError = "No se pudo obtener el numero de ticket";
				resumen.Estado = EstadoResumen.Rechazado;
				resumen.Respuesta = documentoResponse.MensajeError;
				await _siheContexto.CommitAsync();
				return documentoResponse;
			}
			documentoResponse.NroTicket = respuesta.NumeroTicket;
			resumen.Estado = EstadoResumen.Enviado;
			resumen.Ticket = respuesta.NumeroTicket;
			resumen.Respuesta = "";
			await _siheContexto.CommitAsync();

			return documentoResponse;
		}

		public async Task<EnviarDocumentoResponse> ConsultarTicketResumen(ConsultarTicketDTO consultarTicket)
		{
			var documentoResponse = new EnviarDocumentoResponse
			{
				Exito = true
			};

			_configuracion = await _servicioConfiguracion.Obtener();

			string nombreArchivo = $"{_configuracion.Ruc}-{consultarTicket.Tipo}-{consultarTicket.Numero}";

			_servicioSunatDocumentos.Inicializar(new ParametrosConexion
			{
				EndPointUrl = _configuracion.UrlEnvio,
				Password = _configuracion.ClaveSol,
				Ruc = _configuracion.Ruc,
				UserName = _configuracion.UsuarioSol
			});

			var respuesta = _servicioSunatDocumentos.ConsultarTicket(consultarTicket.Ticket);
			var resumen = await _siheContexto.RepositorioResumen.Obtener(consultarTicket.Id);

			if (!respuesta.Exito)
			{
				documentoResponse.Exito = false;
				documentoResponse.MensajeError = respuesta.MensajeError;
				resumen.Estado = EstadoResumen.Rechazado;
				resumen.Respuesta = documentoResponse.MensajeError;
				await _siheContexto.CommitAsync();
				return documentoResponse;
			}

			if (string.IsNullOrEmpty(respuesta.ConstanciaDeRecepcion))
			{
				documentoResponse.Exito = true;
				documentoResponse.MensajeError = "No se pudo obtener el CDR";
				resumen.Estado = EstadoResumen.Rechazado;
				resumen.Respuesta = documentoResponse.MensajeError;
				await _siheContexto.CommitAsync();
				return documentoResponse;
			}

			File.WriteAllBytes($"{_configuracion.CarpetaDocumentos}/CDR/{nombreArchivo}.zip", Convert.FromBase64String(respuesta.ConstanciaDeRecepcion));
			documentoResponse = _serializador.GenerarDocumentoRespuesta(respuesta.ConstanciaDeRecepcion);

			resumen.Estado = EstadoResumen.Aceptado;
			resumen.Respuesta = documentoResponse.MensajeRespuesta;
			foreach (var item in resumen.Detalles)
			{
				if (item.Documento.Estado == ((int)EstadoDocumento.Anulado).ToString())
				{
					item.Documento.Estado = ((int)EstadoDocumento.Baja_Aceptada).ToString();
					item.Documento.BajaEnviada = true;
				}
				else
				{
					item.Documento.Estado = ((int)EstadoDocumento.Aceptado).ToString();
					item.Documento.Enviado = true;
				}

			}

			await _siheContexto.CommitAsync();

			return documentoResponse;
		}

		public async Task<EnviarDocumentoResponse> ConsultarTicketComunicacionBaja(ConsultarTicketDTO consultarTicket)
		{
			var documentoResponse = new EnviarDocumentoResponse
			{
				Exito = true
			};

			_configuracion = await _servicioConfiguracion.Obtener();

			string nombreArchivo = $"{_configuracion.Ruc}-{consultarTicket.Tipo}-{consultarTicket.Numero}";

			_servicioSunatDocumentos.Inicializar(new ParametrosConexion
			{
				EndPointUrl = _configuracion.UrlEnvio,
				Password = _configuracion.ClaveSol,
				Ruc = _configuracion.Ruc,
				UserName = _configuracion.UsuarioSol
			});

			var respuesta = _servicioSunatDocumentos.ConsultarTicket(consultarTicket.Ticket);
			var baja = await _siheContexto.RepositorioComunicacionBaja.Obtener(consultarTicket.Id);

			if (!respuesta.Exito)
			{
				documentoResponse.Exito = false;
				documentoResponse.MensajeError = respuesta.MensajeError;
				baja.Estado = EstadoResumen.Rechazado;
				baja.Respuesta = documentoResponse.MensajeError;
				await _siheContexto.CommitAsync();
				return documentoResponse;
			}

			if (string.IsNullOrEmpty(respuesta.ConstanciaDeRecepcion))
			{
				documentoResponse.Exito = true;
				documentoResponse.MensajeError = "No se pudo obtener el CDR";
				baja.Estado = EstadoResumen.Rechazado;
				baja.Respuesta = documentoResponse.MensajeError;
				await _siheContexto.CommitAsync();
				return documentoResponse;
			}

			File.WriteAllBytes($"{_configuracion.CarpetaDocumentos}/CDR/{nombreArchivo}.zip", Convert.FromBase64String(respuesta.ConstanciaDeRecepcion));
			documentoResponse = _serializador.GenerarDocumentoRespuesta(respuesta.ConstanciaDeRecepcion);

			baja.Estado = EstadoResumen.Aceptado;
			baja.Respuesta = documentoResponse.MensajeRespuesta;
			foreach (var item in baja.Detalles)
			{
				item.Documento.Estado = ((int)EstadoDocumento.Baja_Aceptada).ToString();
				item.Documento.BajaEnviada = true;
			}

			await _siheContexto.CommitAsync();

			return documentoResponse;
		}

		public async Task<EnviarResumenResponse> EnviarComunicacion(EnvioComunicacionBajaDTO envioDocumentoDTO)
		{
			var documentoResponse = new EnviarResumenResponse
			{
				Exito = true
			};

			_configuracion = await _servicioConfiguracion.Obtener();

			string tramaXml;
			string nombreArchivo = $"{_configuracion.Ruc}-{envioDocumentoDTO.Tipo}-{envioDocumentoDTO.NumeroComunicacion}";
			string rutaArchivo = $"{_configuracion.CarpetaDocumentos}/XML/{nombreArchivo}.xml";


			tramaXml = await GenerarXmlComunicaionBaja(envioDocumentoDTO.IdComunicacion);

			var tramaZip = _serializador.GenerarZip(tramaXml, nombreArchivo);

			_servicioSunatDocumentos.Inicializar(new ParametrosConexion
			{
				EndPointUrl = _configuracion.UrlEnvio,
				Password = _configuracion.ClaveSol,
				Ruc = _configuracion.Ruc,
				UserName = _configuracion.UsuarioSol
			});

			var respuesta = _servicioSunatDocumentos.EnviarResumen(new DocumentoSunat
			{
				TramaXml = tramaZip,
				NombreArchivo = $"{nombreArchivo}.zip"
			});

			var comunicacion = await _siheContexto.RepositorioComunicacionBaja.Obtener(x => x.Id == envioDocumentoDTO.IdComunicacion);

			if (!respuesta.Exito)
			{
				documentoResponse.Exito = false;
				documentoResponse.MensajeError = respuesta.MensajeError;
				comunicacion.Estado = EstadoResumen.Rechazado;
				comunicacion.Respuesta = respuesta.MensajeError;
				await _siheContexto.CommitAsync();
				return documentoResponse;
			}

			if (string.IsNullOrEmpty(respuesta.NumeroTicket))
			{
				documentoResponse.Exito = true;
				documentoResponse.MensajeError = "No se pudo obtener el numero de ticket";
				comunicacion.Estado = EstadoResumen.Rechazado;
				comunicacion.Respuesta = documentoResponse.MensajeError;
				await _siheContexto.CommitAsync();
				return documentoResponse;
			}
			documentoResponse.NroTicket = respuesta.NumeroTicket;
			comunicacion.Estado = EstadoResumen.Enviado;
			comunicacion.Ticket = respuesta.NumeroTicket;
			comunicacion.Respuesta = "";
			await _siheContexto.CommitAsync();

			return documentoResponse;
		}

		private async Task<string> GenerarXml(int id)
		{

			var documento = await _servicioDocumento.Obtener(id);
			var documentoElectronico = new DocumentoElectronico
			{
				Emisor = new Contribuyente
				{
					Departamento = _configuracion.Departamento,
					Direccion = _configuracion.Direccion,
					Distrito = _configuracion.Distrito,
					Provincia = _configuracion.Provincia,
					Pais = "PE",
					NombreComercial = _configuracion.RazonSocial,
					NombreLegal = _configuracion.RazonSocial,
					NroDocumento = _configuracion.Ruc,
					TipoDocumento = "6",
					Ubigeo = _configuracion.Ubigeo
				},
				Exoneradas = documento.Exonerado,
				Gravadas = documento.Gravadas,
				Exportaciones = documento.Exportacion,
				Inafectas = documento.Inafecto,
				Gratuitas = documento.Gratuito,
				IdDocumento = $"{documento.Serie}-{documento.Numero}",
				TipoDocumento = documento.TipoDocumento,
				FechaEmision = documento.Fecha.ToString("yyyy-MM-dd"),
				FechaVencimiento = documento.Fecha.ToString("yyyy-MM-dd"),
				HoraEmision = documento.Fecha.ToString("HH:mm:ss"),
				TipoOperacion = documento.TipoOperacion,
				TotalVenta = documento.MontoTotal,
				Moneda = documento.Moneda == "S" ? "PEN" : "USD",
				Receptor = new Contribuyente
				{
					NroDocumento = documento.NumeroDocumentoCliente,
					NombreComercial = documento.RazonSocialCliente,
					NombreLegal = documento.RazonSocialCliente,
					TipoDocumento = documento.TipoDocumentoCliente
				},
				TotalIgv = documento.Igv,
				TotalPrecioVenta = documento.TotalPrecioVenta,
				TotalValorVenta = documento.TotalValorVenta,
			};

			if (documento.Cuotas.Count == 0) //Contado
			{
				documentoElectronico.FormaPagos = new List<FormaPago>
					{
						new FormaPago
						{
							Id = "Contado",
						}
					};
			}
			else
			{
				documentoElectronico.FormaPagos = new List<FormaPago>
					{
						new FormaPago
						{
							Id = "Credito",
							Monto = documento.MontoTotal
						}
					};

				foreach (var cuota in documento.Cuotas)
				{
					documentoElectronico.FormaPagos.Add(new FormaPago
					{
						Id = $"Cuota{cuota.Numero:000}",
						FechaVencimiento = cuota.Fecha.ToString("yyyy-MM-dd"),
						Monto = cuota.Monto
					});
				}
			}

			documentoElectronico.Items = new List<DetalleDocumento>();

			foreach (var item in documento.Detalles)
			{
				documentoElectronico.Items.Add(new DetalleDocumento
				{
					CalculoIgv = item.PorcentajeIgv,
					Cantidad = Math.Round(item.Cantidad, 2),
					CodigoItem = item.CodigoProducto,
					Descripcion = item.DescripcionProducto,
					Id = item.Item,
					Impuesto = item.Igv,
					PrecioVentaUnitario = item.PrecioVentaUnitario,
					TipoPrecio = "01",
					TipoImpuesto = item.TipoIgv,
					UnidadMedida = item.UnidadMedida,
					ValorUnitario = item.ValorUnitario,
					ValorVenta = item.ValorVenta
				});
			}

			var response = _servicioXml.Factura(new GenerarXmlDTO
			{
				CertificadoDigital = Convert.ToBase64String(File.ReadAllBytes(_configuracion.RutaCertificado)),
				PasswordCertificado = _configuracion.ClaveCertificado,
				Ruta = $"{_configuracion.CarpetaDocumentos}/XML",
				Documento = documentoElectronico
			});

			if (!response.Exito)
				throw new Exception($"Error al crear el XML - {response.MensajeError}");

			return response.TramaXmlFirmado;

		}

		private async Task<string> GenerarXmlResumen(int idResumen)
		{

			var resumen = await _servicioResumen.ObtenerResumen(idResumen);

			var resumenDiario = new ResumenDiarioNuevo
			{
				Emisor = new Contribuyente
				{
					Departamento = _configuracion.Departamento,
					Direccion = _configuracion.Direccion,
					Distrito = _configuracion.Distrito,
					Provincia = _configuracion.Provincia,
					Pais = "PE",
					NombreComercial = _configuracion.RazonSocial,
					NombreLegal = _configuracion.RazonSocial,
					NroDocumento = _configuracion.Ruc,
					TipoDocumento = "6",
					Ubigeo = _configuracion.Ubigeo
				},
				FechaEmision = resumen.FechaResumen.ToString("yyyy-MM-dd"),
				FechaReferencia = resumen.FechaDocumentos.ToString("yyyy-MM-dd"),
				IdDocumento = $"RC-{resumen.Numero}-{resumen.Correlativo}"
			};

			resumenDiario.Resumenes = new List<GrupoResumenNuevo>();

			int id = 1;
			foreach (var detalle in resumen.Detalles)
			{
				resumenDiario.Resumenes.Add(new GrupoResumenNuevo
				{
					CodigoEstadoItem = detalle.Estado == EstadoDocumento.Anulado ? 3 : 1,
					DocumentoRelacionado = detalle.NroDocumentoReferencia,
					Exoneradas = detalle.Exonerado,
					Exportacion = detalle.Exportacion,
					Gratuitas = detalle.Gratuito,
					Gravadas = detalle.Gravadas,
					Id = id,
					IdDocumento = $"{detalle.Serie}-{detalle.Numero}",
					Inafectas = detalle.Inafecto,
					Moneda = detalle.Moneda == "S" ? "PEN" : "USD",
					Serie = detalle.Serie,
					NroDocumentoReceptor = detalle.NumeroDocumentoCliente,
					TipoDocumento = detalle.TipoDocumento,
					TipoDocumentoReceptor = detalle.TipoDocumentoCliente,
					TipoDocumentoRelacionado = detalle.TipoDocumentoReferencia,
					TotalDescuentos = 0,
					TotalIgv = detalle.Igv,
					TotalIsc = 0,
					TotalOtrosImpuestos = 0,
					TotalVenta = detalle.MontoTotal
				});
				id++;
			}


			var response = _servicioXml.ResumenDiario(new GenerarXmlDTO
			{
				CertificadoDigital = Convert.ToBase64String(File.ReadAllBytes(_configuracion.RutaCertificado)),
				PasswordCertificado = _configuracion.ClaveCertificado,
				Ruta = $"{_configuracion.CarpetaDocumentos}/XML",
				Documento = resumenDiario
			});

			if (!response.Exito)
				throw new Exception($"Error al crear el XML - {response.MensajeError}");

			return response.TramaXmlFirmado;

		}

		private async Task<string> GenerarXmlComunicaionBaja(int idComunicacion)
		{

			var comunicacion = await _servicioComunicacionBaja.ObtenerComunicacion(idComunicacion);

			var comunicacionBaja = new ComunicacionBaja
			{
				Emisor = new Contribuyente
				{
					Departamento = _configuracion.Departamento,
					Direccion = _configuracion.Direccion,
					Distrito = _configuracion.Distrito,
					Provincia = _configuracion.Provincia,
					Pais = "PE",
					NombreComercial = _configuracion.RazonSocial,
					NombreLegal = _configuracion.RazonSocial,
					NroDocumento = _configuracion.Ruc,
					TipoDocumento = "6",
					Ubigeo = _configuracion.Ubigeo
				},
				FechaEmision = comunicacion.FechaBaja.ToString("yyyy-MM-dd"),
				FechaReferencia = comunicacion.FechaDocumentos.ToString("yyyy-MM-dd"),
				IdDocumento = $"RA-{comunicacion.Numero}-{comunicacion.Correlativo}"
			};

			comunicacionBaja.Bajas = new List<DocumentoBaja>();

			int id = 1;
			foreach (var detalle in comunicacion.Detalles)
			{
				comunicacionBaja.Bajas.Add(new DocumentoBaja
				{
					Id = id,
					Serie = detalle.Serie,
					TipoDocumento = detalle.TipoDocumento,
					Correlativo = detalle.Numero.ToString(),
					MotivoBaja = detalle.Motivo
				});
				id++;
			}


			var response = _servicioXml.ComunicacionBaja(new GenerarXmlDTO
			{
				CertificadoDigital = Convert.ToBase64String(File.ReadAllBytes(_configuracion.RutaCertificado)),
				PasswordCertificado = _configuracion.ClaveCertificado,
				Ruta = $"{_configuracion.CarpetaDocumentos}/XML",
				Documento = comunicacionBaja
			});

			if (!response.Exito)
				throw new Exception($"Error al crear el XML - {response.MensajeError}");

			return response.TramaXmlFirmado;

		}

		
	}
}
