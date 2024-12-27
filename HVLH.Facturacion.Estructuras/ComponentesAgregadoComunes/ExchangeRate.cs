using System;

namespace HVLH.Facturacion.Estructuras.ComponentesAgregadoComunes
{
	[Serializable]
	public class ExchangeRate
	{
		public string SourceCurrencyCode { get; set; }

		public string TargetCurrencyCode { get; set; }

		public Decimal CalculationRate { get; set; }

		public string Date { get; set; }
	}
}
