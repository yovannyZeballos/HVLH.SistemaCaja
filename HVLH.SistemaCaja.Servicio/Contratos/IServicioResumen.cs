using HVLH.SistemaCaja.Servicio.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Servicio.Contratos
{
	public interface IServicioResumen
	{
		Task<List<ListarResumenDTO>> LustarResumenes(DateTime fechaInicio, DateTime fechaFin);
		Task<ObtenerResumenDTO> ObtenerResumen(int id);
		Task<(int, string)> GuardarResumen(GuardarResumenDTO guardarResumenDTO);
		Task<int> ObtenerCorrelativo(string numeroResumen);
	}
}
