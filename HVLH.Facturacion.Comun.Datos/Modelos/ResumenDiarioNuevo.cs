using System.Collections.Generic;

namespace HVLH.Facturacion.Comun.Datos.Modelos
{
	public class ResumenDiarioNuevo : DocumentoResumen
	{
		public List<GrupoResumenNuevo> Resumenes { get; set; }
	}
}
