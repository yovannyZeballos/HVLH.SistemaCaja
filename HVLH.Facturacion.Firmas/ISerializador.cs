using HVLH.Facturacion.Comun;
using HVLH.Facturacion.Comun.Datos.Intercambio;

namespace HVLH.Facturacion.Firmas
{
	public interface ISerializador
	{
		string GenerarZip(string tramaXml, string nombreArchivo);

		EnviarDocumentoResponse GenerarDocumentoRespuesta(
		  string constanciaRecepcion);

		string GenerarXml<T>(T objectToSerialize) where T : IEstructuraXml;

		string GenerarHashZip(string tramaZip);
	}
}
