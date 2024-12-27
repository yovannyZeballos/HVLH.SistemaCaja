namespace HVLH.SistemaCaja.Servicio.DTO
{
	public class DocumentoDetalleDTO
	{
		public int Item { get; set; }
		public string UnidadMedida { get; set; }
		public decimal Cantidad { get; set; }
		public string CodigoProducto { get; set; }
		public string CodigoProductoSunat { get; set; }
		public string CodigoProductoGTIN { get; set; }
		public string DescripcionProducto { get; set; }
		public decimal ValorUnitario { get; set; }
		public decimal ValorVenta { get; set; }
		public decimal PrecioVentaUnitario { get; set; }
		public decimal ValorReferencial { get; set; }
		public decimal Total { get; set; }
		public decimal Igv { get; set; }
		public decimal PorcentajeIgv { get; set; }
		public decimal Isc { get; set; }
		public string TipoIgv { get; set; }
		public decimal Icbper { get; set; }
		public decimal PrecioTotal { get; set; }
	}
}
