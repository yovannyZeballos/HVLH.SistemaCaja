using HVLH.SistemaCaja.Comun;
using System;
using System.Collections.Generic;

namespace HVLH.SistemaCaja.Servicio.DTO
{
	public class GuardarComunicacionBajaDTO
	{
		public int Id { get; set; }
		public string Numero { get; set; }
		public DateTime FechaBaja { get; set; }
		public DateTime FechaDocumentos { get; set; }
		public string Ticket { get; set; }
		public string Respuesta { get; set; }
		public string UsuarioCreacion { get; set; }
		public List<GuardarComunicacionBajaDetalleDTO> Detalles { get; set; }

	}
}
