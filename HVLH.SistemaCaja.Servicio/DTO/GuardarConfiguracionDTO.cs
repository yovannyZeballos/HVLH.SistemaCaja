namespace HVLH.SistemaCaja.Servicio.DTO
{
	public class GuardarConfiguracionDTO
	{
		public int Id { get; set; }
		public string Ruc { get; set; }
		public string RazonSocial { get; set; }
		public string Direccion { get; set; }
		public string Distrito { get; set; }
		public string Provincia { get; set; }
		public string Departamento { get; set; }
		public string Ubigeo { get; set; }
		public string Telefono { get; set; }
		public string RutaCertificado { get; set; }
		public string ClaveCertificado { get; set; }
		public string UsuarioSol { get; set; }
		public string ClaveSol { get; set; }
		public string Correo { get; set; }
		public string ClaveCorreo { get; set; }
		public string Smtp { get; set; }
		public int? Puerto { get; set; }
		public decimal IGV { get; set; }
		public string TipoOperacion { get; set; }
		public string CarpetaDocumentos { get; set; }
		public string UrlEnvio { get; set; }
		public string UrlConsulta { get; set; }
		public string Usuario { get; set; }
	}
}
