using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HVLH.Facturacion.Comun.Datos.Modelos
{

	public partial class DetalleDocumentoGuia
	{
		public int NumeroOrden { get; set; }
		public decimal Cantidad { get; set; }
		public string UnidadMedida { get; set; }
		public string Descripcion { get; set; }
		public string CodigoBien { get; set; }
		public string CodigoSUNAT { get; set; }
		public string CodigoGTIN { get; set; }
		public string EstructuraCodigoGTIN { get; set; }
		public string PartidaArancelaria { get; set; }
		public string IndicadorBienNormalizado { get; set; }
		public string NumeracionDAM_DS { get; set; }
		public string NumeroSerieDAM_DS { get; set; }
	}
}
