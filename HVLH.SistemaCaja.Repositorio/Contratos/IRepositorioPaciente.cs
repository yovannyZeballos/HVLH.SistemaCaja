using HVLH.SistemaCaja.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Repositorio.Contratos
{
	public interface IRepositorioPaciente : IRepositorioGenerico<Paciente>
	{
		Task<string> ObtenerDireccion(string nroDocumento, string tipoDocumento);
		Task InsertarCliente(string nroDocumento, string tipoDocumento, string apellidoPaterno, string apellidoMaterno, string nombres, string razonSocial, string direccion);
	}
}
