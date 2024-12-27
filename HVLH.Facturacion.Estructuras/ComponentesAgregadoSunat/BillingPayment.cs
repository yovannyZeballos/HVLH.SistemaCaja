using HVLH.Facturacion.Estructuras.ComponentesBasicosComunes;
using System;

namespace HVLH.Facturacion.Estructuras.ComponentesAgregadoSunat
{
	[Serializable]
	public class BillingPayment
	{
		public PartyIdentificationId Id { get; set; }

		public PayableAmount PaidAmount { get; set; }

		public string InstructionId { get; set; }

		public BillingPayment()
		{
			this.PaidAmount = new PayableAmount();
			this.Id = new PartyIdentificationId();
		}
	}
}
