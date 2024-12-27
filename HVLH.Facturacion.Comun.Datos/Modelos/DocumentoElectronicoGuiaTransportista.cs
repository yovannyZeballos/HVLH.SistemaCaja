using HVLH.Facturacion.Comun.Datos.Contratos;
using System;
using System.Collections.Generic;
namespace HVLH.Facturacion.Comun.Datos.Modelos
{
	public class DocumentoElectronicoGuiaTransportista : IDocumentoElectronico
	{
		public string IdDocumento { get; set; }
		public string TipoDocumento { get; set; }
		public DateTime FechaEmision { get; set; }
		public TimeSpan HoraEmision { get; set; }
		public string Observacion { get; set; }
		public Transportista Transportista { get; set; }
		public List<DocumentoRelacionado> DocumentosRelacionados { get; set; }
		public Remitente Remitente { get; set; }
		public Destinatario Destinatario { get; set; }
		public List<DetalleDocumentoGuia> Bienes { get; set; }
		public Direccion DireccionPuntoPartida { get; set; }
		public Direccion DireccionPuntoLlegada { get; set; }
		public Vehiculo VehiculoPrincipal { get; set; }
		public List<Vehiculo> VehiculosSecundarios { get; set; }
		public List<Conductor> Conductores { get; set; }
		public DatosEnvio DatosEnvio { get; set; }

		public DocumentoElectronicoGuiaTransportista()
		{
			Remitente = new Remitente();
			Destinatario = new Destinatario();
			DocumentosRelacionados = new List<DocumentoRelacionado>();
			DatosEnvio = new DatosEnvio();
			Transportista = new Transportista();
			VehiculoPrincipal = new Vehiculo();
			VehiculosSecundarios = new List<Vehiculo>();
			Conductores = new List<Conductor>();
			DireccionPuntoPartida = new Direccion();
			DireccionPuntoLlegada = new Direccion();
			Bienes = new List<DetalleDocumentoGuia>();
		}
	}
}
