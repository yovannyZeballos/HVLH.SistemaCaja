using HVLH.SistemaCaja.Modelo;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Repositorio.Contratos
{
	public interface IRepositorioCita : IRepositorioGenerico<CitasResult>
	{
		Task<List<CitasResult>> Listar(string idCita, string nroHistoria, DateTime fechaInicio, DateTime fechaFin, string nroDocumento);
		Task ActualizarCita(string idCita, string estado, decimal montoPagado, string numeroDocumento, DateTime? fechaDocumento);
		Task ActualizarAtencion(string idCita, string estado, decimal montoPagado);
	}
}
