namespace HVLH.Facturacion.Servicio
{
    public class EnvioSunatRequest
    {
        public string Url { get; set; }
        public string Ruc { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string TramaZip { get; set; }
        public string HashZip { get; set; }
    }
}