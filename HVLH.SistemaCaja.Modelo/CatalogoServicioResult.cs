namespace HVLH.SistemaCaja.Modelo
{
	public class CatalogoServicioResult
	{
        public int IdProducto { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
		public string Tipo { get; set; }
		public string Estado { get; set; }
		public string UnidadMedida { get; set; }
        public string TipoIgv { get; set; }

    }
}
