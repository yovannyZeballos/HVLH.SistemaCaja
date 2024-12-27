using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HVLH.SistemaCaja.Modelo
{
	[Table("TBL_CajaCuotas")]
	public class Cuota
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
        public int IdDocumento { get; set; }
        public int Numero { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public Documento Documento { get; set; }
    }
}
