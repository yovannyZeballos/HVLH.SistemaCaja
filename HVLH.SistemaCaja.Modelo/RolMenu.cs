using System.ComponentModel.DataAnnotations.Schema;

namespace HVLH.SistemaCaja.Modelo
{
	[Table("TBL_CajaRolMenu")]
	public class RolMenu : DatosAuditoria
	{
        public int Id { get; set; }
        public int IdMenu { get; set; }
        public int IdRol { get; set; }
        public Rol Rol { get; set; }
        public Menu Menu { get; set; }
    }
}
