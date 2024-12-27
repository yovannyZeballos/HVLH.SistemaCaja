using System.ComponentModel.DataAnnotations.Schema;

namespace HVLH.SistemaCaja.Modelo
{
	[Table("TBL_CajaTipoDocumentoSerie")]
	public class TipoDocumentoSerie : DatosAuditoria
	{
		public int Id { get; set; }
		public int IdTipoDocumento { get; set; }
		public string Serie { get; set; }
		public string Tipo { get; set; }
		public bool AfectoIGV { get; set; }
	}
}
