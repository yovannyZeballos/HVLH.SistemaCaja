using System;

namespace HVLH.Facturacion.Estructuras.ComponentesAgregadoComunes
{
	[Serializable]
	public class AgentParty
	{
		public PartyIdentification PartyIdentification { get; set; }

		public PartyName PartyName { get; set; }

		public PostalAddress PostalAddress { get; set; }

		public PartyLegalEntity PartyLegalEntity { get; set; }

		public AgentParty()
		{
			this.PartyIdentification = new PartyIdentification();
			this.PartyName = new PartyName();
			this.PostalAddress = new PostalAddress();
			this.PartyLegalEntity = new PartyLegalEntity();
		}
	}
}
