namespace HVLH.Facturacion.Servicio
{
    public class SunatTokenRequest
    {
        public string URLSunat { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string UsuarioSol { get; set; }
        public string ClaveSol { get; set; }
        public string Ruc { get; set; }
    }
}