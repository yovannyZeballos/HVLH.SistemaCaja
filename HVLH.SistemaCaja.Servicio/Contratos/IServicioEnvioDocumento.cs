using HVLH.Facturacion.Comun.Datos.Intercambio;
using HVLH.SistemaCaja.Servicio.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Servicio.Contratos
{
	public interface IServicioEnvioDocumento
	{
		Task<EnviarDocumentoResponse> Enviar(EnvioDocumentoDTO envioDocumentoDTO);
		Task<EnviarResumenResponse> EnviarResumen(EnvioResumenDocumentoDTO envioDocumentoDTO);
		Task<EnviarResumenResponse> EnviarComunicacion(EnvioComunicacionBajaDTO envioDocumentoDTO);
		Task<EnviarDocumentoResponse> ConsultarTicketResumen(ConsultarTicketDTO consultarTicket);
		Task<EnviarDocumentoResponse> ConsultarTicketComunicacionBaja(ConsultarTicketDTO consultarTicket);
	}
}
