using HVLH.Facturacion.Estructuras.ComponentesAgregadoComunes;
using HVLH.Facturacion.Estructuras.ComponentesBasicosComunes;
using HVLH.Facturacion.Estructuras.ComponentesExtensionComunes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using HVLH.Facturacion.Comun;

namespace HVLH.Facturacion.Estructuras.EstandarUbl
{
	[Serializable]
	public class Retention : IXmlSerializable, IEstructuraXml
	{
		public string UblVersionId { get; set; }

		public string CustomizationId { get; set; }

		public UblExtensions UblExtensions { get; set; }

		public SignatureCac Signature { get; set; }

		public string Id { get; set; }

		public string IssueDate { get; set; }

		public AgentParty AgentParty { get; set; }

		public AgentParty ReceiverParty { get; set; }

		public string SunatRetentionSystemCode { get; set; }

		public Decimal SunatRetentionPercent { get; set; }

		public string Note { get; set; }

		public PayableAmount TotalInvoiceAmount { get; set; }

		public PayableAmount TotalPaid { get; set; }

		public List<HVLH.Facturacion.Estructuras.ComponentesAgregadoSunat.SunatRetentionDocumentReference> SunatRetentionDocumentReference { get; set; }

		public IFormatProvider Formato { get; set; }

		public Retention()
		{
			this.UblExtensions = new UblExtensions();
			this.AgentParty = new AgentParty();
			this.ReceiverParty = new AgentParty();
			this.TotalInvoiceAmount = new PayableAmount();
			this.TotalPaid = new PayableAmount();
			this.SunatRetentionDocumentReference = new List<HVLH.Facturacion.Estructuras.ComponentesAgregadoSunat.SunatRetentionDocumentReference>();
			this.UblVersionId = "2.0";
			this.CustomizationId = "1.0";
			this.Formato = (IFormatProvider)new CultureInfo("es-PE");
		}

		public XmlSchema GetSchema() => (XmlSchema)null;

		public void ReadXml(XmlReader reader) => reader.ReadStartElement("ext:Extensions");

		public void WriteXml(XmlWriter writer)
		{
			writer.WriteAttributeString("xmlns", "urn:sunat:names:specification:ubl:peru:schema:xsd:Retention-1");
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
			writer.WriteElementString("cbc:IssueDate", Convert.ToDateTime(this.IssueDate).ToString("yyyy-MM-dd"));
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
			writer.WriteStartElement("cac:PartyLegalEntity");
			writer.WriteStartElement("cbc:RegistrationName");
			writer.WriteCData(this.ReceiverParty.PartyLegalEntity.RegistrationName);
			writer.WriteEndElement();
			writer.WriteEndElement();
			writer.WriteEndElement();
			writer.WriteElementString("sac:SUNATRetentionSystemCode", this.SunatRetentionSystemCode);
			writer.WriteElementString("sac:SUNATRetentionPercent", this.SunatRetentionPercent.ToString("###0.#0", this.Formato));
			if (!string.IsNullOrEmpty(this.Note))
				writer.WriteElementString("cbc:Note", this.Note);
			writer.WriteStartElement("cbc:TotalInvoiceAmount");
			writer.WriteAttributeString("currencyID", this.TotalInvoiceAmount.CurrencyId);
			writer.WriteValue(this.TotalInvoiceAmount.Value.ToString("###0.#0", this.Formato));
			writer.WriteEndElement();
			writer.WriteStartElement("sac:SUNATTotalPaid");
			writer.WriteAttributeString("currencyID", this.TotalPaid.CurrencyId);
			XmlWriter xmlWriter1 = writer;
			Decimal calculationRate = this.TotalPaid.Value;
			string str1 = calculationRate.ToString("###0.#0", this.Formato);
			xmlWriter1.WriteValue(str1);
			writer.WriteEndElement();
			foreach (HVLH.Facturacion.Estructuras.ComponentesAgregadoSunat.SunatRetentionDocumentReference documentReference in this.SunatRetentionDocumentReference)
			{
				writer.WriteStartElement("sac:SUNATRetentionDocumentReference");
				writer.WriteStartElement("cbc:ID");
				writer.WriteAttributeString("schemeID", documentReference.Id.SchemeId);
				writer.WriteValue(documentReference.Id.Value);
				writer.WriteEndElement();
				XmlWriter xmlWriter2 = writer;
				DateTime dateTime = Convert.ToDateTime(documentReference.IssueDate);
				string str2 = dateTime.ToString("yyyy-MM-dd");
				xmlWriter2.WriteElementString("cbc:IssueDate", str2);
				writer.WriteStartElement("cbc:TotalInvoiceAmount");
				writer.WriteAttributeString("currencyID", documentReference.TotalInvoiceAmount.CurrencyId);
				XmlWriter xmlWriter3 = writer;
				calculationRate = documentReference.TotalInvoiceAmount.Value;
				string str3 = calculationRate.ToString("###0.#0", this.Formato);
				xmlWriter3.WriteValue(str3);
				writer.WriteEndElement();
				if (!documentReference.Id.SchemeId.Equals("07"))
				{
					writer.WriteStartElement("cac:Payment");
					writer.WriteElementString("cbc:ID", documentReference.Payment.IdPayment.ToString());
					writer.WriteStartElement("cbc:PaidAmount");
					writer.WriteAttributeString("currencyID", documentReference.Payment.PaidAmount.CurrencyId);
					XmlWriter xmlWriter4 = writer;
					calculationRate = documentReference.Payment.PaidAmount.Value;
					string str4 = calculationRate.ToString("###0.#0", this.Formato);
					xmlWriter4.WriteValue(str4);
					writer.WriteEndElement();
					XmlWriter xmlWriter5 = writer;
					dateTime = Convert.ToDateTime(documentReference.Payment.PaidDate);
					string str5 = dateTime.ToString("yyyy-MM-dd");
					xmlWriter5.WriteElementString("cbc:PaidDate", str5);
					writer.WriteEndElement();
					writer.WriteStartElement("sac:SUNATRetentionInformation");
					writer.WriteStartElement("sac:SUNATRetentionAmount");
					writer.WriteAttributeString("currencyID", documentReference.SunatRetentionInformation.SunatRetentionAmount.CurrencyId);
					XmlWriter xmlWriter6 = writer;
					calculationRate = documentReference.SunatRetentionInformation.SunatRetentionAmount.Value;
					string str6 = calculationRate.ToString("###0.#0", this.Formato);
					xmlWriter6.WriteValue(str6);
					writer.WriteEndElement();
					XmlWriter xmlWriter7 = writer;
					dateTime = Convert.ToDateTime(documentReference.SunatRetentionInformation.SunatRetentionDate);
					string str7 = dateTime.ToString("yyyy-MM-dd");
					xmlWriter7.WriteElementString("sac:SUNATRetentionDate", str7);
					writer.WriteStartElement("sac:SUNATNetTotalPaid");
					writer.WriteAttributeString("currencyID", documentReference.SunatRetentionInformation.SunatNetTotalPaid.CurrencyId);
					XmlWriter xmlWriter8 = writer;
					calculationRate = documentReference.SunatRetentionInformation.SunatNetTotalPaid.Value;
					string str8 = calculationRate.ToString("###0.#0", this.Formato);
					xmlWriter8.WriteValue(str8);
					writer.WriteEndElement();
					writer.WriteStartElement("cac:ExchangeRate");
					writer.WriteElementString("cbc:SourceCurrencyCode", documentReference.SunatRetentionInformation.ExchangeRate.SourceCurrencyCode);
					writer.WriteElementString("cbc:TargetCurrencyCode", documentReference.SunatRetentionInformation.ExchangeRate.TargetCurrencyCode);
					XmlWriter xmlWriter9 = writer;
					calculationRate = documentReference.SunatRetentionInformation.ExchangeRate.CalculationRate;
					string str9 = calculationRate.ToString();
					xmlWriter9.WriteElementString("cbc:CalculationRate", str9);
					XmlWriter xmlWriter10 = writer;
					string str10;
					if (string.IsNullOrEmpty(documentReference.SunatRetentionInformation.ExchangeRate.Date))
					{
						dateTime = Convert.ToDateTime(documentReference.SunatRetentionInformation.SunatRetentionDate);
						str10 = dateTime.ToString("yyyy-MM-dd");
					}
					else
					{
						dateTime = Convert.ToDateTime(documentReference.SunatRetentionInformation.ExchangeRate.Date);
						str10 = dateTime.ToString("yyyy-MM-dd");
					}
					xmlWriter10.WriteElementString("cbc:Date", str10);
					writer.WriteEndElement();
					writer.WriteEndElement();
				}
				writer.WriteEndElement();
			}
		}
	}
}
