using System;

namespace HVLH.Facturacion.Estructuras.ComponentesAgregadoComunes
{
	[Serializable]
	public class CarrierParty
	{
		public PartyIdentification PartyIdentification { get; set; }

		public PartyLegalEntity PartyLegalEntity { get; set; }
		public PartyName PartyName { get; set; }

		public CarrierParty()
		{
			PartyIdentification = new PartyIdentification();
			PartyLegalEntity = new PartyLegalEntity();
			PartyName = new PartyName();
		}
	}
}
