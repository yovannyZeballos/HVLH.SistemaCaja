using System;
using System.Collections.Generic;

namespace HVLH.Facturacion.Estructuras.ComponentesAgregadoComunes
{
	[Serializable]
	public class Item
	{
		public string Description { get; set; }
		public SellersItemIdentification SellersItemIdentification { get; set; }
		public CommodityClassification CommodityClassification { get; set; }
		public List<AdditionalItemProperty> AdditionalItemProperties { get; set; }

		public Item()
		{
			SellersItemIdentification = new SellersItemIdentification();
			CommodityClassification = new CommodityClassification();
			AdditionalItemProperties = new List<AdditionalItemProperty>();
		}
	}
}
