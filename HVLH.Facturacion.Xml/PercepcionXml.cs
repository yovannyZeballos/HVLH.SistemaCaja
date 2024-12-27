using HVLH.Facturacion.Comun;
using HVLH.Facturacion.Comun.Datos.Contratos;
using HVLH.Facturacion.Comun.Datos.Modelos;
using HVLH.Facturacion.Estructuras.ComponentesAgregadoComunes;
using HVLH.Facturacion.Estructuras.ComponentesAgregadoSunat;
using HVLH.Facturacion.Estructuras.ComponentesBasicosComunes;
using HVLH.Facturacion.Estructuras.EstandarUbl;

namespace HVLH.Facturacion.Xml
{
	public class PercepcionXml : IDocumentoXml
	{
		IEstructuraXml IDocumentoXml.Generar(IDocumentoElectronico request)
		{
			DocumentoPercepcion documentoPercepcion = (DocumentoPercepcion)request;
			Perception perception = new Perception()
			{
				Id = documentoPercepcion.IdDocumento,
				IssueDate = documentoPercepcion.FechaEmision,
				Signature = new SignatureCac()
				{
					Id = documentoPercepcion.IdDocumento,
					SignatoryParty = new SignatoryParty()
					{
						PartyIdentification = new PartyIdentification()
						{
							Id = new PartyIdentificationId()
							{
								Value = documentoPercepcion.Emisor.NroDocumento
							}
						},
						PartyName = new PartyName()
						{
							Name = documentoPercepcion.Emisor.NombreLegal
						}
					},
					DigitalSignatureAttachment = new DigitalSignatureAttachment()
					{
						ExternalReference = new ExternalReference()
						{
							Uri = documentoPercepcion.Emisor.NroDocumento + "-" + documentoPercepcion.IdDocumento
						}
					}
				},
				AgentParty = new AgentParty()
				{
					PartyIdentification = new PartyIdentification()
					{
						Id = new PartyIdentificationId()
						{
							SchemeId = documentoPercepcion.Emisor.TipoDocumento,
							Value = documentoPercepcion.Emisor.NroDocumento
						}
					},
					PartyName = new PartyName()
					{
						Name = documentoPercepcion.Emisor.NombreComercial
					},
					PostalAddress = new PostalAddress()
					{
						Id = documentoPercepcion.Emisor.Ubigeo,
						StreetName = documentoPercepcion.Emisor.Direccion,
						CitySubdivisionName = documentoPercepcion.Emisor.Urbanizacion,
						CountrySubentity = documentoPercepcion.Emisor.Departamento,
						CityName = documentoPercepcion.Emisor.Provincia,
						District = documentoPercepcion.Emisor.Distrito,
						Country = new Country()
						{
							IdentificationCode = "PE"
						}
					},
					PartyLegalEntity = new PartyLegalEntity()
					{
						RegistrationName = documentoPercepcion.Emisor.NombreLegal
					}
				},
				ReceiverParty = new AgentParty()
				{
					PartyIdentification = new PartyIdentification()
					{
						Id = new PartyIdentificationId()
						{
							SchemeId = documentoPercepcion.Emisor.TipoDocumento,
							Value = documentoPercepcion.Emisor.NroDocumento
						}
					},
					PartyName = new PartyName()
					{
						Name = documentoPercepcion.Emisor.NombreComercial
					},
					PostalAddress = new PostalAddress()
					{
						Id = documentoPercepcion.Emisor.Ubigeo,
						StreetName = documentoPercepcion.Emisor.Direccion,
						CitySubdivisionName = documentoPercepcion.Emisor.Urbanizacion,
						CountrySubentity = documentoPercepcion.Emisor.Departamento,
						CityName = documentoPercepcion.Emisor.Provincia,
						District = documentoPercepcion.Emisor.Distrito,
						Country = new Country()
						{
							IdentificationCode = "PE"
						}
					},
					PartyLegalEntity = new PartyLegalEntity()
					{
						RegistrationName = documentoPercepcion.Emisor.NombreLegal
					}
				},
				SunatPerceptionSystemCode = documentoPercepcion.RegimenPercepcion,
				SunatPerceptionPercent = documentoPercepcion.TasaPercepcion,
				Note = documentoPercepcion.Observaciones,
				TotalInvoiceAmount = new PayableAmount()
				{
					CurrencyId = documentoPercepcion.Moneda,
					Value = documentoPercepcion.ImporteTotalPercibido
				},
				TotalPaid = new PayableAmount()
				{
					CurrencyId = documentoPercepcion.Moneda,
					Value = documentoPercepcion.ImporteTotalCobrado
				}
			};
			foreach (ItemPercepcion documentosRelacionado in documentoPercepcion.DocumentosRelacionados)
				perception.SunatPerceptionDocumentReference.Add(new SunatRetentionDocumentReference()
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
							Value = documentosRelacionado.ImporteSinPercepcion
						},
						PaidDate = documentosRelacionado.FechaPago
					},
					SunatRetentionInformation = new SunatRetentionInformation()
					{
						SunatRetentionAmount = new PayableAmount()
						{
							CurrencyId = documentoPercepcion.Moneda,
							Value = documentosRelacionado.ImportePercibido
						},
						SunatRetentionDate = documentosRelacionado.FechaPercepcion,
						SunatNetTotalPaid = new PayableAmount()
						{
							CurrencyId = documentoPercepcion.Moneda,
							Value = documentosRelacionado.ImporteTotalNeto
						},
						ExchangeRate = new ExchangeRate()
						{
							SourceCurrencyCode = documentosRelacionado.MonedaDocumentoRelacionado,
							TargetCurrencyCode = documentoPercepcion.Moneda,
							CalculationRate = documentosRelacionado.TipoCambio,
							Date = documentosRelacionado.FechaTipoCambio
						}
					}
				});
			return (IEstructuraXml)perception;
		}
	}
}
