namespace HVLH.Facturacion.Comun.Datos.Modelos
{
	public class Vehiculo
	{
		public string NumeroPlaca { get; set; }
		public string TarjetaCirculacion { get; set; }
		public EntidadEmisora EntidadEmisora { get; set; }
		public Vehiculo()
		{
			EntidadEmisora = new EntidadEmisora();
		}
	}
}