using HVLH.SistemaCaja.Servicio.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Servicio.Contratos
{
	public interface IServicioProducto
	{
		Task Guardar(GuardarProductoDTO productoDTO);
		Task<List<ListarProductoDTO>> Listar();
		Task<ObtenerProductoDTO> Obtener(int id);
		Task Eliminar(int id);
	}
}
