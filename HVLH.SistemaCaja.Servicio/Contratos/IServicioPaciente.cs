using HVLH.SistemaCaja.Servicio.DTO;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Servicio.Contratos
{
	public interface IServicioPaciente
	{
		Task<string> ObtenerDireccion(string nroDocumento, string tipoDocumento);
		Task<PacienteDTO> Obtener(string nroDocumento, string tipoDocumento);
		Task InsertarCliente(string nroDocumento, string tipoDocumento, string apellidoPaterno, string apellidoMaterno, string nombres, string razonSocial, string direccion);

	}
}
