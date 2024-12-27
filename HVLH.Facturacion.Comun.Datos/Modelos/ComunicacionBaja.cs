using System.Collections.Generic;

namespace HVLH.Facturacion.Comun.Datos.Modelos
{
	public class ComunicacionBaja : DocumentoResumen
	{
		public List<DocumentoBaja> Bajas { get; set; }
	}
}
