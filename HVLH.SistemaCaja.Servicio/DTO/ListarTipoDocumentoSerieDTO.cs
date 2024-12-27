namespace HVLH.SistemaCaja.Servicio.DTO
{
	public class ListarTipoDocumentoSerieDTO
	{
		public int Id { get; set; }
		public string Serie { get; set; } 
		public string Tipo { get; set; } 
		public bool AfectoIGV { get; set; }
	}
}
