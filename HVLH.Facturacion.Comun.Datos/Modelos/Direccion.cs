namespace HVLH.Facturacion.Comun.Datos.Modelos
{
	public class Direccion
	{
		public string Ubigeo { get; set; }
		public string DireccionDetallada { get; set; }
		public string NumeroDocumentoAsociado { get; set; }
		public string CodigoEstablecimiento { get; set; }
		public CoordenadasGeograficas Longitud { get; set; }
		public CoordenadasGeograficas Latitud { get; set; }
		public Direccion()
		{
			Longitud = new CoordenadasGeograficas();
			Latitud = new CoordenadasGeograficas();
		}
	}
}
