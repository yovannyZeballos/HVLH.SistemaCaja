using HVLH.SistemaCaja.Servicio.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Servicio.Contratos
{
	public interface IServicioTipoMedioPago
	{
		Task<List<ListarTipoMedioPagoDTO>> Listar();
		Task<ListarTipoMedioPagoDTO> Obtener(int id);
		Task Insertar(ListarTipoMedioPagoDTO medioPago);
		Task Eliminar(int id);
	}
}
