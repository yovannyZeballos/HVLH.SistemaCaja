using System;

namespace HVLH.SistemaCaja.Modelo
{
	public abstract class DatosAuditoria
	{
		public string UsuarioCreacion { get; set; }
		public string UsuarioModificacion { get; set; }
		public DateTime FechaCreacion { get; set; }
		public DateTime? FechaModificacion { get; set; }
	}
}
