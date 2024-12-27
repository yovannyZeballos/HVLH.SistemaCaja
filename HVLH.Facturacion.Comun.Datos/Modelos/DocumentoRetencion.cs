using HVLH.Facturacion.Comun.Datos.Contratos;
using System;
using System.Collections.Generic;

namespace HVLH.Facturacion.Comun.Datos.Modelos
{
	public class DocumentoRetencion : DocumentoSunatBase, IDocumentoElectronico
	{
		public string RegimenRetencion { get; set; }

		public decimal TasaRetencion { get; set; }

		public decimal ImporteTotalRetenido { get; set; }

		public decimal ImporteTotalPagado { get; set; }

		public List<ItemRetencion> DocumentosRelacionados { get; set; }
	}
}
