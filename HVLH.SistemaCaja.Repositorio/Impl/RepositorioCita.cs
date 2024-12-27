using HVLH.SistemaCaja.Modelo;
using HVLH.SistemaCaja.Repositorio.Contextos;
using HVLH.SistemaCaja.Repositorio.Contratos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Repositorio.Impl
{
	public class RepositorioCita : RepositorioGenerico<SiheContexto, CitasResult>, IRepositorioCita
	{
		public RepositorioCita(SiheContexto siheContexto) : base(siheContexto)
		{
		}

		public SiheContexto SiheContexto
		{
			get { return _siheContexto; }
		}

		//TODO: Cambiar la temporal
		public async Task ActualizarAtencion(string idCita, string estado, decimal montoPagado)
		{
			await _siheContexto.Database.ExecuteSqlInterpolatedAsync($"UPDATE T_ATENCIONES SET ATE_ESTADOPAGO={estado},ATE_MONTO_PAGAGO={montoPagado} WHERE ATE_IDCITA={idCita}");
		}

		public async Task ActualizarCita(string idCita , string estado, decimal montoPagado, string numeroDocumento, DateTime? fechaDocumento)
		{
			await _siheContexto.Database.ExecuteSqlInterpolatedAsync($"UPDATE T_CITAS SET ESTADOPAGO={estado},MONTO_PAGAGO={montoPagado},NUM_OPERACION ={numeroDocumento},FECHA_DEPOSITO={fechaDocumento} where  IDCITA={idCita}");

		}

		public async Task<List<CitasResult>> Listar(string idCita, string nroHistoria, DateTime fechaInicio, DateTime fechaFin, string nroDocumento)
		{
			return await _siheContexto.Citas.FromSqlInterpolated($"EXEC usp_Caja_Consultar_Citas {idCita},{nroHistoria},{fechaInicio},{fechaFin},{nroDocumento}").ToListAsync();
		}
	}
}
