using HVLH.Facturacion.Estructuras.ComponentesBasicosComunes;
using System;
using System.Collections.Generic;

namespace HVLH.Facturacion.Estructuras.ComponentesAgregadoComunes
{
	[Serializable]
	public class Shipment
	{
		public string ID { get; set; }

		public string HandlingCode { get; set; }

		public string Information { get; set; }

		public bool SplitConsignmentIndicator { get; set; }

		public InvoicedQuantity GrossWeightMeasure { get; set; }

		public int TotalTransportHandlingUnitQuantity { get; set; }

		public List<ShipmentStage> ShipmentStages { get; set; }

		public PostalAddress DeliveryAddress { get; set; }

		public TransportHandlingUnit TransportHandlingUnit { get; set; }

		public PostalAddress OriginAddress { get; set; }

		public string FirstArrivalPortLocationId { get; set; }

		public ShipmentStage ShipmentStage { get; set; }
		public LoadingPortLocation LoadingPortLocation { get; set; }

		public Shipment()
		{
			GrossWeightMeasure = new InvoicedQuantity();
			ShipmentStages = new List<ShipmentStage>();
			DeliveryAddress = new PostalAddress();
			TransportHandlingUnit = new TransportHandlingUnit();
			OriginAddress = new PostalAddress();
			ShipmentStage = new ShipmentStage();
			LoadingPortLocation = new LoadingPortLocation();
		}
	}
}
