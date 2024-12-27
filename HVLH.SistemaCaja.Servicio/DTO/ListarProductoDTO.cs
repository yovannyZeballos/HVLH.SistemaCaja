namespace HVLH.SistemaCaja.Servicio.DTO
{
	public class ListarProductoDTO
	{
		public int Id { get; set; }
		public string Codigo { get; set; }
		public string Descripcion { get; set; }
		public string TipoIgv { get; set; }
		public decimal Precio { get; set; }
		public string UnidadMedida { get; set; }
	}
}
