using HVLH.Facturacion.Comun;
using HVLH.Facturacion.Estructuras.ComponentesAgregadoComunes;
using HVLH.Facturacion.Estructuras.ComponentesBasicosComunes;
using HVLH.Facturacion.Estructuras.ComponentesExtensionComunes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace HVLH.Facturacion.Estructuras.EstandarUbl2._1
{
	[Serializable]
	public class CreditNote : IXmlSerializable, IEstructuraXml
	{
		public UblExtensions UblExtensions { get; set; }

		public string UblVersionId { get; set; }

		public string CustomizationId { get; set; }

		public string Id { get; set; }

		public DateTime IssueDate { get; set; }

		public TimeSpan IssueTime { get; set; }

		public string DocumentCurrencyCode { get; set; }

		public List<DiscrepancyResponse> DiscrepancyResponses { get; set; }

		public List<BillingReference> BillingReferences { get; set; }

		public List<InvoiceDocumentReference> DespatchDocumentReferences { get; set; }

		public List<InvoiceDocumentReference> AdditionalDocumentReferences { get; set; }

		public SignatureCac Signature { get; set; }

		public AccountingSupplierParty AccountingSupplierParty { get; set; }

		public AccountingSupplierParty AccountingCustomerParty { get; set; }

		public List<TaxTotal> TaxTotals { get; set; }

		public LegalMonetaryTotal LegalMonetaryTotal { get; set; }

		public List<InvoiceLine> CreditNoteLines { get; set; }

		public List<Note> Notes { get; set; }

		public IFormatProvider Formato { get; set; }

		public InvoiceTypeCode InvoiceTypeCode { get; set; }

		public string LineCountNumeric { get; set; }

		public string OrderReference { get; set; }

		public CreditNote()
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
			this.LegalMonetaryTotal = new LegalMonetaryTotal();
			this.CreditNoteLines = new List<InvoiceLine>();
			this.UblVersionId = "2.1";
			this.CustomizationId = "2.0";
			this.Formato = (IFormatProvider)new CultureInfo("es-PE");
			this.Notes = new List<Note>();
		}

		public XmlSchema GetSchema() => (XmlSchema)null;

		public void ReadXml(XmlReader reader) => throw new NotImplementedException();

		public void WriteXml(XmlWriter writer)
		{
			writer.WriteAttributeString("xmlns", "urn:oasis:names:specification:ubl:schema:xsd:CreditNote-2");
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
			writer.WriteElementString("cbc:IssueDate", this.IssueDate.ToString("yyyy-MM-dd", this.Formato));
			writer.WriteElementString("cbc:IssueTime", this.IssueTime.ToString("hh\\:mm\\:ss", this.Formato));
			if (this.Notes.Count > 0)
			{
				foreach (Note note in this.Notes)
				{
					writer.WriteStartElement("cbc:Note");
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
			foreach (DiscrepancyResponse discrepancyResponse in this.DiscrepancyResponses)
			{
				writer.WriteStartElement("cac:DiscrepancyResponse");
				writer.WriteElementString("cbc:ReferenceID", discrepancyResponse.ReferenceId);
				writer.WriteStartElement("cbc:ResponseCode");
				writer.WriteAttributeString("listAgencyName", "PE:SUNAT");
				writer.WriteAttributeString("listName", "Tipo de nota de credito");
				writer.WriteAttributeString("listURI", "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo09");
				writer.WriteValue(discrepancyResponse.ResponseCode);
				writer.WriteEndElement();
				writer.WriteStartElement("cbc:Description");
				writer.WriteCData(discrepancyResponse.Description);
				writer.WriteEndElement();
				writer.WriteEndElement();
			}
			if (!string.IsNullOrEmpty(this.OrderReference))
			{
				writer.WriteStartElement("cac:OrderReference");
				writer.WriteElementString("cbc:ID", this.OrderReference);
				writer.WriteEndElement();
			}
			foreach (BillingReference billingReference in this.BillingReferences)
			{
				writer.WriteStartElement("cac:BillingReference");
				writer.WriteStartElement("cac:InvoiceDocumentReference");
				writer.WriteElementString("cbc:ID", billingReference.InvoiceDocumentReference.Id);
				writer.WriteStartElement("cbc:DocumentTypeCode");
				writer.WriteAttributeString("listAgencyName", "PE:SUNAT");
				writer.WriteAttributeString("listName", "Tipo de Documento");
				writer.WriteAttributeString("listURI", "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo01");
				writer.WriteValue(billingReference.InvoiceDocumentReference.DocumentTypeCode);
				writer.WriteEndElement();
				writer.WriteEndElement();
				writer.WriteEndElement();
			}
			foreach (InvoiceDocumentReference documentReference in this.DespatchDocumentReferences)
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
			writer.WriteElementString("cbc:CitySubdivisionName", this.AccountingSupplierParty.Party.PartyLegalEntity.RegistrationAddress.CitySubdivisionName);
			writer.WriteElementString("cbc:CityName", this.AccountingSupplierParty.Party.PartyLegalEntity.RegistrationAddress.CityName);
			writer.WriteElementString("cbc:CountrySubentity", this.AccountingSupplierParty.Party.PartyLegalEntity.RegistrationAddress.CountrySubentity);
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
			writer.WriteStartElement("cac:TaxTotal");
			writer.WriteStartElement("cbc:TaxAmount");
			writer.WriteAttributeString("currencyID", this.DocumentCurrencyCode);
			writer.WriteValue(this.TaxTotals.Sum<TaxTotal>((Func<TaxTotal, Decimal>)(x => x.TaxSubtotal.TaxAmount.Value)).ToString("###0.#0", this.Formato));
			writer.WriteEndElement();
			foreach (TaxTotal taxTotal in this.TaxTotals)
			{
				if (taxTotal.TaxSubtotal.TaxableAmount.Value > 0M)
				{
					writer.WriteStartElement("cac:TaxSubtotal");
					writer.WriteStartElement("cbc:TaxableAmount");
					writer.WriteAttributeString("currencyID", taxTotal.TaxSubtotal.TaxableAmount.CurrencyId);
					XmlWriter xmlWriter1 = writer;
					Decimal num = taxTotal.TaxSubtotal.TaxableAmount.Value;
					string str1 = num.ToString("###0.#0", this.Formato);
					xmlWriter1.WriteValue(str1);
					writer.WriteEndElement();
					writer.WriteStartElement("cbc:TaxAmount");
					writer.WriteAttributeString("currencyID", taxTotal.TaxSubtotal.TaxAmount.CurrencyId);
					XmlWriter xmlWriter2 = writer;
					num = taxTotal.TaxSubtotal.TaxAmount.Value;
					string str2 = num.ToString("###0.#0", this.Formato);
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
			XmlWriter xmlWriter3 = writer;
			Decimal multiplierFactorNumeric = this.LegalMonetaryTotal.AllowanceTotalAmount.Value;
			string str3 = multiplierFactorNumeric.ToString("###0.#0", this.Formato);
			xmlWriter3.WriteValue(str3);
			writer.WriteEndElement();
			writer.WriteStartElement("cbc:ChargeTotalAmount");
			writer.WriteAttributeString("currencyID", this.LegalMonetaryTotal.ChargeTotalAmount.CurrencyId);
			XmlWriter xmlWriter4 = writer;
			multiplierFactorNumeric = this.LegalMonetaryTotal.ChargeTotalAmount.Value;
			string str4 = multiplierFactorNumeric.ToString("###0.#0", this.Formato);
			xmlWriter4.WriteValue(str4);
			writer.WriteEndElement();
			writer.WriteStartElement("cbc:PrepaidAmount");
			writer.WriteAttributeString("currencyID", this.LegalMonetaryTotal.PrepaidAmount.CurrencyId);
			XmlWriter xmlWriter5 = writer;
			multiplierFactorNumeric = this.LegalMonetaryTotal.PrepaidAmount.Value;
			string str5 = multiplierFactorNumeric.ToString("###0.#0", this.Formato);
			xmlWriter5.WriteValue(str5);
			writer.WriteEndElement();
			writer.WriteStartElement("cbc:PayableAmount");
			writer.WriteAttributeString("currencyID", this.LegalMonetaryTotal.PayableAmount.CurrencyId);
			XmlWriter xmlWriter6 = writer;
			multiplierFactorNumeric = this.LegalMonetaryTotal.PayableAmount.Value;
			string str6 = multiplierFactorNumeric.ToString("###0.#0", this.Formato);
			xmlWriter6.WriteValue(str6);
			writer.WriteEndElement();
			writer.WriteEndElement();
			foreach (InvoiceLine creditNoteLine in this.CreditNoteLines)
			{
				writer.WriteStartElement("cac:CreditNoteLine");
				writer.WriteElementString("cbc:ID", creditNoteLine.Id.ToString());
				writer.WriteStartElement("cbc:CreditedQuantity");
				writer.WriteAttributeString("unitCode", creditNoteLine.CreditedQuantity.UnitCode);
				writer.WriteAttributeString("unitCodeListID", "UN/ECE rec 20");
				writer.WriteAttributeString("unitCodeListAgencyName", "United Nations Economic Commission for Europe");
				writer.WriteValue(creditNoteLine.CreditedQuantity.Value);
				writer.WriteEndElement();
				writer.WriteStartElement("cbc:LineExtensionAmount");
				writer.WriteAttributeString("currencyID", creditNoteLine.LineExtensionAmount.CurrencyId);
				XmlWriter xmlWriter1 = writer;
				multiplierFactorNumeric = creditNoteLine.LineExtensionAmount.Value;
				string str1 = multiplierFactorNumeric.ToString("###0.#0", this.Formato);
				xmlWriter1.WriteValue(str1);
				writer.WriteEndElement();
				writer.WriteStartElement("cac:PricingReference");
				foreach (AlternativeConditionPrice alternativeConditionPrice in creditNoteLine.PricingReference.AlternativeConditionPrices)
				{
					writer.WriteStartElement("cac:AlternativeConditionPrice");
					writer.WriteStartElement("cbc:PriceAmount");
					writer.WriteAttributeString("currencyID", alternativeConditionPrice.PriceAmount.CurrencyId);
					XmlWriter xmlWriter2 = writer;
					multiplierFactorNumeric = alternativeConditionPrice.PriceAmount.Value;
					string str2 = multiplierFactorNumeric.ToString("###0.#0", this.Formato);
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
				foreach (TaxTotal taxTotal in creditNoteLine.TaxTotals)
				{
					writer.WriteStartElement("cac:TaxTotal");
					writer.WriteStartElement("cbc:TaxAmount");
					writer.WriteAttributeString("currencyID", taxTotal.TaxAmount.CurrencyId);
					writer.WriteValue(taxTotal.TaxAmount.Value.ToString("###0.#0", this.Formato));
					writer.WriteEndElement();
					writer.WriteStartElement("cac:TaxSubtotal");
					writer.WriteStartElement("cbc:TaxableAmount");
					writer.WriteAttributeString("currencyID", taxTotal.TaxSubtotal.TaxableAmount.CurrencyId);
					writer.WriteValue(taxTotal.TaxSubtotal.TaxableAmount.Value.ToString("###0.#0", this.Formato));
					writer.WriteEndElement();
					writer.WriteStartElement("cbc:TaxAmount");
					writer.WriteAttributeString("currencyID", taxTotal.TaxSubtotal.TaxAmount.CurrencyId);
					writer.WriteValue(taxTotal.TaxSubtotal.TaxAmount.Value.ToString("###0.#0", this.Formato));
					writer.WriteEndElement();
					writer.WriteStartElement("cac:TaxCategory");
					writer.WriteStartElement("cbc:ID");
					writer.WriteAttributeString("schemeID", "UN/ECE 5305");
					writer.WriteAttributeString("schemeName", "Tax Category Identifier");
					writer.WriteAttributeString("schemeAgencyName", "United Nations Economic Commission for Europe");
					writer.WriteValue(taxTotal.TaxSubtotal.TaxCategory.Id);
					writer.WriteEndElement();
					writer.WriteElementString("cbc:Percent", taxTotal.TaxSubtotal.TaxCategory.Percent.ToString("###0.#0"));
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
				writer.WriteStartElement("cac:AllowanceCharge");
				writer.WriteElementString("cbc:ChargeIndicator", creditNoteLine.AllowanceCharge.ChargeIndicator.ToString().ToLower());
				writer.WriteElementString("cbc:AllowanceChargeReasonCode", creditNoteLine.AllowanceCharge.AllowanceChargeReasonCode);
				XmlWriter xmlWriter7 = writer;
				multiplierFactorNumeric = creditNoteLine.AllowanceCharge.MultiplierFactorNumeric;
				string str7 = multiplierFactorNumeric.ToString("###0.#0", this.Formato);
				xmlWriter7.WriteElementString("cbc:MultiplierFactorNumeric", str7);
				writer.WriteStartElement("cbc:Amount");
				writer.WriteAttributeString("currencyID", creditNoteLine.AllowanceCharge.Amount.CurrencyId);
				XmlWriter xmlWriter8 = writer;
				multiplierFactorNumeric = creditNoteLine.AllowanceCharge.Amount.Value;
				string str8 = multiplierFactorNumeric.ToString("###0.#0", this.Formato);
				xmlWriter8.WriteValue(str8);
				writer.WriteEndElement();
				writer.WriteStartElement("cbc:BaseAmount");
				writer.WriteAttributeString("currencyID", creditNoteLine.AllowanceCharge.BaseAmount.CurrencyId);
				XmlWriter xmlWriter9 = writer;
				multiplierFactorNumeric = creditNoteLine.AllowanceCharge.BaseAmount.Value;
				string str9 = multiplierFactorNumeric.ToString("###0.#0", this.Formato);
				xmlWriter9.WriteValue(str9);
				writer.WriteEndElement();
				writer.WriteEndElement();
				writer.WriteStartElement("cac:Item");
				writer.WriteStartElement("cbc:Description");
				writer.WriteCData(creditNoteLine.Item.Description);
				writer.WriteEndElement();
				writer.WriteStartElement("cac:SellersItemIdentification");
				writer.WriteElementString("cbc:ID", creditNoteLine.Item.SellersItemIdentification.Id);
				writer.WriteEndElement();
				if (!string.IsNullOrEmpty(creditNoteLine.Item.CommodityClassification.ItemClassificationCode))
				{
					writer.WriteStartElement("cac:CommodityClassification");
					writer.WriteStartElement("cbc:ItemClassificationCode");
					writer.WriteAttributeString("listID", "UNSPSC");
					writer.WriteAttributeString("listName", "Item Classification");
					writer.WriteAttributeString("listAgencyName", "GS1 US");
					writer.WriteValue(creditNoteLine.Item.CommodityClassification.ItemClassificationCode);
					writer.WriteEndElement();
					writer.WriteEndElement();
				}
				writer.WriteEndElement();
				writer.WriteStartElement("cac:Price");
				writer.WriteStartElement("cbc:PriceAmount");
				writer.WriteAttributeString("currencyID", creditNoteLine.Price.PriceAmount.CurrencyId);
				XmlWriter xmlWriter10 = writer;
				multiplierFactorNumeric = creditNoteLine.Price.PriceAmount.Value;
				string str10 = multiplierFactorNumeric.ToString("###0.#0", this.Formato);
				xmlWriter10.WriteValue(str10);
				writer.WriteEndElement();
				writer.WriteEndElement();
				writer.WriteEndElement();
			}
		}
	}
}
