namespace HVLH.SistemaCaja.Servicio.DTO
{
	public class ObtenerProductoDTO
	{
		public string Codigo { get; set; }
		public string Descripcion { get; set; }
		public int IdTipoAfectacionIgv { get; set; }
		public decimal Precio { get; set; }
		public int IdUnidadMedida { get; set; }
	}
}
