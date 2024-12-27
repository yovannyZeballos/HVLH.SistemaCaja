using HVLH.Facturacion.Comun;
using HVLH.Facturacion.Comun.Datos.Contratos;
using HVLH.Facturacion.Comun.Datos.Modelos;
using HVLH.Facturacion.Estructuras.ComponentesAgregadoComunes;
using HVLH.Facturacion.Estructuras.ComponentesAgregadoSunat;
using HVLH.Facturacion.Estructuras.ComponentesBasicosComunes;
using HVLH.Facturacion.Estructuras.EstandarUbl2._1;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace HVLH.Facturacion.Xml._2._1
{
	public class FacturaXml : IDocumentoXml
	{
		public IFormatProvider Formato { get; set; }

		public IEstructuraXml Generar(IDocumentoElectronico request)
		{
			DocumentoElectronico documentoElectronico = (DocumentoElectronico)request;
			Invoice invoice = new Invoice();
			var formato = new CultureInfo("es-PE");

			invoice.InvoiceTypeCode = new InvoiceTypeCode()
			{
				Value = documentoElectronico.TipoDocumento,
				ListID = documentoElectronico.TipoOperacion
			};
			invoice.IssueDate = DateTime.Parse(documentoElectronico.FechaEmision);
			invoice.IssueTime = TimeSpan.Parse(documentoElectronico.HoraEmision);
			invoice.Id = documentoElectronico.IdDocumento;
			invoice.DueDate = DateTime.Parse(documentoElectronico.FechaVencimiento);
			Note note1 = new Note()
			{
				LanguajeLocaleID = "1000",
				Value = string.Format("SON: {0} {1}.", NumLetra.Convertir(documentoElectronico.TotalVenta.ToString("###0.#0", this.Formato), true), documentoElectronico.Moneda == "USD" ? "DOLARES AMERICANOS" : "SOLES")
			};
			invoice.Notes.Add(note1);

			if (!string.IsNullOrEmpty(documentoElectronico.Observacion))
			{
				var observacion = new Note()
				{
					LanguajeLocaleID = "0",
					Value = documentoElectronico.Observacion
				};
				invoice.Notes.Add(observacion);
			}


			if (documentoElectronico.Gratuitas > 0M && documentoElectronico.TipoOperacion != "02" && (documentoElectronico.TipoOperacion != "0200" && documentoElectronico.TipoOperacion != "0201") && (documentoElectronico.TipoOperacion != "0202" && documentoElectronico.TipoOperacion != "0203" && (documentoElectronico.TipoOperacion != "0204" && documentoElectronico.TipoOperacion != "0205")) && (documentoElectronico.TipoOperacion != "0206" && documentoElectronico.TipoOperacion != "0207" && documentoElectronico.TipoOperacion != "0208") && documentoElectronico.Gravadas == 0M)
			{
				Note note2 = new Note()
				{
					LanguajeLocaleID = "1002",
					Value = "TRANSFERENCIA GRATUITA DE UN BIEN Y/O SERVICIO PRESTADO GRATUITAMENTE"
				};
				invoice.Notes.Add(note2);
			}
			if (documentoElectronico.MontoDetraccion > 0M)
			{
				Note note2 = new Note()
				{
					LanguajeLocaleID = "2006",
					Value = "OPERACIÓN SUJETA A DETRACCIÓN"
				};
				invoice.Notes.Add(note2);
			}
			invoice.PaymentMeans = new PaymentMeans()
			{
				PayeeFinancialAccount = new PayeeFinancialAccount()
				{
					Id = documentoElectronico.CuentaBancoNacion
				}
			};
			invoice.PaymentTerms = new PaymentTerms()
			{
				Id = "022",
				PaymentPercent = documentoElectronico.CalculoDetraccion,
				Amount = documentoElectronico.MontoDetraccion
			};
			invoice.DocumentCurrencyCode = documentoElectronico.Moneda;
			invoice.LineCountNumeric = documentoElectronico.Items.Count.ToString();
			invoice.OrderReference = documentoElectronico.OrdenCompra;
			foreach (DocumentoRelacionado relacionado in documentoElectronico.Relacionados)
				invoice.DespatchDocumentReferences.Add(new InvoiceDocumentReference()
				{
					DocumentTypeCode = relacionado.TipoDocumento,
					Id = relacionado.NroDocumento
				});
			invoice.Signature = new SignatureCac()
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
			invoice.AccountingSupplierParty = new AccountingSupplierParty()
			{
				Party = new Party()
				{
					PartyName = new PartyName()
					{
						Name = documentoElectronico.Emisor.NombreComercial
					},
					PartyIdentification = new PartyIdentification()
					{
						Id = new PartyIdentificationId()
						{
							SchemeId = documentoElectronico.Emisor.TipoDocumento,
							Value = documentoElectronico.Emisor.NroDocumento
						}
					},
					PartyLegalEntity = new PartyLegalEntity()
					{
						RegistrationName = documentoElectronico.Emisor.NombreLegal,
						RegistrationAddress = new RegistrationAddress()
						{
							AddressTypeCode = "0000",
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
							Id = documentoElectronico.Emisor.Ubigeo
						}
					}
				}
			};
			invoice.AccountingCustomerParty = new AccountingSupplierParty()
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

			foreach (var descuento in documentoElectronico.Descuentos)
			{
				invoice.AllowanceCharges.Add(new AllowanceCharge()
				{
					ChargeIndicator = false,
					AllowanceChargeReasonCode = descuento.CodigoDescuentoCargo,
					MultiplierFactorNumeric = descuento.Porcentaje,
					Amount = new PayableAmount()
					{
						CurrencyId = documentoElectronico.Moneda,
						Value = descuento.Importe
					},
					BaseAmount = new PayableAmount()
					{
						CurrencyId = documentoElectronico.Moneda,
						Value = descuento.ImporteBase
					}
				});
			}




			if (documentoElectronico.Anticipos.Count > 0)
			{
				foreach (DocumentoAnticipo anticipo in documentoElectronico.Anticipos)
				{
					invoice.PrepaidPayments.Add(new BillingPayment()
					{
						Id = new PartyIdentificationId()
						{
							SchemeId = anticipo.TipoDocumento,
							Value = anticipo.IdDocumento
						},
						PaidAmount = new PayableAmount()
						{
							CurrencyId = documentoElectronico.Moneda,
							Value = anticipo.Monto
						},
						InstructionId = documentoElectronico.Emisor.NroDocumento
					});

					invoice.AdditionalDocumentReferences.Add(new AdditionalDocumentReference
					{
						Id = anticipo.IdDocumento,
						DocumentStatusCode = anticipo.IdDocumento,
						DocumentTypeCode = anticipo.TipoDocumento,
						IssuerParty = new Party
						{
							PartyIdentification = new PartyIdentification
							{
								Id = new PartyIdentificationId
								{
									SchemeId = documentoElectronico.Emisor.TipoDocumento,
									Value = documentoElectronico.Emisor.NroDocumento
								}
							}
						}
					});
				}

			}

			if (documentoElectronico.Gravadas > 0 || documentoElectronico.Items.Sum(x => x.Impuesto) > 0)
				invoice.TaxTotals.Add(new TaxTotal()
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

			if (documentoElectronico.Inafectas > 0)
				invoice.TaxTotals.Add(new TaxTotal()
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
							Value = 0M
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
				invoice.TaxTotals.Add(new TaxTotal()
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
							Value = 0M
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
				invoice.TaxTotals.Add(new TaxTotal()
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
							Value = 0M
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

			if (documentoElectronico.Exportaciones > 0M)
				invoice.TaxTotals.Add(new TaxTotal()
				{
					TaxSubtotal = new TaxSubtotal()
					{
						TaxableAmount = new PayableAmount()
						{
							CurrencyId = documentoElectronico.Moneda,
							Value = documentoElectronico.Exportaciones
						},
						TaxAmount = new PayableAmount()
						{
							CurrencyId = documentoElectronico.Moneda,
							Value = 0M
						},
						TaxCategory = new TaxCategory()
						{
							Id = "O",
							TaxScheme = new TaxScheme()
							{
								Id = "9995",
								Name = "EXP",
								TaxTypeCode = "FRE",
								SchemeAgencyID = "6"
							}
						}
					}
				});

			invoice.LegalMonetaryTotal.LineExtensionAmount = new PayableAmount()
			{
				CurrencyId = documentoElectronico.Moneda,
				Value = documentoElectronico.TotalValorVenta
			};
			invoice.LegalMonetaryTotal.TaxInclusiveAmount = new PayableAmount()
			{
				CurrencyId = documentoElectronico.Moneda,
				Value = documentoElectronico.TotalPrecioVenta
			};
			invoice.LegalMonetaryTotal.AllowanceTotalAmount = new PayableAmount()
			{
				CurrencyId = documentoElectronico.Moneda,
				Value = documentoElectronico.TotalDescuentos
			};
			invoice.LegalMonetaryTotal.ChargeTotalAmount = new PayableAmount()
			{
				CurrencyId = documentoElectronico.Moneda,
				Value = documentoElectronico.TotalOtrosCargos
			};
			invoice.LegalMonetaryTotal.PayableAmount = new PayableAmount()
			{
				CurrencyId = documentoElectronico.Moneda,
				Value = documentoElectronico.TotalVenta
			};
			invoice.LegalMonetaryTotal.PrepaidAmount = new PayableAmount()
			{
				CurrencyId = documentoElectronico.Moneda,
				Value = documentoElectronico.Anticipos.Sum(x => x.Monto)
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


				var invoiceLine = new InvoiceLine()
				{
					Id = detalleDocumento.Id,
					InvoicedQuantity = new InvoicedQuantity()
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
							Value = detalleDocumento.Descuento.ImporteBase
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
						},
					},
					Price = new Price()
					{
						PriceAmount = new PayableAmount()
						{
							CurrencyId = documentoElectronico.Moneda,
							Value = detalleDocumento.TipoPrecio == "02" ? 0M : detalleDocumento.ValorUnitario
						}
					}
				};

				foreach (var adicional in detalleDocumento.InformacionAdicional)
				{
					invoiceLine.Item.AdditionalItemProperties.Add(new AdditionalItemProperty()
					{
						NameCode = adicional.CodigoConcepto,
						Value = adicional.ValorConcepto,
						Name = adicional.NombreConcepto
					});
				}

				invoice.InvoiceLines.Add(invoiceLine);
			}

			foreach (var formaPago in documentoElectronico.FormaPagos)
			{
				var pt = new PaymentTerms();

				if (formaPago.FechaVencimiento == "" || formaPago.FechaVencimiento == null)
					pt.PaymentDueDate = null;
				else
					pt.PaymentDueDate = DateTime.ParseExact(formaPago.FechaVencimiento, "yyyy-MM-dd", formato);

				pt.Id = "FormaPago";
				pt.PaymentMeansID = formaPago.Id;
				pt.Amount = formaPago.Monto;
				invoice.ListPaymentTerms.Add(pt);
			}

			return invoice;
		}
	}
}
