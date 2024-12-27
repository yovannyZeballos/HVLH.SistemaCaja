using HVLH.Facturacion.Estructuras.ComponentesAgregadoSunat;
using HVLH.Facturacion.Estructuras.ComponentesBasicosComunes;
using System;

namespace HVLH.Facturacion.Estructuras.ComponentesAgregadoComunes
{
	[Serializable]
	public class ShipmentStage
	{
		public int Id { get; set; }

		public CarrierParty CarrierParty { get; set; }

		public PartyIdentification DriverPerson { get; set; }

		public string TransportModeCode { get; set; }

		public DateTime TransitPeriodStartPeriod { get; set; }

		public SunatRoadTransport TransportMeans { get; set; }

		public TransitPeriod TransitPeriod { get; set; }


		public ShipmentStage()
		{
			DriverPerson = new PartyIdentification();
			TransportMeans = new SunatRoadTransport();
			TransitPeriod = new TransitPeriod();
		}
	}
}
