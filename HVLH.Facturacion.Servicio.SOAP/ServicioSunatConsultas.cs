using HVLH.Facturacion.Servicio.Soap.Consultas;
using System;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace HVLH.Facturacion.Servicio.Soap
{
	public class ServicioSunatConsultas : IServicioSunatConsultas, IServicioSunat
	{
		private billServiceClient _proxyConsultas;

		void IServicioSunat.Inicializar(ParametrosConexion parametros)
		{
			ServicePointManager.UseNagleAlgorithm = true;
			ServicePointManager.Expect100Continue = false;
			ServicePointManager.CheckCertificateRevocationList = true;
			this._proxyConsultas = new billServiceClient("ConsultasSunat", parametros.EndPointUrl);
			this._proxyConsultas.Endpoint.Behaviors.Add((IEndpointBehavior)new PasswordDigestBehavior(parametros.Ruc + parametros.UserName, parametros.Password));
		}

		RespuestaSincrono IServicioSunatConsultas.ConsultarConstanciaDeRecepcion(
		  DatosDocumento request)
		{
			RespuestaSincrono respuestaSincrono = new RespuestaSincrono();
			try
			{
				this._proxyConsultas.Open();
				statusResponse statusCdr = this._proxyConsultas.getStatusCdr(request.RucEmisor, request.TipoComprobante, request.Serie, request.Numero);
				this._proxyConsultas.Close();
				bool flag = statusCdr.statusCode != "98" && statusCdr.content != null;
				respuestaSincrono.ConstanciaDeRecepcion = flag ? Convert.ToBase64String(statusCdr.content) : "Aun en proceso";
				respuestaSincrono.Exito = true;
			}
			catch (FaultException ex)
			{
				respuestaSincrono.MensajeError = ex.Code.Name + ex.Message;
			}
			catch (Exception ex)
			{
				string str = ex.InnerException != null ? ex.InnerException.Message + ex.Message : ex.Message;
				if (str.Contains("<faultcode>"))
				{
					int num = str.IndexOf("<faultcode>", StringComparison.Ordinal);
					str = "El Código de Error es " + str.Substring(num + "<faultcode>".Length, 4);
				}
				respuestaSincrono.MensajeError = str;
			}
			return respuestaSincrono;
		}
	}
}
