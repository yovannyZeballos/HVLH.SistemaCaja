using System.Collections.Generic;

namespace HVLH.SistemaCaja.Servicio.DTO
{
	public class AsociarRolesDTO
	{
		public int IdUsuario { get; set; }
		public List<int> IdRoles { get; set; }
        public string Usuario { get; set; }
    }
}
