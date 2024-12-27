using System.ComponentModel.DataAnnotations.Schema;

namespace HVLH.SistemaCaja.Modelo
{
    [Table("TBL_CajaTipoMedioPago")]
	public class TipoMedioPago
	{
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int FormaPago { get; set; }
    }
}
