using HVLH.SistemaCaja.Servicio.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Servicio.Contratos
{
	public interface IServicioCita
	{
		Task<List<ListarCitasDTO>> Listar(string idCita, string nroHistoria, DateTime fechaInicio, DateTime fechaFin, string nroDocumento);
	}
}
