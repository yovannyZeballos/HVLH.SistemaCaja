using System;

namespace HVLH.Facturacion.Estructuras.ComponentesAgregadoComunes
{
	[Serializable]
	public class InvoiceDocumentReference : IEquatable<InvoiceDocumentReference>
	{
		public string Id { get; set; }

		public string DocumentTypeCode { get; set; }

		public InvoiceDocumentReference() => this.Id = string.Empty;

		public bool Equals(InvoiceDocumentReference other) => other != null && !string.IsNullOrEmpty(this.Id) && this.Id.Equals(other.Id);

		public override int GetHashCode() => string.IsNullOrEmpty(this.Id) ? base.GetHashCode() : this.Id.GetHashCode();
	}
}
