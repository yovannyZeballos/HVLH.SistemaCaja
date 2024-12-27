namespace HVLH.Facturacion.Comun.Datos.Intercambio
{
	public class ConsultaConstanciaRequest : EnvioDocumentoComun
	{
		public string Serie { get; set; }

		public int Numero { get; set; }
	}
}
