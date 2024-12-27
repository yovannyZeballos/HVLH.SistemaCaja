using HVLH.SistemaCaja.Comun;
using System;

namespace HVLH.SistemaCaja.Servicio.DTO
{
	public class ListarComunicacionBajaDTO
	{
		public int Id { get; set; }
		public string Numero { get; set; }
		public int Correlativo { get; set; }
		public DateTime FechaBaja { get; set; }
		public DateTime FechaDocumentos { get; set; }
		public string Ticket { get; set; }
		public EstadoResumen Estado { get; set; }
	}
}
