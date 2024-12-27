using HVLH.SistemaCaja.Comun;
using System;

namespace HVLH.SistemaCaja.Servicio.DTO
{
	public class ListarResumenDTO
	{
		public int Id { get; set; }
		public string Numero { get; set; }
		public int Correlativo { get; set; }
		public DateTime FechaResumen { get; set; }
		public DateTime FechaDocumentos { get; set; }
		public string Ticket { get; set; }
		public EstadoResumen Estado { get; set; }
	}
}
