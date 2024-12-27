using System;

namespace HVLH.Facturacion.Estructuras.ComponentesAgregadoComunes
{
	[Serializable]
	public class DigitalSignatureAttachment
	{
		public ExternalReference ExternalReference { get; set; }

		public DigitalSignatureAttachment() => this.ExternalReference = new ExternalReference();
	}
}
