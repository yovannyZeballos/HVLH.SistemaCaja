using System.ComponentModel.DataAnnotations.Schema;

namespace HVLH.SistemaCaja.Modelo
{
	[Table("TBL_CajaDocumentoDetalle")]
	public class DocumentoDetalle
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public int IdDocumento { get; set; }
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
		public decimal Igv { get; set; }
		public decimal PorcentajeIgv { get; set; }
		public decimal Isc { get; set; }
		public string TipoIgv { get; set; }
		public decimal Icbper { get; set; }
		public decimal PrecioTotal { get; set; }
		public Documento Documento { get; set; } 
    }
}
