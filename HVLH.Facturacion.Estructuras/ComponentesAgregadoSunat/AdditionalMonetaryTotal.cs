using HVLH.Facturacion.Estructuras.ComponentesBasicosComunes;
using System;

namespace HVLH.Facturacion.Estructuras.ComponentesAgregadoSunat
{
	[Serializable]
	public class AdditionalMonetaryTotal
	{
		public string Id { get; set; }

		public PayableAmount PayableAmount { get; set; }

		public PayableAmount ReferenceAmount { get; set; }

		public PayableAmount TotalAmount { get; set; }

		public Decimal Percent { get; set; }

		public AdditionalMonetaryTotal()
		{
			this.PayableAmount = new PayableAmount();
			this.ReferenceAmount = new PayableAmount();
			this.TotalAmount = new PayableAmount();
		}
	}
}
