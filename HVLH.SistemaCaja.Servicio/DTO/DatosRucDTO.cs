using System.Text.Json.Serialization;

namespace HVLH.SistemaCaja.Servicio.DTO
{
	public class DatosRucDTO
	{
		[JsonPropertyName("coError")]
		public string CoError { get; set; }
		[JsonPropertyName("nuRuc")]
		public string NuRuc { get; set; }
		[JsonPropertyName("noEmpresa")]
		public string NoEmpresa { get; set; }
		[JsonPropertyName("nombreComercial")]
		public string NombreComercial { get; set; }
		[JsonPropertyName("deDireccion")]
		public string DeDireccion { get; set; }
		[JsonPropertyName("esActivo")]
		public string EsActivo { get; set; }
		[JsonPropertyName("tiIdenti")]
		public string TiIdenti { get; set; }
		[JsonPropertyName("coContribuyente")]
		public string CoContribuyente { get; set; }
		[JsonPropertyName("domicilioLegal")]
		public string DomicilioLegal { get; set; }
		[JsonPropertyName("coUbigeo")]
		public string CoUbigeo { get; set; }
		[JsonPropertyName("deDepartamento")]
		public string DeDepartamento { get; set; }
		[JsonPropertyName("deProvincia")]
		public string DeProvincia { get; set; }
		[JsonPropertyName("deDistrito")]
		public string DeDistrito { get; set; }
		[JsonPropertyName("tiContribuyente")]
		public string TiContribuyente { get; set; }
		[JsonPropertyName("feInscripcion")]
		public string FeInscripcion { get; set; }
		[JsonPropertyName("ddp_ciiu")]
		public string Ddp_ciiu { get; set; }
		[JsonPropertyName("desc_ciiu")]
		public string Desc_ciiu { get; set; }
		[JsonPropertyName("ddp_tpoemp")]
		public string Ddp_tpoemp { get; set; }
		[JsonPropertyName("desc_tpoemp")]
		public string Desc_tpoemp { get; set; }
	}
}
