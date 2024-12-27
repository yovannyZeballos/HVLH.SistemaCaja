using HVLH.Facturacion.Comun.Datos.Contratos;

namespace HVLH.Facturacion.Comun.Datos.Modelos
{
	public abstract class DocumentoResumen : IDocumentoElectronico
	{
		public string IdDocumento { get; set; }

		public string FechaEmision { get; set; }

		public string FechaReferencia { get; set; }

		public Contribuyente Emisor { get; set; }
	}
}
