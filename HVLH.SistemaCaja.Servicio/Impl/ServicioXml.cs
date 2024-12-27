using HVLH.Facturacion.Comun.Datos.Intercambio;
using HVLH.Facturacion.Comun.Datos.Modelos;
using HVLH.Facturacion.Firmas;
using HVLH.Facturacion.Xml;
using HVLH.Facturacion.Xml._2._1;
using HVLH.SistemaCaja.Servicio.Contratos;
using HVLH.SistemaCaja.Servicio.DTO;
using System;
using System.IO;
using FacturaXml = HVLH.Facturacion.Xml._2._1.FacturaXml;
using NotaDebitoXml = HVLH.Facturacion.Xml._2._1.NotaDebitoXml;

namespace HVLH.SistemaCaja.Servicio.Impl
{
	public class ServicioXml : IServicioXml
	{
		private IDocumentoXml _documentoXml;
		private readonly ISerializador _serializador;
		private readonly ICertificador _certificador;

		public ServicioXml(ISerializador serializador, ICertificador certificador)
		{
			_serializador = serializador;
			_certificador = certificador;
		}

		public FirmadoResponse Factura(GenerarXmlDTO generarXmlDTO)
		{
			_documentoXml = new FacturaXml();

			var documentoElectronico = (DocumentoElectronico)generarXmlDTO.Documento;
			var estructuraXml = _documentoXml.Generar(documentoElectronico);

			var tramaXml = _serializador.GenerarXml(estructuraXml);

			var response = _certificador.FirmarXml(new FirmadoRequest
			{
				TramaXmlSinFirma = tramaXml,
				CertificadoDigital = generarXmlDTO.CertificadoDigital,
				PasswordCertificado = generarXmlDTO.PasswordCertificado,
				RucEmisor = documentoElectronico.Emisor.NroDocumento,
				UnSoloNodoExtension = true
			});


			File.WriteAllBytes($"{generarXmlDTO.Ruta}/{documentoElectronico.Emisor.NroDocumento}-{documentoElectronico.TipoDocumento}-{documentoElectronico.IdDocumento}.xml", 
				Convert.FromBase64String(response.TramaXmlFirmado));

			return response;

		}

		public FirmadoResponse NotaCredito(GenerarXmlDTO generarXmlDTO)
		{
			_documentoXml = new NotaCreditoXml();

			var documentoElectronico = (DocumentoElectronico)generarXmlDTO.Documento;
			var estructuraXml = _documentoXml.Generar(documentoElectronico);

			var tramaXml = _serializador.GenerarXml(estructuraXml);

			var response = _certificador.FirmarXml(new FirmadoRequest
			{
				TramaXmlSinFirma = tramaXml,
				CertificadoDigital = generarXmlDTO.CertificadoDigital,
				PasswordCertificado = generarXmlDTO.PasswordCertificado,
				RucEmisor = documentoElectronico.Emisor.NroDocumento,
				UnSoloNodoExtension = true
			});


			File.WriteAllBytes($"{generarXmlDTO.Ruta}/{documentoElectronico.Emisor.NroDocumento}-{documentoElectronico.TipoDocumento}-{documentoElectronico.IdDocumento}.xml",
				Convert.FromBase64String(response.TramaXmlFirmado));

			return response;
		}

		public FirmadoResponse ResumenDiario(GenerarXmlDTO generarXmlDTO)
		{
			_documentoXml = new ResumenDiarioNuevoXml();
			var documentoElectronico = (ResumenDiarioNuevo)generarXmlDTO.Documento;
			var estructuraXml = _documentoXml.Generar(documentoElectronico);

			var tramaXml = _serializador.GenerarXml(estructuraXml);

			var response = _certificador.FirmarXml(new FirmadoRequest
			{
				TramaXmlSinFirma = tramaXml,
				CertificadoDigital = generarXmlDTO.CertificadoDigital,
				PasswordCertificado = generarXmlDTO.PasswordCertificado,
				RucEmisor = documentoElectronico.Emisor.NroDocumento,
				UnSoloNodoExtension = true
			});


			File.WriteAllBytes($"{generarXmlDTO.Ruta}/{documentoElectronico.IdDocumento}.xml",
				Convert.FromBase64String(response.TramaXmlFirmado));

			return response;
		}

		public FirmadoResponse ComunicacionBaja(GenerarXmlDTO generarXmlDTO)
		{
			_documentoXml = new ComunicacionBajaXml();
			var documentoElectronico = (ComunicacionBaja)generarXmlDTO.Documento;
			var estructuraXml = _documentoXml.Generar(documentoElectronico);

			var tramaXml = _serializador.GenerarXml(estructuraXml);

			var response = _certificador.FirmarXml(new FirmadoRequest
			{
				TramaXmlSinFirma = tramaXml,
				CertificadoDigital = generarXmlDTO.CertificadoDigital,
				PasswordCertificado = generarXmlDTO.PasswordCertificado,
				RucEmisor = documentoElectronico.Emisor.NroDocumento,
				UnSoloNodoExtension = true
			});


			File.WriteAllBytes($"{generarXmlDTO.Ruta}/{documentoElectronico.IdDocumento}.xml",
				Convert.FromBase64String(response.TramaXmlFirmado));

			return response;
		}
	}
}
