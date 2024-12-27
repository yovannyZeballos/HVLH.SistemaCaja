namespace HVLH.Facturacion.Servicio
{
    public class ConsultaSunatResponse : SunatResponseError
    {
        public string codRespuesta { get; set; }
        public string arcCdr { get; set; }
        public string indCdrGenerado { get; set; }
        public ConsultaSunatResponseDetalle error { get; set; }
    }
}