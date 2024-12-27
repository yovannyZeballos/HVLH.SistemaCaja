using HVLH.Facturacion.Estructuras.ComponentesAgregadoComunes;
using HVLH.Facturacion.Estructuras.ComponentesBasicosComunes;
using System;

namespace HVLH.Facturacion.Estructuras.ComponentesAgregadoSunat
{
	[Serializable]
	public class SunatRetentionInformation
	{
		public PayableAmount SunatRetentionAmount { get; set; }

		public string SunatRetentionDate { get; set; }

		public PayableAmount SunatNetTotalPaid { get; set; }

		public ExchangeRate ExchangeRate { get; set; }

		public SunatRetentionInformation()
		{
			this.SunatRetentionAmount = new PayableAmount();
			this.SunatNetTotalPaid = new PayableAmount();
			this.ExchangeRate = new ExchangeRate();
		}
	}
}
