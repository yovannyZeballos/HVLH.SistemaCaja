using System;

namespace HVLH.Facturacion.Estructuras.ComponentesAgregadoComunes
{
	[Serializable]
	public class SignatoryParty
	{
		public PartyIdentification PartyIdentification { get; set; }

		public PartyName PartyName { get; set; }

		public SignatoryParty()
		{
			this.PartyIdentification = new PartyIdentification();
			this.PartyName = new PartyName();
		}
	}
}
