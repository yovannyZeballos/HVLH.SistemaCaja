using System;

namespace HVLH.Facturacion.Estructuras.ComponentesAgregadoComunes
{
	[Serializable]
	public class BillingReference : IEquatable<BillingReference>
	{
		public InvoiceDocumentReference InvoiceDocumentReference { get; set; }

		public BillingReference() => this.InvoiceDocumentReference = new InvoiceDocumentReference();

		public bool Equals(BillingReference other) => this.InvoiceDocumentReference.Equals(other.InvoiceDocumentReference);

		public override int GetHashCode() => this.InvoiceDocumentReference.GetHashCode();
	}
}
