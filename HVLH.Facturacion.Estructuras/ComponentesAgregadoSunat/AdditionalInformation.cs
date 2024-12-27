using System;
using System.Collections.Generic;

namespace HVLH.Facturacion.Estructuras.ComponentesAgregadoSunat
{
	[Serializable]
	public class AdditionalInformation
	{
		public List<AdditionalMonetaryTotal> AdditionalMonetaryTotals { get; set; }

		public List<AdditionalProperty> AdditionalProperties { get; set; }

		public SunatEmbededDespatchAdvice SunatEmbededDespatchAdvice { get; set; }

		public SunatCosts SunatCosts { get; set; }

		public SunatTransaction SunatTransaction { get; private set; }

		public AdditionalInformation()
		{
			this.AdditionalMonetaryTotals = new List<AdditionalMonetaryTotal>();
			this.AdditionalProperties = new List<AdditionalProperty>();
			this.SunatEmbededDespatchAdvice = new SunatEmbededDespatchAdvice();
			this.SunatTransaction = new SunatTransaction();
			this.SunatCosts = new SunatCosts();
		}
	}
}
