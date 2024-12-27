using HVLH.SistemaCaja.Comun;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Modelo
{
	[Table("TBL_CajaResumen")]
	public class Resumen
	{
		public int Id { get; set; }
		public string Numero { get; set; }
		public int Correlativo { get; set; }
		public DateTime FechaResumen { get; set; }
		public DateTime FechaDocumentos { get; set; }
		public string Ticket { get; set; }
		public string Respuesta { get; set; }
		public string UsuarioCreacion { get; set; }
		public DateTime FechaCreacion { get; set; }
		public EstadoResumen Estado { get; set; }
		public ICollection<ResumenDetalle> Detalles { get; set; } = new List<ResumenDetalle>();
	}
}
