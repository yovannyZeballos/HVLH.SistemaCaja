using System.ComponentModel.DataAnnotations.Schema;

namespace HVLH.SistemaCaja.Modelo
{
    [Table("TBL_CajaMedioPagoDocumento")]
	public class MedioPagoDocumento
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
        public int IdDocumento { get; set; }
        public int IdTipoMedioPago { get; set; }
		public decimal Importe { get; set; }
        public decimal Diferencia { get; set; }
        public Documento Documento { get; set; }
    }
}
