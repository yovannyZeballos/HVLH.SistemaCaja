using System.ComponentModel.DataAnnotations.Schema;

namespace HVLH.SistemaCaja.Modelo
{
	[Table("TBL_CajaUsuarioRol")]
	public class UsuarioRol : DatosAuditoria
	{
		public int Id { get; set; }
		public int IdUsuario { get; set; }
		public int IdRol { get; set; }
		public Usuario Usuario { get; set; }
		public Rol Rol { get; set; }
	}
}
