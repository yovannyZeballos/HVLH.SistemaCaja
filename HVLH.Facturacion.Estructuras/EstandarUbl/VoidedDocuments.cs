using HVLH.Facturacion.Comun;
using HVLH.Facturacion.Estructuras.ComponentesAgregadoComunes;
using HVLH.Facturacion.Estructuras.ComponentesAgregadoSunat;
using HVLH.Facturacion.Estructuras.ComponentesExtensionComunes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace HVLH.Facturacion.Estructuras.EstandarUbl
{
	public class VoidedDocuments : IXmlSerializable, IEstructuraXml
	{
		public UblExtensions UblExtensions { get; set; }

		public string UblVersionId { get; set; }

		public string CustomizationId { get; set; }

		public string Id { get; set; }

		public DateTime IssueDate { get; set; }

		public DateTime ReferenceDate { get; set; }

		public SignatureCac Signature { get; set; }

		public AccountingSupplierParty AccountingSupplierParty { get; set; }

		public List<VoidedDocumentsLine> VoidedDocumentsLines { get; set; }

		public IFormatProvider Formato { get; set; }

		public VoidedDocuments()
		{
			this.UblExtensions = new UblExtensions();
			this.Signature = new SignatureCac();
			this.AccountingSupplierParty = new AccountingSupplierParty();
			this.VoidedDocumentsLines = new List<VoidedDocumentsLine>();
			this.UblVersionId = "2.0";
			this.CustomizationId = "1.0";
			this.Formato = (IFormatProvider)new CultureInfo("es-PE");
		}

		public XmlSchema GetSchema() => (XmlSchema)null;

		public void ReadXml(XmlReader reader) => throw new NotImplementedException();

		public void WriteXml(XmlWriter writer)
		{
			writer.WriteAttributeString("xmlns", "urn:sunat:names:specification:ubl:peru:schema:xsd:VoidedDocuments-1");
			writer.WriteAttributeString("xmlns:cac", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2");
			writer.WriteAttributeString("xmlns:cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2");
			writer.WriteAttributeString("xmlns:ds", "http://www.w3.org/2000/09/xmldsig#");
			writer.WriteAttributeString("xmlns:ext", "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2");
			writer.WriteAttributeString("xmlns:sac", "urn:sunat:names:specification:ubl:peru:schema:xsd:SunatAggregateComponents-1");
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
			writer.WriteElementString("cbc:ReferenceDate", this.ReferenceDate.ToString("yyyy-MM-dd"));
			writer.WriteElementString("cbc:IssueDate", this.IssueDate.ToString("yyyy-MM-dd"));
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
			writer.WriteStartElement("cac:AccountingSupplierParty");
			writer.WriteElementString("cbc:CustomerAssignedAccountID", this.AccountingSupplierParty.CustomerAssignedAccountId);
			writer.WriteElementString("cbc:AdditionalAccountID", this.AccountingSupplierParty.AdditionalAccountId);
			writer.WriteStartElement("cac:Party");
			writer.WriteStartElement("cac:PartyLegalEntity");
			writer.WriteStartElement("cbc:RegistrationName");
			writer.WriteCData(this.AccountingSupplierParty.Party.PartyLegalEntity.RegistrationName);
			writer.WriteEndElement();
			writer.WriteEndElement();
			writer.WriteEndElement();
			writer.WriteEndElement();
			foreach (VoidedDocumentsLine voidedDocumentsLine in this.VoidedDocumentsLines)
			{
				writer.WriteStartElement("sac:VoidedDocumentsLine");
				XmlWriter xmlWriter1 = writer;
				int num = voidedDocumentsLine.LineId;
				string str1 = num.ToString();
				xmlWriter1.WriteElementString("cbc:LineID", str1);
				writer.WriteElementString("cbc:DocumentTypeCode", voidedDocumentsLine.DocumentTypeCode);
				writer.WriteElementString("sac:DocumentSerialID", voidedDocumentsLine.DocumentSerialId);
				XmlWriter xmlWriter2 = writer;
				num = voidedDocumentsLine.DocumentNumberId;
				string str2 = num.ToString();
				xmlWriter2.WriteElementString("sac:DocumentNumberID", str2);
				writer.WriteElementString("sac:VoidReasonDescription", voidedDocumentsLine.VoidReasonDescription);
				writer.WriteEndElement();
			}
		}
	}
}
