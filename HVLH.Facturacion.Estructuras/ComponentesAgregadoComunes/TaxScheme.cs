using System;

namespace HVLH.Facturacion.Estructuras.ComponentesAgregadoComunes
{
	[Serializable]
	public class TaxScheme
	{
		public string Id { get; set; }

		public string Name { get; set; }

		public string TaxTypeCode { get; set; }

		public string SchemeAgencyID { get; set; }
	}
}
