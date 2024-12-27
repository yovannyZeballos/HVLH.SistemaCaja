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
  public class DebitNote : IXmlSerializable, IEstructuraXml
  {
    public UblExtensions UblExtensions { get; set; }

    public string UblVersionId { get; set; }

    public string CustomizationId { get; set; }

    public string Id { get; set; }

    public DateTime IssueDate { get; set; }

    public string DocumentCurrencyCode { get; set; }

    public List<DiscrepancyResponse> DiscrepancyResponses { get; set; }

    public List<BillingReference> BillingReferences { get; set; }

    public List<InvoiceDocumentReference> DespatchDocumentReferences { get; set; }

    public List<InvoiceDocumentReference> AdditionalDocumentReferences { get; set; }

    public SignatureCac Signature { get; set; }

    public AccountingSupplierParty AccountingSupplierParty { get; set; }

    public AccountingSupplierParty AccountingCustomerParty { get; set; }

    public List<TaxTotal> TaxTotals { get; set; }

    public LegalMonetaryTotal RequestedMonetaryTotal { get; set; }

    public List<InvoiceLine> DebitNoteLines { get; set; }

    public IFormatProvider Formato { get; set; }

    public DebitNote()
    {
      this.UblExtensions = new UblExtensions();
      this.DiscrepancyResponses = new List<DiscrepancyResponse>();
      this.BillingReferences = new List<BillingReference>();
      this.DespatchDocumentReferences = new List<InvoiceDocumentReference>();
      this.AdditionalDocumentReferences = new List<InvoiceDocumentReference>();
      this.Signature = new SignatureCac();
      this.AccountingCustomerParty = new AccountingSupplierParty();
      this.AccountingSupplierParty = new AccountingSupplierParty();
      this.TaxTotals = new List<TaxTotal>();
      this.RequestedMonetaryTotal = new LegalMonetaryTotal();
      this.DebitNoteLines = new List<InvoiceLine>();
      this.UblVersionId = "2.0";
      this.CustomizationId = "1.0";
      this.Formato = (IFormatProvider) new CultureInfo("es-PE");
    }

    public XmlSchema GetSchema() => (XmlSchema) null;

    public void ReadXml(XmlReader reader) => throw new NotImplementedException();

    public void WriteXml(XmlWriter writer)
    {
      writer.WriteAttributeString("xmlns", "urn:oasis:names:specification:ubl:schema:xsd:DebitNote-2");
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
      if (additionalInformation.AdditionalMonetaryTotals.Count > 0)
        writer.WriteStartElement("sac:AdditionalInformation");
      foreach (AdditionalMonetaryTotal additionalMonetaryTotal in additionalInformation.AdditionalMonetaryTotals)
      {
        if (additionalMonetaryTotal.PayableAmount.Value > 0M)
        {
          writer.WriteStartElement("sac:AdditionalMonetaryTotal");
          writer.WriteElementString("cbc:ID", additionalMonetaryTotal.Id);
          writer.WriteStartElement("cbc:PayableAmount");
          writer.WriteAttributeString("currencyID", additionalMonetaryTotal.PayableAmount.CurrencyId);
          writer.WriteValue(additionalMonetaryTotal.PayableAmount.Value.ToString("###0.#0", this.Formato));
          writer.WriteEndElement();
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
      writer.WriteElementString("cbc:DocumentCurrencyCode", this.DocumentCurrencyCode);
      foreach (DiscrepancyResponse discrepancyResponse in this.DiscrepancyResponses)
      {
        writer.WriteStartElement("cac:DiscrepancyResponse");
        writer.WriteElementString("cbc:ReferenceID", discrepancyResponse.ReferenceId);
        writer.WriteElementString("cbc:ResponseCode", discrepancyResponse.ResponseCode);
        writer.WriteElementString("cbc:Description", discrepancyResponse.Description);
        writer.WriteEndElement();
      }
      foreach (BillingReference billingReference in this.BillingReferences)
      {
        writer.WriteStartElement("cac:BillingReference");
        writer.WriteStartElement("cac:InvoiceDocumentReference");
        writer.WriteElementString("cbc:ID", billingReference.InvoiceDocumentReference.Id);
        writer.WriteElementString("cbc:DocumentTypeCode", billingReference.InvoiceDocumentReference.DocumentTypeCode);
        writer.WriteEndElement();
        writer.WriteEndElement();
      }
      foreach (InvoiceDocumentReference documentReference in this.DespatchDocumentReferences)
      {
        writer.WriteStartElement("cac:DespatchDocumentReference");
        writer.WriteElementString("cbc:ID", documentReference.Id);
        writer.WriteElementString("cbc:DocumentTypeCode", documentReference.DocumentTypeCode);
        writer.WriteEndElement();
      }
      foreach (InvoiceDocumentReference documentReference in this.AdditionalDocumentReferences)
      {
        writer.WriteStartElement("cac:AdditionalDocumentReference");
        writer.WriteElementString("cbc:ID", documentReference.Id);
        writer.WriteElementString("cbc:DocumentTypeCode", documentReference.DocumentTypeCode);
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
      writer.WriteStartElement("cac:RequestedMonetaryTotal");
      writer.WriteStartElement("cbc:PayableAmount");
      writer.WriteAttributeString("currencyID", this.RequestedMonetaryTotal.PayableAmount.CurrencyId);
      writer.WriteValue(this.RequestedMonetaryTotal.PayableAmount.Value.ToString("###0.#0", this.Formato));
      writer.WriteEndElement();
      writer.WriteEndElement();
      foreach (InvoiceLine debitNoteLine in this.DebitNoteLines)
      {
        writer.WriteStartElement("cac:DebitNoteLine");
        writer.WriteElementString("cbc:ID", debitNoteLine.Id.ToString());
        writer.WriteStartElement("cbc:DebitedQuantity");
        writer.WriteAttributeString("unitCode", debitNoteLine.DebitedQuantity.UnitCode);
        XmlWriter xmlWriter1 = writer;
        Decimal num = debitNoteLine.DebitedQuantity.Value;
        string str1 = num.ToString("###0.#0", this.Formato);
        xmlWriter1.WriteValue(str1);
        writer.WriteEndElement();
        writer.WriteStartElement("cbc:LineExtensionAmount");
        writer.WriteAttributeString("currencyID", debitNoteLine.LineExtensionAmount.CurrencyId);
        XmlWriter xmlWriter2 = writer;
        num = debitNoteLine.LineExtensionAmount.Value;
        string str2 = num.ToString("###0.#0", this.Formato);
        xmlWriter2.WriteValue(str2);
        writer.WriteEndElement();
        writer.WriteStartElement("cac:PricingReference");
        foreach (AlternativeConditionPrice alternativeConditionPrice in debitNoteLine.PricingReference.AlternativeConditionPrices)
        {
          writer.WriteStartElement("cac:AlternativeConditionPrice");
          writer.WriteStartElement("cbc:PriceAmount");
          writer.WriteAttributeString("currencyID", alternativeConditionPrice.PriceAmount.CurrencyId);
          XmlWriter xmlWriter3 = writer;
          num = alternativeConditionPrice.PriceAmount.Value;
          string str3 = num.ToString("###0.#0", this.Formato);
          xmlWriter3.WriteValue(str3);
          writer.WriteEndElement();
          writer.WriteElementString("cbc:PriceTypeCode", alternativeConditionPrice.PriceTypeCode);
          writer.WriteEndElement();
        }
        writer.WriteEndElement();
        if (debitNoteLine.AllowanceCharge.ChargeIndicator)
        {
          writer.WriteStartElement("cac:AllowanceCharge");
          writer.WriteElementString("cbc:ChargeIndicator", debitNoteLine.AllowanceCharge.ChargeIndicator.ToString());
          writer.WriteStartElement("cbc:Amount");
          writer.WriteAttributeString("currencyID", debitNoteLine.AllowanceCharge.Amount.CurrencyId);
          writer.WriteValue(debitNoteLine.AllowanceCharge.Amount.Value.ToString("###0.#0", this.Formato));
          writer.WriteEndElement();
          writer.WriteEndElement();
        }
        foreach (TaxTotal taxTotal in debitNoteLine.TaxTotals)
        {
          writer.WriteStartElement("cac:TaxTotal");
          writer.WriteStartElement("cbc:TaxAmount");
          writer.WriteAttributeString("currencyID", taxTotal.TaxAmount.CurrencyId);
          XmlWriter xmlWriter3 = writer;
          Decimal percent = taxTotal.TaxAmount.Value;
          string text1 = percent.ToString("###0.#0", this.Formato);
          xmlWriter3.WriteString(text1);
          writer.WriteEndElement();
          writer.WriteStartElement("cac:TaxSubtotal");
          if (!string.IsNullOrEmpty(taxTotal.TaxableAmount.CurrencyId))
          {
            writer.WriteStartElement("cbc:TaxableAmount");
            writer.WriteAttributeString("currencyID", taxTotal.TaxableAmount.CurrencyId);
            XmlWriter xmlWriter4 = writer;
            percent = taxTotal.TaxableAmount.Value;
            string text2 = percent.ToString("###0.#0", this.Formato);
            xmlWriter4.WriteString(text2);
            writer.WriteEndElement();
          }
          writer.WriteStartElement("cbc:TaxAmount");
          writer.WriteAttributeString("currencyID", taxTotal.TaxSubtotal.TaxAmount.CurrencyId);
          XmlWriter xmlWriter5 = writer;
          percent = taxTotal.TaxAmount.Value;
          string text3 = percent.ToString("###0.#0", this.Formato);
          xmlWriter5.WriteString(text3);
          writer.WriteEndElement();
          if (taxTotal.TaxSubtotal.Percent > 0M)
          {
            XmlWriter xmlWriter4 = writer;
            percent = taxTotal.TaxSubtotal.Percent;
            string str3 = percent.ToString("###0.#0", this.Formato);
            xmlWriter4.WriteElementString("cbc:Percent", str3);
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
        writer.WriteElementString("cbc:Description", debitNoteLine.Item.Description);
        writer.WriteStartElement("cac:SellersItemIdentification");
        writer.WriteElementString("cbc:ID", debitNoteLine.Item.SellersItemIdentification.Id);
        writer.WriteEndElement();
        writer.WriteEndElement();
        writer.WriteStartElement("cac:Price");
        writer.WriteStartElement("cbc:PriceAmount");
        writer.WriteAttributeString("currencyID", debitNoteLine.Price.PriceAmount.CurrencyId);
        writer.WriteString(debitNoteLine.Price.PriceAmount.Value.ToString("###0.#0", this.Formato));
        writer.WriteEndElement();
        writer.WriteEndElement();
        writer.WriteEndElement();
      }
    }
  }
}
