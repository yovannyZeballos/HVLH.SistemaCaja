using System;

namespace HVLH.Facturacion.Estructuras.ComponentesExtensionComunes
{
	[Serializable]
	public class UblExtension
	{
		public ExtensionContent ExtensionContent { get; set; }

		public UblExtension() => this.ExtensionContent = new ExtensionContent();
	}
}
