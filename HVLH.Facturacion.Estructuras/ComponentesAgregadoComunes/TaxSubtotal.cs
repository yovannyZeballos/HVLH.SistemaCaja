using HVLH.Facturacion.Estructuras.ComponentesBasicosComunes;
using System;

namespace HVLH.Facturacion.Estructuras.ComponentesAgregadoComunes
{
	[Serializable]
	public class TaxSubtotal
	{
		public PayableAmount TaxAmount { get; set; }

		public TaxCategory TaxCategory { get; set; }

		public PayableAmount TaxableAmount { get; set; }

		public Decimal Percent { get; set; }

		public TaxSubtotal()
		{
			this.TaxAmount = new PayableAmount();
			this.TaxCategory = new TaxCategory();
			this.TaxableAmount = new PayableAmount();
		}
	}
}
