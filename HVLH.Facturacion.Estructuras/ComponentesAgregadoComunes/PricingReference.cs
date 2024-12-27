using System;
using System.Collections.Generic;

namespace HVLH.Facturacion.Estructuras.ComponentesAgregadoComunes
{
	[Serializable]
	public class PricingReference
	{
		public List<AlternativeConditionPrice> AlternativeConditionPrices { get; set; }

		public PricingReference() => this.AlternativeConditionPrices = new List<AlternativeConditionPrice>();
	}
}
