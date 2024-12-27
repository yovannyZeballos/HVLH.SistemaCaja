using HVLH.SistemaCaja.Comun;

namespace HVLH.SistemaCaja.Servicio.DTO
{
	public class ListarUsuarioDTO
	{
        public int Id { get; set; }
        public string Login { get; set; }
        public string Nombres { get; set; }
        public bool EsCajero { get; set; }
		public Estado Estado { get; set; }
    }
}
