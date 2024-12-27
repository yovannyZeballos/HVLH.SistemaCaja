using System;

namespace HVLH.Facturacion.Estructuras.ComponentesAgregadoComunes
{
	[Serializable]
	public class TaxCategory
	{
		public string TaxExemptionReasonCode { get; set; }

		public string TierRange { get; set; }

		public TaxScheme TaxScheme { get; set; }

		public string Id { get; set; }

		public Decimal Percent { get; set; }

		public TaxCategory()
		{
			this.TaxScheme = new TaxScheme();
			this.Percent = 18.00M;
		}
	}
}
