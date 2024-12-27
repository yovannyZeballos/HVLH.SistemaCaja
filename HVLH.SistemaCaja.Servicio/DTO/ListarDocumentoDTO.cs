using HVLH.SistemaCaja.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Servicio.DTO
{
	public class ListarDocumentoDTO
	{
		public int Id { get; set; }
		public string TipoDocumento { get; set; }
		public string Serie { get; set; }
		public long Numero { get; set; }
		public DateTime Fecha { get; set; }
		public string TipoOperacion { get; set; }
		public string TipoDocumentoCliente { get; set; }
		public string NumeroDocumentoCliente { get; set; }
		public string RazonSocialCliente { get; set; }
		public string Moneda { get; set; }
		public decimal Igv { get; set; }
		public decimal Gravadas { get; set; }
		public decimal Exportacion { get; set; }
		public decimal Inafecto { get; set; }
		public decimal Exonerado { get; set; }
		public decimal Gratuito { get; set; }
		public decimal TotalPrecioVenta { get; set; }
		public decimal TotalValorVenta { get; set; }
		public decimal MontoTotal { get; set; }
		public string FormaPago { get; set; }
		public string Estado { get; set; }
		public string NroPreventa { get; set; }
	}
}
