namespace HVLH.Facturacion.Comun.Datos.Intercambio
{
	public class ConsultaTicketRequest : EnvioDocumentoComun
	{
		public string NroTicket { get; set; }

		public string Ruta { get; set; }
	}
}
