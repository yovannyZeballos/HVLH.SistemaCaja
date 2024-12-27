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
	public class Invoice : IXmlSerializable, IEstructuraXml
	{
		public DateTime IssueDate { get; set; }

		public UblExtensions UblExtensions { get; set; }

		public SignatureCac Signature { get; set; }

		public AccountingSupplierParty AccountingSupplierParty { get; set; }

		public string InvoiceTypeCode { get; set; }

		public string Id { get; set; }

		public AccountingSupplierParty AccountingCustomerParty { get; set; }

		public List<InvoiceLine> InvoiceLines { get; set; }

		public List<InvoiceDocumentReference> DespatchDocumentReferences { get; set; }

		public string DocumentCurrencyCode { get; set; }

		public List<TaxTotal> TaxTotals { get; set; }

		public LegalMonetaryTotal LegalMonetaryTotal { get; set; }

		public List<BillingPayment> PrepaidPayments { get; set; }

		public string UblVersionId { get; set; }

		public string CustomizationId { get; set; }

		public IFormatProvider Formato { get; set; }

		public Invoice()
		{
			this.AccountingSupplierParty = new AccountingSupplierParty();
			this.AccountingCustomerParty = new AccountingSupplierParty();
			this.DespatchDocumentReferences = new List<InvoiceDocumentReference>();
			this.UblExtensions = new UblExtensions();
			this.Signature = new SignatureCac();
			this.InvoiceLines = new List<InvoiceLine>();
			this.TaxTotals = new List<TaxTotal>();
			this.LegalMonetaryTotal = new LegalMonetaryTotal();
			this.PrepaidPayments = new List<BillingPayment>();
			this.UblVersionId = "2.0";
			this.CustomizationId = "1.0";
			this.Formato = (IFormatProvider)new CultureInfo("es-PE");
		}

		public XmlSchema GetSchema() => (XmlSchema)null;

		public void ReadXml(XmlReader reader) => throw new NotImplementedException();

		public void WriteXml(XmlWriter writer)
		{
			writer.WriteAttributeString("xmlns", "urn:oasis:names:specification:ubl:schema:xsd:Invoice-2");
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
			AdditionalInformation additionalInformation = this.UblExtensions.Extension2.ExtensionContent.AdditionalInformation;
			writer.WriteStartElement("ext:UBLExtension");
			writer.WriteStartElement("ext:ExtensionContent");
			writer.WriteStartElement("sac:AdditionalInformation");
			Decimal percent1;
			foreach (AdditionalMonetaryTotal additionalMonetaryTotal in additionalInformation.AdditionalMonetaryTotals)
			{
				if (this.PrepaidPayments.Count > 0)
				{
					if (additionalMonetaryTotal.PayableAmount.Value >= 0M && additionalMonetaryTotal.Id == "1001")
					{
						writer.WriteStartElement("sac:AdditionalMonetaryTotal");
						writer.WriteElementString("cbc:ID", additionalMonetaryTotal.Id);
						writer.WriteStartElement("cbc:PayableAmount");
						writer.WriteAttributeString("currencyID", additionalMonetaryTotal.PayableAmount.CurrencyId);
						XmlWriter xmlWriter1 = writer;
						percent1 = additionalMonetaryTotal.PayableAmount.Value;
						string str1 = percent1.ToString("###0.#0", this.Formato);
						xmlWriter1.WriteValue(str1);
						writer.WriteEndElement();
						if (additionalMonetaryTotal.Percent > 0M)
						{
							XmlWriter xmlWriter2 = writer;
							percent1 = additionalMonetaryTotal.Percent;
							string str2 = percent1.ToString("###0.#0", this.Formato);
							xmlWriter2.WriteElementString("cbc:Percent", str2);
						}
						writer.WriteEndElement();
					}
					else if (additionalMonetaryTotal.PayableAmount.Value > 0M && additionalMonetaryTotal.Id != "1001")
					{
						writer.WriteStartElement("sac:AdditionalMonetaryTotal");
						writer.WriteElementString("cbc:ID", additionalMonetaryTotal.Id);
						writer.WriteStartElement("cbc:PayableAmount");
						writer.WriteAttributeString("currencyID", additionalMonetaryTotal.PayableAmount.CurrencyId);
						XmlWriter xmlWriter1 = writer;
						percent1 = additionalMonetaryTotal.PayableAmount.Value;
						string str1 = percent1.ToString("###0.#0", this.Formato);
						xmlWriter1.WriteValue(str1);
						writer.WriteEndElement();
						if (additionalMonetaryTotal.Percent > 0M)
						{
							XmlWriter xmlWriter2 = writer;
							percent1 = additionalMonetaryTotal.Percent;
							string str2 = percent1.ToString("###0.#0", this.Formato);
							xmlWriter2.WriteElementString("cbc:Percent", str2);
						}
						writer.WriteEndElement();
					}
				}
				else if (additionalMonetaryTotal.PayableAmount.Value > 0M)
				{
					writer.WriteStartElement("sac:AdditionalMonetaryTotal");
					writer.WriteElementString("cbc:ID", additionalMonetaryTotal.Id);
					writer.WriteStartElement("cbc:PayableAmount");
					writer.WriteAttributeString("currencyID", additionalMonetaryTotal.PayableAmount.CurrencyId);
					XmlWriter xmlWriter1 = writer;
					percent1 = additionalMonetaryTotal.PayableAmount.Value;
					string str1 = percent1.ToString("###0.#0", this.Formato);
					xmlWriter1.WriteValue(str1);
					writer.WriteEndElement();
					if (additionalMonetaryTotal.Percent > 0M)
					{
						XmlWriter xmlWriter2 = writer;
						percent1 = additionalMonetaryTotal.Percent;
						string str2 = percent1.ToString("###0.#0", this.Formato);
						xmlWriter2.WriteElementString("cbc:Percent", str2);
					}
					writer.WriteEndElement();
				}
			}
			foreach (AdditionalProperty additionalProperty in additionalInformation.AdditionalProperties)
			{
				writer.WriteStartElement("sac:AdditionalProperty");
				writer.WriteElementString("cbc:ID", additionalProperty.Id);
				writer.WriteElementString("cbc:Value", additionalProperty.Value);
				writer.WriteEndElement();
			}
			if (!string.IsNullOrEmpty(additionalInformation.SunatEmbededDespatchAdvice.DeliveryAddress.Id))
			{
				writer.WriteStartElement("sac:SUNATEmbededDespatchAdvice");
				writer.WriteStartElement("cac:DeliveryAddress");
				writer.WriteElementString("cbc:ID", additionalInformation.SunatEmbededDespatchAdvice.DeliveryAddress.Id);
				writer.WriteElementString("cbc:StreetName", additionalInformation.SunatEmbededDespatchAdvice.DeliveryAddress.StreetName);
				if (!string.IsNullOrEmpty(additionalInformation.SunatEmbededDespatchAdvice.DeliveryAddress.CitySubdivisionName))
					writer.WriteElementString("cbc:CitySubdivisionName", additionalInformation.SunatEmbededDespatchAdvice.DeliveryAddress.CitySubdivisionName);
				writer.WriteElementString("cbc:CityName", additionalInformation.SunatEmbededDespatchAdvice.DeliveryAddress.CityName);
				writer.WriteElementString("cbc:CountrySubentity", additionalInformation.SunatEmbededDespatchAdvice.DeliveryAddress.CountrySubentity);
				writer.WriteElementString("cbc:District", additionalInformation.SunatEmbededDespatchAdvice.DeliveryAddress.District);
				writer.WriteStartElement("cac:Country");
				writer.WriteElementString("cbc:IdentificationCode", additionalInformation.SunatEmbededDespatchAdvice.DeliveryAddress.Country.IdentificationCode);
				writer.WriteEndElement();
				writer.WriteEndElement();
				writer.WriteStartElement("cac:OriginAddress");
				writer.WriteElementString("cbc:ID", additionalInformation.SunatEmbededDespatchAdvice.OriginAddress.Id);
				writer.WriteElementString("cbc:StreetName", additionalInformation.SunatEmbededDespatchAdvice.OriginAddress.StreetName);
				if (!string.IsNullOrEmpty(additionalInformation.SunatEmbededDespatchAdvice.OriginAddress.CitySubdivisionName))
					writer.WriteElementString("cbc:CitySubdivisionName", additionalInformation.SunatEmbededDespatchAdvice.OriginAddress.CitySubdivisionName);
				writer.WriteElementString("cbc:CityName", additionalInformation.SunatEmbededDespatchAdvice.OriginAddress.CityName);
				writer.WriteElementString("cbc:CountrySubentity", additionalInformation.SunatEmbededDespatchAdvice.OriginAddress.CountrySubentity);
				writer.WriteElementString("cbc:District", additionalInformation.SunatEmbededDespatchAdvice.OriginAddress.District);
				writer.WriteStartElement("cac:Country");
				writer.WriteElementString("cbc:IdentificationCode", additionalInformation.SunatEmbededDespatchAdvice.OriginAddress.Country.IdentificationCode);
				writer.WriteEndElement();
				writer.WriteEndElement();
				writer.WriteStartElement("sac:SUNATCarrierParty");
				writer.WriteElementString("cbc:CustomerAssignedAccountID", additionalInformation.SunatEmbededDespatchAdvice.SunatCarrierParty.CustomerAssignedAccountId);
				writer.WriteElementString("cbc:AdditionalAccountID", additionalInformation.SunatEmbededDespatchAdvice.SunatCarrierParty.AdditionalAccountId);
				writer.WriteStartElement("cac:Party");
				writer.WriteStartElement("cac:PartyLegalEntity");
				writer.WriteElementString("cbc:RegistrationName", additionalInformation.SunatEmbededDespatchAdvice.SunatCarrierParty.Party.PartyLegalEntity.RegistrationName);
				writer.WriteEndElement();
				writer.WriteEndElement();
				writer.WriteEndElement();
				writer.WriteStartElement("sac:DriverParty");
				writer.WriteStartElement("cac:Party");
				writer.WriteStartElement("cac:PartyIdentification");
				writer.WriteElementString("cbc:ID", additionalInformation.SunatEmbededDespatchAdvice.DriverParty.PartyIdentification.Id.Value);
				writer.WriteEndElement();
				writer.WriteEndElement();
				writer.WriteEndElement();
				writer.WriteStartElement("sac:SUNATRoadTransport");
				writer.WriteElementString("cbc:LicensePlateID", additionalInformation.SunatEmbededDespatchAdvice.SunatRoadTransport.LicensePlateId);
				writer.WriteElementString("cbc:TransportAuthorizationCode", additionalInformation.SunatEmbededDespatchAdvice.SunatRoadTransport.TransportAuthorizationCode);
				writer.WriteElementString("cbc:BrandName", additionalInformation.SunatEmbededDespatchAdvice.SunatRoadTransport.BrandName);
				writer.WriteEndElement();
				writer.WriteElementString("cbc:TransportModeCode", additionalInformation.SunatEmbededDespatchAdvice.TransportModeCode);
				writer.WriteStartElement("cbc:GrossWeightMeasure");
				writer.WriteAttributeString("unitCode", additionalInformation.SunatEmbededDespatchAdvice.GrossWeightMeasure.UnitCode);
				writer.WriteValue(additionalInformation.SunatEmbededDespatchAdvice.GrossWeightMeasure.Value.ToString("###0.#0", this.Formato));
				writer.WriteEndElement();
				writer.WriteEndElement();
			}
			if (!string.IsNullOrEmpty(additionalInformation.SunatCosts.RoadTransport.LicensePlateId))
			{
				writer.WriteStartElement("sac:SUNATCosts");
				writer.WriteStartElement("cac:RoadTransport");
				writer.WriteElementString("cbc:LicensePlateID", additionalInformation.SunatCosts.RoadTransport.LicensePlateId);
				writer.WriteEndElement();
				writer.WriteEndElement();
			}
			if (!string.IsNullOrEmpty(additionalInformation.SunatTransaction.Id) && string.IsNullOrEmpty(additionalInformation.SunatCosts.RoadTransport.LicensePlateId))
			{
				writer.WriteStartElement("sac:SUNATTransaction");
				writer.WriteElementString("cbc:ID", additionalInformation.SunatTransaction.Id);
				writer.WriteEndElement();
			}
			writer.WriteEndElement();
			writer.WriteEndElement();
			writer.WriteEndElement();
			writer.WriteStartElement("ext:UBLExtension");
			writer.WriteStartElement("ext:ExtensionContent");
			writer.WriteEndElement();
			writer.WriteEndElement();
			writer.WriteEndElement();
			writer.WriteElementString("cbc:UBLVersionID", this.UblVersionId);
			writer.WriteElementString("cbc:CustomizationID", this.CustomizationId);
			writer.WriteElementString("cbc:ID", this.Id);
			writer.WriteElementString("cbc:IssueDate", this.IssueDate.ToString("yyyy-MM-dd"));
			writer.WriteElementString("cbc:InvoiceTypeCode", this.InvoiceTypeCode);
			writer.WriteElementString("cbc:DocumentCurrencyCode", this.DocumentCurrencyCode);
			foreach (InvoiceDocumentReference documentReference in this.DespatchDocumentReferences)
			{
				if (!string.IsNullOrEmpty(documentReference.Id.Trim()))
				{
					writer.WriteStartElement("cac:DespatchDocumentReference");
					writer.WriteElementString("cbc:ID", documentReference.Id);
					writer.WriteElementString("cbc:DocumentTypeCode", documentReference.DocumentTypeCode);
					writer.WriteEndElement();
				}
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
			writer.WriteStartElement("cac:AccountingSupplierParty");
			writer.WriteElementString("cbc:CustomerAssignedAccountID", this.AccountingSupplierParty.CustomerAssignedAccountId);
			writer.WriteElementString("cbc:AdditionalAccountID", this.AccountingSupplierParty.AdditionalAccountId);
			writer.WriteStartElement("cac:Party");
			writer.WriteStartElement("cac:PartyName");
			writer.WriteStartElement("cbc:Name");
			writer.WriteCData(this.AccountingSupplierParty.Party.PartyName.Name);
			writer.WriteEndElement();
			writer.WriteEndElement();
			writer.WriteStartElement("cac:PostalAddress");
			writer.WriteElementString("cbc:ID", this.AccountingSupplierParty.Party.PostalAddress.Id);
			writer.WriteElementString("cbc:StreetName", this.AccountingSupplierParty.Party.PostalAddress.StreetName);
			if (!string.IsNullOrEmpty(this.AccountingSupplierParty.Party.PostalAddress.CitySubdivisionName))
				writer.WriteElementString("cbc:CitySubdivisionName", this.AccountingSupplierParty.Party.PostalAddress.CitySubdivisionName);
			writer.WriteElementString("cbc:CityName", this.AccountingSupplierParty.Party.PostalAddress.CityName);
			writer.WriteElementString("cbc:CountrySubentity", this.AccountingSupplierParty.Party.PostalAddress.CountrySubentity);
			writer.WriteElementString("cbc:District", this.AccountingSupplierParty.Party.PostalAddress.District);
			writer.WriteStartElement("cac:Country");
			writer.WriteElementString("cbc:IdentificationCode", this.AccountingSupplierParty.Party.PostalAddress.Country.IdentificationCode);
			writer.WriteEndElement();
			writer.WriteEndElement();
			writer.WriteStartElement("cac:PartyLegalEntity");
			writer.WriteStartElement("cbc:RegistrationName");
			writer.WriteCData(this.AccountingSupplierParty.Party.PartyLegalEntity.RegistrationName);
			writer.WriteEndElement();
			writer.WriteEndElement();
			writer.WriteEndElement();
			writer.WriteEndElement();
			writer.WriteStartElement("cac:AccountingCustomerParty");
			writer.WriteElementString("cbc:CustomerAssignedAccountID", this.AccountingCustomerParty.CustomerAssignedAccountId);
			writer.WriteElementString("cbc:AdditionalAccountID", this.AccountingCustomerParty.AdditionalAccountId);
			writer.WriteStartElement("cac:Party");
			writer.WriteStartElement("cac:PartyLegalEntity");
			writer.WriteStartElement("cbc:RegistrationName");
			writer.WriteCData(this.AccountingCustomerParty.Party.PartyLegalEntity.RegistrationName);
			writer.WriteEndElement();
			writer.WriteEndElement();
			writer.WriteEndElement();
			writer.WriteEndElement();
			foreach (BillingPayment prepaidPayment in this.PrepaidPayments)
			{
				writer.WriteStartElement("cac:PrepaidPayment");
				writer.WriteStartElement("cbc:ID");
				writer.WriteAttributeString("schemeID", prepaidPayment.Id.SchemeId);
				writer.WriteValue(prepaidPayment.Id.Value);
				writer.WriteEndElement();
				writer.WriteStartElement("cbc:PaidAmount");
				writer.WriteAttributeString("currencyID", prepaidPayment.PaidAmount.CurrencyId);
				writer.WriteValue(prepaidPayment.PaidAmount.Value.ToString("###0.#0", this.Formato));
				writer.WriteEndElement();
				writer.WriteStartElement("cbc:InstructionID");
				writer.WriteAttributeString("schemeID", "6");
				writer.WriteValue(prepaidPayment.InstructionId);
				writer.WriteEndElement();
				writer.WriteEndElement();
			}
			foreach (TaxTotal taxTotal in this.TaxTotals)
			{
				writer.WriteStartElement("cac:TaxTotal");
				writer.WriteStartElement("cbc:TaxAmount");
				writer.WriteAttributeString("currencyID", taxTotal.TaxAmount.CurrencyId);
				XmlWriter xmlWriter1 = writer;
				Decimal num = taxTotal.TaxAmount.Value;
				string text1 = num.ToString("###0.#0", this.Formato);
				xmlWriter1.WriteString(text1);
				writer.WriteEndElement();
				writer.WriteStartElement("cac:TaxSubtotal");
				writer.WriteStartElement("cbc:TaxAmount");
				writer.WriteAttributeString("currencyID", taxTotal.TaxSubtotal.TaxAmount.CurrencyId);
				XmlWriter xmlWriter2 = writer;
				num = taxTotal.TaxAmount.Value;
				string text2 = num.ToString("###0.#0", this.Formato);
				xmlWriter2.WriteString(text2);
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
			writer.WriteStartElement("cac:LegalMonetaryTotal");
			Decimal num1;
			if (this.LegalMonetaryTotal.AllowanceTotalAmount.Value > 0M)
			{
				writer.WriteStartElement("cbc:AllowanceTotalAmount");
				writer.WriteAttributeString("currencyID", this.LegalMonetaryTotal.AllowanceTotalAmount.CurrencyId);
				XmlWriter xmlWriter = writer;
				num1 = this.LegalMonetaryTotal.AllowanceTotalAmount.Value;
				string str = num1.ToString("###0.#0", this.Formato);
				xmlWriter.WriteValue(str);
				writer.WriteEndElement();
			}
			if (this.LegalMonetaryTotal.ChargeTotalAmount.Value > 0M)
			{
				writer.WriteStartElement("cbc:ChargeTotalAmount");
				writer.WriteAttributeString("currencyID", this.LegalMonetaryTotal.ChargeTotalAmount.CurrencyId);
				XmlWriter xmlWriter = writer;
				num1 = this.LegalMonetaryTotal.ChargeTotalAmount.Value;
				string str = num1.ToString("###0.#0", this.Formato);
				xmlWriter.WriteValue(str);
				writer.WriteEndElement();
			}
			if (this.LegalMonetaryTotal.PrepaidAmount.Value > 0M)
			{
				writer.WriteStartElement("cbc:PrepaidAmount");
				writer.WriteAttributeString("currencyID", this.LegalMonetaryTotal.PrepaidAmount.CurrencyId);
				XmlWriter xmlWriter = writer;
				num1 = this.LegalMonetaryTotal.PrepaidAmount.Value;
				string str = num1.ToString("###0.#0", this.Formato);
				xmlWriter.WriteValue(str);
				writer.WriteEndElement();
			}
			writer.WriteStartElement("cbc:PayableAmount");
			writer.WriteAttributeString("currencyID", this.LegalMonetaryTotal.PayableAmount.CurrencyId);
			XmlWriter xmlWriter3 = writer;
			num1 = this.LegalMonetaryTotal.PayableAmount.Value;
			string str3 = num1.ToString("###0.#0", this.Formato);
			xmlWriter3.WriteValue(str3);
			writer.WriteEndElement();
			writer.WriteEndElement();
			foreach (InvoiceLine invoiceLine in this.InvoiceLines)
			{
				writer.WriteStartElement("cac:InvoiceLine");
				writer.WriteElementString("cbc:ID", invoiceLine.Id.ToString());
				writer.WriteStartElement("cbc:InvoicedQuantity");
				writer.WriteAttributeString("unitCode", invoiceLine.InvoicedQuantity.UnitCode);
				XmlWriter xmlWriter1 = writer;
				num1 = invoiceLine.InvoicedQuantity.Value;
				string str1 = num1.ToString("###0.#0", this.Formato);
				xmlWriter1.WriteValue(str1);
				writer.WriteEndElement();
				writer.WriteStartElement("cbc:LineExtensionAmount");
				writer.WriteAttributeString("currencyID", invoiceLine.LineExtensionAmount.CurrencyId);
				XmlWriter xmlWriter2 = writer;
				num1 = invoiceLine.LineExtensionAmount.Value;
				string str2 = num1.ToString("###0.#0", this.Formato);
				xmlWriter2.WriteValue(str2);
				writer.WriteEndElement();
				writer.WriteStartElement("cac:PricingReference");
				foreach (AlternativeConditionPrice alternativeConditionPrice in invoiceLine.PricingReference.AlternativeConditionPrices)
				{
					writer.WriteStartElement("cac:AlternativeConditionPrice");
					writer.WriteStartElement("cbc:PriceAmount");
					writer.WriteAttributeString("currencyID", alternativeConditionPrice.PriceAmount.CurrencyId);
					XmlWriter xmlWriter4 = writer;
					num1 = alternativeConditionPrice.PriceAmount.Value;
					string str4 = num1.ToString("###0.#0", this.Formato);
					xmlWriter4.WriteValue(str4);
					writer.WriteEndElement();
					writer.WriteElementString("cbc:PriceTypeCode", alternativeConditionPrice.PriceTypeCode);
					writer.WriteEndElement();
				}
				writer.WriteEndElement();
				Decimal percent2;
				if (invoiceLine.AllowanceCharge.Amount.Value > 0M)
				{
					writer.WriteStartElement("cac:AllowanceCharge");
					writer.WriteElementString("cbc:ChargeIndicator", invoiceLine.AllowanceCharge.ChargeIndicator.ToString().ToLower());
					writer.WriteStartElement("cbc:Amount");
					writer.WriteAttributeString("currencyID", invoiceLine.AllowanceCharge.Amount.CurrencyId);
					XmlWriter xmlWriter4 = writer;
					percent2 = invoiceLine.AllowanceCharge.Amount.Value;
					string str4 = percent2.ToString("###0.#0", this.Formato);
					xmlWriter4.WriteValue(str4);
					writer.WriteEndElement();
					writer.WriteEndElement();
				}
				foreach (TaxTotal taxTotal in invoiceLine.TaxTotals)
				{
					writer.WriteStartElement("cac:TaxTotal");
					writer.WriteStartElement("cbc:TaxAmount");
					writer.WriteAttributeString("currencyID", taxTotal.TaxAmount.CurrencyId);
					XmlWriter xmlWriter4 = writer;
					percent2 = taxTotal.TaxAmount.Value;
					string text1 = percent2.ToString("###0.#0", this.Formato);
					xmlWriter4.WriteString(text1);
					writer.WriteEndElement();
					writer.WriteStartElement("cac:TaxSubtotal");
					if (!string.IsNullOrEmpty(taxTotal.TaxableAmount.CurrencyId))
					{
						writer.WriteStartElement("cbc:TaxableAmount");
						writer.WriteAttributeString("currencyID", taxTotal.TaxableAmount.CurrencyId);
						XmlWriter xmlWriter5 = writer;
						percent2 = taxTotal.TaxableAmount.Value;
						string text2 = percent2.ToString("###0.#0", this.Formato);
						xmlWriter5.WriteString(text2);
						writer.WriteEndElement();
					}
					writer.WriteStartElement("cbc:TaxAmount");
					writer.WriteAttributeString("currencyID", taxTotal.TaxSubtotal.TaxAmount.CurrencyId);
					XmlWriter xmlWriter6 = writer;
					percent2 = taxTotal.TaxAmount.Value;
					string text3 = percent2.ToString("###0.#0", this.Formato);
					xmlWriter6.WriteString(text3);
					writer.WriteEndElement();
					if (taxTotal.TaxSubtotal.Percent > 0M)
					{
						XmlWriter xmlWriter5 = writer;
						percent2 = taxTotal.TaxSubtotal.Percent;
						string str4 = percent2.ToString("###0.#0", this.Formato);
						xmlWriter5.WriteElementString("cbc:Percent", str4);
					}
					writer.WriteStartElement("cac:TaxCategory");
					writer.WriteElementString("cbc:TaxExemptionReasonCode", taxTotal.TaxSubtotal.TaxCategory.TaxExemptionReasonCode);
					if (!string.IsNullOrEmpty(taxTotal.TaxSubtotal.TaxCategory.TierRange))
						writer.WriteElementString("cbc:TierRange", taxTotal.TaxSubtotal.TaxCategory.TierRange);
					writer.WriteStartElement("cac:TaxScheme");
					writer.WriteElementString("cbc:ID", taxTotal.TaxSubtotal.TaxCategory.TaxScheme.Id);
					writer.WriteElementString("cbc:Name", taxTotal.TaxSubtotal.TaxCategory.TaxScheme.Name);
					writer.WriteElementString("cbc:TaxTypeCode", taxTotal.TaxSubtotal.TaxCategory.TaxScheme.TaxTypeCode);
					writer.WriteEndElement();
					writer.WriteEndElement();
					writer.WriteEndElement();
					writer.WriteEndElement();
				}
				writer.WriteStartElement("cac:Item");
				writer.WriteElementString("cbc:Description", invoiceLine.Item.Description);
				writer.WriteStartElement("cac:SellersItemIdentification");
				writer.WriteElementString("cbc:ID", invoiceLine.Item.SellersItemIdentification.Id);
				writer.WriteEndElement();
				writer.WriteEndElement();
				writer.WriteStartElement("cac:Price");
				writer.WriteStartElement("cbc:PriceAmount");
				writer.WriteAttributeString("currencyID", invoiceLine.Price.PriceAmount.CurrencyId);
				writer.WriteString(invoiceLine.Price.PriceAmount.Value.ToString("###0.#0", this.Formato));
				writer.WriteEndElement();
				writer.WriteEndElement();
				writer.WriteEndElement();
			}
		}
	}
}
