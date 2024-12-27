namespace HVLH.SistemaCaja.Servicio.DTO
{
	public class ListarCitasDTO
	{
		public string IdCita { get; set; }
		public string FechaCita { get; set; }
		public string HoraCita { get; set; }
		public string NroHistoria { get; set; }
		public string TipoDocCliente { get; set; }
		public string NroDocCliente { get; set; }
		public string NombresPaciente { get; set; }
		public string Medico { get; set; }
		public int IdFinanciador { get; set; }
		public string DescripcionFinan { get; set; }
		public string CodProducto { get; set; }
		public string DescripcionProducto { get; set; }
		public decimal Precio { get; set; }
		public string TipoIgv { get; set; }
	}
}
