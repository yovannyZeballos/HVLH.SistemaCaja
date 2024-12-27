using System;

namespace HVLH.Facturacion.Estructuras.ComponentesBasicosComunes
{
	[Serializable]
	public class InvoicedQuantity
	{
		public string UnitCode { get; set; }

		public Decimal Value { get; set; }
	}
}
