using HVLH.SistemaCaja.Comun;
using System;
using System.Collections.Generic;

namespace HVLH.SistemaCaja.Servicio.DTO
{
	public class GuardarResumenDTO
	{
		public int Id { get; set; }
		public string Numero { get; set; }
		public DateTime FechaResumen { get; set; }
		public DateTime FechaDocumentos { get; set; }
		public string Ticket { get; set; }
		public string Respuesta { get; set; }
		public string UsuarioCreacion { get; set; }
		public List<GuardarResumenDetalleDTO> Detalles { get; set; }

	}
}
