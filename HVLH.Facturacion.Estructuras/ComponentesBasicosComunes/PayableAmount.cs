using System;

namespace HVLH.Facturacion.Estructuras.ComponentesBasicosComunes
{
	[Serializable]
	public class PayableAmount
	{
		public string CurrencyId { get; set; }

		public Decimal Value { get; set; }
	}
}
