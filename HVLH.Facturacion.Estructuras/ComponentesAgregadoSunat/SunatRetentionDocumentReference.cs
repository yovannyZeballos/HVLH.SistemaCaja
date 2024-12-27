using HVLH.Facturacion.Estructuras.ComponentesAgregadoComunes;
using HVLH.Facturacion.Estructuras.ComponentesBasicosComunes;
using System;

namespace HVLH.Facturacion.Estructuras.ComponentesAgregadoSunat
{
	[Serializable]
	public class SunatRetentionDocumentReference
	{
		public PartyIdentificationId Id { get; set; }

		public string IssueDate { get; set; }

		public PayableAmount TotalInvoiceAmount { get; set; }

		public Payment Payment { get; set; }

		public SunatRetentionInformation SunatRetentionInformation { get; set; }

		public SunatRetentionDocumentReference()
		{
			this.Id = new PartyIdentificationId();
			this.TotalInvoiceAmount = new PayableAmount();
			this.Payment = new Payment();
			this.SunatRetentionInformation = new SunatRetentionInformation();
		}
	}
}
