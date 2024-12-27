using System.ComponentModel.DataAnnotations.Schema;

namespace HVLH.SistemaCaja.Modelo
{
    [Table("TBL_CajaTipoAfectacionIgv")]
	public class TipoAfectacionIgv
	{
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
    }
}
