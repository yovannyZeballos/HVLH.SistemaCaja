using HVLH.Facturacion.Estructuras.ComponentesBasicosComunes;
using System;

namespace HVLH.Facturacion.Estructuras.ComponentesAgregadoComunes
{
	[Serializable]
	public class LegalMonetaryTotal
	{
		public PayableAmount PayableAmount { get; set; }

		public PayableAmount AllowanceTotalAmount { get; set; }

		public PayableAmount ChargeTotalAmount { get; set; }

		public PayableAmount PrepaidAmount { get; set; }

		public PayableAmount TaxInclusiveAmount { get; set; }

		public PayableAmount LineExtensionAmount { get; set; }

		public LegalMonetaryTotal()
		{
			this.PayableAmount = new PayableAmount();
			this.AllowanceTotalAmount = new PayableAmount();
			this.ChargeTotalAmount = new PayableAmount();
			this.PrepaidAmount = new PayableAmount();
			this.TaxInclusiveAmount = new PayableAmount();
			this.LineExtensionAmount = new PayableAmount();
		}
	}
}
