using System.ComponentModel.DataAnnotations.Schema;

namespace HVLH.SistemaCaja.Modelo
{
	[Table("TBL_CajaProducto")]
	public class Producto : DatosAuditoria
	{
		public int Id { get; set; }
		public string Codigo { get; set; }
		public string Descripcion { get; set; }
		public int IdTipoAfectacionIgv { get; set; }
		public decimal Precio { get; set; }
		public int IdUnidadMedida { get; set; }
        public UnidadMedida UnidadMedida { get; set; }
        public TipoAfectacionIgv TipoAfectacionIgv { get; set; }
	}
}
