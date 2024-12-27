using HVLH.Facturacion.Comun;
using HVLH.Facturacion.Comun.Datos.Contratos;
using HVLH.Facturacion.Comun.Datos.Modelos;
using HVLH.Facturacion.Estructuras.ComponentesAgregadoComunes;
using HVLH.Facturacion.Estructuras.ComponentesAgregadoSunat;
using HVLH.Facturacion.Estructuras.ComponentesBasicosComunes;
using HVLH.Facturacion.Estructuras.EstandarUbl;
using System;
using System.Collections.Generic;

namespace HVLH.Facturacion.Xml
{
	public class ResumenDiarioXml : IDocumentoXml
	{
		IEstructuraXml IDocumentoXml.Generar(IDocumentoElectronico request)
		{
			ResumenDiario resumenDiario = (ResumenDiario)request;
			SummaryDocuments summaryDocuments = new SummaryDocuments()
			{
				Id = resumenDiario.IdDocumento,
				IssueDate = Convert.ToDateTime(resumenDiario.FechaEmision),
				ReferenceDate = Convert.ToDateTime(resumenDiario.FechaReferencia),
				CustomizationId = "1.0",
				UblVersionId = "2.0",
				Signature = new SignatureCac()
				{
					Id = resumenDiario.IdDocumento,
					SignatoryParty = new SignatoryParty()
					{
						PartyIdentification = new PartyIdentification()
						{
							Id = new PartyIdentificationId()
							{
								Value = resumenDiario.Emisor.NroDocumento
							}
						},
						PartyName = new PartyName()
						{
							Name = resumenDiario.Emisor.NombreLegal
						}
					},
					DigitalSignatureAttachment = new DigitalSignatureAttachment()
					{
						ExternalReference = new ExternalReference()
						{
							Uri = resumenDiario.Emisor.NroDocumento + "-" + resumenDiario.IdDocumento
						}
					}
				},
				AccountingSupplierParty = new AccountingSupplierParty()
				{
					CustomerAssignedAccountId = resumenDiario.Emisor.NroDocumento,
					AdditionalAccountId = resumenDiario.Emisor.TipoDocumento,
					Party = new Party()
					{
						PartyLegalEntity = new PartyLegalEntity()
						{
							RegistrationName = resumenDiario.Emisor.NombreLegal
						}
					}
				}
			};
			foreach (GrupoResumen resumene in resumenDiario.Resumenes)
			{
				VoidedDocumentsLine voidedDocumentsLine = new VoidedDocumentsLine()
				{
					LineId = resumene.Id,
					DocumentTypeCode = resumene.TipoDocumento,
					DocumentSerialId = resumene.Serie,
					StartDocumentNumberId = resumene.CorrelativoInicio,
					EndDocumentNumberId = resumene.CorrelativoFin,
					TotalAmount = new PayableAmount()
					{
						CurrencyId = resumene.Moneda,
						Value = resumene.TotalVenta
					},
					BillingPayments = new List<BillingPayment>()
		  {
			new BillingPayment()
			{
			  PaidAmount = new PayableAmount()
			  {
				CurrencyId = resumene.Moneda,
				Value = resumene.Gravadas
			  },
			  InstructionId = "01"
			},
			new BillingPayment()
			{
			  PaidAmount = new PayableAmount()
			  {
				CurrencyId = resumene.Moneda,
				Value = resumene.Exoneradas
			  },
			  InstructionId = "02"
			},
			new BillingPayment()
			{
			  PaidAmount = new PayableAmount()
			  {
				CurrencyId = resumene.Moneda,
				Value = resumene.Inafectas
			  },
			  InstructionId = "03"
			}
		  },
					AllowanceCharge = new AllowanceCharge()
					{
						ChargeIndicator = true,
						Amount = new PayableAmount()
						{
							CurrencyId = resumene.Moneda,
							Value = resumene.TotalDescuentos
						}
					},
					TaxTotals = new List<TaxTotal>()
		  {
			new TaxTotal()
			{
			  TaxAmount = new PayableAmount()
			  {
				CurrencyId = resumene.Moneda,
				Value = resumene.TotalIsc
			  },
			  TaxSubtotal = new TaxSubtotal()
			  {
				TaxAmount = new PayableAmount()
				{
				  CurrencyId = resumene.Moneda,
				  Value = resumene.TotalIsc
				},
				TaxCategory = new TaxCategory()
				{
				  TaxScheme = new TaxScheme()
				  {
					Id = "2000",
					Name = "ISC",
					TaxTypeCode = "EXC"
				  }
				}
			  }
			},
			new TaxTotal()
			{
			  TaxAmount = new PayableAmount()
			  {
				CurrencyId = resumene.Moneda,
				Value = resumene.TotalIgv
			  },
			  TaxSubtotal = new TaxSubtotal()
			  {
				TaxAmount = new PayableAmount()
				{
				  CurrencyId = resumene.Moneda,
				  Value = resumene.TotalIgv
				},
				TaxCategory = new TaxCategory()
				{
				  TaxScheme = new TaxScheme()
				  {
					Id = "1000",
					Name = "IGV",
					TaxTypeCode = "VAT"
				  }
				}
			  }
			},
			new TaxTotal()
			{
			  TaxAmount = new PayableAmount()
			  {
				CurrencyId = resumene.Moneda,
				Value = resumene.TotalOtrosImpuestos
			  },
			  TaxSubtotal = new TaxSubtotal()
			  {
				TaxAmount = new PayableAmount()
				{
				  CurrencyId = resumene.Moneda,
				  Value = resumene.TotalOtrosImpuestos
				},
				TaxCategory = new TaxCategory()
				{
				  TaxScheme = new TaxScheme()
				  {
					Id = "9999",
					Name = "OTROS",
					TaxTypeCode = "OTH"
				  }
				}
			  }
			}
		  }
				};
				if (resumene.Exportacion > 0M)
					voidedDocumentsLine.BillingPayments.Add(new BillingPayment()
					{
						PaidAmount = new PayableAmount()
						{
							CurrencyId = resumene.Moneda,
							Value = resumene.Exportacion
						},
						InstructionId = "04"
					});
				if (resumene.Gratuitas > 0M)
					voidedDocumentsLine.BillingPayments.Add(new BillingPayment()
					{
						PaidAmount = new PayableAmount()
						{
							CurrencyId = resumene.Moneda,
							Value = resumene.Gratuitas
						},
						InstructionId = "05"
					});
				summaryDocuments.SummaryDocumentsLines.Add(voidedDocumentsLine);
			}
			return (IEstructuraXml)summaryDocuments;
		}
	}
}
