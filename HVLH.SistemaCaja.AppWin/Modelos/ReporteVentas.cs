namespace HVLH.SistemaCaja.AppWin.Modelos
{
	public class ReporteVentas
	{
        public string TipoDocumento { get; set; }
        public string NroDocumento { get; set; }
        public string Fecha { get; set; }
        public string Referencia { get; set; }
        public string RazonSocialCliente { get; set; }
        public string RucCliente { get; set; }
        public string Moneda { get; set; }
        public decimal Gravadas { get; set; }
        public decimal Inafectas { get; set; }
        public decimal Igv { get; set; }
        public decimal Total { get; set; }
		public string MedioPago { get; set; }

	}
}
