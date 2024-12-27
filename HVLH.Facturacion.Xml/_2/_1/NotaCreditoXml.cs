using HVLH.Facturacion.Comun;
using HVLH.Facturacion.Comun.Datos.Contratos;
using HVLH.Facturacion.Comun.Datos.Modelos;
using HVLH.Facturacion.Estructuras.ComponentesAgregadoComunes;
using HVLH.Facturacion.Estructuras.ComponentesBasicosComunes;
using HVLH.Facturacion.Estructuras.EstandarUbl2._1;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HVLH.Facturacion.Xml._2._1
{
	public class NotaCreditoXml : IDocumentoXml
	{
		public IEstructuraXml Generar(IDocumentoElectronico request)
		{
			DocumentoElectronico documentoElectronico = (DocumentoElectronico)request;
			CreditNote creditNote = new CreditNote();
			creditNote.Id = documentoElectronico.IdDocumento;
			creditNote.InvoiceTypeCode = new InvoiceTypeCode()
			{
				Value = documentoElectronico.TipoDocumento,
				ListID = documentoElectronico.TipoOperacion
			};
			creditNote.IssueDate = DateTime.Parse(documentoElectronico.FechaEmision);
			creditNote.IssueTime = TimeSpan.Parse(documentoElectronico.HoraEmision);
			creditNote.DocumentCurrencyCode = documentoElectronico.Moneda;
			creditNote.LineCountNumeric = documentoElectronico.Items.Count.ToString();
			creditNote.OrderReference = documentoElectronico.OrdenCompra;
			Note note1 = new Note()
			{
				LanguajeLocaleID = "1000",
				Value = string.Format("SON: {0} {1}.", (object)NumLetra.Convertir(documentoElectronico.TotalVenta.ToString("###0.#0"), true), documentoElectronico.Moneda == "USD" ? (object)"DOLARES AMERICANOS" : (object)"SOLES")
			};
			creditNote.Notes.Add(note1);
			if (documentoElectronico.Gratuitas > 0M && documentoElectronico.TipoOperacion != "02" && (documentoElectronico.TipoOperacion != "0200" && documentoElectronico.TipoOperacion != "0201") && (documentoElectronico.TipoOperacion != "0202" && documentoElectronico.TipoOperacion != "0203" && (documentoElectronico.TipoOperacion != "0204" && documentoElectronico.TipoOperacion != "0205")) && (documentoElectronico.TipoOperacion != "0206" && documentoElectronico.TipoOperacion != "0207" && documentoElectronico.TipoOperacion != "0208") && documentoElectronico.Gravadas == 0M)
			{
				Note note2 = new Note()
				{
					LanguajeLocaleID = "1002",
					Value = "TRANSFERENCIA GRATUITA DE UN BIEN Y/O SERVICIO PRESTADO GRATUITAMENTE"
				};
				creditNote.Notes.Add(note2);
			}
			if (documentoElectronico.MontoDetraccion > 0M)
			{
				Note note2 = new Note()
				{
					LanguajeLocaleID = "2006",
					Value = "OPERACIÓN SUJETA A DETRACCIÓN"
				};
				creditNote.Notes.Add(note2);
			}
			foreach (Discrepancia discrepancia in documentoElectronico.Discrepancias)
				creditNote.DiscrepancyResponses.Add(new DiscrepancyResponse()
				{
					ReferenceId = discrepancia.NroReferencia,
					ResponseCode = discrepancia.Tipo,
					Description = discrepancia.Descripcion
				});
			foreach (DocumentoRelacionado relacionado in documentoElectronico.Relacionados)
				creditNote.BillingReferences.Add(new BillingReference()
				{
					InvoiceDocumentReference = new InvoiceDocumentReference()
					{
						Id = relacionado.NroDocumento,
						DocumentTypeCode = relacionado.TipoDocumento
					}
				});
			foreach (DocumentoRelacionado relacionado in documentoElectronico.Relacionados)
				creditNote.AdditionalDocumentReferences.Add(new InvoiceDocumentReference()
				{
					Id = relacionado.NroDocumento,
					DocumentTypeCode = relacionado.TipoDocumento
				});
			creditNote.Signature = new SignatureCac()
			{
				Id = string.Format("#sign{0}", (object)documentoElectronico.Emisor.NroDocumento),
				SignatoryParty = new SignatoryParty()
				{
					PartyIdentification = new PartyIdentification()
					{
						Id = new PartyIdentificationId()
						{
							Value = documentoElectronico.Emisor.NroDocumento
						}
					},
					PartyName = new PartyName()
					{
						Name = documentoElectronico.Emisor.NombreLegal
					}
				},
				DigitalSignatureAttachment = new DigitalSignatureAttachment()
				{
					ExternalReference = new ExternalReference()
					{
						Uri = string.Format("#sign{0}", (object)documentoElectronico.Emisor.NroDocumento)
					}
				}
			};
			creditNote.AccountingSupplierParty = new AccountingSupplierParty()
			{
				CustomerAssignedAccountId = documentoElectronico.Emisor.NroDocumento,
				AdditionalAccountId = documentoElectronico.Emisor.TipoDocumento,
				Party = new Party()
				{
					PostalAddress = new PostalAddress()
					{
						Id = documentoElectronico.Emisor.Ubigeo,
						StreetName = documentoElectronico.Emisor.Direccion,
						CitySubdivisionName = documentoElectronico.Emisor.Urbanizacion,
						CountrySubentity = documentoElectronico.Emisor.Departamento,
						CityName = documentoElectronico.Emisor.Provincia,
						District = documentoElectronico.Emisor.Distrito,
						Country = new Country()
						{
							IdentificationCode = "PE"
						}
					},
					PartyLegalEntity = new PartyLegalEntity()
					{
						RegistrationName = documentoElectronico.Emisor.NombreLegal,
						RegistrationAddress = new RegistrationAddress()
						{
							AddressLine = new AddressLine()
							{
								Line = documentoElectronico.Emisor.Direccion
							},
							CityName = documentoElectronico.Emisor.Provincia,
							CitySubdivisionName = documentoElectronico.Emisor.Urbanizacion,
							Country = new Country()
							{
								IdentificationCode = documentoElectronico.Emisor.Pais
							},
							CountrySubentity = documentoElectronico.Emisor.Departamento,
							District = documentoElectronico.Emisor.Distrito,
							Id = documentoElectronico.Emisor.Ubigeo,
							AddressTypeCode = "0000"
						}
					},
					PartyIdentification = new PartyIdentification()
					{
						Id = new PartyIdentificationId()
						{
							SchemeId = documentoElectronico.Emisor.TipoDocumento,
							Value = documentoElectronico.Emisor.NroDocumento
						}
					}
				}
			};
			creditNote.AccountingCustomerParty = new AccountingSupplierParty()
			{
				Party = new Party()
				{
					PartyIdentification = new PartyIdentification()
					{
						Id = new PartyIdentificationId()
						{
							SchemeId = documentoElectronico.Receptor.TipoDocumento,
							Value = documentoElectronico.Receptor.NroDocumento
						}
					},
					PartyLegalEntity = new PartyLegalEntity()
					{
						RegistrationName = documentoElectronico.Receptor.NombreLegal
					}
				}
			};
			if (documentoElectronico.Gravadas > 0M)
				creditNote.TaxTotals.Add(new TaxTotal()
				{
					TaxSubtotal = new TaxSubtotal()
					{
						TaxableAmount = new PayableAmount()
						{
							CurrencyId = documentoElectronico.Moneda,
							Value = documentoElectronico.Gravadas
						},
						TaxAmount = new PayableAmount()
						{
							CurrencyId = documentoElectronico.Moneda,
							Value = documentoElectronico.TotalIgv
						},
						TaxCategory = new TaxCategory()
						{
							Id = "S",
							TaxScheme = new TaxScheme()
							{
								Id = "1000",
								Name = "IGV",
								TaxTypeCode = "VAT",
								SchemeAgencyID = "6"
							}
						}
					}
				});
			if (documentoElectronico.Inafectas > 0M)
				creditNote.TaxTotals.Add(new TaxTotal()
				{
					TaxSubtotal = new TaxSubtotal()
					{
						TaxableAmount = new PayableAmount()
						{
							CurrencyId = documentoElectronico.Moneda,
							Value = documentoElectronico.Inafectas
						},
						TaxAmount = new PayableAmount()
						{
							CurrencyId = documentoElectronico.Moneda,
							Value = documentoElectronico.TotalIgv
						},
						TaxCategory = new TaxCategory()
						{
							Id = "O",
							TaxScheme = new TaxScheme()
							{
								Id = "9998",
								Name = "INA",
								TaxTypeCode = "FRE",
								SchemeAgencyID = "6"
							}
						}
					}
				});
			if (documentoElectronico.Exoneradas > 0M)
				creditNote.TaxTotals.Add(new TaxTotal()
				{
					TaxSubtotal = new TaxSubtotal()
					{
						TaxableAmount = new PayableAmount()
						{
							CurrencyId = documentoElectronico.Moneda,
							Value = documentoElectronico.Exoneradas
						},
						TaxAmount = new PayableAmount()
						{
							CurrencyId = documentoElectronico.Moneda,
							Value = documentoElectronico.TotalIgv
						},
						TaxCategory = new TaxCategory()
						{
							Id = "E",
							TaxScheme = new TaxScheme()
							{
								Id = "9997",
								Name = "EXO",
								TaxTypeCode = "VAT",
								SchemeAgencyID = "6"
							}
						}
					}
				});
			if (documentoElectronico.Gratuitas > 0M)
				creditNote.TaxTotals.Add(new TaxTotal()
				{
					TaxSubtotal = new TaxSubtotal()
					{
						TaxableAmount = new PayableAmount()
						{
							CurrencyId = documentoElectronico.Moneda,
							Value = documentoElectronico.Gratuitas
						},
						TaxAmount = new PayableAmount()
						{
							CurrencyId = documentoElectronico.Moneda,
							Value = documentoElectronico.TotalIgv
						},
						TaxCategory = new TaxCategory()
						{
							Id = "Z",
							TaxScheme = new TaxScheme()
							{
								Id = "9996",
								Name = "GRA",
								TaxTypeCode = "FRE",
								SchemeAgencyID = "6"
							}
						}
					}
				});
			creditNote.LegalMonetaryTotal.LineExtensionAmount = new PayableAmount()
			{
				CurrencyId = documentoElectronico.Moneda,
				Value = documentoElectronico.TotalValorVenta
			};
			creditNote.LegalMonetaryTotal.TaxInclusiveAmount = new PayableAmount()
			{
				CurrencyId = documentoElectronico.Moneda,
				Value = documentoElectronico.TotalPrecioVenta
			};
			creditNote.LegalMonetaryTotal.AllowanceTotalAmount = new PayableAmount()
			{
				CurrencyId = documentoElectronico.Moneda,
				Value = documentoElectronico.TotalDescuentos
			};
			creditNote.LegalMonetaryTotal.ChargeTotalAmount = new PayableAmount()
			{
				CurrencyId = documentoElectronico.Moneda,
				Value = documentoElectronico.TotalOtrosCargos
			};
			creditNote.LegalMonetaryTotal.PrepaidAmount = new PayableAmount()
			{
				CurrencyId = documentoElectronico.Moneda,
				Value = documentoElectronico.Anticipos.Sum<DocumentoAnticipo>((Func<DocumentoAnticipo, Decimal>)(x => x.Monto))
			};
			creditNote.LegalMonetaryTotal.PayableAmount = new PayableAmount()
			{
				CurrencyId = documentoElectronico.Moneda,
				Value = documentoElectronico.TotalVenta
			};
			foreach (DetalleDocumento detalleDocumento in documentoElectronico.Items)
			{
				TaxScheme taxScheme = (TaxScheme)null;
				switch (detalleDocumento.TipoImpuesto)
				{
					case "10":
						taxScheme = new TaxScheme()
						{
							Id = "1000",
							Name = "IGV",
							TaxTypeCode = "VAT"
						};
						break;
					case "11":
					case "12":
					case "13":
					case "14":
					case "15":
					case "16":
					case "17":
					case "21":
					case "31":
					case "32":
					case "33":
					case "34":
					case "35":
					case "36":
					case "37":
						taxScheme = new TaxScheme()
						{
							Id = "9996",
							Name = "GRA",
							TaxTypeCode = "FRE"
						};
						break;
					case "20":
						taxScheme = new TaxScheme()
						{
							Id = "9997",
							Name = "EXO",
							TaxTypeCode = "VAT"
						};
						break;
					case "30":
						taxScheme = new TaxScheme()
						{
							Id = "9998",
							Name = "INA",
							TaxTypeCode = "FRE"
						};
						break;
					case "40":
						taxScheme = new TaxScheme()
						{
							Id = "9995",
							Name = "EXP",
							TaxTypeCode = "FRE"
						};
						break;
				}
				creditNote.CreditNoteLines.Add(new InvoiceLine()
				{
					Id = detalleDocumento.Id,
					CreditedQuantity = new InvoicedQuantity()
					{
						UnitCode = detalleDocumento.UnidadMedida == "" ? "ZZ" : detalleDocumento.UnidadMedida,
						Value = detalleDocumento.Cantidad
					},
					LineExtensionAmount = new PayableAmount()
					{
						CurrencyId = documentoElectronico.Moneda,
						Value = detalleDocumento.TipoPrecio == "02" ? 0M : detalleDocumento.ValorVenta
					},
					PricingReference = new PricingReference()
					{
						AlternativeConditionPrices = new List<AlternativeConditionPrice>()
			{
			  new AlternativeConditionPrice()
			  {
				PriceAmount = new PayableAmount()
				{
				  CurrencyId = documentoElectronico.Moneda,
				  Value = detalleDocumento.PrecioVentaUnitario
				},
				PriceTypeCode = detalleDocumento.TipoPrecio
			  }
			}
					},
					AllowanceCharge = new AllowanceCharge()
					{
						ChargeIndicator = false,
						AllowanceChargeReasonCode = "00",
						MultiplierFactorNumeric = detalleDocumento.Descuento.Porcentaje,
						Amount = new PayableAmount()
						{
							CurrencyId = documentoElectronico.Moneda,
							Value = detalleDocumento.Descuento.Importe
						},
						BaseAmount = new PayableAmount()
						{
							CurrencyId = documentoElectronico.Moneda,
							Value = Math.Round(detalleDocumento.Cantidad * detalleDocumento.ValorUnitario, 2)
						}
					},
					TaxTotals = new List<TaxTotal>()
		  {
			new TaxTotal()
			{
			  TaxAmount = new PayableAmount()
			  {
				CurrencyId = documentoElectronico.Moneda,
				Value = detalleDocumento.Impuesto
			  },
			  TaxSubtotal = new TaxSubtotal()
			  {
				TaxableAmount = new PayableAmount()
				{
				  CurrencyId = documentoElectronico.Moneda,
				  Value = detalleDocumento.ValorVenta
				},
				TaxAmount = new PayableAmount()
				{
				  CurrencyId = documentoElectronico.Moneda,
				  Value = documentoElectronico.Inafectas > 0M || detalleDocumento.TipoPrecio == "02" ? 0M : detalleDocumento.Impuesto
				},
				TaxCategory = new TaxCategory()
				{
				  Id = documentoElectronico.Inafectas > 0M ? "O" : (detalleDocumento.TipoPrecio == "02" ? "Z" : "S"),
				  Percent = documentoElectronico.Inafectas > 0M ? 0M : detalleDocumento.CalculoIgv,
				  TaxExemptionReasonCode = detalleDocumento.TipoImpuesto,
				  TaxScheme = taxScheme
				}
			  }
			}
		  },
					Item = new Item()
					{
						Description = detalleDocumento.Descripcion,
						SellersItemIdentification = new SellersItemIdentification()
						{
							Id = detalleDocumento.CodigoItem
						},
						CommodityClassification = new CommodityClassification()
						{
							ItemClassificationCode = detalleDocumento.CodigoInternacional
						}
					},
					Price = new Price()
					{
						PriceAmount = new PayableAmount()
						{
							CurrencyId = documentoElectronico.Moneda,
							Value = detalleDocumento.TipoPrecio == "02" ? 0M : detalleDocumento.ValorUnitario
						}
					}
				});
			}
			return (IEstructuraXml)creditNote;
		}
	}
}
