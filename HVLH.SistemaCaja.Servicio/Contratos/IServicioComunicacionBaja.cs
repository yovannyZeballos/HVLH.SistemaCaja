using HVLH.SistemaCaja.Servicio.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Servicio.Contratos
{
	public interface IServicioComunicacionBaja
	{
		Task<List<ListarComunicacionBajaDTO>> ListarComunicaciones(DateTime fechaInicio, DateTime fechaFin);
		Task<ObtenerComunicacionBajaDTO> ObtenerComunicacion(int id);
		Task<(int, string)> GuardarComunicacion(GuardarComunicacionBajaDTO guardarComunicacionBajaDTO);
		Task<int> ObtenerCorrelativo(string numeroBaja);
	}
}
