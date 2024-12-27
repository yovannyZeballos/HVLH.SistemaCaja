using System;

namespace HVLH.SistemaCaja.Modelo
{
	public class PreventaResult
	{
        public string PreventaDetId { get; set; }
        public string PreventaCabNum { get; set; }
        public DateTime FechaEmision { get; set; }
        public string PuntoCarga { get; set; }
        public int IdPaciente { get; set; }
        public string NroHistoriaClinica { get; set; }
        public string NroDocCliente { get; set; }
        public string TipoDocCliente { get; set; }
        public string NombresPaciente { get; set; }
        public int IdProducto { get; set; }
        public string CodProducto { get; set; }
        public string CodSiga { get; set; }
        public string UnidadMedida { get; set; }
        public string DescripcionProducto { get; set; }
        public int Cantidad { get; set; }
        public double PrecioUnitario { get; set; }
        public double PrecioTotal { get; set; }
        public decimal MontoTotal { get; set; }
        public int IdEstado { get; set; }
        public string Estado { get; set; }
        public decimal Igv { get; set; }
        public decimal IgvTotal { get; set; }
		public decimal PorcentajeIgv { get; set; }
        public string TipoIgv { get; set; }

    }
}
