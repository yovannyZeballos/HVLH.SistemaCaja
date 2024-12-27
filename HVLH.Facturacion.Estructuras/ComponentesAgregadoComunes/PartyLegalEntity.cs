using System;

namespace HVLH.Facturacion.Estructuras.ComponentesAgregadoComunes
{
	[Serializable]
	public class PartyLegalEntity
	{
		public string RegistrationName { get; set; }

		public RegistrationAddress RegistrationAddress { get; set; }

		public PartyLegalEntity() => this.RegistrationAddress = new RegistrationAddress();
	}
}
