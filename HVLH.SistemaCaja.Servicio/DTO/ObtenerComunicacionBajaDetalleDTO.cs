using System;

namespace HVLH.SistemaCaja.Servicio.DTO
{
	public class ObtenerComunicacionBajaDetalleDTO
	{
		public int IdDocumento { get; set; }
		public string TipoDocumento { get; set; }
		public string Serie { get; set; }
		public long Numero { get; set; }
		public DateTime Fecha { get; set; }
		public string NumeroDocumentoCliente { get; set; }
		public string RazonSocialCliente { get; set; }
		public string Moneda { get; set; }
		public decimal MontoTotal { get; set; }
		public string Motivo { get; set; }
	}
}
