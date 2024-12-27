using System;

namespace HVLH.Facturacion.Estructuras.ComponentesAgregadoComunes
{
	[Serializable]
	public class SignatureCac
	{
		public string Id { get; set; }

		public SignatoryParty SignatoryParty { get; set; }

		public DigitalSignatureAttachment DigitalSignatureAttachment { get; set; }

		public SignatureCac()
		{
			this.SignatoryParty = new SignatoryParty();
			this.DigitalSignatureAttachment = new DigitalSignatureAttachment();
		}
	}
}
