using HVLH.SistemaCaja.Comun;
using System.ComponentModel.DataAnnotations.Schema;

namespace HVLH.SistemaCaja.Modelo
{
	[Table("TBL_CajaComunicacionBajaDetalle")]
	public class ComunicacionBajaDetalle
	{
		public int Id { get; set; }
		public int IdBaja { get; set; }
		public int IdDocumento { get; set; }
        public string Motivo { get; set; }
        public ComunicacionBaja ComunicacionBaja { get; set; }
        public Documento Documento { get; set; }
    }
}
