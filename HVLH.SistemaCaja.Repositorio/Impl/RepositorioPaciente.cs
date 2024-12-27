using HVLH.SistemaCaja.Comun;
using HVLH.SistemaCaja.Modelo;
using HVLH.SistemaCaja.Repositorio.Contextos;
using HVLH.SistemaCaja.Repositorio.Contratos;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Repositorio.Impl
{
	public class RepositorioPaciente : RepositorioGenerico<SiheContexto, Paciente>, IRepositorioPaciente
	{
		public RepositorioPaciente(SiheContexto siheContexto) : base(siheContexto)
		{
		}

		public SiheContexto SiheContexto
		{
			get { return _siheContexto; }
		}

		public async Task InsertarCliente(string nroDocumento, string tipoDocumento, string apellidoPaterno, string apellidoMaterno, string nombres, string razonSocial, string direccion)
		{
			await _siheContexto.Database.ExecuteSqlInterpolatedAsync($"EXEC usp_Caja_Insertar_Paciente {nroDocumento}, {tipoDocumento}, {direccion}, {nombres}, {apellidoPaterno}, {apellidoMaterno}, {razonSocial}");
		}

		public async Task<string> ObtenerDireccion(string nroDocumento, string tipoDocumento)
		{
			var direccion = "";
			if (tipoDocumento == "6")
			{
				direccion = await _siheContexto.Pacientes
					.Where(x => x.Ruc == nroDocumento)
					.Select(x => x.Direccion)
					.FirstOrDefaultAsync();

				if (string.IsNullOrEmpty(direccion))
					direccion = await _siheContexto.Pacientes
						.Where(x => x.NroDocumento == nroDocumento)
						.Select(x => x.Direccion)
						.FirstOrDefaultAsync();
			}
			else
			{
				direccion = await _siheContexto.Pacientes
				.Where(x => x.NroDocumento == nroDocumento)
				.Select(x => x.Direccion)
				.FirstOrDefaultAsync();
			}


			return direccion;
		}
	}
}
