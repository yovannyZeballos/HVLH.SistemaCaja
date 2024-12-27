using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HVLH.SistemaCaja.Modelo
{
	[Table("TBL_CajaMenu")]
	public class Menu : DatosAuditoria
	{
        public int Id { get; set; }
        public int IdMenuPadre { get; set; }
        public string Descripcion { get; set; }
        public string Nombre { get; set; }
		public ICollection<RolMenu> RolMenus { get; set; }
	}
}
