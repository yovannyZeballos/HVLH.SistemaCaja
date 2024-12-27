using System;
using System.Collections.Generic;

namespace HVLH.Facturacion.Estructuras.ComponentesAgregadoComunes
{
	[Serializable]
	public class TransportHandlingUnit
	{
		public string Id { get; set; }

		public List<TransportEquipment> TransportEquipments { get; set; }

		public TransportHandlingUnit() => this.TransportEquipments = new List<TransportEquipment>();
	}
}
