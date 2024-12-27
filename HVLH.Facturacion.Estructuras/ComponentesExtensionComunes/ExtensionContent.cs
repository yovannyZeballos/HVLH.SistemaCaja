using HVLH.Facturacion.Estructuras.ComponentesAgregadoSunat;
using System;

namespace HVLH.Facturacion.Estructuras.ComponentesExtensionComunes
{
	[Serializable]
	public class ExtensionContent
	{
		public AdditionalInformation AdditionalInformation { get; set; }

		public ExtensionContent() => this.AdditionalInformation = new AdditionalInformation();
	}
}
