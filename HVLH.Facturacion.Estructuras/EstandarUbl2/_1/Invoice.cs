using HVLH.Facturacion.Estructuras.ComponentesAgregadoComunes;
using HVLH.Facturacion.Estructuras.ComponentesAgregadoSunat;
using HVLH.Facturacion.Estructuras.ComponentesBasicosComunes;
using HVLH.Facturacion.Estructuras.ComponentesExtensionComunes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using HVLH.Facturacion.Comun;
using HVLH.Facturacion.Comun.Constantes;

namespace HVLH.Facturacion.Estructuras.EstandarUbl2._1
{
    [Serializable]
    public class Invoice : IXmlSerializable, IEstructuraXml
    {
        public DateTime IssueDate { get; set; }
        public DateTime DueDate { get; set; }
        public TimeSpan IssueTime { get; set; }
        public UblExtensions UblExtensions { get; set; }
        public SignatureCac Signature { get; set; }
        public AccountingSupplierParty AccountingSupplierParty { get; set; }
        public InvoiceTypeCode InvoiceTypeCode { get; set; }
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
        public ProfileID ProfileID { get; set; }
        public List<Note> Notes { get; set; }
        public string LineCountNumeric { get; set; }
        public string OrderReference { get; set; }
        public List<AllowanceCharge> AllowanceCharges { get; set; }
        public PaymentMeans PaymentMeans { get; set; }
        public PaymentTerms PaymentTerms { get; set; }
        public List<PaymentTerms> ListPaymentTerms { get; set; }
        public List<AdditionalDocumentReference> AdditionalDocumentReferences { get; set; }

        public Invoice()
        {
            AccountingSupplierParty = new AccountingSupplierParty();
            AccountingCustomerParty = new AccountingSupplierParty();
            DespatchDocumentReferences = new List<InvoiceDocumentReference>();
            UblExtensions = new UblExtensions();
            Signature = new SignatureCac();
            InvoiceLines = new List<InvoiceLine>();
            TaxTotals = new List<TaxTotal>();
            LegalMonetaryTotal = new LegalMonetaryTotal();
            PrepaidPayments = new List<BillingPayment>();
            UblVersionId = "2.1";
            CustomizationId = "2.0";
            Formato = (IFormatProvider)new CultureInfo("es-PE");
            ProfileID = new ProfileID();
            Notes = new List<Note>();
            InvoiceTypeCode = new InvoiceTypeCode();
            ListPaymentTerms = new List<PaymentTerms>();
            AllowanceCharges = new List<AllowanceCharge>();
            AdditionalDocumentReferences = new List<AdditionalDocumentReference>();
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
            writer.WriteElementString("cbc:IssueTime", this.IssueTime.ToString("hh\\:mm\\:ss"));
            writer.WriteStartElement("cbc:InvoiceTypeCode");
            writer.WriteAttributeString("listID", this.InvoiceTypeCode.ListID);
            writer.WriteAttributeString("listAgencyName", "PE:SUNAT");
            writer.WriteAttributeString("listName", "Tipo de Documento");
            writer.WriteAttributeString("listURI", "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo01");
            writer.WriteValue(this.InvoiceTypeCode.Value);
            writer.WriteEndElement();
            if (this.Notes.Count > 0)
            {
                foreach (Note note in this.Notes)
                {
                    writer.WriteStartElement("cbc:Note");

                    if (note.LanguajeLocaleID != "0")
                        writer.WriteAttributeString("languageLocaleID", note.LanguajeLocaleID);

                    writer.WriteCData(note.Value);
                    writer.WriteEndElement();
                }
            }
            writer.WriteStartElement("cbc:DocumentCurrencyCode");
            writer.WriteAttributeString("listID", "ISO 4217 Alpha");
            writer.WriteAttributeString("listName", "Currency");
            writer.WriteAttributeString("listAgencyName", "United Nations Economic Commission for Europe");
            writer.WriteValue(this.DocumentCurrencyCode);
            writer.WriteEndElement();
            writer.WriteElementString("cbc:LineCountNumeric", this.LineCountNumeric);
            if (!string.IsNullOrEmpty(this.OrderReference))
            {
                writer.WriteStartElement("cac:OrderReference");
                writer.WriteElementString("cbc:ID", this.OrderReference);
                writer.WriteEndElement();
            }
            foreach (InvoiceDocumentReference documentReference in this.DespatchDocumentReferences)
            {
                if (!string.IsNullOrEmpty(documentReference.Id.Trim()))
                {
                    writer.WriteStartElement("cac:DespatchDocumentReference");
                    writer.WriteElementString("cbc:ID", documentReference.Id);
                    writer.WriteStartElement("cbc:DocumentTypeCode");
                    writer.WriteAttributeString("listAgencyName", "PE:SUNAT");
                    writer.WriteAttributeString("listName", "SUNAT:Identificador de guía relacionada");
                    writer.WriteAttributeString("listURI", "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo01");
                    writer.WriteValue(documentReference.DocumentTypeCode);
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                }
            }


            foreach (AdditionalDocumentReference AdditionalDocumentReference in AdditionalDocumentReferences)
            {
                if (!string.IsNullOrEmpty(AdditionalDocumentReference.Id.Trim()))
                {
                    writer.WriteStartElement("cac:AdditionalDocumentReference");

                    writer.WriteStartElement("cbc:ID");
                    writer.WriteValue(AdditionalDocumentReference.Id);
                    writer.WriteEndElement();

                    writer.WriteStartElement("cbc:DocumentTypeCode");
                    writer.WriteAttributeString("listName", Atributos.IdentificadorDocumentosRelacionados);
                    writer.WriteAttributeString("listAgencyName", Atributos.AgencyNameSunat);
                    writer.WriteAttributeString("listURI", Atributos.URICatalogo12);
                    writer.WriteValue(AdditionalDocumentReference.DocumentTypeCode);
                    writer.WriteEndElement();

                    if (AdditionalDocumentReference.DocumentTypeCode == "02" | AdditionalDocumentReference.DocumentTypeCode == "03")
                    {
                        writer.WriteStartElement("cbc:DocumentStatusCode");
                        writer.WriteAttributeString("listName", Atributos.IdentificadoAnticipo);
                        writer.WriteAttributeString("listAgencyName", Atributos.AgencyNameSunat);
                        writer.WriteValue(AdditionalDocumentReference.DocumentStatusCode);
                        writer.WriteEndElement();

                        writer.WriteStartElement("cac:IssuerParty");
                        writer.WriteStartElement("cac:PartyIdentification");
                        writer.WriteStartElement("cbc:ID");
                        writer.WriteAttributeString("schemeID", AdditionalDocumentReference.IssuerParty.PartyIdentification.Id.SchemeId);
                        writer.WriteAttributeString("schemeName", Atributos.IdentificadorDocumentoIdentidad);
                        writer.WriteAttributeString("schemeAgencyName", Atributos.AgencyNameSunat);
                        writer.WriteAttributeString("schemeURI", Atributos.URICatalogo06);
                        writer.WriteValue(AdditionalDocumentReference.IssuerParty.PartyIdentification.Id.Value);
                        writer.WriteEndElement();
                        writer.WriteEndElement();
                        writer.WriteEndElement();
                    }

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
            writer.WriteStartElement("cac:Party");
            writer.WriteStartElement("cac:PartyIdentification");
            writer.WriteStartElement("cbc:ID");
            writer.WriteAttributeString("schemeID", this.AccountingSupplierParty.Party.PartyIdentification.Id.SchemeId);
            writer.WriteAttributeString("schemeName", "Documento de Identidad");
            writer.WriteAttributeString("schemeAgencyName", "PE:SUNAT");
            writer.WriteAttributeString("schemeURI", "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo06");
            writer.WriteValue(this.AccountingSupplierParty.Party.PartyIdentification.Id.Value);
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteStartElement("cac:PartyName");
            writer.WriteStartElement("cbc:Name");
            writer.WriteCData(this.AccountingSupplierParty.Party.PartyName.Name);
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteStartElement("cac:PartyLegalEntity");
            writer.WriteStartElement("cbc:RegistrationName");
            writer.WriteCData(this.AccountingSupplierParty.Party.PartyLegalEntity.RegistrationName);
            writer.WriteEndElement();
            writer.WriteStartElement("cac:RegistrationAddress");
            writer.WriteStartElement("cbc:ID");
            writer.WriteAttributeString("schemeAgencyName", "PE:INEI");
            writer.WriteAttributeString("schemeName", "Ubigeos");
            writer.WriteValue(this.AccountingSupplierParty.Party.PartyLegalEntity.RegistrationAddress.Id);
            writer.WriteEndElement();
            writer.WriteElementString("cbc:AddressTypeCode", this.AccountingSupplierParty.Party.PartyTaxScheme.RegistrationAddress.AddressTypeCode);

            if(!string.IsNullOrEmpty(AccountingSupplierParty.Party.PartyLegalEntity.RegistrationAddress.CitySubdivisionName))
                writer.WriteElementString("cbc:CitySubdivisionName", this.AccountingSupplierParty.Party.PartyLegalEntity.RegistrationAddress.CitySubdivisionName);

			if (!string.IsNullOrEmpty(AccountingSupplierParty.Party.PartyLegalEntity.RegistrationAddress.CityName))
				writer.WriteElementString("cbc:CityName", this.AccountingSupplierParty.Party.PartyLegalEntity.RegistrationAddress.CityName);

			if (!string.IsNullOrEmpty(AccountingSupplierParty.Party.PartyLegalEntity.RegistrationAddress.CountrySubentity))
				writer.WriteElementString("cbc:CountrySubentity", this.AccountingSupplierParty.Party.PartyLegalEntity.RegistrationAddress.CountrySubentity);

			if (!string.IsNullOrEmpty(AccountingSupplierParty.Party.PartyLegalEntity.RegistrationAddress.District))
				writer.WriteElementString("cbc:District", this.AccountingSupplierParty.Party.PartyLegalEntity.RegistrationAddress.District);
            
            writer.WriteStartElement("cac:AddressLine");
            writer.WriteElementString("cbc:Line", this.AccountingSupplierParty.Party.PartyLegalEntity.RegistrationAddress.AddressLine.Line);
            writer.WriteEndElement();
            writer.WriteStartElement("cac:Country");
            writer.WriteStartElement("cbc:IdentificationCode");
            writer.WriteAttributeString("listID", "ISO 3166-1");
            writer.WriteAttributeString("listAgencyName", "United Nations Economic Commission for Europe");
            writer.WriteAttributeString("listName", "Country");
            writer.WriteValue(this.AccountingSupplierParty.Party.PartyLegalEntity.RegistrationAddress.Country.IdentificationCode);
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteStartElement("cac:AccountingCustomerParty");
            writer.WriteStartElement("cac:Party");
            writer.WriteStartElement("cac:PartyIdentification");
            writer.WriteStartElement("cbc:ID");
            writer.WriteAttributeString("schemeID", this.AccountingCustomerParty.Party.PartyIdentification.Id.SchemeId);
            writer.WriteAttributeString("schemeName", "Documento de Identidad");
            writer.WriteAttributeString("schemeAgencyName", "PE:SUNAT");
            writer.WriteAttributeString("schemeURI", "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo06");
            writer.WriteValue(this.AccountingCustomerParty.Party.PartyIdentification.Id.Value);
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteStartElement("cac:PartyLegalEntity");
            writer.WriteStartElement("cbc:RegistrationName");
            writer.WriteCData(this.AccountingCustomerParty.Party.PartyLegalEntity.RegistrationName);
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndElement();
            if (this.PaymentTerms.Amount > 0M)
            {
                writer.WriteStartElement("cac:PaymentMeans");
                writer.WriteStartElement("cac:PayeeFinancialAccount");
                writer.WriteElementString("cbc:ID", this.PaymentMeans.PayeeFinancialAccount.Id);
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteStartElement("cac:PaymentTerms");
                writer.WriteStartElement("cbc:ID");
                writer.WriteAttributeString("schemeName", "SUNAT:Codigo de detraccion");
                writer.WriteAttributeString("schemeAgencyName", "PE:SUNAT");
                writer.WriteAttributeString("schemeURI", "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo54");
                writer.WriteValue(this.PaymentTerms.Id);
                writer.WriteEndElement();
                writer.WriteElementString("cbc:PaymentPercent", this.PaymentTerms.PaymentPercent.ToString("###0.#0", this.Formato));
                writer.WriteElementString("cbc:Amount", this.PaymentTerms.Amount.ToString("###0.#0", this.Formato));
                writer.WriteEndElement();
            }

            #region Forma de pago - Cambio por RS 193-2020 SUNAT

            foreach (var paymentTerm in ListPaymentTerms)
            {
                if (paymentTerm.Id == "FormaPago")
                {
                    writer.WriteStartElement("cac:PaymentTerms");

                    writer.WriteStartElement("cbc:ID");
                    writer.WriteValue(paymentTerm.Id);
                    writer.WriteEndElement();

                    writer.WriteStartElement("cbc:PaymentMeansID");
                    writer.WriteValue(paymentTerm.PaymentMeansID);
                    writer.WriteEndElement();

                    if (paymentTerm.PaymentMeansID != "Contado")
                    {
                        writer.WriteStartElement("cbc:Amount");
                        writer.WriteAttributeString("currencyID", DocumentCurrencyCode);
                        writer.WriteValue(paymentTerm.Amount.ToString(Formatos.FormatoNumerico, Formato));
                        writer.WriteEndElement();

                        if (paymentTerm.PaymentMeansID.Contains("Cuota"))
                        {
                            writer.WriteStartElement("cbc:PaymentDueDate");
                            writer.WriteValue(paymentTerm.PaymentDueDate.Value.ToString(Formatos.FormatoFecha, Formato));
                            writer.WriteEndElement();
                        }
                    }


                    writer.WriteEndElement();
                }
            }

            #endregion


            foreach (BillingPayment prepaidPayment in this.PrepaidPayments)
            {
                writer.WriteStartElement("cac:PrepaidPayment");
                writer.WriteStartElement("cbc:ID");
                writer.WriteAttributeString("schemeID", prepaidPayment.Id.SchemeId);
                writer.WriteAttributeString("schemeName", "Documentos Relacionados");
                writer.WriteAttributeString("schemeAgencyName", "PE:SUNAT");
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
            Decimal num1;

            foreach (var allowanceCharge in AllowanceCharges)
            {
                if (allowanceCharge.Amount.Value > 0)
                {
                    writer.WriteStartElement("cac:AllowanceCharge");
                    writer.WriteElementString("cbc:ChargeIndicator", allowanceCharge.ChargeIndicator.ToString().ToLower());
                    writer.WriteElementString("cbc:AllowanceChargeReasonCode", allowanceCharge.AllowanceChargeReasonCode);

                    if (allowanceCharge.MultiplierFactorNumeric > 0)
                        writer.WriteElementString("cbc:MultiplierFactorNumeric", allowanceCharge.MultiplierFactorNumeric.ToString("###0.#0", Formato));

                    writer.WriteStartElement("cbc:Amount");
                    writer.WriteAttributeString("currencyID", allowanceCharge.Amount.CurrencyId);
                    writer.WriteValue(allowanceCharge.Amount.Value.ToString("###0.#0", Formato));
                    writer.WriteEndElement();
                    writer.WriteStartElement("cbc:BaseAmount");
                    writer.WriteAttributeString("currencyID", allowanceCharge.BaseAmount.CurrencyId);
                    writer.WriteValue(allowanceCharge.BaseAmount.Value.ToString("###0.#0", this.Formato));
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                }
            }

            writer.WriteStartElement("cac:TaxTotal");
            writer.WriteStartElement("cbc:TaxAmount");
            writer.WriteAttributeString("currencyID", this.DocumentCurrencyCode);
            XmlWriter xmlWriter4 = writer;
            num1 = this.TaxTotals.Sum<TaxTotal>((Func<TaxTotal, Decimal>)(x => x.TaxSubtotal.TaxAmount.Value));
            string str4 = num1.ToString("###0.#0", this.Formato);
            xmlWriter4.WriteValue(str4);
            writer.WriteEndElement();
            foreach (TaxTotal taxTotal in this.TaxTotals)
            {
                //if (taxTotal.TaxSubtotal.TaxableAmount.Value > 0M)
                {
                    writer.WriteStartElement("cac:TaxSubtotal");
                    writer.WriteStartElement("cbc:TaxableAmount");
                    writer.WriteAttributeString("currencyID", taxTotal.TaxSubtotal.TaxableAmount.CurrencyId);
                    XmlWriter xmlWriter1 = writer;
                    num1 = taxTotal.TaxSubtotal.TaxableAmount.Value;
                    string str1 = num1.ToString("###0.#0", this.Formato);
                    xmlWriter1.WriteValue(str1);
                    writer.WriteEndElement();
                    writer.WriteStartElement("cbc:TaxAmount");
                    writer.WriteAttributeString("currencyID", taxTotal.TaxSubtotal.TaxAmount.CurrencyId);
                    XmlWriter xmlWriter2 = writer;
                    num1 = taxTotal.TaxSubtotal.TaxAmount.Value;
                    string str2 = num1.ToString("###0.#0", this.Formato);
                    xmlWriter2.WriteValue(str2);
                    writer.WriteEndElement();
                    writer.WriteStartElement("cac:TaxCategory");
                    writer.WriteStartElement("cbc:ID");
                    writer.WriteAttributeString("schemeID", "UN/ECE 5305");
                    writer.WriteAttributeString("schemeName", "Tax Category Identifier");
                    writer.WriteAttributeString("schemeAgencyName", "United Nations Economic Commission for Europe");
                    writer.WriteValue(taxTotal.TaxSubtotal.TaxCategory.Id);
                    writer.WriteEndElement();
                    writer.WriteStartElement("cac:TaxScheme");
                    writer.WriteStartElement("cbc:ID");
                    writer.WriteAttributeString("schemeID", "UN/ECE 5153");
                    writer.WriteAttributeString("schemeAgencyID", taxTotal.TaxSubtotal.TaxCategory.TaxScheme.SchemeAgencyID);
                    writer.WriteValue(taxTotal.TaxSubtotal.TaxCategory.TaxScheme.Id);
                    writer.WriteEndElement();
                    writer.WriteElementString("cbc:Name", taxTotal.TaxSubtotal.TaxCategory.TaxScheme.Name);
                    writer.WriteElementString("cbc:TaxTypeCode", taxTotal.TaxSubtotal.TaxCategory.TaxScheme.TaxTypeCode);
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                }
            }
            writer.WriteEndElement();
            writer.WriteStartElement("cac:LegalMonetaryTotal");
            writer.WriteStartElement("cbc:LineExtensionAmount");
            writer.WriteAttributeString("currencyID", this.LegalMonetaryTotal.LineExtensionAmount.CurrencyId);
            writer.WriteValue(this.LegalMonetaryTotal.LineExtensionAmount.Value.ToString("###0.#0", this.Formato));
            writer.WriteEndElement();
            writer.WriteStartElement("cbc:TaxInclusiveAmount");
            writer.WriteAttributeString("currencyID", this.LegalMonetaryTotal.TaxInclusiveAmount.CurrencyId);
            writer.WriteValue(this.LegalMonetaryTotal.TaxInclusiveAmount.Value.ToString("###0.#0", this.Formato));
            writer.WriteEndElement();
            writer.WriteStartElement("cbc:AllowanceTotalAmount");
            writer.WriteAttributeString("currencyID", this.LegalMonetaryTotal.AllowanceTotalAmount.CurrencyId);
            XmlWriter xmlWriter5 = writer;
            Decimal num2 = this.LegalMonetaryTotal.AllowanceTotalAmount.Value;
            string str5 = num2.ToString("###0.#0", this.Formato);
            xmlWriter5.WriteValue(str5);
            writer.WriteEndElement();
            writer.WriteStartElement("cbc:ChargeTotalAmount");
            writer.WriteAttributeString("currencyID", this.LegalMonetaryTotal.ChargeTotalAmount.CurrencyId);
            XmlWriter xmlWriter6 = writer;
            num2 = this.LegalMonetaryTotal.ChargeTotalAmount.Value;
            string str6 = num2.ToString("###0.#0", this.Formato);
            xmlWriter6.WriteValue(str6);
            writer.WriteEndElement();
            writer.WriteStartElement("cbc:PrepaidAmount");
            writer.WriteAttributeString("currencyID", this.LegalMonetaryTotal.PrepaidAmount.CurrencyId);
            XmlWriter xmlWriter7 = writer;
            num2 = this.LegalMonetaryTotal.PrepaidAmount.Value;
            string str7 = num2.ToString("###0.#0", this.Formato);
            xmlWriter7.WriteValue(str7);
            writer.WriteEndElement();
            writer.WriteStartElement("cbc:PayableAmount");
            writer.WriteAttributeString("currencyID", this.LegalMonetaryTotal.PayableAmount.CurrencyId);
            XmlWriter xmlWriter8 = writer;
            num2 = this.LegalMonetaryTotal.PayableAmount.Value;
            string str8 = num2.ToString("###0.#0", this.Formato);
            xmlWriter8.WriteValue(str8);
            writer.WriteEndElement();
            writer.WriteEndElement();
            foreach (InvoiceLine invoiceLine in this.InvoiceLines)
            {
                writer.WriteStartElement("cac:InvoiceLine");
                writer.WriteElementString("cbc:ID", invoiceLine.Id.ToString());
                writer.WriteStartElement("cbc:InvoicedQuantity");
                writer.WriteAttributeString("unitCode", invoiceLine.InvoicedQuantity.UnitCode);
                writer.WriteAttributeString("unitCodeListID", "UN/ECE rec 20");
                writer.WriteAttributeString("unitCodeListAgencyName", "United Nations Economic Commission for Europe");
                writer.WriteValue(invoiceLine.InvoicedQuantity.Value);
                writer.WriteEndElement();
                writer.WriteStartElement("cbc:LineExtensionAmount");
                writer.WriteAttributeString("currencyID", invoiceLine.LineExtensionAmount.CurrencyId);
                XmlWriter xmlWriter1 = writer;
                num2 = invoiceLine.LineExtensionAmount.Value;
                string str1 = num2.ToString("###0.#0", this.Formato);
                xmlWriter1.WriteValue(str1);
                writer.WriteEndElement();
                writer.WriteStartElement("cac:PricingReference");
                foreach (AlternativeConditionPrice alternativeConditionPrice in invoiceLine.PricingReference.AlternativeConditionPrices)
                {
                    writer.WriteStartElement("cac:AlternativeConditionPrice");
                    writer.WriteStartElement("cbc:PriceAmount");
                    writer.WriteAttributeString("currencyID", alternativeConditionPrice.PriceAmount.CurrencyId);
                    XmlWriter xmlWriter2 = writer;
                    num2 = alternativeConditionPrice.PriceAmount.Value;
                    string str2 = num2.ToString("###0.#0", this.Formato);
                    xmlWriter2.WriteValue(str2);
                    writer.WriteEndElement();
                    writer.WriteStartElement("cbc:PriceTypeCode");
                    writer.WriteAttributeString("listName", "Tipo de Precio");
                    writer.WriteAttributeString("listAgencyName", "PE:SUNAT");
                    writer.WriteAttributeString("listURI", "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo16");
                    writer.WriteValue(alternativeConditionPrice.PriceTypeCode);
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.WriteStartElement("cac:AllowanceCharge");
                writer.WriteElementString("cbc:ChargeIndicator", invoiceLine.AllowanceCharge.ChargeIndicator.ToString().ToLower());
                writer.WriteElementString("cbc:AllowanceChargeReasonCode", invoiceLine.AllowanceCharge.AllowanceChargeReasonCode);
                writer.WriteElementString("cbc:MultiplierFactorNumeric", invoiceLine.AllowanceCharge.MultiplierFactorNumeric.ToString("###0.#0", this.Formato));
                writer.WriteStartElement("cbc:Amount");
                writer.WriteAttributeString("currencyID", invoiceLine.AllowanceCharge.Amount.CurrencyId);
                XmlWriter xmlWriter3 = writer;
                Decimal percent = invoiceLine.AllowanceCharge.Amount.Value;
                string str3 = percent.ToString("###0.#0", this.Formato);
                xmlWriter3.WriteValue(str3);
                writer.WriteEndElement();
                writer.WriteStartElement("cbc:BaseAmount");
                writer.WriteAttributeString("currencyID", invoiceLine.AllowanceCharge.BaseAmount.CurrencyId);
                XmlWriter xmlWriter9 = writer;
                percent = invoiceLine.AllowanceCharge.BaseAmount.Value;
                string str9 = percent.ToString("###0.#0", this.Formato);
                xmlWriter9.WriteValue(str9);
                writer.WriteEndElement();
                writer.WriteEndElement();
                foreach (TaxTotal taxTotal in invoiceLine.TaxTotals)
                {
                    writer.WriteStartElement("cac:TaxTotal");
                    writer.WriteStartElement("cbc:TaxAmount");
                    writer.WriteAttributeString("currencyID", taxTotal.TaxAmount.CurrencyId);
                    XmlWriter xmlWriter2 = writer;
                    percent = taxTotal.TaxAmount.Value;
                    string str2 = percent.ToString("###0.#0", this.Formato);
                    xmlWriter2.WriteValue(str2);
                    writer.WriteEndElement();
                    writer.WriteStartElement("cac:TaxSubtotal");
                    writer.WriteStartElement("cbc:TaxableAmount");
                    writer.WriteAttributeString("currencyID", taxTotal.TaxSubtotal.TaxableAmount.CurrencyId);
                    XmlWriter xmlWriter10 = writer;
                    percent = taxTotal.TaxSubtotal.TaxableAmount.Value;
                    string str10 = percent.ToString("###0.#0", this.Formato);
                    xmlWriter10.WriteValue(str10);
                    writer.WriteEndElement();
                    writer.WriteStartElement("cbc:TaxAmount");
                    writer.WriteAttributeString("currencyID", taxTotal.TaxSubtotal.TaxAmount.CurrencyId);
                    XmlWriter xmlWriter11 = writer;
                    percent = taxTotal.TaxSubtotal.TaxAmount.Value;
                    string str11 = percent.ToString("###0.#0", this.Formato);
                    xmlWriter11.WriteValue(str11);
                    writer.WriteEndElement();
                    writer.WriteStartElement("cac:TaxCategory");
                    writer.WriteStartElement("cbc:ID");
                    writer.WriteAttributeString("schemeID", "UN/ECE 5305");
                    writer.WriteAttributeString("schemeName", "Tax Category Identifier");
                    writer.WriteAttributeString("schemeAgencyName", "United Nations Economic Commission for Europe");
                    writer.WriteValue(taxTotal.TaxSubtotal.TaxCategory.Id);
                    writer.WriteEndElement();
                    XmlWriter xmlWriter12 = writer;
                    percent = taxTotal.TaxSubtotal.TaxCategory.Percent;
                    string str12 = percent.ToString("###0.#0");
                    xmlWriter12.WriteElementString("cbc:Percent", str12);
                    writer.WriteStartElement("cbc:TaxExemptionReasonCode");
                    writer.WriteAttributeString("listAgencyName", "PE:SUNAT");
                    writer.WriteAttributeString("listName", "Afectacion del IGV");
                    writer.WriteAttributeString("listURI", "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo07");
                    writer.WriteValue(taxTotal.TaxSubtotal.TaxCategory.TaxExemptionReasonCode);
                    writer.WriteEndElement();
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
                {

                    writer.WriteStartElement("cbc:Description");
                    {
                        writer.WriteCData(invoiceLine.Item.Description);
                    }
                    writer.WriteEndElement();

                    writer.WriteStartElement("cac:SellersItemIdentification");
                    {
                        writer.WriteElementString("cbc:ID", invoiceLine.Item.SellersItemIdentification.Id);
                    }
                    writer.WriteEndElement();

                    if (!string.IsNullOrEmpty(invoiceLine.Item.CommodityClassification.ItemClassificationCode))
                    {
                        writer.WriteStartElement("cac:CommodityClassification");
                        {
                            writer.WriteStartElement("cbc:ItemClassificationCode");
                            {
                                writer.WriteAttributeString("listID", "UNSPSC");
                                writer.WriteAttributeString("listName", "Item Classification");
                                writer.WriteAttributeString("listAgencyName", "GS1 US");
                                writer.WriteValue(invoiceLine.Item.CommodityClassification.ItemClassificationCode);
                            }
                            writer.WriteEndElement();
                        }
                        writer.WriteEndElement();
                    }

                    #region . Información adcional del item .
                    if (invoiceLine.Item.AdditionalItemProperties.Count > 0)
                    {
                        foreach (var additionalItemProperty in invoiceLine.Item.AdditionalItemProperties)
                        {
                            if (additionalItemProperty.NameCode != "4002" & additionalItemProperty.NameCode != "4003" &
                                additionalItemProperty.NameCode != "4004" & additionalItemProperty.NameCode != "4006" &
                                additionalItemProperty.NameCode != "3005" & additionalItemProperty.NameCode != "3006" &
                                additionalItemProperty.NameCode != "4005" & additionalItemProperty.NameCode != "3059" &
                                additionalItemProperty.NameCode != "3060" & additionalItemProperty.NameCode != "4048" &
                                additionalItemProperty.NameCode != "4047" & additionalItemProperty.NameCode != "4062" &
                                additionalItemProperty.NameCode != "4063")
                            {
                                writer.WriteStartElement("cac:AdditionalItemProperty");
                                writer.WriteStartElement("cbc:Name");
                                writer.WriteCData(additionalItemProperty.Name);
                                writer.WriteEndElement();
                                writer.WriteStartElement("cbc:NameCode");
                                writer.WriteAttributeString("listName", Atributos.IdentificadorPropiedadItem);
                                writer.WriteAttributeString("listAgencyName", Atributos.AgencyNameSunat);
                                writer.WriteAttributeString("listURI", Atributos.URICatalogo55);
                                writer.WriteValue(additionalItemProperty.NameCode);
                                writer.WriteEndElement();
                                writer.WriteElementString("cbc:Value", additionalItemProperty.Value);
                                writer.WriteEndElement();
                            }
                        }

                        foreach (var additionalItemProperty in invoiceLine.Item.AdditionalItemProperties)
                        {
                            if (additionalItemProperty.NameCode == "3006")
                            {
                                writer.WriteStartElement("cac:AdditionalItemProperty");
                                writer.WriteStartElement("cbc:Name");
                                writer.WriteCData(additionalItemProperty.Name);
                                writer.WriteEndElement();
                                writer.WriteStartElement("cbc:NameCode");
                                writer.WriteAttributeString("listName", Atributos.IdentificadorPropiedadItem);
                                writer.WriteAttributeString("listAgencyName", Atributos.AgencyNameSunat);
                                writer.WriteAttributeString("listURI", Atributos.URICatalogo55);
                                writer.WriteValue(additionalItemProperty.NameCode);
                                writer.WriteEndElement();
                                writer.WriteStartElement("cbc:ValueQuantity");
                                writer.WriteAttributeString("unitCode", "TNE");
                                writer.WriteValue(additionalItemProperty.Value);
                                writer.WriteEndElement();
                                writer.WriteEndElement();
                            }
                        }

                        foreach (var additionalItemProperty in invoiceLine.Item.AdditionalItemProperties)
                        {
                            if (additionalItemProperty.NameCode == "4005")
                            {
                                writer.WriteStartElement("cac:AdditionalItemProperty");
                                writer.WriteStartElement("cbc:Name");
                                writer.WriteCData(additionalItemProperty.Name);
                                writer.WriteEndElement();
                                writer.WriteStartElement("cbc:NameCode");
                                writer.WriteAttributeString("listName", Atributos.IdentificadorPropiedadItem);
                                writer.WriteAttributeString("listAgencyName", Atributos.AgencyNameSunat);
                                writer.WriteAttributeString("listURI", Atributos.URICatalogo55);
                                writer.WriteValue(additionalItemProperty.NameCode);
                                writer.WriteEndElement();
                                writer.WriteStartElement("cac:UsabilityPeriod");
                                writer.WriteStartElement("cbc:DurationMeasure");
                                writer.WriteAttributeString("unitCode", "DAY");
                                writer.WriteValue(additionalItemProperty.Value);
                                writer.WriteEndElement();
                                writer.WriteEndElement();
                                writer.WriteEndElement();
                            }
                        }

                        foreach (var additionalItemProperty in invoiceLine.Item.AdditionalItemProperties)
                        {
                            if (additionalItemProperty.NameCode == "4002" || additionalItemProperty.NameCode == "4003" ||
                               additionalItemProperty.NameCode == "4004" || additionalItemProperty.NameCode == "4006" ||
                               additionalItemProperty.NameCode == "3005" || additionalItemProperty.NameCode == "3059" ||
                               additionalItemProperty.NameCode == "4048" || additionalItemProperty.NameCode == "4062")
                            {
                                writer.WriteStartElement("cac:AdditionalItemProperty");
                                writer.WriteStartElement("cbc:Name");
                                writer.WriteCData(additionalItemProperty.Name);
                                writer.WriteEndElement();
                                writer.WriteStartElement("cbc:NameCode");
                                writer.WriteAttributeString("listName", Atributos.IdentificadorPropiedadItem);
                                writer.WriteAttributeString("listAgencyName", Atributos.AgencyNameSunat);
                                writer.WriteAttributeString("listURI", Atributos.URICatalogo55);
                                writer.WriteValue(additionalItemProperty.NameCode);
                                writer.WriteEndElement();
                                writer.WriteStartElement("cac:UsabilityPeriod");
                                writer.WriteElementString("cbc:StartDate", additionalItemProperty.Value);
                                writer.WriteEndElement();
                                writer.WriteEndElement();
                            }
                        }

                        foreach (var additionalItemProperty in invoiceLine.Item.AdditionalItemProperties)
                        {
                            if (additionalItemProperty.NameCode == "3060" || additionalItemProperty.NameCode == "4047")
                            {
                                writer.WriteStartElement("cac:AdditionalItemProperty");
                                writer.WriteStartElement("cbc:Name");
                                writer.WriteCData(additionalItemProperty.Name);
                                writer.WriteEndElement();
                                writer.WriteStartElement("cbc:NameCode");
                                writer.WriteAttributeString("listName", Atributos.IdentificadorPropiedadItem);
                                writer.WriteAttributeString("listAgencyName", Atributos.AgencyNameSunat);
                                writer.WriteAttributeString("listURI", Atributos.URICatalogo55);
                                writer.WriteValue(additionalItemProperty.NameCode);
                                writer.WriteEndElement();
                                writer.WriteStartElement("cac:UsabilityPeriod");
                                writer.WriteElementString("cbc:StartTime", additionalItemProperty.Value);
                                writer.WriteEndElement();
                                writer.WriteEndElement();
                            }
                        }

                        foreach (var additionalItemProperty in invoiceLine.Item.AdditionalItemProperties)
                        {
                            if (additionalItemProperty.NameCode == "4063")
                            {
                                writer.WriteStartElement("cac:AdditionalItemProperty");
                                writer.WriteStartElement("cbc:Name");
                                writer.WriteCData(additionalItemProperty.Name);
                                writer.WriteEndElement();
                                writer.WriteStartElement("cbc:NameCode");
                                writer.WriteAttributeString("listName", Atributos.IdentificadorPropiedadItem);
                                writer.WriteAttributeString("listAgencyName", Atributos.AgencyNameSunat);
                                writer.WriteAttributeString("listURI", Atributos.URICatalogo55);
                                writer.WriteValue(additionalItemProperty.NameCode);
                                writer.WriteEndElement();
                                writer.WriteStartElement("cac:UsabilityPeriod");
                                writer.WriteElementString("cbc:EndDate", additionalItemProperty.Value);
                                writer.WriteEndElement();
                                writer.WriteEndElement();
                            }
                        }
                    }

                    #endregion

                }
                writer.WriteEndElement();

                writer.WriteStartElement("cac:Price");
                {
                    writer.WriteStartElement("cbc:PriceAmount");
                    {
                        writer.WriteAttributeString("currencyID", invoiceLine.Price.PriceAmount.CurrencyId);
                        writer.WriteValue(invoiceLine.Price.PriceAmount.Value.ToString("###0.#000", this.Formato));
                    }
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();

                writer.WriteEndElement();
            }
        }
    }
}
