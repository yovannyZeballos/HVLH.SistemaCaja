namespace HVLH.Facturacion.Comun.Datos.Modelos
{
	public class Transportista : Contribuyente
	{
		public string NumeroRegistroMTC { get; set; }
		public EntidadEmisora EntidadEmisora { get; set; }
		public Transportista()
		{
			EntidadEmisora = new EntidadEmisora();
		}
	}
}