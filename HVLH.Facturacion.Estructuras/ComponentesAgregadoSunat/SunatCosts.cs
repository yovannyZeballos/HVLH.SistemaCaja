using System;

namespace HVLH.Facturacion.Estructuras.ComponentesAgregadoSunat
{
	[Serializable]
	public class SunatCosts
	{
		public SunatRoadTransport RoadTransport { get; set; }

		public SunatCosts() => this.RoadTransport = new SunatRoadTransport();
	}
}
