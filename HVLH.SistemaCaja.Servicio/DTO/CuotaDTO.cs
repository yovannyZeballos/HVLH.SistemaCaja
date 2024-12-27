using HVLH.SistemaCaja.Modelo;
using System;

namespace HVLH.SistemaCaja.Servicio.DTO
{
	public class CuotaDTO
	{
		public int Numero { get; set; }
		public decimal Monto { get; set; }
		public DateTime Fecha { get; set; }
		public Documento Documento { get; set; }
	}
}
