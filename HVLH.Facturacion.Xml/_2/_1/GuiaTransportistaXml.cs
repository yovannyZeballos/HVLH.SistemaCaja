using HVLH.Facturacion.Comun;
using HVLH.Facturacion.Comun.Datos.Contratos;
using HVLH.Facturacion.Estructuras.EstandarUbl2._1;
using System.Collections.Generic;
using HVLH.Facturacion.Comun.Datos.Modelos;
using HVLH.Facturacion.Comun.Constantes;
using ValueType = HVLH.Facturacion.Comun.ValueType;

namespace HVLH.Facturacion.Xml._2._1
{
	public class GuiaTransportistaXml : IDocumentoXml
	{
		public IEstructuraXml Generar(IDocumentoElectronico request)
		{
			var guia = request as DocumentoElectronicoGuiaTransportista;

			var despatchAdvice = new DespatchAdvice
			{
				UblVersionId = Atributos.Ubl2_1,
				CustomizationId = Atributos.CustomizationID2_0,
				Id = guia.IdDocumento,
				IssueDate = guia.FechaEmision,
				IssueTime = guia.HoraEmision,
				DespatchAdviceTypeCode = new CodeType
				{
					listAgencyName = Atributos.AgencyNameSunat,
					listName = Atributos.IdentificadorTipoDocumento,
					listURI = Atributos.URICatalogo01,
					Value = guia.TipoDocumento
				},
				Note = guia.Observacion,
				DespatchSupplierParty = new SupplierPartyType
				{
					Party = new PartyType
					{
						PartyIdentification = new PartyIdentificationType[]
						{
								new PartyIdentificationType
								{
									ID = new IDType
									{
										schemeID = guia.Transportista.TipoDocumento,
										schemeName = Atributos.IdentificadorDocumentoIdentidad,
										schemeAgencyName = Atributos.AgencyNameSunat,
										schemeURI = Atributos.URICatalogo06,
										Value = guia.Transportista.NroDocumento
									}
								}
						},
						PartyLegalEntity = new PartyLegalEntityType[]
						{
								new PartyLegalEntityType
								{
									RegistrationName = new RegistrationNameType
									{
										Value = guia.Transportista.NombreLegal
									}
								}
						}
					}
				},
				DeliveryCustomerParty = new CustomerPartyType
				{
					Party = new PartyType
					{
						PartyIdentification = new PartyIdentificationType[]
						{
								new PartyIdentificationType
								{
									ID = new IDType
									{
										schemeID = guia.Destinatario.TipoDocumento,
										schemeName = Atributos.IdentificadorDocumentoIdentidad,
										schemeAgencyName = Atributos.AgencyNameSunat,
										schemeURI = Atributos.URICatalogo06,
										Value = guia.Destinatario.NroDocumento
									}
								}
						},
						PartyLegalEntity = new PartyLegalEntityType[]
						{
								new PartyLegalEntityType
								{
									RegistrationName = new RegistrationNameType
									{
										Value = guia.Destinatario.NombreLegal
									}
								}
						}
					}
				},
				Signature = new SignatureType
				{
					ID = new IDType
					{
						Value = $"{guia.Transportista.NroDocumento}"
					},
					SignatoryParty = new PartyType
					{
						PartyIdentification = new PartyIdentificationType[]
						{
								new PartyIdentificationType
								{
									ID = new IDType
									{
										Value = guia.Transportista.NroDocumento
									}
								}
						},
						PartyName = new PartyNameType[]
						{
								new PartyNameType
								{
									Name = new NameType1
									{
										Value = guia.Transportista.NombreLegal
									}
								}
						}
					},
					DigitalSignatureAttachment = new AttachmentType
					{
						ExternalReference = new ExternalReferenceType
						{
							URI = new URIType
							{
								Value = $"#IDSign{guia.Transportista.NroDocumento}"
							}
						}
					}
				}
			};

			despatchAdvice.Shipment = new ShipmentType
			{
				ID = new IDType
				{
					Value = Atributos.IdentificadorTraslado
				},
				HandlingCode = new HandlingCodeType
				{
					listAgencyName = Atributos.AgencyNameSunat,
					listName = Atributos.IdentificadorMotivoTraslado,
					listURI = Atributos.URICatalogo20,
					Value = guia.DatosEnvio.MotivoTraslado
				}
			};

			if (!string.IsNullOrEmpty(guia.DatosEnvio.DescripcionMotivoTraslado))
			{
				despatchAdvice.Shipment.HandlingInstructions = new HandlingInstructionsType[]
				{
						new HandlingInstructionsType
						{
							Value = guia.DatosEnvio.DescripcionMotivoTraslado
						}
				};
			}

			if (!string.IsNullOrEmpty(guia.DatosEnvio.SustentoDiferenciaPeso))
			{
				despatchAdvice.Shipment.Information = new InformationType[]
				{
						new InformationType
						{
							Value = guia.DatosEnvio.SustentoDiferenciaPeso
						}
				};
			}

			despatchAdvice.Shipment.GrossWeightMeasure = new GrossWeightMeasureType
			{
				Value = guia.DatosEnvio.PesoBrutoTotalCarga.Valor,
				unitCode = guia.DatosEnvio.PesoBrutoTotalCarga.UnidadMedida + "M" //TODO: quitar
			};

			if (guia.DatosEnvio.PesoBrutoTotalItemsSeleccionados.Valor > 0)
			{
				despatchAdvice.Shipment.NetWeightMeasure = new NetWeightMeasureType
				{
					Value = guia.DatosEnvio.PesoBrutoTotalItemsSeleccionados.Valor,
					unitCode = guia.DatosEnvio.PesoBrutoTotalItemsSeleccionados.UnidadMedida
				};
			}

			if (guia.DatosEnvio.NumeroBultos > 0)
			{
				despatchAdvice.Shipment.TotalTransportHandlingUnitQuantity = new TotalTransportHandlingUnitQuantityType
				{
					Value = guia.DatosEnvio.NumeroBultos
				};
			}

			if (guia.DatosEnvio.Indicadores.Count > 0)
			{
				despatchAdvice.Shipment.SpecialInstructions = new SpecialInstructionsType[guia.DatosEnvio.Indicadores.Count];

				for (int i = 0; i < guia.DatosEnvio.Indicadores.Count; i++)
				{
					despatchAdvice.Shipment.SpecialInstructions[i] = new SpecialInstructionsType
					{
						Value = guia.DatosEnvio.Indicadores[i]
					};
				}
			}

			despatchAdvice.Shipment.ShipmentStage = new ShipmentStageType[]
			{
					new ShipmentStageType
					{
						TransportModeCode = new TransportModeCodeType
						{
							listName = Atributos.IdentificadorModalidadTraslado,
							listAgencyName =Atributos.AgencyNameSunat,
							listURI = Atributos.URICatalogo18,
							Value = guia.DatosEnvio.ModalidadTraslado
						}
					}
			};

			if (guia.DatosEnvio.FechaInicioTraslado != null || guia.DatosEnvio.FechaEntregaBienesTransportista != null)
			{
				despatchAdvice.Shipment.ShipmentStage[0].TransitPeriod = new PeriodType
				{
					StartDate = new StartDateType
					{
						Value = guia.DatosEnvio.ModalidadTraslado == "02" ? guia.DatosEnvio.FechaInicioTraslado.Value : guia.DatosEnvio.FechaEntregaBienesTransportista.Value
					}
				};
			}

			if (!string.IsNullOrEmpty(guia.Transportista.NroDocumento))
			{
				despatchAdvice.Shipment.ShipmentStage[0].CarrierParty = new PartyType[]
				{
						new PartyType
						{
							PartyIdentification = new PartyIdentificationType[]
							{
								new PartyIdentificationType
								{
									ID = new IDType
									{
										schemeID = guia.Transportista.TipoDocumento,
										schemeName = Atributos.IdentificadorDocumentoIdentidad,
										schemeAgencyName = Atributos.AgencyNameSunat,
										schemeURI =Atributos.URICatalogo06,
										Value = guia.Transportista.NroDocumento
									}
								}
							}
						}
				};

				if (!string.IsNullOrEmpty(guia.Transportista.NombreLegal))
				{
					despatchAdvice.Shipment.ShipmentStage[0].CarrierParty[0].PartyLegalEntity = new PartyLegalEntityType[]
						{
								new PartyLegalEntityType
								{
									RegistrationName = new RegistrationNameType
									{
										Value = guia.Transportista.NombreLegal
									}
								}
						};

					if (!string.IsNullOrEmpty(guia.Transportista.NumeroRegistroMTC))
					{
						despatchAdvice.Shipment.ShipmentStage[0].CarrierParty[0].PartyLegalEntity[0].CompanyID = new CompanyIDType
						{
							Value = guia.Transportista.NumeroRegistroMTC
						};
					}
				}


				if (!string.IsNullOrEmpty(guia.Transportista.EntidadEmisora.NumeroAutorizacion))
				{
					despatchAdvice.Shipment.ShipmentStage[0].CarrierParty[0].AgentParty = new PartyType
					{
						PartyLegalEntity = new PartyLegalEntityType[]
						{
								new PartyLegalEntityType
								{
									CompanyID = new CompanyIDType
									{
										schemeID = guia.Transportista.EntidadEmisora.CodigoEntidadAutorizadora,
										Value =guia.Transportista.EntidadEmisora.NumeroAutorizacion,
										schemeName = Atributos.IdentificadorEntidadAutorizadora,
										schemeAgencyName= Atributos.AgencyNameSunat
									}
								}
						}
					};
				}

			}

			if (!string.IsNullOrEmpty(guia.DatosEnvio.TipoEvento))
			{
				despatchAdvice.Shipment.ShipmentStage[0].TransportEvent = new TransportEventType[]
				{
						new TransportEventType
						{
							TransportEventTypeCode = new TransportEventTypeCodeType
							{
								Value = guia.DatosEnvio.TipoEvento
							}
						}
				};
			}

			if (guia.Conductores.Count > 0)
			{
				despatchAdvice.Shipment.ShipmentStage[0].DriverPerson = new PersonType[guia.Conductores.Count];

				for (int i = 0; i < guia.Conductores.Count; i++)
				{
					if (!string.IsNullOrEmpty(guia.Conductores[i].NroDocumento))
					{
						despatchAdvice.Shipment.ShipmentStage[0].DriverPerson[i] = new PersonType
						{
							JobTitle = new JobTitleType
							{
								Value = guia.Conductores[i].TipoConductor
							},
							ID = new IDType
							{
								schemeID = guia.Conductores[i].TipoDocumento,
								schemeName = Atributos.IdentificadorDocumentoIdentidad,
								schemeAgencyName = Atributos.AgencyNameSunat,
								schemeURI = Atributos.URICatalogo06,
								Value = guia.Conductores[i].NroDocumento
							}
						};


						if (!string.IsNullOrEmpty(guia.Conductores[i].Nombres))
						{
							despatchAdvice.Shipment.ShipmentStage[0].DriverPerson[i].FirstName = new FirstNameType
							{
								Value = guia.Conductores[i].Nombres
							};
						}

						if (!string.IsNullOrEmpty(guia.Conductores[i].Apellidos))
						{
							despatchAdvice.Shipment.ShipmentStage[0].DriverPerson[i].FamilyName = new FamilyNameType
							{
								Value = guia.Conductores[i].Apellidos
							};
						}

						if (!string.IsNullOrEmpty(guia.Conductores[i].NumeroLicencia))
						{
							despatchAdvice.Shipment.ShipmentStage[0].DriverPerson[i].IdentityDocumentReference = new DocumentReferenceType[]
							{
									new DocumentReferenceType
									{
										ID = new IDType
										{
											Value = guia.Conductores[i].NumeroLicencia
										}
									}
							};
						}
					}
				}
			}

			despatchAdvice.Shipment.Delivery = new DeliveryType
			{
				Despatch = new DespatchType
				{
					DespatchAddress = new AddressType
					{
						ID = new IDType
						{
							Value = guia.DireccionPuntoPartida.Ubigeo,
							schemeAgencyName = Atributos.AgencyNameINEI,
							schemeName = Atributos.Ubigeos
						},
						AddressLine = new AddressLineType[]
						{
								new AddressLineType
								{
									Line = new LineType
									{
										Value = guia.DireccionPuntoPartida.DireccionDetallada
									}
								}
						}
					}
				}
			};

			if (!string.IsNullOrEmpty(guia.DireccionPuntoPartida.NumeroDocumentoAsociado))
			{
				despatchAdvice.Shipment.Delivery.Despatch.DespatchAddress.AddressTypeCode = new AddressTypeCodeType
				{
					listID = guia.DireccionPuntoPartida.NumeroDocumentoAsociado
				};

				if (!string.IsNullOrEmpty(guia.DireccionPuntoPartida.CodigoEstablecimiento))
				{
					despatchAdvice.Shipment.Delivery.Despatch.DespatchAddress.AddressTypeCode.Value = guia.DireccionPuntoPartida.CodigoEstablecimiento;
					despatchAdvice.Shipment.Delivery.Despatch.DespatchAddress.AddressTypeCode.listAgencyName = Atributos.AgencyNameSunat;
					despatchAdvice.Shipment.Delivery.Despatch.DespatchAddress.AddressTypeCode.listName = Atributos.IdentificadorEstablecimientosAnexos;
				}

				if (guia.DireccionPuntoPartida.Longitud.Valor > 0 && guia.DireccionPuntoPartida.Latitud.Valor > 0)
				{
					despatchAdvice.Shipment.Delivery.Despatch.DespatchAddress.LocationCoordinate = new LocationCoordinateType[]
					{
							new LocationCoordinateType
							{
								LatitudeDegreesMeasure = new LatitudeDegreesMeasureType
								{
									Value = guia.DireccionPuntoPartida.Latitud.Valor,
									unitCode = guia.DireccionPuntoPartida.Latitud.UnidadMedida
								},
								LongitudeDegreesMeasure = new LongitudeDegreesMeasureType
								{
									Value = guia.DireccionPuntoPartida.Longitud.Valor,
									unitCode = guia.DireccionPuntoPartida.Longitud.UnidadMedida
								}
							}
					};
				}
			}

			if (!string.IsNullOrEmpty(guia.DireccionPuntoLlegada.Ubigeo))
			{
				despatchAdvice.Shipment.Delivery.DeliveryAddress = new AddressType
				{
					ID = new IDType
					{
						Value = guia.DireccionPuntoLlegada.Ubigeo,
						schemeAgencyName = Atributos.AgencyNameINEI,
						schemeName = Atributos.Ubigeos
					},
					AddressLine = new AddressLineType[]
						{
								new AddressLineType
								{
									Line = new LineType
									{
										Value = guia.DireccionPuntoLlegada.DireccionDetallada
									}
								}
						}
				};


				if (!string.IsNullOrEmpty(guia.DireccionPuntoLlegada.NumeroDocumentoAsociado))
				{
					despatchAdvice.Shipment.Delivery.DeliveryAddress.AddressTypeCode = new AddressTypeCodeType
					{
						listID = guia.DireccionPuntoLlegada.NumeroDocumentoAsociado
					};

					if (!string.IsNullOrEmpty(guia.DireccionPuntoLlegada.CodigoEstablecimiento))
					{
						despatchAdvice.Shipment.Delivery.DeliveryAddress.AddressTypeCode.Value = guia.DireccionPuntoLlegada.CodigoEstablecimiento;
						despatchAdvice.Shipment.Delivery.DeliveryAddress.AddressTypeCode.listAgencyName = Atributos.AgencyNameSunat;
						despatchAdvice.Shipment.Delivery.DeliveryAddress.AddressTypeCode.listName = Atributos.IdentificadorEstablecimientosAnexos;
					}

					if (guia.DireccionPuntoLlegada.Longitud.Valor > 0 && guia.DireccionPuntoLlegada.Latitud.Valor > 0)
					{
						despatchAdvice.Shipment.Delivery.DeliveryAddress.LocationCoordinate = new LocationCoordinateType[]
						{
							new LocationCoordinateType
							{
								LatitudeDegreesMeasure = new LatitudeDegreesMeasureType
								{
									Value = guia.DireccionPuntoLlegada.Latitud.Valor,
									unitCode = guia.DireccionPuntoLlegada.Latitud.UnidadMedida
								},
								LongitudeDegreesMeasure = new LongitudeDegreesMeasureType
								{
									Value = guia.DireccionPuntoLlegada.Longitud.Valor,
									unitCode = guia.DireccionPuntoLlegada.Longitud.UnidadMedida
								}
							}
						};
					}
				}
			}

			if (!string.IsNullOrEmpty(guia.Remitente.NroDocumento))
			{
				despatchAdvice.Shipment.Delivery.Despatch.DespatchParty = new PartyType
				{
					PartyIdentification = new PartyIdentificationType[]
					{
						new PartyIdentificationType
						{
							ID = new IDType
							{
								Value = guia.Remitente.NroDocumento,
								schemeID =  guia.Remitente.TipoDocumento,
								schemeName = Atributos.IdentificadorDocumentoIdentidad,
								schemeAgencyName = Atributos.AgencyNameSunat,
								schemeDataURI = Atributos.URICatalogo06
							}
						}
					},
					PartyLegalEntity = new PartyLegalEntityType[]
					{
						new PartyLegalEntityType
						{
							RegistrationName = new RegistrationNameType
							{
								Value =  guia.Remitente.NombreLegal
							},
						}
					}
				};
			}

			if (guia.DocumentosRelacionados.Count > 0)
			{
				despatchAdvice.AdditionalDocumentReferences = new List<DocumentReferenceType>();

				foreach (var documentoRelacionado in guia.DocumentosRelacionados)
				{
					var additionalDocumentReference = new DocumentReferenceType
					{
						DocumentType = new DocumentTypeType
						{
							Value = documentoRelacionado.DescripcionTipoDocumento
						},
						DocumentTypeCode = new DocumentTypeCodeType
						{
							Value = documentoRelacionado.TipoDocumento,
							listAgencyName = Atributos.AgencyNameSunat,
							listName = Atributos.IdentificadorDocumentosRelacionadosTransporte,
							listURI = Atributos.URICatalogo61
						},
						ID = new IDType
						{
							Value = documentoRelacionado.NroDocumento
						}
					};


					if (!string.IsNullOrEmpty(documentoRelacionado.Emisor.NroDocumento))
					{
						additionalDocumentReference.IssuerParty = new PartyType
						{
							PartyIdentification = new PartyIdentificationType[]
							{
									new PartyIdentificationType
									{
										ID = new IDType
										{
											Value = documentoRelacionado.Emisor.NroDocumento,
											schemeID = documentoRelacionado.Emisor.TipoDocumento,
											schemeName = Atributos.IdentificadorDocumentoIdentidad,
											schemeAgencyName = Atributos.AgencyNameSunat,
											schemeURI = Atributos.URICatalogo06
										}
									}
							}
						};
					}

					despatchAdvice.AdditionalDocumentReferences.Add(additionalDocumentReference);

				}
			}

			var TransportHandlingUnit = new List<TransportHandlingUnitType>();
			var packages = new List<PackageType>();

			if (!string.IsNullOrEmpty(guia.DatosEnvio.NumeroContenedor1))
			{
				packages.Add(new PackageType
				{
					ID = new IDType
					{
						Value = guia.DatosEnvio.NumeroContenedor1,
					},
					TraceID = new TraceIDType
					{
						Value = guia.DatosEnvio.NumeroPrecinto1
					}
				});


			}

			if (!string.IsNullOrEmpty(guia.DatosEnvio.NumeroContenedor2))
			{
				packages.Add(new PackageType
				{
					ID = new IDType
					{
						Value = guia.DatosEnvio.NumeroContenedor2,
					},
					TraceID = new TraceIDType
					{
						Value = guia.DatosEnvio.NumeroPrecinto2
					}
				});

			}

			if (packages.Count > 0)
			{
				TransportHandlingUnit.Add(new TransportHandlingUnitType
				{
					Package = packages.ToArray()
				});
			}


			if (!string.IsNullOrEmpty(guia.VehiculoPrincipal.NumeroPlaca))
			{
				var transportEquipment = new TransportEquipmentType
				{
					ID = new IDType
					{
						Value = guia.VehiculoPrincipal.NumeroPlaca
					}
				};

				if (!string.IsNullOrEmpty(guia.VehiculoPrincipal.TarjetaCirculacion))
				{
					transportEquipment.ApplicableTransportMeans = new TransportMeansType
					{
						RegistrationNationalityID = new RegistrationNationalityIDType
						{
							Value = guia.VehiculoPrincipal.TarjetaCirculacion
						}
					};
				}

				if (!string.IsNullOrEmpty(guia.VehiculoPrincipal.EntidadEmisora.NumeroAutorizacion))
				{
					transportEquipment.ShipmentDocumentReference = new DocumentReferenceType[]
					{
							new DocumentReferenceType
							{
								ID = new IDType
								{
									Value = guia.VehiculoPrincipal.EntidadEmisora.NumeroAutorizacion,
									schemeID = guia.VehiculoPrincipal.EntidadEmisora.CodigoEntidadAutorizadora,
									schemeName = Atributos.IdentificadorEntidadAutorizadora,
									schemeAgencyName = Atributos.AgencyNameSunat
								}
							}
					};
				}

				if (guia.VehiculosSecundarios.Count > 0)
				{
					var attachedTransportEquipments = new List<TransportEquipmentType>();

					foreach (var vehiculo in guia.VehiculosSecundarios)
					{
						var attachedTransportEquipment = new TransportEquipmentType
						{
							ID = new IDType
							{
								Value = vehiculo.NumeroPlaca
							}
						};

						if (!string.IsNullOrEmpty(vehiculo.TarjetaCirculacion))
						{
							attachedTransportEquipment.ApplicableTransportMeans = new TransportMeansType
							{
								RegistrationNationalityID = new RegistrationNationalityIDType
								{
									Value = vehiculo.TarjetaCirculacion
								}
							};
						}


						if (!string.IsNullOrEmpty(vehiculo.EntidadEmisora.NumeroAutorizacion))
						{
							attachedTransportEquipment.ShipmentDocumentReference = new DocumentReferenceType[]
							{
									new DocumentReferenceType
									{
										ID = new IDType
										{
											Value = vehiculo.EntidadEmisora.NumeroAutorizacion,
											schemeID = vehiculo.EntidadEmisora.CodigoEntidadAutorizadora,
											schemeName = Atributos.IdentificadorEntidadAutorizadora,
											schemeAgencyName = Atributos.AgencyNameSunat
										}
									}
							};
						}
						attachedTransportEquipments.Add(attachedTransportEquipment);
					}

					transportEquipment.AttachedTransportEquipment = attachedTransportEquipments.ToArray();
				}

				TransportHandlingUnit.Add(new TransportHandlingUnitType
				{
					TransportEquipment = new TransportEquipmentType[]
					{
							transportEquipment
					}
				});

			}

			despatchAdvice.Shipment.TransportHandlingUnit = TransportHandlingUnit.ToArray();



			if (guia.Bienes.Count > 0)
			{
				despatchAdvice.DespatchLines = new List<DespatchLineType>();

				if (!string.IsNullOrEmpty(guia.DatosEnvio.AnotacionBienesTranpostar))
				{
					despatchAdvice.DespatchLines.Add(new DespatchLineType
					{
						ID = new IDType
						{
							Value = "0"
						},
						OrderLineReference = new OrderLineReferenceType[]
						{
							new OrderLineReferenceType
							{
								LineID = new LineIDType
								{
									Value = "0"
								}
							}
						},
						Item = new ItemType
						{
							Description = new DescriptionType[]
							{
								new DescriptionType
								{
									Value = guia.DatosEnvio.AnotacionBienesTranpostar
								}
							}
						}
					});
				}

				foreach (var bien in guia.Bienes)
				{
					var despatchLine = new DespatchLineType
					{
						ID = new IDType
						{
							Value = bien.NumeroOrden.ToString(Formatos.FormatoNumericoEntero)
						},
						OrderLineReference = new OrderLineReferenceType[]
						{
								new OrderLineReferenceType
								{
									LineID = new LineIDType
									{
										Value = bien.NumeroOrden.ToString(Formatos.FormatoNumericoEntero)
									}
								}

						},
						DeliveredQuantity = new DeliveredQuantityType
						{
							Value = bien.Cantidad,
							unitCode = bien.UnidadMedida,
							unitCodeListID = Atributos.UNECERec20,
							unitCodeListAgencyName = Atributos.AgencyNameEurope
						},
						Item = new ItemType
						{
							Description = new DescriptionType[]
							{
									new DescriptionType
									{
										Value = bien.Descripcion
									}
							},
							SellersItemIdentification = new ItemIdentificationType
							{
								ID = new IDType
								{
									Value = bien.CodigoBien
								}
							}
						}
					};

					if (!string.IsNullOrEmpty(bien.CodigoSUNAT))
					{
						despatchLine.Item.CommodityClassification = new CommodityClassificationType[]
						{
								new CommodityClassificationType
								{
									ItemClassificationCode = new ItemClassificationCodeType
									{
										Value = bien.CodigoSUNAT.Length <= 8 ? bien.CodigoSUNAT: bien.CodigoSUNAT.Substring(0,8),
										listID = Atributos.UNSPSC,
										listAgencyName = Atributos.AgencyNameGS1US,
										listName = Atributos.ItemClassification
									}
								}
						};
					}

					if (!string.IsNullOrEmpty(bien.CodigoGTIN))
					{
						despatchLine.Item.StandardItemIdentification = new ItemIdentificationType
						{
							ID = new IDType
							{
								Value = bien.CodigoGTIN,
								schemeID = bien.EstructuraCodigoGTIN
							}
						};
					}

					var additionalItemProperties = new List<ItemPropertyType>();

					if (!string.IsNullOrEmpty(bien.PartidaArancelaria))
					{
						additionalItemProperties.Add(new ItemPropertyType
						{
							Name = new NameType1
							{
								Value = "Partida arancelaria"
							},
							NameCode = new NameCodeType
							{
								Value = "7020",
								listName = Atributos.IdentificadorPropiedadItem,
								listAgencyName = Atributos.AgencyNameSunat,
								listURI = Atributos.URICatalogo55
							},
							Value = new ValueType
							{
								Value = bien.PartidaArancelaria
							}
						});
					}

					if (!string.IsNullOrEmpty(bien.IndicadorBienNormalizado))
					{
						additionalItemProperties.Add(new ItemPropertyType
						{
							Name = new NameType1
							{
								Value = "Indicador de bien normalizado"
							},
							NameCode = new NameCodeType
							{
								Value = "7022",
								listName = Atributos.IdentificadorPropiedadItem,
								listAgencyName = Atributos.AgencyNameSunat,
								listURI = Atributos.URICatalogo55
							},
							Value = new ValueType
							{
								Value = bien.IndicadorBienNormalizado
							}
						});
					}

					if (!string.IsNullOrEmpty(bien.NumeracionDAM_DS))
					{
						additionalItemProperties.Add(new ItemPropertyType
						{
							Name = new NameType1
							{
								Value = "Numeración de la DAM o DS"
							},
							NameCode = new NameCodeType
							{
								Value = "7021",
								listName = Atributos.IdentificadorPropiedadItem,
								listAgencyName = Atributos.AgencyNameSunat,
								listURI = Atributos.URICatalogo55
							},
							Value = new ValueType
							{
								Value = bien.NumeracionDAM_DS
							}
						});
					}

					if (!string.IsNullOrEmpty(bien.NumeroSerieDAM_DS))
					{
						additionalItemProperties.Add(new ItemPropertyType
						{
							Name = new NameType1
							{
								Value = "Número de serie en la DAM o DS"
							},
							NameCode = new NameCodeType
							{
								Value = "7023",
								listName = Atributos.IdentificadorPropiedadItem,
								listAgencyName = Atributos.AgencyNameSunat,
								listURI = Atributos.URICatalogo55
							},
							Value = new ValueType
							{
								Value = bien.NumeroSerieDAM_DS
							}
						});
					}

					despatchLine.Item.AdditionalItemProperty = additionalItemProperties.ToArray();

					despatchAdvice.DespatchLines.Add(despatchLine);
				}
			}

			return despatchAdvice;
		}
	}
}
