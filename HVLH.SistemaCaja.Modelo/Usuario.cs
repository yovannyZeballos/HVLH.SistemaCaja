
using HVLH.SistemaCaja.Comun;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HVLH.SistemaCaja.Modelo
{
	[Table("TBL_CajaUsuario")]
	public class Usuario : DatosAuditoria
	{
		public int Id { get; set; }
		public string Login { get; set; }
		public string Nombres { get; set; }
		public byte[] PasswordHash { get; set; }
		public byte[] PasswordSalt { get; set; }
		public bool EsCajero { get; set; }
		public bool CambioClave { get; set; }
		public Estado Estado { get; set; }
		public ICollection<UsuarioRol> UsuarioRoles { get; set; }

	}
}
