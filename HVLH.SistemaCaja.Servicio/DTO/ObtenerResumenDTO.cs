using HVLH.SistemaCaja.Comun;
using System;
using System.Collections.Generic;

namespace HVLH.SistemaCaja.Servicio.DTO
{
	public class ObtenerResumenDTO
	{
		public string Numero { get; set; }
		public int Correlativo { get; set; }
		public DateTime FechaResumen { get; set; }
		public DateTime FechaDocumentos { get; set; }
		public string Ticket { get; set; }
		public string Respuesta { get; set; }
		public EstadoResumen Estado { get; set; }
		public List<ObtenerResumenDetalleDTO> Detalles { get; set; }
	}
}
