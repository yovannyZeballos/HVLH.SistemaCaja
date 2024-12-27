using HVLH.Facturacion.Estructuras.ComponentesAgregadoComunes;
using HVLH.Facturacion.Estructuras.ComponentesExtensionComunes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using HVLH.Facturacion.Comun;

namespace HVLH.Facturacion.Estructuras.EstandarUbl
{
	[Serializable]
	public class DespatchAdvice : IXmlSerializable, IEstructuraXml
	{
		public UblExtensions UblExtensions { get; set; }

		public string UblVersionId { get; set; }

		public string CustomizationId { get; set; }

		public string Id { get; set; }

		public DateTime IssueDate { get; set; }

		public string DespatchAdviceTypeCode { get; set; }

		public string Note { get; set; }

		public OrderReference OrderReference { get; set; }

		public InvoiceDocumentReference AdditionalDocumentReference { get; set; }

		public SignatureCac Signature { get; set; }

		public AccountingSupplierParty DespatchSupplierParty { get; set; }

		public AccountingSupplierParty DeliveryCustomerParty { get; set; }

		public AccountingSupplierParty SellerSupplierParty { get; set; }

		public Shipment Shipment { get; set; }

		public List<DespatchLine> DespatchLines { get; set; }

		public IFormatProvider Formato { get; set; }

		public DespatchAdvice()
		{
			this.UblExtensions = new UblExtensions();
			this.OrderReference = new OrderReference();
			this.AdditionalDocumentReference = new InvoiceDocumentReference();
			this.Signature = new SignatureCac();
			this.DespatchSupplierParty = new AccountingSupplierParty();
			this.DeliveryCustomerParty = new AccountingSupplierParty();
			this.SellerSupplierParty = new AccountingSupplierParty();
			this.Shipment = new Shipment();
			this.DespatchLines = new List<DespatchLine>();
			this.UblVersionId = "2.0";
			this.CustomizationId = "1.0";
			this.Formato = (IFormatProvider)new CultureInfo("es-PE");
		}

		public XmlSchema GetSchema() => (XmlSchema)null;

		public void ReadXml(XmlReader reader) => throw new NotImplementedException();

		public void WriteXml(XmlWriter writer)
		{
			writer.WriteAttributeString("xmlns", "urn:oasis:names:specification:ubl:schema:xsd:DespatchAdvice-2");
			writer.WriteAttributeString("xmlns:cac", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2");
			writer.WriteAttributeString("xmlns:cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2");
			writer.WriteAttributeString("xmlns:ccts", "urn:un:unece:uncefact:documentation:2");
			writer.WriteAttributeString("xmlns:ds", "http://www.w3.org/2000/09/xmldsig#");
			writer.WriteAttributeString("xmlns:ext", "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2");
			writer.WriteAttributeString("xmlns:qdt", "urn:oasis:names:specification:ubl:schema:xsd:QualifiedDatatypes-2");
			writer.WriteAttributeString("xmlns:sac", "urn:sunat:names:specification:ubl:peru:schema:xsd:SunatAggregateComponents-1");
			writer.WriteAttributeString("xmlns:udt", "urn:un:unece:uncefact:data:specification:UnqualifiedDataTypesSchemaModule:2");
			writer.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
			writer.WriteStartElement("ext:UBLExtensions");
			writer.WriteStartElement("ext:UBLExtension");
			writer.WriteStartElement("ext:ExtensionContent");
			writer.WriteEndElement();
			writer.WriteEndElement();
			writer.WriteEndElement();
			writer.WriteElementString("cbc:UBLVersionID", this.UblVersionId);
			writer.WriteElementString("cbc:CustomizationID", this.CustomizationId);
			writer.WriteElementString("cbc:ID", this.Id);
			writer.WriteElementString("cbc:IssueDate", this.IssueDate.ToString("yyyy-MM-dd"));
			writer.WriteElementString("cbc:DespatchAdviceTypeCode", this.DespatchAdviceTypeCode);
			if (!string.IsNullOrEmpty(this.Note))
				writer.WriteElementString("cbc:Note", this.Note);
			if (!string.IsNullOrEmpty(this.OrderReference.Id))
			{
				writer.WriteStartElement("cac:OrderReference");
				writer.WriteElementString("cbc:ID", this.OrderReference.Id);
				writer.WriteStartElement("cbc:OrderTypeCode");
				writer.WriteAttributeString("name", this.OrderReference.OrderTypeCode.Name);
				writer.WriteValue(this.OrderReference.OrderTypeCode.Value);
				writer.WriteEndElement();
				writer.WriteEndElement();
			}
			if (!string.IsNullOrEmpty(this.AdditionalDocumentReference.Id))
			{
				writer.WriteStartElement("cac:AdditionalDocumentReference");
				writer.WriteElementString("cbc:ID", this.AdditionalDocumentReference.Id);
				writer.WriteElementString("cbc:DocumentTypeCode", this.AdditionalDocumentReference.DocumentTypeCode);
				writer.WriteEndElement();
			}
			writer.WriteStartElement("cac:Signature");
			writer.WriteElementString("cbc:ID", this.Signature.Id);
			writer.WriteStartElement("cac:SignatoryParty");
			writer.WriteStartElement("cac:PartyIdentification");
			writer.WriteElementString("cbc:ID", this.Signature.SignatoryParty.PartyIdentification.Id.Value);
			writer.WriteEndElement();
			writer.WriteStartElement("cac:PartyName");
			writer.WriteElementString("cbc:Name", this.Signature.SignatoryParty.PartyName.Name);
			writer.WriteEndElement();
			writer.WriteEndElement();
			writer.WriteStartElement("cac:DigitalSignatureAttachment");
			writer.WriteStartElement("cac:ExternalReference");
			writer.WriteElementString("cbc:URI", this.Signature.DigitalSignatureAttachment.ExternalReference.Uri.Trim());
			writer.WriteEndElement();
			writer.WriteEndElement();
			writer.WriteEndElement();
			writer.WriteStartElement("cac:DespatchSupplierParty");
			writer.WriteStartElement("cbc:CustomerAssignedAccountID");
			writer.WriteAttributeString("schemeID", this.DespatchSupplierParty.AdditionalAccountId);
			writer.WriteValue(this.DespatchSupplierParty.CustomerAssignedAccountId);
			writer.WriteEndElement();
			writer.WriteStartElement("cac:Party");
			writer.WriteStartElement("cac:PartyLegalEntity");
			writer.WriteElementString("cbc:RegistrationName", this.DespatchSupplierParty.Party.PartyLegalEntity.RegistrationName);
			writer.WriteEndElement();
			writer.WriteEndElement();
			writer.WriteEndElement();
			writer.WriteStartElement("cac:DeliveryCustomerParty");
			writer.WriteStartElement("cbc:CustomerAssignedAccountID");
			writer.WriteAttributeString("schemeID", this.DeliveryCustomerParty.AdditionalAccountId);
			writer.WriteValue(this.DeliveryCustomerParty.CustomerAssignedAccountId);
			writer.WriteEndElement();
			writer.WriteStartElement("cac:Party");
			writer.WriteStartElement("cac:PartyLegalEntity");
			writer.WriteElementString("cbc:RegistrationName", this.DeliveryCustomerParty.Party.PartyLegalEntity.RegistrationName);
			writer.WriteEndElement();
			writer.WriteEndElement();
			writer.WriteEndElement();
			if (!string.IsNullOrEmpty(this.SellerSupplierParty.AdditionalAccountId))
			{
				writer.WriteStartElement("cac:SellerSupplierParty");
				writer.WriteStartElement("cbc:CustomerAssignedAccountID");
				writer.WriteAttributeString("schemeID", this.SellerSupplierParty.AdditionalAccountId);
				writer.WriteValue(this.SellerSupplierParty.CustomerAssignedAccountId);
				writer.WriteEndElement();
				writer.WriteStartElement("cac:Party");
				writer.WriteStartElement("cac:PartyLegalEntity");
				writer.WriteElementString("cbc:RegistrationName", this.SellerSupplierParty.Party.PartyLegalEntity.RegistrationName);
				writer.WriteEndElement();
				writer.WriteEndElement();
				writer.WriteEndElement();
			}
			writer.WriteStartElement("cac:Shipment");
			writer.WriteElementString("cbc:HandlingCode", this.Shipment.HandlingCode);
			writer.WriteElementString("cbc:Information", this.Shipment.Information);
			writer.WriteElementString("cbc:SplitConsignmentIndicator", this.Shipment.SplitConsignmentIndicator.ToString().ToLower());
			writer.WriteStartElement("cbc:GrossWeightMeasure");
			writer.WriteAttributeString("unitCode", this.Shipment.GrossWeightMeasure.UnitCode);
			writer.WriteValue(this.Shipment.GrossWeightMeasure.Value.ToString("###0.#0"));
			writer.WriteEndElement();
			XmlWriter xmlWriter1 = writer;
			int num1 = this.Shipment.TotalTransportHandlingUnitQuantity;
			string str1 = num1.ToString();
			xmlWriter1.WriteElementString("cbc:TotalTransportHandlingUnitQuantity", str1);
			foreach (ShipmentStage shipmentStage in this.Shipment.ShipmentStages)
			{
				XmlWriter xmlWriter2 = writer;
				num1 = shipmentStage.Id;
				string str2 = num1.ToString();
				xmlWriter2.WriteElementString("cbc:ID", str2);
				writer.WriteElementString("cbc:TransportModeCode", shipmentStage.TransportModeCode);
				writer.WriteStartElement("cac:TransitPeriod");
				writer.WriteElementString("cbc:StartDate", shipmentStage.TransitPeriodStartPeriod.ToString("yyyy-MM-dd"));
				writer.WriteEndElement();
				if (!string.IsNullOrEmpty(shipmentStage.CarrierParty.PartyIdentification.Id.Value))
				{
					writer.WriteStartElement("cac:CarrierParty");
					writer.WriteStartElement("cac:PartyIdentification");
					writer.WriteStartElement("cbc:ID");
					writer.WriteAttributeString("schemeID", shipmentStage.CarrierParty.PartyIdentification.Id.SchemeId);
					writer.WriteValue(shipmentStage.CarrierParty.PartyIdentification.Id.Value);
					writer.WriteEndElement();
					writer.WriteEndElement();
					writer.WriteElementString("cbc:RegistrationName", shipmentStage.CarrierParty.PartyLegalEntity.RegistrationName);
					writer.WriteEndElement();
				}
				writer.WriteStartElement("cac:TransportMeans");
				writer.WriteStartElement("cac:RoadTransport");
				writer.WriteElementString("cbc:LicensePlateID", shipmentStage.TransportMeans.LicensePlateId);
				writer.WriteEndElement();
				writer.WriteEndElement();
				writer.WriteStartElement("cac:DriverPerson");
				writer.WriteStartElement("cbc:ID");
				writer.WriteAttributeString("schemeID", shipmentStage.DriverPerson.Id.SchemeId);
				writer.WriteValue(shipmentStage.DriverPerson.Id.Value);
				writer.WriteEndElement();
				writer.WriteEndElement();
			}
			writer.WriteStartElement("cac:DeliveryAddress");
			writer.WriteElementString("cbc:ID", this.Shipment.DeliveryAddress.Id);
			writer.WriteElementString("cbc:StreetName", this.Shipment.DeliveryAddress.StreetName);
			writer.WriteEndElement();
			writer.WriteStartElement("cac:TransportHandlingUnit");
			writer.WriteElementString("cbc:ID", this.Shipment.ShipmentStages.First<ShipmentStage>().TransportMeans.LicensePlateId);
			foreach (TransportEquipment transportEquipment in this.Shipment.TransportHandlingUnit.TransportEquipments)
			{
				if (!string.IsNullOrEmpty(transportEquipment.Id))
				{
					writer.WriteStartElement("cac:TransportEquipment");
					writer.WriteElementString("cbc:ID", transportEquipment.Id);
					writer.WriteEndElement();
				}
			}
			writer.WriteEndElement();
			writer.WriteStartElement("cac:OriginAddress");
			writer.WriteElementString("cbc:ID", this.Shipment.OriginAddress.Id);
			writer.WriteElementString("cbc:StreetName", this.Shipment.OriginAddress.StreetName);
			writer.WriteEndElement();
			if (!string.IsNullOrEmpty(this.Shipment.FirstArrivalPortLocationId))
			{
				writer.WriteStartElement("cac:FirstArrivalPortLocation");
				writer.WriteElementString("cbc:ID", this.Shipment.FirstArrivalPortLocationId);
				writer.WriteEndElement();
			}
			writer.WriteEndElement();
			foreach (DespatchLine despatchLine in this.DespatchLines)
			{
				writer.WriteStartElement("cac:DespatchLine");
				XmlWriter xmlWriter2 = writer;
				int num2 = despatchLine.Id;
				string str2 = num2.ToString();
				xmlWriter2.WriteElementString("cbc:ID", str2);
				writer.WriteStartElement("cbc:DeliveredQuantity");
				writer.WriteAttributeString("unitCode", despatchLine.DeliveredQuantity.UnitCode);
				writer.WriteValue(despatchLine.DeliveredQuantity.Value.ToString("###0.#0"));
				writer.WriteEndElement();
				if (despatchLine.OrderLineReferenceId > 0)
				{
					writer.WriteStartElement("cac:OrderLineReference");
					XmlWriter xmlWriter3 = writer;
					num2 = despatchLine.OrderLineReferenceId;
					string str3 = num2.ToString();
					xmlWriter3.WriteElementString("cbc:LineID", str3);
					writer.WriteEndElement();
				}
				writer.WriteStartElement("cac:Item");
				writer.WriteElementString("cbc:Description", despatchLine.Item.Description);
				writer.WriteStartElement("cac:SellersItemIdentification");
				writer.WriteElementString("cbc:ID", despatchLine.Item.SellersIdentificationId);
				writer.WriteEndElement();
				writer.WriteEndElement();
				writer.WriteEndElement();
			}
		}
	}
}
