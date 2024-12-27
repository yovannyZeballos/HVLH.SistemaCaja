using System;

namespace HVLH.Facturacion.Estructuras.ComponentesAgregadoComunes
{
	[Serializable]
	public class Party
	{
		public PartyName PartyName { get; set; }

		public PostalAddress PostalAddress { get; set; }

		public PartyLegalEntity PartyLegalEntity { get; set; }

		public PartyTaxScheme PartyTaxScheme { get; set; }

		public PartyIdentification PartyIdentification { get; set; }

		public Party()
		{
			this.PartyName = new PartyName();
			this.PostalAddress = new PostalAddress();
			this.PartyLegalEntity = new PartyLegalEntity();
			this.PartyTaxScheme = new PartyTaxScheme();
			this.PartyIdentification = new PartyIdentification();
		}
	}
}
