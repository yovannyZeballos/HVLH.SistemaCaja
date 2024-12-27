namespace HVLH.Facturacion.Comun.Datos.Modelos
{
	public class Remitente : Contribuyente
	{
		public EntidadEmisora EntidadEmisora { get; set; }
		public Remitente()
		{
			EntidadEmisora = new EntidadEmisora();
		}
	}
}
