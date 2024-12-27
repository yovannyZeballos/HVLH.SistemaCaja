namespace HVLH.SistemaCaja.Servicio.DTO
{
	public class ListarMenuDTO
	{
		public int Id { get; set; }
		public int IdMenuPadre { get; set; }
		public string Descripcion { get; set; }
		public string Nombre { get; set; }
		public bool Marcado { get; set; }
	}
}
