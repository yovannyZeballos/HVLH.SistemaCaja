using HVLH.Facturacion.Comun.Datos.Intercambio;
using HVLH.Facturacion.Comun.Datos.Modelos;
using HVLH.SistemaCaja.Servicio.DTO;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Servicio.Contratos
{
	public interface IServicioXml
	{
		FirmadoResponse Factura(GenerarXmlDTO generarXmlDTO);
		FirmadoResponse NotaCredito(GenerarXmlDTO generarXmlDTO);
		FirmadoResponse ResumenDiario(GenerarXmlDTO generarXmlDTO);
		FirmadoResponse ComunicacionBaja(GenerarXmlDTO generarXmlDTO);
	}
}
