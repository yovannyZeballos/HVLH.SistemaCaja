using HVLH.SistemaCaja.Servicio.Contratos;
using HVLH.SistemaCaja.Servicio.DTO;
using HVLH.SistemaCaja.Servicio.SWReniec;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Servicio.Impl
{
	public class ServicioReniec : IServicioReniec
	{
		private readonly serviciomqSoapClient serviciomqSoapClient;
		private readonly Credencialmq credencialmq;
		public ServicioReniec()
		{
			serviciomqSoapClient = new serviciomqSoapClient();

			credencialmq = new Credencialmq
			{
				app = ConfigurationManager.AppSettings.Get("CredencialesReniecApp"),
				usuario = ConfigurationManager.AppSettings.Get("CredencialesReniecUsuario"),
				clave = ConfigurationManager.AppSettings.Get("CredencialesReniecClave")
			};
		}

		public async Task<DatosDniDTO> Obtener(string dni)
		{
			var respuesta = await serviciomqSoapClient.obtenerDatosBasicosAsync(credencialmq, dni);
			var datosBasicosObtenidos = respuesta.obtenerDatosBasicosResult;

			if (datosBasicosObtenidos.Length == 0 || datosBasicosObtenidos[0] != "0000") return null;

			var datosReniec = new DatosDniDTO
			{
				Nombres = datosBasicosObtenidos[5],
				ApellidoPaterno = datosBasicosObtenidos[2],
				ApellidoMaterno = datosBasicosObtenidos[3],
				Direccion = $"{datosBasicosObtenidos[18]} {datosBasicosObtenidos[14]}-{datosBasicosObtenidos[15]}-{datosBasicosObtenidos[16]}"
			};

			return datosReniec;
		}
	}
}
