using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HVLH.SistemaCaja.Modelo
{
	[Table("T_PACIENTES")]
	public class Paciente
	{
		[Key]
		[Column("IDPACIENTE")]
		public int IdPaciente { get; set; }

		[Column("NRO_DOCIDENTIDADPAC")]
		public string NroDocumento { get; set; }

		[Column("RUCCLI")]
		public string Ruc { get; set; }

		[Column("DIRECCIONPAC")]
		public string Direccion { get; set; }

		[Column("PRIMERNOMBREPAC")]
		public string Nombres { get; set; }

		[Column("APELLIDO_PATERNOPAC")]
		public string ApellidoPaterno { get; set; }

		[Column("APELLIDO_MATERNOPAC")]
		public string ApellidoMaterno { get; set; }
	}
}
