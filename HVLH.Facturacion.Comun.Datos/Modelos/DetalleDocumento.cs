using System.Collections.Generic;

namespace HVLH.Facturacion.Comun.Datos.Modelos
{
	public class DetalleDocumento
	{
		public int Id { get; set; }

		public decimal Cantidad { get; set; }

		public string UnidadMedida { get; set; }

		public string CodigoItem { get; set; }

		public string Descripcion { get; set; }

		public decimal ValorUnitario { get; set; }

		public decimal PrecioVentaUnitario { get; set; }

		public string TipoPrecio { get; set; }

		public string TipoImpuesto { get; set; }

		public decimal Impuesto { get; set; }

		public DescuentoCargo Descuento { get; set; }

		public decimal ValorVenta { get; set; }

		public string CodigoInternacional { get; set; }

		public List<InformacionAdicional> InformacionAdicional { get; set; }
        public decimal CalculoIgv { get; set; }

        public DetalleDocumento()
		{
			Id = 1;
			UnidadMedida = "NIU";
			TipoPrecio = "01";
			TipoImpuesto = "10";
			Descuento = new DescuentoCargo();
			InformacionAdicional = new List<InformacionAdicional>();
		}
	}
}
