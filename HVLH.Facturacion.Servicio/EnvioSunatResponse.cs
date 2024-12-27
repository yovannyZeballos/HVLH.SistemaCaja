namespace HVLH.Facturacion.Servicio
{
    public class EnvioSunatResponse : SunatResponseError
    {
        public string numTicket { get; set; }
        public string fecRecepcion { get; set; }
    }
}