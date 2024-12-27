using HVLH.SistemaCaja.Comun;

namespace HVLH.SistemaCaja.Servicio.DTO
{
	public class ActualizarUsuarioDTO
	{
        public int Id { get; set; }
        public string Nombres { get; set; }
        public bool EsCajero { get; set; }
        public Estado Estado { get; set; }
        public string Usuario { get; set; }
    }
}
