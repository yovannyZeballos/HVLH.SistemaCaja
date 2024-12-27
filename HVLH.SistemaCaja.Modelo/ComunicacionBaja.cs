using HVLH.SistemaCaja.Comun;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Modelo
{
	[Table("TBL_CajaComunicacionBaja")]
	public class ComunicacionBaja
	{
		public int Id { get; set; }
		public string Numero { get; set; }
		public int Correlativo { get; set; }
		public DateTime FechaBaja { get; set; }
		public DateTime FechaDocumentos { get; set; }
		public string Ticket { get; set; }
		public string Respuesta { get; set; }
		public string UsuarioCreacion { get; set; }
		public DateTime FechaCreacion { get; set; }
		public EstadoResumen Estado { get; set; }
		public ICollection<ComunicacionBajaDetalle> Detalles { get; set; } = new List<ComunicacionBajaDetalle>();
	}
}
