
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
	[Serializable]
	public class SummaryDocuments : IXmlSerializable, IEstructuraXml
	{
		public UblExtensions UblExtensions { get; set; }

		public string UblVersionId { get; set; }

		public string CustomizationId { get; set; }

		public string Id { get; set; }

		public DateTime IssueDate { get; set; }

		public DateTime ReferenceDate { get; set; }

		public SignatureCac Signature { get; set; }

		public AccountingSupplierParty AccountingSupplierParty { get; set; }

		public List<VoidedDocumentsLine> SummaryDocumentsLines { get; set; }

		public IFormatProvider Formato { get; set; }

		public SummaryDocuments()
		{
			this.UblExtensions = new UblExtensions();
			this.Signature = new SignatureCac();
			this.AccountingSupplierParty = new AccountingSupplierParty();
			this.SummaryDocumentsLines = new List<VoidedDocumentsLine>();
			this.UblVersionId = "2.0";
			this.CustomizationId = "1.0";
			this.Formato = (IFormatProvider)new CultureInfo("es-PE");
		}

		public XmlSchema GetSchema() => (XmlSchema)null;

		public void ReadXml(XmlReader reader) => throw new NotImplementedException();

		public void WriteXml(XmlWriter writer)
		{
			writer.WriteAttributeString("xmlns", "urn:sunat:names:specification:ubl:peru:schema:xsd:SummaryDocuments-1");
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
			foreach (VoidedDocumentsLine summaryDocumentsLine in this.SummaryDocumentsLines)
			{
				writer.WriteStartElement("sac:SummaryDocumentsLine");
				XmlWriter xmlWriter1 = writer;
				int num1 = summaryDocumentsLine.LineId;
				string str1 = num1.ToString();
				xmlWriter1.WriteElementString("cbc:LineID", str1);
				writer.WriteElementString("cbc:DocumentTypeCode", summaryDocumentsLine.DocumentTypeCode);
				if (!string.IsNullOrEmpty(summaryDocumentsLine.Id))
				{
					writer.WriteElementString("cbc:ID", summaryDocumentsLine.Id);
				}
				else
				{
					writer.WriteElementString("sac:DocumentSerialID", summaryDocumentsLine.DocumentSerialId);
					XmlWriter xmlWriter2 = writer;
					num1 = summaryDocumentsLine.StartDocumentNumberId;
					string str2 = num1.ToString();
					xmlWriter2.WriteElementString("sac:StartDocumentNumberID", str2);
					XmlWriter xmlWriter3 = writer;
					num1 = summaryDocumentsLine.EndDocumentNumberId;
					string str3 = num1.ToString();
					xmlWriter3.WriteElementString("sac:EndDocumentNumberID", str3);
				}
				if (!string.IsNullOrEmpty(summaryDocumentsLine.AccountingCustomerParty.AdditionalAccountId))
				{
					writer.WriteStartElement("cac:AccountingCustomerParty");
					writer.WriteElementString("cbc:CustomerAssignedAccountID", summaryDocumentsLine.AccountingCustomerParty.CustomerAssignedAccountId);
					writer.WriteElementString("cbc:AdditionalAccountID", summaryDocumentsLine.AccountingCustomerParty.AdditionalAccountId);
					writer.WriteEndElement();
				}
				if (!string.IsNullOrEmpty(summaryDocumentsLine.BillingReference.InvoiceDocumentReference.Id))
				{
					writer.WriteStartElement("cac:BillingReference");
					writer.WriteStartElement("cac:InvoiceDocumentReference");
					writer.WriteElementString("cbc:ID", summaryDocumentsLine.BillingReference.InvoiceDocumentReference.Id);
					writer.WriteElementString("cbc:DocumentTypeCode", summaryDocumentsLine.BillingReference.InvoiceDocumentReference.DocumentTypeCode);
					writer.WriteEndElement();
					writer.WriteEndElement();
				}
				if (summaryDocumentsLine.ConditionCode.HasValue)
				{
					writer.WriteStartElement("cac:Status");
					XmlWriter xmlWriter2 = writer;
					num1 = summaryDocumentsLine.ConditionCode.Value;
					string str2 = num1.ToString();
					xmlWriter2.WriteElementString("cbc:ConditionCode", str2);
					writer.WriteEndElement();
				}
				writer.WriteStartElement("sac:TotalAmount");
				writer.WriteAttributeString("currencyID", summaryDocumentsLine.TotalAmount.CurrencyId);
				writer.WriteValue(summaryDocumentsLine.TotalAmount.Value.ToString("###0.#0", this.Formato));
				writer.WriteEndElement();
				foreach (BillingPayment billingPayment in summaryDocumentsLine.BillingPayments)
				{
					if (billingPayment.PaidAmount.Value > 0M)
					{
						writer.WriteStartElement("sac:BillingPayment");
						writer.WriteStartElement("cbc:PaidAmount");
						writer.WriteAttributeString("currencyID", summaryDocumentsLine.TotalAmount.CurrencyId);
						writer.WriteValue(billingPayment.PaidAmount.Value.ToString("###0.#0", this.Formato));
						writer.WriteEndElement();
						writer.WriteElementString("cbc:InstructionID", billingPayment.InstructionId);
						writer.WriteEndElement();
					}
				}
				if (summaryDocumentsLine.AllowanceCharge.Amount.Value > 0M)
				{
					writer.WriteStartElement("cac:AllowanceCharge");
					writer.WriteElementString("cbc:ChargeIndicator", summaryDocumentsLine.AllowanceCharge.ChargeIndicator ? "true" : "false");
					writer.WriteStartElement("cbc:Amount");
					writer.WriteAttributeString("currencyID", summaryDocumentsLine.AllowanceCharge.Amount.CurrencyId);
					writer.WriteValue(summaryDocumentsLine.AllowanceCharge.Amount.Value.ToString("###0.#0", this.Formato));
					writer.WriteEndElement();
					writer.WriteEndElement();
				}
				foreach (TaxTotal taxTotal in summaryDocumentsLine.TaxTotals)
				{
					writer.WriteStartElement("cac:TaxTotal");
					writer.WriteStartElement("cbc:TaxAmount");
					writer.WriteAttributeString("currencyID", taxTotal.TaxAmount.CurrencyId);
					XmlWriter xmlWriter2 = writer;
					Decimal num2 = taxTotal.TaxAmount.Value;
					string text1 = num2.ToString("###0.#0", this.Formato);
					xmlWriter2.WriteString(text1);
					writer.WriteEndElement();
					writer.WriteStartElement("cac:TaxSubtotal");
					writer.WriteStartElement("cbc:TaxAmount");
					writer.WriteAttributeString("currencyID", taxTotal.TaxSubtotal.TaxAmount.CurrencyId);
					XmlWriter xmlWriter3 = writer;
					num2 = taxTotal.TaxAmount.Value;
					string text2 = num2.ToString("###0.#0", this.Formato);
					xmlWriter3.WriteString(text2);
					writer.WriteEndElement();
					writer.WriteStartElement("cac:TaxCategory");
					writer.WriteStartElement("cac:TaxScheme");
					writer.WriteElementString("cbc:ID", taxTotal.TaxSubtotal.TaxCategory.TaxScheme.Id);
					writer.WriteElementString("cbc:Name", taxTotal.TaxSubtotal.TaxCategory.TaxScheme.Name);
					writer.WriteElementString("cbc:TaxTypeCode", taxTotal.TaxSubtotal.TaxCategory.TaxScheme.TaxTypeCode);
					writer.WriteEndElement();
					writer.WriteEndElement();
					writer.WriteEndElement();
					writer.WriteEndElement();
				}
				writer.WriteEndElement();
			}
		}
	}
}
