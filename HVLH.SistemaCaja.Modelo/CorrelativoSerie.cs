using System.ComponentModel.DataAnnotations.Schema;

namespace HVLH.SistemaCaja.Modelo
{
	[Table("TBL_CajaCorrelativoSerie")]
	public class CorrelativoSerie : DatosAuditoria
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
        public long Numero { get; set; }
        public int IdTipoDocumentoSerie { get; set; }
	}
}
