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
	public class ResumenDiarioNuevoXml : IDocumentoXml
	{
		IEstructuraXml IDocumentoXml.Generar(IDocumentoElectronico request)
		{
			ResumenDiarioNuevo resumenDiarioNuevo = (ResumenDiarioNuevo)request;
			SummaryDocuments summaryDocuments = new SummaryDocuments()
			{
				Id = resumenDiarioNuevo.IdDocumento,
				IssueDate = Convert.ToDateTime(resumenDiarioNuevo.FechaEmision),
				ReferenceDate = Convert.ToDateTime(resumenDiarioNuevo.FechaReferencia),
				CustomizationId = "1.1",
				UblVersionId = "2.0",
				Signature = new SignatureCac()
				{
					Id = resumenDiarioNuevo.IdDocumento,
					SignatoryParty = new SignatoryParty()
					{
						PartyIdentification = new PartyIdentification()
						{
							Id = new PartyIdentificationId()
							{
								Value = resumenDiarioNuevo.Emisor.NroDocumento
							}
						},
						PartyName = new PartyName()
						{
							Name = resumenDiarioNuevo.Emisor.NombreLegal
						}
					},
					DigitalSignatureAttachment = new DigitalSignatureAttachment()
					{
						ExternalReference = new ExternalReference()
						{
							Uri = resumenDiarioNuevo.Emisor.NroDocumento + "-" + resumenDiarioNuevo.IdDocumento
						}
					}
				},
				AccountingSupplierParty = new AccountingSupplierParty()
				{
					CustomerAssignedAccountId = resumenDiarioNuevo.Emisor.NroDocumento,
					AdditionalAccountId = resumenDiarioNuevo.Emisor.TipoDocumento,
					Party = new Party()
					{
						PartyLegalEntity = new PartyLegalEntity()
						{
							RegistrationName = resumenDiarioNuevo.Emisor.NombreLegal
						}
					}
				}
			};
			foreach (GrupoResumenNuevo resumene in resumenDiarioNuevo.Resumenes)
			{
				VoidedDocumentsLine voidedDocumentsLine = new VoidedDocumentsLine()
				{
					LineId = resumene.Id,
					DocumentTypeCode = resumene.TipoDocumento,
					Id = resumene.IdDocumento,
					AccountingCustomerParty = new AccountingSupplierParty()
					{
						AdditionalAccountId = resumene.TipoDocumentoReceptor,
						CustomerAssignedAccountId = resumene.NroDocumentoReceptor
					},
					BillingReference = new BillingReference()
					{
						InvoiceDocumentReference = new InvoiceDocumentReference()
						{
							Id = resumene.DocumentoRelacionado,
							DocumentTypeCode = resumene.TipoDocumentoRelacionado
						}
					},
					ConditionCode = new int?(resumene.CodigoEstadoItem),
					TotalAmount = new PayableAmount()
					{
						CurrencyId = resumene.Moneda,
						Value = resumene.TotalVenta
					},
					AllowanceCharge = new AllowanceCharge()
					{
						ChargeIndicator = true,
						Amount = new PayableAmount()
						{
							CurrencyId = resumene.Moneda,
							Value = resumene.TotalDescuentos
						}
					}
				};
				if (resumene.Gravadas > 0M)
					voidedDocumentsLine.BillingPayments.Add(new BillingPayment()
					{
						PaidAmount = new PayableAmount()
						{
							CurrencyId = resumene.Moneda,
							Value = resumene.Gravadas
						},
						InstructionId = "01"
					});
				if (resumene.Exoneradas > 0M)
					voidedDocumentsLine.BillingPayments.Add(new BillingPayment()
					{
						PaidAmount = new PayableAmount()
						{
							CurrencyId = resumene.Moneda,
							Value = resumene.Exoneradas
						},
						InstructionId = "02"
					});
				if (resumene.Inafectas > 0M)
					voidedDocumentsLine.BillingPayments.Add(new BillingPayment()
					{
						PaidAmount = new PayableAmount()
						{
							CurrencyId = resumene.Moneda,
							Value = resumene.Inafectas
						},
						InstructionId = "03"
					});
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
				if (resumene.TotalIsc > 0M)
					voidedDocumentsLine.TaxTotals.Add(new TaxTotal()
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
					});
				voidedDocumentsLine.TaxTotals.Add(new TaxTotal()
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
				});
				if (resumene.TotalOtrosImpuestos > 0M)
					voidedDocumentsLine.TaxTotals.Add(new TaxTotal()
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
					});
				summaryDocuments.SummaryDocumentsLines.Add(voidedDocumentsLine);
			}
			return (IEstructuraXml)summaryDocuments;
		}
	}
}
