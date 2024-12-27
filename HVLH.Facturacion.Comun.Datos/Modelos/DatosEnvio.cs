using System;
using System.Collections.Generic;

namespace HVLH.Facturacion.Comun.Datos.Modelos
{
	public class DatosEnvio
	{
		public string IndetificadorTraslado { get; set; }
		public string MotivoTraslado { get; set; }
		public string DescripcionMotivoTraslado { get; set; }
		public Peso PesoBrutoTotalItemsSeleccionados { get; set; }
		public string SustentoDiferenciaPeso { get; set; }
		public Peso PesoBrutoTotalCarga { get; set; }
		public decimal NumeroBultos { get; set; }
		public string NumeroContenedor1 { get; set; }
		public string NumeroContenedor2 { get; set; }
		public string NumeroPrecinto1 { get; set; }
		public string NumeroPrecinto2 { get; set; }
		public string ModalidadTraslado { get; set; }
		public DateTime? FechaInicioTraslado { get; set; }
		public DateTime? FechaEntregaBienesTransportista { get; set; }
		public List<string> Indicadores { get; set; }
		public string TipoEvento { get; set; }
		public string AnotacionBienesTranpostar { get; set; }

		public DatosEnvio()
		{
			PesoBrutoTotalCarga = new Peso();
			PesoBrutoTotalItemsSeleccionados = new Peso();
			Indicadores = new List<string>();
		}
	}
}
