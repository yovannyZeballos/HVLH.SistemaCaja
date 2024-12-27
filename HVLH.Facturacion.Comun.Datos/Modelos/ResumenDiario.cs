using System.Collections.Generic;

namespace HVLH.Facturacion.Comun.Datos.Modelos
{
	public class ResumenDiario : DocumentoResumen
	{
		public List<GrupoResumen> Resumenes { get; set; }
	}
}
