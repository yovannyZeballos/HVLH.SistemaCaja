using HVLH.Facturacion.Estructuras.ComponentesBasicosComunes;
using System;
using System.Collections.Generic;

namespace HVLH.Facturacion.Estructuras.ComponentesAgregadoComunes
{
	[Serializable]
	public class InvoiceLine
	{
		public int Id { get; set; }

		public InvoicedQuantity CreditedQuantity { get; set; }

		public InvoicedQuantity InvoicedQuantity { get; set; }

		public InvoicedQuantity DebitedQuantity { get; set; }

		public PayableAmount LineExtensionAmount { get; set; }

		public PricingReference PricingReference { get; set; }

		public AllowanceCharge AllowanceCharge { get; set; }

		public List<TaxTotal> TaxTotals { get; set; }

		public Item Item { get; set; }

		public Price Price { get; set; }

		public InvoiceLine()
		{
			this.CreditedQuantity = new InvoicedQuantity();
			this.InvoicedQuantity = new InvoicedQuantity();
			this.DebitedQuantity = new InvoicedQuantity();
			this.LineExtensionAmount = new PayableAmount();
			this.PricingReference = new PricingReference();
			this.AllowanceCharge = new AllowanceCharge();
			this.TaxTotals = new List<TaxTotal>();
			this.Item = new Item();
			this.Price = new Price();
		}
	}
}
