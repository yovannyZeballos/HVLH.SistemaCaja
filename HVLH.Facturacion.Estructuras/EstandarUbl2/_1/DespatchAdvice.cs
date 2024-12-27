using HVLH.Facturacion.Comun;
using HVLH.Facturacion.Comun.Constantes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace HVLH.Facturacion.Estructuras.EstandarUbl2._1
{

	public class DespatchAdvice : IXmlSerializable, IEstructuraXml
	{
		public string UblVersionId { get; set; }
		public string CustomizationId { get; set; }
		public string Id { get; set; }
		public DateTime IssueDate { get; set; }
		public TimeSpan IssueTime { get; set; }
		public CodeType DespatchAdviceTypeCode { get; set; }
		public string Note { get; set; }
		public SupplierPartyType DespatchSupplierParty { get; set; }
		public ShipmentType Shipment { get; set; }
		public List<DocumentReferenceType> AdditionalDocumentReferences { get; set; }
		public CustomerPartyType DeliveryCustomerParty { get; set; }
		public SupplierPartyType SellerSupplierParty { get; set; }
		public CustomerPartyType BuyerCustomerParty { get; set; }
		public List<DespatchLineType> DespatchLines { get; set; }
		public SignatureType Signature { get; set; }
		public IFormatProvider Formato { get; set; }

		public DespatchAdvice()
		{
			Formato = new CultureInfo("es-PE");
		}

		public XmlSchema GetSchema()
		{
			throw new NotImplementedException();
		}

		public void ReadXml(XmlReader reader)
		{
			throw new NotImplementedException();
		}

		public void WriteXml(XmlWriter writer)
		{
			writer.WriteAttributeString("xmlns", EspacioNombres.xmlnsDespatchAdvice);
			writer.WriteAttributeString("xmlns:cac", EspacioNombres.cac);
			writer.WriteAttributeString("xmlns:cbc", EspacioNombres.cbc);
			writer.WriteAttributeString("xmlns:ccts", EspacioNombres.ccts);
			writer.WriteAttributeString("xmlns:ds", EspacioNombres.ds);
			writer.WriteAttributeString("xmlns:ext", EspacioNombres.ext);
			writer.WriteAttributeString("xmlns:qdt", EspacioNombres.qdt);
			writer.WriteAttributeString("xmlns:udt", EspacioNombres.udt);


			#region UBLExtensions
			writer.WriteStartElement("ext:UBLExtensions");

			#region UBLExtension

			writer.WriteStartElement("ext:UBLExtension");
			#region ExtensionContent
			writer.WriteStartElement("ext:ExtensionContent");

			// En esta zona va el certificado digital.

			writer.WriteEndElement();
			#endregion
			writer.WriteEndElement();
			#endregion

			writer.WriteEndElement();
			#endregion

			#region Datos de guía de remisión

			writer.WriteElementString("cbc:UBLVersionID", UblVersionId);
			writer.WriteElementString("cbc:CustomizationID", CustomizationId);
			writer.WriteElementString("cbc:ID", Id);
			writer.WriteElementString("cbc:IssueDate", IssueDate.ToString(Formatos.FormatoFecha, Formato));
			writer.WriteElementString("cbc:IssueTime", IssueTime.ToString(Formatos.FormatoHora, Formato));


			writer.WriteStartElement("cbc:DespatchAdviceTypeCode");
			writer.WriteAttributeString("listAgencyName", DespatchAdviceTypeCode.listAgencyName);
			writer.WriteAttributeString("listName", DespatchAdviceTypeCode.listName);
			writer.WriteAttributeString("listURI", DespatchAdviceTypeCode.listURI);
			writer.WriteValue(DespatchAdviceTypeCode.Value);
			writer.WriteEndElement();

			if (!string.IsNullOrEmpty(Note))
			{
				writer.WriteElementString("cbc:Note", Note);
			}

			#endregion

			#region Documento relacionado

			if (AdditionalDocumentReferences != null)
			{
				foreach (var additionalDocumentReference in AdditionalDocumentReferences)
				{
					if (additionalDocumentReference.ID != null)
					{
						writer.WriteStartElement("cac:AdditionalDocumentReference");
						writer.WriteElementString("cbc:ID", additionalDocumentReference.ID.Value);

						writer.WriteStartElement("cbc:DocumentTypeCode");
						writer.WriteAttributeString("listAgencyName", additionalDocumentReference.DocumentTypeCode.listAgencyName);
						writer.WriteAttributeString("listName", additionalDocumentReference.DocumentTypeCode.listName);
						writer.WriteAttributeString("listURI", additionalDocumentReference.DocumentTypeCode.listURI);
						writer.WriteValue(additionalDocumentReference.DocumentTypeCode.Value);
						writer.WriteEndElement();

						writer.WriteElementString("cbc:DocumentType", additionalDocumentReference.DocumentType.Value);

						if (additionalDocumentReference.IssuerParty != null &&
							additionalDocumentReference.IssuerParty.PartyIdentification != null)
						{
							writer.WriteStartElement("cac:IssuerParty");

							foreach (var partyIdentification in additionalDocumentReference.IssuerParty.PartyIdentification)
							{
								writer.WriteStartElement("cac:PartyIdentification");
								writer.WriteStartElement("cbc:ID");
								writer.WriteAttributeString("schemeAgencyName", partyIdentification.ID.schemeAgencyName);
								writer.WriteAttributeString("schemeID", partyIdentification.ID.schemeID);
								writer.WriteAttributeString("schemeName", partyIdentification.ID.schemeName);
								writer.WriteAttributeString("schemeURI", partyIdentification.ID.schemeURI);
								writer.WriteValue(partyIdentification.ID.Value);
								writer.WriteEndElement();
								writer.WriteEndElement();
							}

							writer.WriteEndElement();

						}

						writer.WriteEndElement();
					}
				}
			}


			#endregion

			#region Signature
			writer.WriteStartElement("cac:Signature");
			writer.WriteElementString("cbc:ID", Signature.ID.Value);

			#region SignatoryParty

			writer.WriteStartElement("cac:SignatoryParty");
			writer.WriteStartElement("cac:PartyIdentification");
			writer.WriteElementString("cbc:ID", Signature.SignatoryParty.PartyIdentification[0].ID.Value);
			writer.WriteEndElement();

			#region PartyName
			writer.WriteStartElement("cac:PartyName");

			// writer.WriteStartElement("cbc:Name");
			// writer.WriteCData(Signature.SignatoryParty.PartyName.Name);
			// writer.WriteEndElement();
			writer.WriteElementString("cbc:Name", Signature.SignatoryParty.PartyName[0].Name.Value);
			writer.WriteEndElement();
			#endregion

			writer.WriteEndElement();
			#endregion

			#region DigitalSignatureAttachment
			writer.WriteStartElement("cac:DigitalSignatureAttachment");
			writer.WriteStartElement("cac:ExternalReference");
			writer.WriteElementString("cbc:URI", Signature.DigitalSignatureAttachment.ExternalReference.URI.Value);
			writer.WriteEndElement();
			writer.WriteEndElement();
			#endregion

			writer.WriteEndElement();
			#endregion

			#region Datos del Remitente

			writer.WriteStartElement("cac:DespatchSupplierParty");
			writer.WriteStartElement("cac:Party");

			foreach (var partyIdentification in DespatchSupplierParty.Party.PartyIdentification)
			{
				writer.WriteStartElement("cac:PartyIdentification");
				writer.WriteStartElement("cbc:ID");
				writer.WriteAttributeString("schemeAgencyName", partyIdentification.ID.schemeAgencyName);
				writer.WriteAttributeString("schemeID", partyIdentification.ID.schemeID);
				writer.WriteAttributeString("schemeName", partyIdentification.ID.schemeName);
				writer.WriteAttributeString("schemeURI", partyIdentification.ID.schemeURI);
				writer.WriteValue(partyIdentification.ID.Value);
				writer.WriteEndElement();
				writer.WriteEndElement();
			}

			foreach (var partyLegalEntity in DespatchSupplierParty.Party.PartyLegalEntity)
			{
				writer.WriteStartElement("cac:PartyLegalEntity");
				writer.WriteElementString("cbc:RegistrationName", partyLegalEntity.RegistrationName.Value);
				writer.WriteEndElement();
			}

			writer.WriteEndElement();
			writer.WriteEndElement();
			#endregion

			#region Datos del Destinatario

			writer.WriteStartElement("cac:DeliveryCustomerParty");
			writer.WriteStartElement("cac:Party");

			foreach (var partyIdentification in DeliveryCustomerParty.Party.PartyIdentification)
			{
				writer.WriteStartElement("cac:PartyIdentification");
				writer.WriteStartElement("cbc:ID");
				writer.WriteAttributeString("schemeAgencyName", partyIdentification.ID.schemeAgencyName);
				writer.WriteAttributeString("schemeID", partyIdentification.ID.schemeID);
				writer.WriteAttributeString("schemeName", partyIdentification.ID.schemeName);
				writer.WriteAttributeString("schemeURI", partyIdentification.ID.schemeURI);
				writer.WriteValue(partyIdentification.ID.Value);
				writer.WriteEndElement();
				writer.WriteEndElement();
			}

			foreach (var partyLegalEntity in DeliveryCustomerParty.Party.PartyLegalEntity)
			{
				writer.WriteStartElement("cac:PartyLegalEntity");
				writer.WriteElementString("cbc:RegistrationName", partyLegalEntity.RegistrationName.Value);
				writer.WriteEndElement();
			}

			writer.WriteEndElement();
			writer.WriteEndElement();

			#endregion

			#region Datos del Comprador



			if (BuyerCustomerParty?.Party != null)
			{
				writer.WriteStartElement("cac:BuyerCustomerParty");
				writer.WriteStartElement("cac:Party");

				if (BuyerCustomerParty.Party.PartyIdentification != null)
				{

					foreach (var partyIdentification in BuyerCustomerParty.Party.PartyIdentification)
					{
						writer.WriteStartElement("cac:PartyIdentification");
						writer.WriteStartElement("cbc:ID");
						writer.WriteAttributeString("schemeAgencyName", partyIdentification.ID.schemeAgencyName);
						writer.WriteAttributeString("schemeID", partyIdentification.ID.schemeID);
						writer.WriteAttributeString("schemeName", partyIdentification.ID.schemeName);
						writer.WriteAttributeString("schemeURI", partyIdentification.ID.schemeURI);
						writer.WriteValue(partyIdentification.ID.Value);
						writer.WriteEndElement();
						writer.WriteEndElement();
					}
				}

				if (BuyerCustomerParty.Party.PartyLegalEntity != null)
				{
					foreach (var partyLegalEntity in BuyerCustomerParty?.Party?.PartyLegalEntity)
					{
						writer.WriteStartElement("cac:PartyLegalEntity");
						writer.WriteElementString("cbc:RegistrationName", partyLegalEntity.RegistrationName.Value);
						writer.WriteEndElement();
					}
				}

				writer.WriteEndElement();
				writer.WriteEndElement();
			}





			#endregion

			#region Datos del Proveedor



			if (SellerSupplierParty?.Party != null)
			{
				writer.WriteStartElement("cac:SellerSupplierParty");
				writer.WriteStartElement("cac:Party");

				if (SellerSupplierParty.Party.PartyIdentification != null)
				{
					foreach (var partyIdentification in SellerSupplierParty.Party.PartyIdentification)
					{
						writer.WriteStartElement("cac:PartyIdentification");
						writer.WriteStartElement("cbc:ID");
						writer.WriteAttributeString("schemeAgencyName", partyIdentification.ID.schemeAgencyName);
						writer.WriteAttributeString("schemeID", partyIdentification.ID.schemeID);
						writer.WriteAttributeString("schemeName", partyIdentification.ID.schemeName);
						writer.WriteAttributeString("schemeURI", partyIdentification.ID.schemeURI);
						writer.WriteValue(partyIdentification.ID.Value);
						writer.WriteEndElement();
						writer.WriteEndElement();
					}
				}

				if (SellerSupplierParty.Party.PartyLegalEntity != null)
				{
					foreach (var partyLegalEntity in SellerSupplierParty.Party.PartyLegalEntity)
					{
						writer.WriteStartElement("cac:PartyLegalEntity");
						writer.WriteElementString("cbc:RegistrationName", partyLegalEntity.RegistrationName.Value);
						writer.WriteEndElement();
					}
				}


				writer.WriteEndElement();
				writer.WriteEndElement();
			}


			#endregion

			#region Datos del envio

			writer.WriteStartElement("cac:Shipment");

			writer.WriteElementString("cbc:ID", Shipment.ID.Value);

			writer.WriteStartElement("cbc:HandlingCode");
			writer.WriteAttributeString("listAgencyName", Shipment.HandlingCode.listAgencyName);
			writer.WriteAttributeString("listName", Shipment.HandlingCode.listName);
			writer.WriteAttributeString("listURI", Shipment.HandlingCode.listURI);
			writer.WriteValue(Shipment.HandlingCode.Value);
			writer.WriteEndElement();

			if (Shipment.HandlingInstructions != null)
			{
				foreach (var handlingInstructions in Shipment.HandlingInstructions)
				{
					writer.WriteElementString("cbc:HandlingInstructions", handlingInstructions.Value);
				}
			}

			if (Shipment.Information != null)
			{
				foreach (var information in Shipment.Information)
				{
					writer.WriteElementString("cbc:Information", information.Value);
				}
			}

			writer.WriteStartElement("cbc:GrossWeightMeasure");
			writer.WriteAttributeString("unitCode", Shipment.GrossWeightMeasure.unitCode);
			writer.WriteValue(Shipment.GrossWeightMeasure.Value.ToString(Formatos.FormatoNumerico, Formato));
			writer.WriteEndElement();

			if (Shipment.NetWeightMeasure != null)
			{
				writer.WriteStartElement("cbc:NetWeightMeasure");
				writer.WriteAttributeString("unitCode", Shipment.NetWeightMeasure.unitCode);
				writer.WriteValue(Shipment.NetWeightMeasure.Value.ToString(Formatos.FormatoNumerico, Formato));
				writer.WriteEndElement();
			}

			if (Shipment.TotalTransportHandlingUnitQuantity != null)
			{
				writer.WriteElementString("cbc:TotalTransportHandlingUnitQuantity", Shipment.TotalTransportHandlingUnitQuantity.Value.ToString(Formatos.FormatoNumericoEntero, Formato));
			}

			if (Shipment.SpecialInstructions != null)
			{
				foreach (var specialInstructions in Shipment.SpecialInstructions)
				{
					writer.WriteElementString("cbc:SpecialInstructions", specialInstructions.Value);
				}
			}

			foreach (var shipmentStage in Shipment.ShipmentStage)
			{
				writer.WriteStartElement("cac:ShipmentStage");

				writer.WriteElementString("cbc:ID", "1");

				writer.WriteStartElement("cbc:TransportModeCode");
				writer.WriteAttributeString("listAgencyName", shipmentStage.TransportModeCode.listAgencyName);
				writer.WriteAttributeString("listName", shipmentStage.TransportModeCode.listName);
				writer.WriteAttributeString("listURI", shipmentStage.TransportModeCode.listURI);
				writer.WriteValue(shipmentStage.TransportModeCode.Value);
				writer.WriteEndElement();

				if (shipmentStage.TransitPeriod.StartDate != null)
				{
					writer.WriteStartElement("cac:TransitPeriod");
					writer.WriteElementString("cbc:StartDate", shipmentStage.TransitPeriod.StartDate.Value.ToString(Formatos.FormatoFecha, Formato));
					writer.WriteEndElement();
				}


				#region Datos del transportista

				if (shipmentStage.CarrierParty != null)
				{
					foreach (var carrierParty in shipmentStage.CarrierParty)
					{
						if (shipmentStage.TransportModeCode.Value != "02")
						{
							writer.WriteStartElement("cac:CarrierParty");

							foreach (var partyIdentification in carrierParty.PartyIdentification)
							{
								writer.WriteStartElement("cac:PartyIdentification");
								writer.WriteStartElement("cbc:ID");
								writer.WriteAttributeString("schemeAgencyName", partyIdentification.ID.schemeAgencyName);
								writer.WriteAttributeString("schemeID", partyIdentification.ID.schemeID);
								writer.WriteAttributeString("schemeName", partyIdentification.ID.schemeName);
								writer.WriteAttributeString("schemeURI", partyIdentification.ID.schemeURI);
								writer.WriteValue(partyIdentification.ID.Value);
								writer.WriteEndElement();
								writer.WriteEndElement();
							}

							foreach (var partyLegalEntity in carrierParty.PartyLegalEntity)
							{
								writer.WriteStartElement("cac:PartyLegalEntity");
								writer.WriteElementString("cbc:RegistrationName", partyLegalEntity.RegistrationName.Value);
								if (partyLegalEntity.CompanyID != null)
									writer.WriteElementString("cbc:CompanyID", partyLegalEntity.CompanyID.Value);
								writer.WriteEndElement();

							}

							if (carrierParty.AgentParty != null)
							{
								writer.WriteStartElement("cac:AgentParty");

								foreach (var PartyLegalEntity in carrierParty.AgentParty.PartyLegalEntity)
								{
									writer.WriteStartElement("cac:PartyLegalEntity");
									writer.WriteStartElement("cbc:CompanyID");
									writer.WriteAttributeString("schemeAgencyName", PartyLegalEntity.CompanyID.schemeAgencyName);
									writer.WriteAttributeString("schemeID", PartyLegalEntity.CompanyID.schemeID);
									writer.WriteAttributeString("schemeName", PartyLegalEntity.CompanyID.schemeName);
									writer.WriteValue(PartyLegalEntity.CompanyID.Value);
									writer.WriteEndElement();
									writer.WriteEndElement();
								}

								writer.WriteEndElement();
							}
							writer.WriteEndElement();
						}

					}

				}
				#endregion

				if (shipmentStage.TransportEvent != null)
				{
					foreach (var transportEvent in shipmentStage.TransportEvent)
					{
						writer.WriteStartElement("cac:TransportEvent");
						writer.WriteElementString("cbc:TransportEventTypeCode", transportEvent.TransportEventTypeCode.Value);
						writer.WriteEndElement();
					}
				}

				#region Conductor principal y Conductores secundarios

				if (shipmentStage.DriverPerson != null)
				{
					foreach (var driverPerson in shipmentStage.DriverPerson)
					{
						if (driverPerson.ID?.Value != "-")
						{
							writer.WriteStartElement("cac:DriverPerson");

							if (driverPerson.ID != null)
							{
								writer.WriteStartElement("cbc:ID");
								writer.WriteAttributeString("schemeAgencyName", driverPerson.ID.schemeAgencyName);
								writer.WriteAttributeString("schemeID", driverPerson.ID.schemeID);
								writer.WriteAttributeString("schemeName", driverPerson.ID.schemeName);
								writer.WriteAttributeString("schemeURI", driverPerson.ID.schemeURI);
								writer.WriteValue(driverPerson.ID.Value);
								writer.WriteEndElement();
							}

							if (driverPerson.FirstName != null)
							{
								writer.WriteElementString("cbc:FirstName", driverPerson.FirstName.Value);
							}

							if (driverPerson.FamilyName != null)
							{
								writer.WriteElementString("cbc:FamilyName", driverPerson.FamilyName.Value);
							}

							if (driverPerson.JobTitle != null)
							{
								writer.WriteElementString("cbc:JobTitle", driverPerson.JobTitle.Value);
							}

							if (driverPerson.IdentityDocumentReference != null)
							{
								foreach (var identityDocumentReference in driverPerson.IdentityDocumentReference)
								{
									writer.WriteStartElement("cac:IdentityDocumentReference");
									writer.WriteElementString("cbc:ID", identityDocumentReference.ID.Value);
									writer.WriteEndElement();
								}
							}
							writer.WriteEndElement();
						}

					}
				}

				#endregion


				writer.WriteEndElement();
			}


			writer.WriteStartElement("cac:Delivery");

			#region Dirección del punto de llegada

			if (Shipment.Delivery.DeliveryAddress != null)
			{
				writer.WriteStartElement("cac:DeliveryAddress");

				if (Shipment.Delivery.DeliveryAddress.ID != null)
				{
					writer.WriteStartElement("cbc:ID");
					writer.WriteAttributeString("schemeAgencyName", Shipment.Delivery.DeliveryAddress.ID.schemeAgencyName);
					writer.WriteAttributeString("schemeName", Shipment.Delivery.DeliveryAddress.ID.schemeName);
					writer.WriteValue(Shipment.Delivery.DeliveryAddress.ID.Value);
					writer.WriteEndElement();
				}

				if (Shipment.Delivery.DeliveryAddress.AddressTypeCode != null)
				{
					writer.WriteStartElement("cbc:AddressTypeCode");
					writer.WriteAttributeString("listAgencyName", Shipment.Delivery.DeliveryAddress.AddressTypeCode.listAgencyName);
					writer.WriteAttributeString("listID", Shipment.Delivery.DeliveryAddress.AddressTypeCode.listID);
					writer.WriteAttributeString("listName", Shipment.Delivery.DeliveryAddress.AddressTypeCode.listName);
					writer.WriteValue(Shipment.Delivery.DeliveryAddress.AddressTypeCode.Value);
					writer.WriteEndElement();
				}

				if (Shipment.Delivery.DeliveryAddress.AddressLine != null)
				{
					foreach (var addressLine in Shipment.Delivery.DeliveryAddress.AddressLine)
					{
						writer.WriteStartElement("cac:AddressLine");
						writer.WriteElementString("cbc:Line", addressLine.Line.Value);
						writer.WriteEndElement();
					}
				}

				if (Shipment.Delivery.DeliveryAddress.LocationCoordinate != null)
				{
					foreach (var locationCoordinate in Shipment.Delivery.DeliveryAddress.LocationCoordinate)
					{
						writer.WriteStartElement("cac:LocationCoordinate");

						writer.WriteStartElement("cbc:LatitudeDegreesMeasure");
						writer.WriteAttributeString("unitCode", locationCoordinate.LatitudeDegreesMeasure.unitCode);
						writer.WriteValue(locationCoordinate.LatitudeDegreesMeasure.Value);
						writer.WriteEndElement();

						writer.WriteStartElement("cbc:LongitudeDegreesMeasure");
						writer.WriteAttributeString("unitCode", locationCoordinate.LongitudeDegreesMeasure.unitCode);
						writer.WriteValue(locationCoordinate.LongitudeDegreesMeasure.Value);
						writer.WriteEndElement();

						writer.WriteEndElement();
					}
				}


				writer.WriteEndElement();
			}

			#endregion

			#region Dirección del punto de partida

			if (Shipment.Delivery.Despatch != null)
			{
				writer.WriteStartElement("cac:Despatch");

				if (Shipment.Delivery.Despatch.DespatchAddress != null)
				{
					writer.WriteStartElement("cac:DespatchAddress");

					if (Shipment.Delivery.Despatch.DespatchAddress.ID != null)
					{
						writer.WriteStartElement("cbc:ID");
						writer.WriteAttributeString("schemeAgencyName", Shipment.Delivery.Despatch.DespatchAddress.ID.schemeAgencyName);
						writer.WriteAttributeString("schemeName", Shipment.Delivery.Despatch.DespatchAddress.ID.schemeName);
						writer.WriteValue(Shipment.Delivery.Despatch.DespatchAddress.ID.Value);
						writer.WriteEndElement();
					}

					if (Shipment.Delivery.Despatch.DespatchAddress.AddressTypeCode != null)
					{
						writer.WriteStartElement("cbc:AddressTypeCode");
						writer.WriteAttributeString("listAgencyName", Shipment.Delivery.Despatch.DespatchAddress.AddressTypeCode.listAgencyName);
						writer.WriteAttributeString("listID", Shipment.Delivery.Despatch.DespatchAddress.AddressTypeCode.listID);
						writer.WriteAttributeString("listName", Shipment.Delivery.Despatch.DespatchAddress.AddressTypeCode.listName);
						writer.WriteValue(Shipment.Delivery.Despatch.DespatchAddress.AddressTypeCode.Value);
						writer.WriteEndElement();
					}

					if (Shipment.Delivery.Despatch.DespatchAddress.AddressLine != null)
					{
						foreach (var addressLine in Shipment.Delivery.Despatch.DespatchAddress.AddressLine)
						{
							writer.WriteStartElement("cac:AddressLine");
							writer.WriteElementString("cbc:Line", addressLine.Line.Value);
							writer.WriteEndElement();
						}
					}

					if (Shipment.Delivery.Despatch.DespatchAddress.LocationCoordinate != null)
					{
						foreach (var locationCoordinate in Shipment.Delivery.Despatch.DespatchAddress.LocationCoordinate)
						{
							writer.WriteStartElement("cac:LocationCoordinate");

							writer.WriteStartElement("cbc:LatitudeDegreesMeasure");
							writer.WriteAttributeString("unitCode", locationCoordinate.LatitudeDegreesMeasure.unitCode);
							writer.WriteValue(locationCoordinate.LatitudeDegreesMeasure.Value);
							writer.WriteEndElement();

							writer.WriteStartElement("cbc:LongitudeDegreesMeasure");
							writer.WriteAttributeString("unitCode", locationCoordinate.LongitudeDegreesMeasure.unitCode);
							writer.WriteValue(locationCoordinate.LongitudeDegreesMeasure.Value);
							writer.WriteEndElement();

							writer.WriteEndElement();
						}
					}

					writer.WriteEndElement();
				}


				if (Shipment.Delivery.Despatch.DespatchParty != null)
				{
					writer.WriteStartElement("cac:DespatchParty");

					if (Shipment.Delivery.Despatch.DespatchParty.PartyIdentification != null)
					{
						foreach (var partyIdentification in Shipment.Delivery.Despatch.DespatchParty.PartyIdentification)
						{
							writer.WriteStartElement("cac:PartyIdentification");
							writer.WriteStartElement("cbc:ID");
							writer.WriteAttributeString("schemeAgencyName", partyIdentification.ID.schemeAgencyName);
							writer.WriteAttributeString("schemeID", partyIdentification.ID.schemeID);
							writer.WriteAttributeString("schemeName", partyIdentification.ID.schemeName);
							writer.WriteAttributeString("schemeURI", partyIdentification.ID.schemeURI);
							writer.WriteValue(partyIdentification.ID.Value);
							writer.WriteEndElement();
							writer.WriteEndElement();
						}
					}

					if (Shipment.Delivery.Despatch.DespatchParty.PartyLegalEntity != null)
					{
						foreach (var partyLegalEntity in Shipment.Delivery.Despatch.DespatchParty.PartyLegalEntity)
						{
							writer.WriteStartElement("cac:PartyLegalEntity");
							writer.WriteStartElement("cbc:RegistrationName");
							writer.WriteValue(partyLegalEntity.RegistrationName.Value);
							writer.WriteEndElement();
							writer.WriteEndElement();
						}
					}

					if (Shipment.Delivery.Despatch.DespatchParty.AgentParty != null)
					{
						writer.WriteStartElement("cac:AgentParty");

						foreach (var partyLegalEntity in Shipment.Delivery.Despatch.DespatchParty.AgentParty.PartyLegalEntity)
						{
							writer.WriteStartElement("cac:PartyLegalEntity");
							writer.WriteStartElement("cbc:CompanyID");
							writer.WriteAttributeString("schemeAgencyName", partyLegalEntity.CompanyID.schemeAgencyName);
							writer.WriteAttributeString("schemeID", partyLegalEntity.CompanyID.schemeID);
							writer.WriteAttributeString("schemeName", partyLegalEntity.CompanyID.schemeName);
							writer.WriteValue(partyLegalEntity.CompanyID.Value);
							writer.WriteEndElement();
							writer.WriteEndElement();
						}

						writer.WriteEndElement();
					}

					writer.WriteEndElement();

				}



				writer.WriteEndElement();
			}

			#endregion

			writer.WriteEndElement();

			if (Shipment.TransportHandlingUnit != null)
			{
				foreach (var transportHandlingUnit in Shipment.TransportHandlingUnit)
				{
					writer.WriteStartElement("cac:TransportHandlingUnit");

					#region Vehiculo principal y secundario
					foreach (var transportEquipment in transportHandlingUnit.TransportEquipment)
					{
						if (transportEquipment.ID?.Value != "-")
						{
							writer.WriteStartElement("cac:TransportEquipment");

							if (transportEquipment.ID != null)
								writer.WriteElementString("cbc:ID", transportEquipment.ID.Value);

							if (transportEquipment.ApplicableTransportMeans != null)
							{
								writer.WriteStartElement("cac:ApplicableTransportMeans");
								writer.WriteElementString("cbc:RegistrationNationalityID", transportEquipment.ApplicableTransportMeans.RegistrationNationalityID.Value);
								writer.WriteEndElement();
							}

							if (transportEquipment.AttachedTransportEquipment != null)
							{
								foreach (var attachedTransportEquipment in transportEquipment.AttachedTransportEquipment)
								{
									writer.WriteStartElement("cac:AttachedTransportEquipment");

									if (attachedTransportEquipment.ID != null)
										writer.WriteElementString("cbc:ID", attachedTransportEquipment.ID.Value);

									if (attachedTransportEquipment.ApplicableTransportMeans != null)
									{
										writer.WriteStartElement("cac:ApplicableTransportMeans");
										writer.WriteElementString("cbc:RegistrationNationalityID", attachedTransportEquipment.ApplicableTransportMeans.RegistrationNationalityID.Value);
										writer.WriteEndElement();
									}

									if (attachedTransportEquipment.ShipmentDocumentReference != null)
									{
										foreach (var shipmentDocumentReference in attachedTransportEquipment.ShipmentDocumentReference)
										{
											writer.WriteStartElement("cac:ShipmentDocumentReference");
											writer.WriteStartElement("cbc:ID");
											writer.WriteAttributeString("schemeAgencyName", shipmentDocumentReference.ID.schemeAgencyName);
											writer.WriteAttributeString("schemeID", shipmentDocumentReference.ID.schemeID);
											writer.WriteAttributeString("schemeName", shipmentDocumentReference.ID.schemeName);
											writer.WriteValue(shipmentDocumentReference.ID.Value);
											writer.WriteEndElement();
											writer.WriteEndElement();
										}

									}

									writer.WriteEndElement();
								}


							}

							if (transportEquipment.ShipmentDocumentReference != null)
							{
								foreach (var shipmentDocumentReference in transportEquipment.ShipmentDocumentReference)
								{
									writer.WriteStartElement("cac:ShipmentDocumentReference");
									writer.WriteStartElement("cbc:ID");
									writer.WriteAttributeString("schemeAgencyName", shipmentDocumentReference.ID.schemeAgencyName);
									writer.WriteAttributeString("schemeID", shipmentDocumentReference.ID.schemeID);
									writer.WriteAttributeString("schemeName", shipmentDocumentReference.ID.schemeName);
									writer.WriteValue(shipmentDocumentReference.ID.Value);
									writer.WriteEndElement();
									writer.WriteEndElement();
								}
							}

							writer.WriteEndElement();
						}

					}

					#endregion

					#region Contenedores
					if (transportHandlingUnit.Package != null)
					{
						foreach (var package in transportHandlingUnit.Package)
						{
							writer.WriteStartElement("cac:Package");
							writer.WriteElementString("cbc:ID", package.ID.Value);
							writer.WriteElementString("cbc:TraceID", package.TraceID.Value);
							writer.WriteEndElement();
						}
					}


					#endregion

					writer.WriteEndElement();
				}

			}


			if (Shipment.FirstArrivalPortLocation != null)
			{
				writer.WriteStartElement("cac:FirstArrivalPortLocation");

				if (Shipment.FirstArrivalPortLocation.ID != null)
				{
					writer.WriteStartElement("cbc:ID");
					writer.WriteAttributeString("schemeAgencyName", Shipment.FirstArrivalPortLocation.ID.schemeAgencyName);
					writer.WriteAttributeString("schemeName", Shipment.FirstArrivalPortLocation.ID.schemeName);
					writer.WriteAttributeString("schemeURI", Shipment.FirstArrivalPortLocation.ID.schemeURI);
					writer.WriteValue(Shipment.HandlingCode.Value);
					writer.WriteEndElement();
				}

				if (Shipment.FirstArrivalPortLocation.LocationTypeCode != null)
					writer.WriteElementString("cbc:LocationTypeCode", Shipment.FirstArrivalPortLocation.LocationTypeCode.Value);

				if (Shipment.FirstArrivalPortLocation.Name != null)
					writer.WriteElementString("cbc:Name", Shipment.FirstArrivalPortLocation.Name.Value);

				writer.WriteEndElement();

			}


			writer.WriteEndElement();

			#endregion

			#region bienes a trasladar

			foreach (var despatchLine in DespatchLines.Where(x => x.ID.Value == "0").ToList())
			{
				writer.WriteStartElement("cac:DespatchLine");
				{
					writer.WriteElementString("cbc:ID", despatchLine.ID.Value);
					foreach (var orderLineReference in despatchLine.OrderLineReference)
					{
						writer.WriteStartElement("cac:OrderLineReference");
						{
							writer.WriteElementString("cbc:LineID", orderLineReference.LineID.Value);
						}
						writer.WriteEndElement();
					}

					writer.WriteStartElement("cac:Item");
					{
						foreach (var description in despatchLine.Item.Description)
						{
							writer.WriteElementString("cbc:Description", description.Value);
						}
					}
					writer.WriteEndElement();
				}
				writer.WriteEndElement();
			}

			foreach (var despatchLine in DespatchLines.Where(x => x.ID.Value != "0").ToList())
			{
				writer.WriteStartElement("cac:DespatchLine");
				{
					writer.WriteElementString("cbc:ID", despatchLine.ID.Value);
					writer.WriteStartElement("cbc:DeliveredQuantity");
					writer.WriteAttributeString("unitCode", despatchLine.DeliveredQuantity.unitCode);
					writer.WriteAttributeString("unitCodeListAgencyName", despatchLine.DeliveredQuantity.unitCodeListAgencyName);
					writer.WriteAttributeString("unitCodeListID", despatchLine.DeliveredQuantity.unitCodeListID);
					writer.WriteValue(despatchLine.DeliveredQuantity.Value.ToString(Formatos.FormatoNumerico10D, Formato));
					writer.WriteEndElement();

					foreach (var orderLineReference in despatchLine.OrderLineReference)
					{
						writer.WriteStartElement("cac:OrderLineReference");
						writer.WriteElementString("cbc:LineID", orderLineReference.LineID.Value);
						writer.WriteEndElement();
					}


					writer.WriteStartElement("cac:Item");

					foreach (var description in despatchLine.Item.Description)
					{
						writer.WriteElementString("cbc:Description", description.Value);
					}

					if (despatchLine.Item.SellersItemIdentification != null)
					{
						writer.WriteStartElement("cac:SellersItemIdentification");
						writer.WriteElementString("cbc:ID", despatchLine.Item.SellersItemIdentification.ID.Value);
						writer.WriteEndElement();
					}

					if (despatchLine.Item.StandardItemIdentification != null)
					{
						writer.WriteStartElement("cac:StandardItemIdentification");
						writer.WriteStartElement("cbc:ID");
						writer.WriteAttributeString("schemeID", despatchLine.Item.StandardItemIdentification.ID.schemeID);
						writer.WriteValue(despatchLine.Item.StandardItemIdentification.ID.Value);
						writer.WriteEndElement();
						writer.WriteEndElement();
					}

					if (despatchLine.Item.CommodityClassification != null)
					{
						foreach (var commodityClassification in despatchLine.Item.CommodityClassification)
						{
							writer.WriteStartElement("cac:CommodityClassification");
							writer.WriteStartElement("cbc:ItemClassificationCode");
							writer.WriteAttributeString("listAgencyName", commodityClassification.ItemClassificationCode.listAgencyName);
							writer.WriteAttributeString("listID", commodityClassification.ItemClassificationCode.listID);
							writer.WriteAttributeString("listName", commodityClassification.ItemClassificationCode.listName);
							writer.WriteValue(commodityClassification.ItemClassificationCode.Value);
							writer.WriteEndElement();
							writer.WriteEndElement();
						}

					}

					if (despatchLine.Item.AdditionalItemProperty != null)
					{
						foreach (var additionalItemProperty in despatchLine.Item.AdditionalItemProperty)
						{
							writer.WriteStartElement("cac:AdditionalItemProperty");

							writer.WriteElementString("cbc:Name", additionalItemProperty.Name.Value);

							writer.WriteStartElement("cbc:NameCode");
							writer.WriteAttributeString("listAgencyName", additionalItemProperty.NameCode.listAgencyName);
							writer.WriteAttributeString("listName", additionalItemProperty.NameCode.listName);
							writer.WriteAttributeString("listURI", additionalItemProperty.NameCode.listURI);
							writer.WriteValue(additionalItemProperty.NameCode.Value);
							writer.WriteEndElement();

							writer.WriteElementString("cbc:Value", additionalItemProperty.Value.Value);

							writer.WriteEndElement();
						}
					}

					writer.WriteEndElement();
				}
				writer.WriteEndElement();
			}

			#endregion

		}
	}
}
