namespace HVLH.Facturacion.Comun.Datos.Modelos
{
    public class Conductor : Contribuyente
    {
        public string TipoConductor { get; set; }
        public string NumeroLicencia { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
    }
}