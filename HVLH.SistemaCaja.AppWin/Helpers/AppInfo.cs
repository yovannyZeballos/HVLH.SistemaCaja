using HVLH.SistemaCaja.Servicio.DTO;
using System.Collections.Generic;

namespace HVLH.SistemaCaja.AppWin.Helpers
{
	public class AppInfo
	{
		public static string Usuario { get; set; } = string.Empty;
		public static int IdUsuario { get; set; } 
		public static string Nombres { get; set; }
		public static List<MenusAsociadosDTO> Menus { get; set; }
	}
}
