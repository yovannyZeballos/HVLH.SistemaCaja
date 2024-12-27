using HVLH.Facturacion.Estructuras.ComponentesBasicosComunes;
using System;

namespace HVLH.Facturacion.Estructuras.ComponentesAgregadoComunes
{
	[Serializable]
	public class PartyIdentification
	{
		public PartyIdentificationId Id { get; set; }

		public PartyIdentification() => this.Id = new PartyIdentificationId();
	}
}
