using HVLH.Facturacion.Estructuras.ComponentesBasicosComunes;
using System;

namespace HVLH.Facturacion.Estructuras.ComponentesAgregadoComunes
{
	[Serializable]
	public class OrderReference
	{
		public string Id { get; set; }

		public OrderTypeCode OrderTypeCode { get; set; }

		public OrderReference() => this.OrderTypeCode = new OrderTypeCode();
	}
}
