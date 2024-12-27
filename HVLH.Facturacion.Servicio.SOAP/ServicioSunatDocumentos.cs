using HVLH.Facturacion.Servicio.Soap.Documentos;
using HVLH.Facturacion.Comun;
using System;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace HVLH.Facturacion.Servicio.Soap
{
	public class ServicioSunatDocumentos : IServicioSunatDocumentos, IServicioSunat
	{
		private billServiceClient _proxyDocumentos;

		void IServicioSunat.Inicializar(ParametrosConexion parametros)
		{
			ServicePointManager.UseNagleAlgorithm = true;
			ServicePointManager.Expect100Continue = false;
			ServicePointManager.CheckCertificateRevocationList = true;
			this._proxyDocumentos = new billServiceClient("ServicioSunat", parametros.EndPointUrl);
			this._proxyDocumentos.Endpoint.Behaviors.Add((IEndpointBehavior)new PasswordDigestBehavior(parametros.Ruc + parametros.UserName, parametros.Password));
		}

		RespuestaSincrono IServicioSunatDocumentos.EnviarDocumento(
		  DocumentoSunat request)
		{
			byte[] contentFile = Convert.FromBase64String(request.TramaXml);
			RespuestaSincrono respuestaSincrono = new RespuestaSincrono();
			try
			{
				this._proxyDocumentos.Open();
				byte[] inArray = this._proxyDocumentos.sendBill(request.NombreArchivo, contentFile, "");
				this._proxyDocumentos.Close();
				respuestaSincrono.ConstanciaDeRecepcion = Convert.ToBase64String(inArray);
				respuestaSincrono.Exito = true;
			}
			catch (FaultException ex)
			{
				string str = ErroresSunat.MensajeError(ex.Code.Name.Replace("Client.", ""));
				if (string.IsNullOrWhiteSpace(str))
				{
					respuestaSincrono.MensajeError = ex.Code.Name + ex.Message;
				}
				else
				{
					respuestaSincrono.MensajeError = str;
					respuestaSincrono.ConstanciaDeRecepcion = ex.Code.Name.Replace("Client.", "");
				}
			}
			catch (Exception ex)
			{
				string str1 = ex.InnerException?.Message + ex.Message;
				if (str1.Contains("<faultcode>"))
				{
					int num = str1.IndexOf("<faultcode>", StringComparison.Ordinal);
					string CodigoError = str1.Substring(num + "<faultcode>".Length, 4);
					string str2 = CodigoError;
					string str3 = ErroresSunat.MensajeError(CodigoError);
					respuestaSincrono.MensajeError = !string.IsNullOrWhiteSpace(str3) ? str3 : str2;
				}
				else
					respuestaSincrono.MensajeError = ex.Message;
			}
			return respuestaSincrono;
		}

		RespuestaAsincrono IServicioSunatDocumentos.EnviarResumen(
		  DocumentoSunat request)
		{
			byte[] contentFile = Convert.FromBase64String(request.TramaXml);
			RespuestaAsincrono respuestaAsincrono = new RespuestaAsincrono();
			try
			{
				this._proxyDocumentos.Open();
				string str = this._proxyDocumentos.sendSummary(request.NombreArchivo, contentFile, "");
				this._proxyDocumentos.Close();
				respuestaAsincrono.NumeroTicket = str;
				respuestaAsincrono.Exito = true;
			}
			catch (FaultException ex)
			{
				string str = ErroresSunat.MensajeError(ex.Message);
				respuestaAsincrono.MensajeError = !string.IsNullOrWhiteSpace(str) ? str : ex.Code.Name + ex.Message;
			}
			catch (Exception ex)
			{
				string str1 = ex.InnerException?.Message + ex.Message;
				if (str1.Contains("<faultcode>"))
				{
					int num = str1.IndexOf("<faultcode>", StringComparison.Ordinal);
					string CodigoError = str1.Substring(num + "<faultcode>".Length, 4);
					string str2 = CodigoError;
					string str3 = ErroresSunat.MensajeError(CodigoError);
					respuestaAsincrono.MensajeError = !string.IsNullOrWhiteSpace(str3) ? str3 : str2;
				}
			}
			return respuestaAsincrono;
		}

		RespuestaSincrono IServicioSunatDocumentos.ConsultarTicket(
		  string numeroTicket)
		{
			RespuestaSincrono respuestaSincrono = new RespuestaSincrono();
			try
			{
				this._proxyDocumentos.Open();
				statusResponse status = this._proxyDocumentos.getStatus(numeroTicket);
				this._proxyDocumentos.Close();
				if (status.statusCode == "0")
				{
					respuestaSincrono.ConstanciaDeRecepcion = Convert.ToBase64String(status.content);
					respuestaSincrono.Exito = true;
				}
				else if (status.statusCode == "99")
				{
					respuestaSincrono.ConstanciaDeRecepcion = Convert.ToBase64String(status.content);
					respuestaSincrono.Exito = true;
				}
				else if (status.statusCode == "98")
				{
					respuestaSincrono.ConstanciaDeRecepcion = "";
					respuestaSincrono.MensajeError = "En Proceso";
					respuestaSincrono.Exito = true;
				}
				else
				{
					respuestaSincrono.ConstanciaDeRecepcion = "";
					respuestaSincrono.MensajeError = ErroresSunat.MensajeError(status.statusCode);
					respuestaSincrono.Exito = false;
				}
			}
			catch (FaultException ex)
			{
				string str = ErroresSunat.MensajeError(ex.Code.Name);
				respuestaSincrono.MensajeError = !string.IsNullOrWhiteSpace(str) ? str : ex.Code.Name + ex.Message;
			}
			catch (Exception ex)
			{
				string str1 = ex.InnerException?.Message + ex.Message;
				if (str1.Contains("<faultcode>"))
				{
					int num = str1.IndexOf("<faultcode>", StringComparison.Ordinal);
					string CodigoError = str1.Substring(num + "<faultcode>".Length, 4);
					string str2 = CodigoError;
					string str3 = ErroresSunat.MensajeError(CodigoError);
					respuestaSincrono.MensajeError = !string.IsNullOrWhiteSpace(str3) ? str3 : str2;
				}
			}
			return respuestaSincrono;
		}
	}
}
