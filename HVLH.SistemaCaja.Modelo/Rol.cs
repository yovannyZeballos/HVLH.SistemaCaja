using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HVLH.SistemaCaja.Modelo
{
	[Table("TBL_CajaRol")]
	public class Rol : DatosAuditoria
	{
        public int Id { get; set; }
        public string Descripcion { get; set; }
		public ICollection<RolMenu> RolMenus { get; set; }
		public ICollection<UsuarioRol> UsuarioRoles { get; set; }
		
	}
}
