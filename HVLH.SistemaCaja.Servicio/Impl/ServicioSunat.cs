using HVLH.SistemaCaja.Servicio.Contratos;
using HVLH.SistemaCaja.Servicio.DTO;
using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Servicio.Impl
{
	public class ServicioSunat : IServicioSunat
	{
		private static readonly HttpClient _httpClient;

		static ServicioSunat()
		{
			_httpClient = new HttpClient();
		}
		public async Task<DatosRucDTO> ObtenerDatosRuc(string ruc)
		{
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, CrearUrlRequest("consultaruc", $"numRuc={ruc}"));

			string data = null;
			using (HttpResponseMessage response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead))
			{
				response.EnsureSuccessStatusCode();
				data = await response.Content.ReadAsStringAsync();
			}


			return JsonSerializer.Deserialize<DatosRucDTO>(data);
		}

		private Uri CrearUrlRequest(string relativePath, string queryString = "")
		{
			Uri uri = new Uri(new Uri(ConfigurationManager.AppSettings.Get("ApiConsultaRuc")), relativePath);
			UriBuilder uriBuilder = new UriBuilder(uri)
			{
				Query = queryString
			};
			return uriBuilder.Uri;
		}
	}
}
