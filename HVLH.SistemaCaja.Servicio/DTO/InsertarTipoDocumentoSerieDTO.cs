namespace HVLH.SistemaCaja.Servicio.DTO
{
	public class InsertarTipoDocumentoSerieDTO
	{
		public int Id { get; set; }
		public int IdTipoDocumento { get; set; }
		public string Serie { get; set; } 
		public string Tipo { get; set; } 
		public string Usuario { get; set; } 
		public bool AfectoIGV { get; set; }
	}
}
