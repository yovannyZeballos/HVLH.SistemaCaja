namespace HVLH.SistemaCaja.Servicio.DTO
{
	public class ObtenerTipoDocumentoSerieDTO
	{
		public int Id { get; set; }
		public int IdTipoDocumento { get; set; }
		public string Serie { get; set; } 
		public string Tipo { get; set; } 
		public bool AfectoIGV { get; set; }
	}
}
