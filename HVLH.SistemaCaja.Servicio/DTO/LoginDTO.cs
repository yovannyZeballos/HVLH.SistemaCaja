
using System.Collections.Generic;

namespace HVLH.SistemaCaja.Servicio.DTO
{
	public class LoginDTO
	{
        public int IdUsuario { get; set; }
        public string Usuario { get; set; }
		public string Nombres { get; set; }
        public bool CambioClave { get; set; }
        public List<MenusAsociadosDTO> Menus { get; set; }
    }
}
