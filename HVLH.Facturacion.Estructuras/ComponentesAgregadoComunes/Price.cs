using HVLH.Facturacion.Estructuras.ComponentesBasicosComunes;
using System;

namespace HVLH.Facturacion.Estructuras.ComponentesAgregadoComunes
{
	[Serializable]
	public class Price
	{
		public PayableAmount PriceAmount { get; set; }

		public Price() => this.PriceAmount = new PayableAmount();
	}
}
