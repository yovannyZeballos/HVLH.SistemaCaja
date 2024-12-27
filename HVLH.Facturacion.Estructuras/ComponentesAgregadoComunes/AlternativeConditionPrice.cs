using HVLH.Facturacion.Estructuras.ComponentesBasicosComunes;
using System;

namespace HVLH.Facturacion.Estructuras.ComponentesAgregadoComunes
{
	[Serializable]
	public class AlternativeConditionPrice
	{
		public PayableAmount PriceAmount { get; set; }

		public string PriceTypeCode { get; set; }

		public AlternativeConditionPrice() => this.PriceAmount = new PayableAmount();
	}
}
