namespace HVLH.Facturacion.Comun.Datos.Intercambio
{
	public class FirmadoRequest
	{
		public string CertificadoDigital { get; set; }

		public string PasswordCertificado { get; set; }

		public string TramaXmlSinFirma { get; set; }

		public bool UnSoloNodoExtension { get; set; }

		public string RucEmisor { get; set; }
	}
}
