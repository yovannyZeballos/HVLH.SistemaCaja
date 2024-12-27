namespace HVLH.SistemaCaja.Servicio.DTO
{
	public class GuardarProductoDTO
	{
		public int Id { get; set; }
		public string Codigo { get; set; }
		public string Descripcion { get; set; }
		public int IdTipoAfectacionIgv { get; set; }
		public decimal Precio { get; set; }
		public int IdUnidadMedida { get; set; }
        public string Usuario { get; set; }
    }
}
