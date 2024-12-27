using HVLH.Facturacion.Comun;
using HVLH.Facturacion.Estructuras.ComponentesAgregadoComunes;
using HVLH.Facturacion.Estructuras.ComponentesAgregadoSunat;
using HVLH.Facturacion.Estructuras.ComponentesBasicosComunes;
using HVLH.Facturacion.Estructuras.ComponentesExtensionComunes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace HVLH.Facturacion.Estructuras.EstandarUbl
{
	[Serializable]
	public class Perception : IXmlSerializable, IEstructuraXml
	{
		public string UblVersionId { get; set; }

		public string CustomizationId { get; set; }

		public string Id { get; set; }

		public UblExtensions UblExtensions { get; set; }

		public SignatureCac Signature { get; set; }

		public string IssueDate { get; set; }

		public AgentParty AgentParty { get; set; }

		public AgentParty ReceiverParty { get; set; }

		public string SunatPerceptionSystemCode { get; set; }

		public Decimal SunatPerceptionPercent { get; set; }

		public string Note { get; set; }

		public PayableAmount TotalInvoiceAmount { get; set; }

		public PayableAmount TotalPaid { get; set; }

		public List<SunatRetentionDocumentReference> SunatPerceptionDocumentReference { get; set; }

		public IFormatProvider Formato { get; set; }

		public Perception()
		{
			this.UblExtensions = new UblExtensions();
			this.AgentParty = new AgentParty();
			this.ReceiverParty = new AgentParty();
			this.TotalInvoiceAmount = new PayableAmount();
			this.TotalPaid = new PayableAmount();
			this.SunatPerceptionDocumentReference = new List<SunatRetentionDocumentReference>();
			this.UblVersionId = "2.0";
			this.CustomizationId = "1.0";
			this.Formato = (IFormatProvider)new CultureInfo("es-PE");
		}

		public XmlSchema GetSchema() => (XmlSchema)null;

		public void ReadXml(XmlReader reader) => throw new NotImplementedException();

		public void WriteXml(XmlWriter writer)
		{
			writer.WriteAttributeString("xmlns", "urn:sunat:names:specification:ubl:peru:schema:xsd:Perception-1");
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
			writer.WriteStartElement("cac:Signature");
			writer.WriteElementString("cbc:ID", this.Signature.Id);
			writer.WriteStartElement("cac:SignatoryParty");
			writer.WriteStartElement("cac:PartyIdentification");
			writer.WriteElementString("cbc:ID", this.Signature.SignatoryParty.PartyIdentification.Id.Value);
			writer.WriteEndElement();
			writer.WriteStartElement("cac:PartyName");
			writer.WriteStartElement("cbc:Name");
			writer.WriteCData(this.Signature.SignatoryParty.PartyName.Name);
			writer.WriteEndElement();
			writer.WriteEndElement();
			writer.WriteEndElement();
			writer.WriteStartElement("cac:DigitalSignatureAttachment");
			writer.WriteStartElement("cac:ExternalReference");
			writer.WriteElementString("cbc:URI", this.Signature.DigitalSignatureAttachment.ExternalReference.Uri);
			writer.WriteEndElement();
			writer.WriteEndElement();
			writer.WriteEndElement();
			writer.WriteElementString("cbc:ID", this.Id);
			writer.WriteElementString("cbc:IssueDate", this.IssueDate);
			writer.WriteStartElement("cac:AgentParty");
			writer.WriteStartElement("cac:PartyIdentification");
			writer.WriteStartElement("cbc:ID");
			writer.WriteAttributeString("schemeID", this.AgentParty.PartyIdentification.Id.SchemeId);
			writer.WriteValue(this.AgentParty.PartyIdentification.Id.Value);
			writer.WriteEndElement();
			writer.WriteEndElement();
			writer.WriteStartElement("cac:PartyName");
			writer.WriteStartElement("cbc:Name");
			writer.WriteCData(this.AgentParty.PartyName.Name);
			writer.WriteEndElement();
			writer.WriteEndElement();
			writer.WriteStartElement("cac:PostalAddress");
			writer.WriteElementString("cbc:ID", this.AgentParty.PostalAddress.Id);
			writer.WriteStartElement("cbc:StreetName");
			writer.WriteCData(this.AgentParty.PostalAddress.StreetName);
			writer.WriteEndElement();
			writer.WriteElementString("cbc:CitySubdivisionName", this.AgentParty.PostalAddress.CitySubdivisionName);
			writer.WriteElementString("cbc:CityName", this.AgentParty.PostalAddress.CityName);
			writer.WriteElementString("cbc:CountrySubentity", this.AgentParty.PostalAddress.CountrySubentity);
			writer.WriteElementString("cbc:District", this.AgentParty.PostalAddress.District);
			writer.WriteStartElement("cac:Country");
			writer.WriteElementString("cbc:IdentificationCode", this.AgentParty.PostalAddress.Country.IdentificationCode);
			writer.WriteEndElement();
			writer.WriteEndElement();
			writer.WriteStartElement("cac:PartyLegalEntity");
			writer.WriteStartElement("cbc:RegistrationName");
			writer.WriteCData(this.AgentParty.PartyLegalEntity.RegistrationName);
			writer.WriteEndElement();
			writer.WriteEndElement();
			writer.WriteEndElement();
			writer.WriteStartElement("cac:ReceiverParty");
			writer.WriteStartElement("cac:PartyIdentification");
			writer.WriteStartElement("cbc:ID");
			writer.WriteAttributeString("schemeID", this.ReceiverParty.PartyIdentification.Id.SchemeId);
			writer.WriteValue(this.ReceiverParty.PartyIdentification.Id.Value);
			writer.WriteEndElement();
			writer.WriteEndElement();
			writer.WriteStartElement("cac:PartyName");
			writer.WriteStartElement("cbc:Name");
			writer.WriteCData(this.ReceiverParty.PartyName.Name);
			writer.WriteEndElement();
			writer.WriteEndElement();
			writer.WriteStartElement("cac:PostalAddress");
			if (!string.IsNullOrEmpty(this.ReceiverParty.PostalAddress.Id))
				writer.WriteElementString("cbc:ID", this.ReceiverParty.PostalAddress.Id);
			writer.WriteElementString("cbc:StreetName", this.ReceiverParty.PostalAddress.StreetName);
			writer.WriteElementString("cbc:CitySubdivisionName", this.ReceiverParty.PostalAddress.CitySubdivisionName);
			writer.WriteElementString("cbc:CityName", this.ReceiverParty.PostalAddress.CityName);
			writer.WriteElementString("cbc:CountrySubentity", this.ReceiverParty.PostalAddress.CountrySubentity);
			writer.WriteElementString("cbc:District", this.ReceiverParty.PostalAddress.District);
			writer.WriteStartElement("cac:Country");
			writer.WriteElementString("cbc:IdentificationCode", this.ReceiverParty.PostalAddress.Country.IdentificationCode);
			writer.WriteEndElement();
			writer.WriteEndElement();
			writer.WriteStartElement("cac:PartyLegalEntity");
			writer.WriteStartElement("cbc:RegistrationName");
			writer.WriteCData(this.ReceiverParty.PartyLegalEntity.RegistrationName);
			writer.WriteEndElement();
			writer.WriteEndElement();
			writer.WriteEndElement();
			writer.WriteElementString("sac:SUNATPerceptionSystemCode", this.SunatPerceptionSystemCode);
			writer.WriteElementString("sac:SUNATPerceptionPercent", this.SunatPerceptionPercent.ToString("###0.#0", this.Formato));
			if (!string.IsNullOrEmpty(this.Note))
				writer.WriteElementString("cbc:Note", this.Note);
			writer.WriteStartElement("cbc:TotalInvoiceAmount");
			writer.WriteAttributeString("currencyID", this.TotalInvoiceAmount.CurrencyId);
			writer.WriteValue(this.TotalInvoiceAmount.Value.ToString("###0.#0", this.Formato));
			writer.WriteEndElement();
			writer.WriteStartElement("sac:SUNATTotalCashed");
			writer.WriteAttributeString("currencyID", this.TotalPaid.CurrencyId);
			XmlWriter xmlWriter1 = writer;
			Decimal calculationRate = this.TotalPaid.Value;
			string str1 = calculationRate.ToString("###0.#0", this.Formato);
			xmlWriter1.WriteValue(str1);
			writer.WriteEndElement();
			foreach (SunatRetentionDocumentReference documentReference in this.SunatPerceptionDocumentReference)
			{
				writer.WriteStartElement("sac:SUNATPerceptionDocumentReference");
				writer.WriteStartElement("cbc:ID");
				writer.WriteAttributeString("schemeID", documentReference.Id.SchemeId);
				writer.WriteValue(documentReference.Id.Value);
				writer.WriteEndElement();
				writer.WriteElementString("cbc:IssueDate", documentReference.IssueDate);
				writer.WriteStartElement("cbc:TotalInvoiceAmount");
				writer.WriteAttributeString("currencyID", documentReference.TotalInvoiceAmount.CurrencyId);
				XmlWriter xmlWriter2 = writer;
				calculationRate = documentReference.TotalInvoiceAmount.Value;
				string str2 = calculationRate.ToString("###0.#0", this.Formato);
				xmlWriter2.WriteValue(str2);
				writer.WriteEndElement();
				writer.WriteStartElement("cac:Payment");
				writer.WriteElementString("cbc:ID", documentReference.Payment.IdPayment.ToString());
				writer.WriteStartElement("cbc:PaidAmount");
				writer.WriteAttributeString("currencyID", documentReference.Payment.PaidAmount.CurrencyId);
				XmlWriter xmlWriter3 = writer;
				calculationRate = documentReference.Payment.PaidAmount.Value;
				string str3 = calculationRate.ToString("###0.#0", this.Formato);
				xmlWriter3.WriteValue(str3);
				writer.WriteEndElement();
				writer.WriteElementString("cbc:PaidDate", documentReference.Payment.PaidDate);
				writer.WriteEndElement();
				writer.WriteStartElement("sac:SUNATPerceptionInformation");
				writer.WriteStartElement("sac:SUNATPerceptionAmount");
				writer.WriteAttributeString("currencyID", documentReference.SunatRetentionInformation.SunatRetentionAmount.CurrencyId);
				XmlWriter xmlWriter4 = writer;
				calculationRate = documentReference.SunatRetentionInformation.SunatRetentionAmount.Value;
				string str4 = calculationRate.ToString("###0.#0", this.Formato);
				xmlWriter4.WriteValue(str4);
				writer.WriteEndElement();
				writer.WriteElementString("sac:SUNATPerceptionDate", documentReference.SunatRetentionInformation.SunatRetentionDate);
				writer.WriteStartElement("sac:SUNATNetTotalCashed");
				writer.WriteAttributeString("currencyID", documentReference.SunatRetentionInformation.SunatNetTotalPaid.CurrencyId);
				XmlWriter xmlWriter5 = writer;
				calculationRate = documentReference.SunatRetentionInformation.SunatNetTotalPaid.Value;
				string str5 = calculationRate.ToString("###0.#0", this.Formato);
				xmlWriter5.WriteValue(str5);
				writer.WriteEndElement();
				writer.WriteStartElement("cac:ExchangeRate");
				writer.WriteElementString("cbc:SourceCurrencyCode", documentReference.SunatRetentionInformation.ExchangeRate.SourceCurrencyCode);
				writer.WriteElementString("cbc:TargetCurrencyCode", documentReference.SunatRetentionInformation.ExchangeRate.TargetCurrencyCode);
				XmlWriter xmlWriter6 = writer;
				calculationRate = documentReference.SunatRetentionInformation.ExchangeRate.CalculationRate;
				string str6 = calculationRate.ToString("###0.#0", this.Formato);
				xmlWriter6.WriteElementString("cbc:CalculationRate", str6);
				writer.WriteElementString("cbc:Date", !string.IsNullOrEmpty(documentReference.SunatRetentionInformation.ExchangeRate.Date) ? documentReference.SunatRetentionInformation.ExchangeRate.Date : documentReference.SunatRetentionInformation.SunatRetentionDate);
				writer.WriteEndElement();
				writer.WriteEndElement();
				writer.WriteEndElement();
			}
		}
	}
}
