using HVLH.Facturacion.Estructuras.ComponentesAgregadoComunes;
using HVLH.Facturacion.Estructuras.ComponentesBasicosComunes;
using System;

namespace HVLH.Facturacion.Estructuras.ComponentesAgregadoSunat
{
	[Serializable]
	public class SunatEmbededDespatchAdvice
	{
		public PostalAddress DeliveryAddress { get; set; }

		public PostalAddress OriginAddress { get; set; }

		public AccountingSupplierParty SunatCarrierParty { get; set; }

		public AgentParty DriverParty { get; set; }

		public SunatRoadTransport SunatRoadTransport { get; set; }

		public string TransportModeCode { get; set; }

		public InvoicedQuantity GrossWeightMeasure { get; set; }

		public SunatEmbededDespatchAdvice()
		{
			this.DeliveryAddress = new PostalAddress();
			this.OriginAddress = new PostalAddress();
			this.SunatCarrierParty = new AccountingSupplierParty();
			this.DriverParty = new AgentParty();
			this.SunatRoadTransport = new SunatRoadTransport();
			this.GrossWeightMeasure = new InvoicedQuantity();
		}
	}
}
