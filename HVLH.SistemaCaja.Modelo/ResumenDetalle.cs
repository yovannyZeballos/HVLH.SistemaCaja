using HVLH.SistemaCaja.Comun;
using System.ComponentModel.DataAnnotations.Schema;

namespace HVLH.SistemaCaja.Modelo
{
	[Table("TBL_CajaResumenDetalle")]
	public class ResumenDetalle
	{
		public int Id { get; set; }
		public int IdResumen { get; set; }
		public int IdDocumento { get; set; }
        public EstadoResumenDetalle Estado { get; set; }
        public Resumen Resumen { get; set; }
        public Documento Documento { get; set; }
    }
}
