using System;

namespace HVLH.Facturacion.Estructuras.ComponentesExtensionComunes
{
	[Serializable]
	public class UblExtensions
	{
		public UblExtension Extension1 { get; set; }

		public UblExtension Extension2 { get; set; }

		public UblExtensions()
		{
			this.Extension1 = new UblExtension();
			this.Extension2 = new UblExtension();
		}
	}
}
