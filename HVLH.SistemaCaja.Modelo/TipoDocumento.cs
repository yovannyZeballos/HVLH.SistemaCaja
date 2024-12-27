using System.ComponentModel.DataAnnotations.Schema;

namespace HVLH.SistemaCaja.Modelo
{
	[Table("TBL_CajaTipoDocumento")]
	public class TipoDocumento : DatosAuditoria
	{
		public int Id { get; set; }
		public string Codigo { get; set; } 
		public string Descripcion { get; set; } 
		public string DescripcionCorta { get; set; } 
	}
}
