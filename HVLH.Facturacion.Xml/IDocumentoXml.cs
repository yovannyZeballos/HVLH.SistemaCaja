using HVLH.Facturacion.Comun;
using HVLH.Facturacion.Comun.Datos.Contratos;

namespace HVLH.Facturacion.Xml
{
	public interface IDocumentoXml
	{
		IEstructuraXml Generar(IDocumentoElectronico request);
	}
}
