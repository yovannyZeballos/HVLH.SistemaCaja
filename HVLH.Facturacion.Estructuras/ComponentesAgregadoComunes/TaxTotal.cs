using HVLH.Facturacion.Estructuras.ComponentesBasicosComunes;
using System;

namespace HVLH.Facturacion.Estructuras.ComponentesAgregadoComunes
{
	[Serializable]
	public class TaxTotal
	{
		public PayableAmount TaxableAmount { get; set; }

		public PayableAmount TaxAmount { get; set; }

		public TaxSubtotal TaxSubtotal { get; set; }

		public TaxTotal()
		{
			this.TaxableAmount = new PayableAmount();
			this.TaxAmount = new PayableAmount();
			this.TaxSubtotal = new TaxSubtotal();
		}
	}
}
