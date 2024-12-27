using HVLH.Facturacion.Comun.Datos.Intercambio;

namespace HVLH.Facturacion.Firmas
{
    public interface ICertificador
    {
        FirmadoResponse FirmarXml(FirmadoRequest request);

        FirmadoResponse ObetenerValorFirma(string rutaXml);

        CodigoBarrasResponse GenerarCodigoQr(CodigoBarrasRequest request);
    }
}
