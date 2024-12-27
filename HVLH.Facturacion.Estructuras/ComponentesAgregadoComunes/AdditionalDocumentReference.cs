using System;

namespace HVLH.Facturacion.Estructuras.ComponentesAgregadoComunes
{
	[Serializable]
	public class AdditionalDocumentReference
	{
		public string Id { get; set; }
		public string DocumentStatusCode { get; set; }
		public string DocumentTypeCode { get; set; }
		public Party IssuerParty { get; set; }
	}
}
