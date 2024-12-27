
using System.Collections.Generic;
using System;

namespace HVLH.SistemaCaja.Servicio.DTO
{
	public class ImpresionNotaDTO : IImpresionDocumentoDTO
	{
		public string RucEmpresa { get; set; }
		public string RazonSocialEmpresa { get; set; }
		public string DirecciónEmpresa { get; set; }
		public string Distrito { get; set; }
		public string Provincia { get; set; }
		public int IdTipoDocumento { get; set; }
		public string Serie { get; set; }
		public long Numero { get; set; }
		public DateTime Fecha { get; set; }
		public DateTime FechaVencimiento { get; set; }
		public string TipoDocumentoCliente { get; set; }
		public string NumeroDocumentoCliente { get; set; }
		public string RazonSocialCliente { get; set; }
		public string DireccionCliente { get; set; }
		public string Moneda { get; set; }
		public decimal Igv { get; set; }
		public decimal Gravadas { get; set; }
		public decimal Exportacion { get; set; }
		public decimal Inafecto { get; set; }
		public decimal Exonerado { get; set; }
		public decimal Gratuito { get; set; }
		public decimal MontoTotal { get; set; }
		public string FormaPago { get; set; }
		public string HoraParqueo { get; set; }
		public string Usuario { get; set; }
		public string ResumenFirma { get; set; }
		public string DescMedioPago { get; set; }
		public decimal ImportePago { get; set; }
		public decimal Vuelto { get; set; }
		public string DocumentoModifica { get; set; }
		public string TipoDocumentoModifica { get; set; }
		public string Motivo { get; set; }
		public DateTime FechaDocumentoModifica { get; set; }
		public List<DetalleImpresionDTO> Detalles { get; set; }
		public List<CuotaDTO> Cuotas { get; set; }

	}
}
