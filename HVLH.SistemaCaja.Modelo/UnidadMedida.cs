using System.ComponentModel.DataAnnotations.Schema;

namespace HVLH.SistemaCaja.Modelo
{
	[Table("TBL_CajaUnidadMedida")]
	public class UnidadMedida
	{
		public int Id { get; set; }
		public string Codigo { get; set; }
		public string Descripcion { get; set; }
	}
}
