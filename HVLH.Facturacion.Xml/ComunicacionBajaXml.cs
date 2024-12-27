using HVLH.Facturacion.Comun;
using HVLH.Facturacion.Comun.Datos.Contratos;
using HVLH.Facturacion.Comun.Datos.Modelos;
using HVLH.Facturacion.Estructuras.ComponentesAgregadoComunes;
using HVLH.Facturacion.Estructuras.ComponentesAgregadoSunat;
using HVLH.Facturacion.Estructuras.ComponentesBasicosComunes;
using HVLH.Facturacion.Estructuras.EstandarUbl;
using System;

namespace HVLH.Facturacion.Xml
{
	public class ComunicacionBajaXml : IDocumentoXml
	{
		IEstructuraXml IDocumentoXml.Generar(IDocumentoElectronico request)
		{
			ComunicacionBaja comunicacionBaja = (ComunicacionBaja)request;
			VoidedDocuments voidedDocuments = new VoidedDocuments()
			{
				Id = comunicacionBaja.IdDocumento,
				IssueDate = Convert.ToDateTime(comunicacionBaja.FechaEmision),
				ReferenceDate = Convert.ToDateTime(comunicacionBaja.FechaReferencia),
				CustomizationId = "1.0",
				UblVersionId = "2.0",
				Signature = new SignatureCac()
				{
					Id = "Sign" + comunicacionBaja.Emisor.NroDocumento,
					SignatoryParty = new SignatoryParty()
					{
						PartyIdentification = new PartyIdentification()
						{
							Id = new PartyIdentificationId()
							{
								Value = comunicacionBaja.Emisor.NroDocumento
							}
						},
						PartyName = new PartyName()
						{
							Name = comunicacionBaja.Emisor.NombreLegal
						}
					},
					DigitalSignatureAttachment = new DigitalSignatureAttachment()
					{
						ExternalReference = new ExternalReference()
						{
							Uri = "#Sign" + comunicacionBaja.Emisor.NroDocumento
						}
					}
				},
				AccountingSupplierParty = new AccountingSupplierParty()
				{
					CustomerAssignedAccountId = comunicacionBaja.Emisor.NroDocumento,
					AdditionalAccountId = comunicacionBaja.Emisor.TipoDocumento,
					Party = new Party()
					{
						PartyLegalEntity = new PartyLegalEntity()
						{
							RegistrationName = comunicacionBaja.Emisor.NombreLegal
						}
					}
				}
			};
			foreach (DocumentoBaja baja in comunicacionBaja.Bajas)
				voidedDocuments.VoidedDocumentsLines.Add(new VoidedDocumentsLine()
				{
					LineId = baja.Id,
					DocumentTypeCode = baja.TipoDocumento,
					DocumentSerialId = baja.Serie,
					DocumentNumberId = Convert.ToInt32(baja.Correlativo),
					VoidReasonDescription = baja.MotivoBaja
				});
			return (IEstructuraXml)voidedDocuments;
		}
	}
}
