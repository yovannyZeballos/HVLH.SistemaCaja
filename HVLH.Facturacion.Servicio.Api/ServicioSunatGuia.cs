using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace HVLH.Facturacion.Servicio.Api
{
	public class ServicioSunatGuia : IServicioSunatGuia
	{
		private static readonly HttpClient client;
		static ServicioSunatGuia()
		{
			client = new HttpClient();
		}

		public ConsultaSunatResponse ConsultaTciketSunat(ConsultaSunatRequest request)
		{
			var url = $"{request.Url}/{request.NumeroTicket}";

			var response = client.GetAsync(url).Result;
			var sunatResponseString = response.Content.ReadAsStringAsync().Result;

			var sunatResponse = JsonConvert.DeserializeObject<ConsultaSunatResponse>(sunatResponseString);
			sunatResponse.StatusCode = (int)response.StatusCode;
			return sunatResponse;
		}

		public EnvioSunatResponse EnvioSunat(EnvioSunatRequest request)
		{
			var url = $"{request.Url}/{request.Ruc}-{request.TipoDocumento}-{request.NumeroDocumento}";

			var data = new StringContent(JsonConvert.SerializeObject(new
			{
				archivo = new
				{
					nomArchivo = $"{request.Ruc}-{request.TipoDocumento}-{request.NumeroDocumento}.zip",
					arcGreZip = request.TramaZip,
					hashZip = request.HashZip
				}
			}));

			data.Headers.ContentType = new MediaTypeHeaderValue("application/json");

			var response = client.PostAsync(url, data).Result;
			var sunatResponseString = response.Content.ReadAsStringAsync().Result;

			var sunatResponse = JsonConvert.DeserializeObject<EnvioSunatResponse>(sunatResponseString);
			sunatResponse.StatusCode = (int)response.StatusCode;

			return sunatResponse;

		}

		public SunatTokenResponse GenerarToken(SunatTokenRequest request, bool obtenerToken, string token = "")
		{
			var sunatResponse = new SunatTokenResponse();
			try
			{
				if (obtenerToken)
				{
					var requestContent = new FormUrlEncodedContent(new[]
					{
						new KeyValuePair<string, string>("grant_type", "password"),
						new KeyValuePair<string, string>("scope", "https://api-cpe.sunat.gob.pe"),
						new KeyValuePair<string, string>("client_id", request.ClientId),
						new KeyValuePair<string, string>("client_secret", request.ClientSecret),
						new KeyValuePair<string, string>("username", $"{request.Ruc}{request.UsuarioSol}"),
						new KeyValuePair<string, string>("password", request.ClaveSol),
					});

					var response = client.PostAsync(string.Format(request.URLSunat, request.ClientId), requestContent).Result;
					var sunatResponseString = response.Content.ReadAsStringAsync().Result;
					sunatResponse = JsonConvert.DeserializeObject<SunatTokenResponse>(sunatResponseString);

					if (response.StatusCode == System.Net.HttpStatusCode.OK)
					{
						sunatResponse.Ok = true;
						client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sunatResponse.access_token);
					}
					else
					{
						sunatResponse.Ok = false;
					}
				}
				else
				{
					client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
					sunatResponse.Ok = true;
				}

			}
			catch (Exception ex)
			{
				sunatResponse.Ok = false;
				sunatResponse.error_description = ex.Message;

				if (ex.InnerException != null)
				{
					sunatResponse.error_description += " " + ex.InnerException.Message;
				}
			}
			return sunatResponse;
		}
	}
}
