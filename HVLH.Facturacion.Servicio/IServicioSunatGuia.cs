namespace HVLH.Facturacion.Servicio
{
    public interface IServicioSunatGuia
    {
        SunatTokenResponse GenerarToken(SunatTokenRequest request, bool obtenerToken, string token = "");
        EnvioSunatResponse EnvioSunat(EnvioSunatRequest request);
        ConsultaSunatResponse ConsultaTciketSunat(ConsultaSunatRequest request);
    }
}
