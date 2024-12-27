using System;

namespace HVLH.Facturacion.Estructuras.ComponentesAgregadoComunes
{
	[Serializable]
	public class DiscrepancyResponse : IEquatable<DiscrepancyResponse>
	{
		public string ReferenceId { get; set; }

		public string ResponseCode { get; set; }

		public string Description { get; set; }

		public DiscrepancyResponse() => this.ReferenceId = string.Empty;

		public bool Equals(DiscrepancyResponse other) => !string.IsNullOrEmpty(this.ReferenceId) && this.ReferenceId.Equals(other.ReferenceId);

		public override int GetHashCode() => string.IsNullOrEmpty(this.ReferenceId) ? base.GetHashCode() : this.ReferenceId.GetHashCode();
	}
}
