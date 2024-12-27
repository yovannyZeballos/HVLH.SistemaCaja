using HVLH.SistemaCaja.Comun;
using System;
using System.Collections.Generic;

namespace HVLH.SistemaCaja.Servicio.DTO
{
	public class ObtenerComunicacionBajaDTO
	{
		public string Numero { get; set; }
		public int Correlativo { get; set; }
		public DateTime FechaBaja { get; set; }
		public DateTime FechaDocumentos { get; set; }
		public string Ticket { get; set; }
		public string Respuesta { get; set; }
		public EstadoResumen Estado { get; set; }
		public List<ObtenerComunicacionBajaDetalleDTO> Detalles { get; set; }
	}
}
