using HVLH.Facturacion.Estructuras.ComponentesBasicosComunes;
using System;

namespace HVLH.Facturacion.Estructuras.ComponentesAgregadoComunes
{
	[Serializable]
	public class AllowanceCharge
	{
		public bool ChargeIndicator { get; set; }

		public PayableAmount Amount { get; set; }

		public string AllowanceChargeReasonCode { get; set; }

		public Decimal MultiplierFactorNumeric { get; set; }

		public PayableAmount BaseAmount { get; set; }

		public AllowanceCharge() => this.Amount = new PayableAmount();
	}
}
