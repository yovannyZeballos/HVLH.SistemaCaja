using System.Collections.Generic;

namespace HVLH.SistemaCaja.Servicio.DTO
{
	public class AsociarMenusDTO
	{
		public int IdRol { get; set; }
        public List<int> IdMenus { get; set; }
        public string Usuario { get; set; }
    }
}
