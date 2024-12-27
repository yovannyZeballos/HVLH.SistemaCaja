using HVLH.Facturacion.Comun.Datos.Contratos;
using System;
using System.Collections.Generic;

namespace HVLH.Facturacion.Comun.Datos.Modelos
{
	public class DocumentoPercepcion : DocumentoSunatBase, IDocumentoElectronico
	{
		public string RegimenPercepcion { get; set; }

		public decimal TasaPercepcion { get; set; }

		public decimal ImporteTotalPercibido { get; set; }

		public decimal ImporteTotalCobrado { get; set; }

		public List<ItemPercepcion> DocumentosRelacionados { get; set; }
	}
}
