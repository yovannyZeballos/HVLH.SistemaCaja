using HVLH.SistemaCaja.Servicio.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Servicio.Contratos
{
	public interface IServicioImpresion
	{
		Task Factura(IImpresionDocumentoDTO documento);
		Task Boleta(IImpresionDocumentoDTO documento);
		Task NotaCredito(IImpresionDocumentoDTO documento);
		Task ReporteVenta(List<ObtenerDocumentoDTO> documentos, DateTime fechaInicio, DateTime fechafin, string cajero, string descMedioPago);
	}
}
