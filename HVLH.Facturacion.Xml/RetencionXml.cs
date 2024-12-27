using HVLH.Facturacion.Comun;
using HVLH.Facturacion.Comun.Datos.Contratos;
using HVLH.Facturacion.Comun.Datos.Modelos;
using HVLH.Facturacion.Estructuras.ComponentesAgregadoComunes;
using HVLH.Facturacion.Estructuras.ComponentesAgregadoSunat;
using HVLH.Facturacion.Estructuras.ComponentesBasicosComunes;
using HVLH.Facturacion.Estructuras.EstandarUbl;
using System;
using System.Linq;

namespace HVLH.Facturacion.Xml
{
	public class RetencionXml : IDocumentoXml
	{
		IEstructuraXml IDocumentoXml.Generar(IDocumentoElectronico request)
		{
			DocumentoRetencion documentoRetencion = (DocumentoRetencion)request;
			Decimal num = documentoRetencion.DocumentosRelacionados.Where<ItemRetencion>((Func<ItemRetencion, bool>)(x => x.TipoDocumento != "07")).Sum<ItemRetencion>((Func<ItemRetencion, Decimal>)(x => x.ImporteRetenido));
			foreach (ItemRetencion documentosRelacionado in documentoRetencion.DocumentosRelacionados)
				;
			Retention retention = new Retention()
			{
				Id = documentoRetencion.IdDocumento,
				IssueDate = documentoRetencion.FechaEmision,
				Signature = new SignatureCac()
				{
					Id = documentoRetencion.IdDocumento,
					SignatoryParty = new SignatoryParty()
					{
						PartyIdentification = new PartyIdentification()
						{
							Id = new PartyIdentificationId()
							{
								Value = documentoRetencion.Emisor.NroDocumento
							}
						},
						PartyName = new PartyName()
						{
							Name = documentoRetencion.Emisor.NombreLegal
						}
					},
					DigitalSignatureAttachment = new DigitalSignatureAttachment()
					{
						ExternalReference = new ExternalReference()
						{
							Uri = documentoRetencion.Emisor.NroDocumento + "-" + documentoRetencion.IdDocumento
						}
					}
				},
				AgentParty = new AgentParty()
				{
					PartyIdentification = new PartyIdentification()
					{
						Id = new PartyIdentificationId()
						{
							SchemeId = documentoRetencion.Emisor.TipoDocumento,
							Value = documentoRetencion.Emisor.NroDocumento
						}
					},
					PartyName = new PartyName()
					{
						Name = documentoRetencion.Emisor.NombreComercial
					},
					PostalAddress = new PostalAddress()
					{
						Id = documentoRetencion.Emisor.Ubigeo,
						StreetName = documentoRetencion.Emisor.Direccion,
						CitySubdivisionName = documentoRetencion.Emisor.Urbanizacion,
						CountrySubentity = documentoRetencion.Emisor.Departamento,
						CityName = documentoRetencion.Emisor.Provincia,
						District = documentoRetencion.Emisor.Distrito,
						Country = new Country()
						{
							IdentificationCode = "PE"
						}
					},
					PartyLegalEntity = new PartyLegalEntity()
					{
						RegistrationName = documentoRetencion.Emisor.NombreLegal
					}
				},
				ReceiverParty = new AgentParty()
				{
					PartyIdentification = new PartyIdentification()
					{
						Id = new PartyIdentificationId()
						{
							SchemeId = documentoRetencion.Receptor.TipoDocumento,
							Value = documentoRetencion.Receptor.NroDocumento
						}
					},
					PartyName = new PartyName()
					{
						Name = documentoRetencion.Receptor.NombreComercial
					},
					PartyLegalEntity = new PartyLegalEntity()
					{
						RegistrationName = documentoRetencion.Receptor.NombreLegal
					}
				},
				SunatRetentionSystemCode = documentoRetencion.RegimenRetencion,
				SunatRetentionPercent = documentoRetencion.TasaRetencion,
				Note = documentoRetencion.Observaciones,
				TotalInvoiceAmount = new PayableAmount()
				{
					CurrencyId = documentoRetencion.Moneda,
					Value = num
				},
				TotalPaid = new PayableAmount()
				{
					CurrencyId = documentoRetencion.Moneda,
					Value = documentoRetencion.ImporteTotalPagado
				}
			};
			foreach (ItemRetencion documentosRelacionado in documentoRetencion.DocumentosRelacionados)
				retention.SunatRetentionDocumentReference.Add(new SunatRetentionDocumentReference()
				{
					Id = new PartyIdentificationId()
					{
						SchemeId = documentosRelacionado.TipoDocumento,
						Value = documentosRelacionado.NroDocumento
					},
					IssueDate = documentosRelacionado.FechaEmision,
					TotalInvoiceAmount = new PayableAmount()
					{
						CurrencyId = documentosRelacionado.MonedaDocumentoRelacionado,
						Value = documentosRelacionado.ImporteTotal
					},
					Payment = new Payment()
					{
						IdPayment = documentosRelacionado.NumeroPago,
						PaidAmount = new PayableAmount()
						{
							CurrencyId = documentosRelacionado.MonedaDocumentoRelacionado,
							Value = documentosRelacionado.ImporteSinRetencion
						},
						PaidDate = documentosRelacionado.FechaPago
					},
					SunatRetentionInformation = new SunatRetentionInformation()
					{
						SunatRetentionAmount = new PayableAmount()
						{
							CurrencyId = "PEN",
							Value = documentosRelacionado.ImporteRetenido
						},
						SunatRetentionDate = documentosRelacionado.FechaRetencion,
						SunatNetTotalPaid = new PayableAmount()
						{
							CurrencyId = "PEN",
							Value = documentosRelacionado.ImporteTotalNeto
						},
						ExchangeRate = new ExchangeRate()
						{
							SourceCurrencyCode = documentosRelacionado.MonedaDocumentoRelacionado,
							TargetCurrencyCode = "PEN",
							CalculationRate = documentosRelacionado.TipoCambio,
							Date = documentosRelacionado.FechaTipoCambio
						}
					}
				});
			return (IEstructuraXml)retention;
		}
	}
}
