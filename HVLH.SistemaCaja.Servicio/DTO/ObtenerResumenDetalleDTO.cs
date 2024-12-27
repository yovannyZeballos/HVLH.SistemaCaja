using HVLH.SistemaCaja.Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Servicio.DTO
{
	public class ObtenerResumenDetalleDTO
	{
		public int IdDocumento { get; set; }
		public string TipoDocumento { get; set; }
		public string Serie { get; set; }
		public long Numero { get; set; }
		public DateTime Fecha { get; set; }
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
		public decimal MontoTotal { get; set; }
		public EstadoDocumento Estado { get; set; }
		public EstadoResumenDetalle EstadoResumenDetalle { get; set; }
		public bool Enviado { get; set; }
		public string NroDocumentoReferencia { get; set; }
		public string TipoDocumentoReferencia { get; set; }
	}
}
