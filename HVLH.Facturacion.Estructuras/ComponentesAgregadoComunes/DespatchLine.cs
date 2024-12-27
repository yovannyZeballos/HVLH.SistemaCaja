using HVLH.Facturacion.Estructuras.ComponentesBasicosComunes;
using System;

namespace HVLH.Facturacion.Estructuras.ComponentesAgregadoComunes
{
	[Serializable]
	public class DespatchLine
	{
		public int Id { get; set; }

		public InvoicedQuantity DeliveredQuantity { get; set; }

		public int OrderLineReferenceId { get; set; }

		public DespatchLineItem Item { get; set; }
	}
}
