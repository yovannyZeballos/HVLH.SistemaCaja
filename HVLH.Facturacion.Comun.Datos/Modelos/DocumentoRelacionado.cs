namespace HVLH.Facturacion.Comun.Datos.Modelos
{
	public class DocumentoRelacionado
	{
		public string NroDocumento { get; set; }
		public string TipoDocumento { get; set; }
		public string DescripcionTipoDocumento { get; set; }
		public Contribuyente Emisor { get; set; }
		public DocumentoRelacionado()
		{
			Emisor = new Contribuyente();
		}
	}
}
