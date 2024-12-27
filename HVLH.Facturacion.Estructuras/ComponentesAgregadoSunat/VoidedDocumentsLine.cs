using HVLH.Facturacion.Estructuras.ComponentesAgregadoComunes;
using HVLH.Facturacion.Estructuras.ComponentesBasicosComunes;
using System;
using System.Collections.Generic;

namespace HVLH.Facturacion.Estructuras.ComponentesAgregadoSunat
{
	[Serializable]
	public class VoidedDocumentsLine
	{
		public int LineId { get; set; }

		public string DocumentTypeCode { get; set; }

		public string DocumentSerialId { get; set; }

		public int DocumentNumberId { get; set; }

		public string VoidReasonDescription { get; set; }

		public string Id { get; set; }

		public int StartDocumentNumberId { get; set; }

		public int EndDocumentNumberId { get; set; }

		public PayableAmount TotalAmount { get; set; }

		public List<BillingPayment> BillingPayments { get; set; }

		public AllowanceCharge AllowanceCharge { get; set; }

		public List<TaxTotal> TaxTotals { get; set; }

		public AccountingSupplierParty AccountingCustomerParty { get; set; }

		public BillingReference BillingReference { get; set; }

		public int? ConditionCode { get; set; }

		public VoidedDocumentsLine()
		{
			this.TotalAmount = new PayableAmount();
			this.BillingPayments = new List<BillingPayment>();
			this.AllowanceCharge = new AllowanceCharge();
			this.TaxTotals = new List<TaxTotal>();
			this.AccountingCustomerParty = new AccountingSupplierParty();
			this.BillingReference = new BillingReference();
		}
	}
}
