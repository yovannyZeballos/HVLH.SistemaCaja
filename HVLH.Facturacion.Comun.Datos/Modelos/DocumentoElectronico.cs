using HVLH.Facturacion.Comun.Datos.Contratos;
using System.Collections.Generic;

namespace HVLH.Facturacion.Comun.Datos.Modelos
{
	public class DocumentoElectronico : IDocumentoElectronico
	{
		public string IdDocumento { get; set; }

		public string TipoDocumento { get; set; }

		public Contribuyente Emisor { get; set; }

		public Contribuyente Receptor { get; set; }

		public string FechaEmision { get; set; }

		public string HoraEmision { get; set; }

		public string FechaVencimiento { get; set; }

		public string Moneda { get; set; }

		public string TipoOperacion { get; set; }

		public decimal Gravadas { get; set; }

		public decimal Gratuitas { get; set; }

		public decimal Inafectas { get; set; }

		public decimal Exoneradas { get; set; }

		public decimal Exportaciones { get; set; }

		public List<DetalleDocumento> Items { get; set; }

		public decimal TotalVenta { get; set; }

		public decimal TotalIgv { get; set; }

		public decimal TotalIsc { get; set; }

		public decimal TotalOtrosTributos { get; set; }

		public string MontoEnLetras { get; set; }

		public string PlacaVehiculo { get; set; }

		public decimal MontoPercepcion { get; set; }

		public decimal MontoDetraccion { get; set; }

		public List<DatoAdicional> DatoAdicionales { get; set; }

		public string TipoDocAnticipo { get; set; }

		public string DocAnticipo { get; set; }

		public string MonedaAnticipo { get; set; }

		public decimal MontoAnticipo { get; set; }

		public DatosGuia DatosGuiaTransportista { get; set; }

		public List<DocumentoRelacionado> Relacionados { get; set; }

		public List<Discrepancia> Discrepancias { get; set; }

		//public decimal CalculoIgv { get; set; }

		public decimal CalculoIsc { get; set; }

		public decimal CalculoDetraccion { get; set; }

		public List<DocumentoAnticipo> Anticipos { get; set; }

		public string OrdenCompra { get; set; }

		public List<DescuentoCargo> Descuentos { get; set; }

		public decimal TotalValorVenta { get; set; }

		public decimal TotalPrecioVenta { get; set; }

		public decimal TotalOtrosCargos { get; set; }

		public string CuentaBancoNacion { get; set; }

		public string CodigoDetraccion { get; set; }

		public decimal TotalDescuentos { get; set; }

		public string Observacion { get; set; }

		/// <summary>
		/// Lista de formas de pago
		/// </summary>
		public List<FormaPago> FormaPagos { get; set; }

		public DocumentoElectronico()
		{
			this.Emisor = new Contribuyente()
			{
				TipoDocumento = "6"
			};
			this.Receptor = new Contribuyente()
			{
				TipoDocumento = "6"
			};
			//this.CalculoIgv = 18.00M;
			this.CalculoIsc = 0.10M;
			this.CalculoDetraccion = 0.04M;
			this.Items = new List<DetalleDocumento>();
			this.DatoAdicionales = new List<DatoAdicional>();
			this.Relacionados = new List<DocumentoRelacionado>();
			this.Discrepancias = new List<Discrepancia>();
			this.Anticipos = new List<DocumentoAnticipo>();
			this.Descuentos = new List<DescuentoCargo>();
			this.TipoDocumento = "01";
			this.TipoOperacion = "01";
			this.Moneda = "PEN";
			FormaPagos = new List<FormaPago>();
		}
	}
}
