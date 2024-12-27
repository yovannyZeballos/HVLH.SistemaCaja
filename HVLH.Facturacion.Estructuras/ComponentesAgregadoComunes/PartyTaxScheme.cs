namespace HVLH.Facturacion.Estructuras.ComponentesAgregadoComunes
{
	public class PartyTaxScheme
	{
		public string RegistrationName { get; set; }

		public CompanyID CompanyID { get; set; }

		public RegistrationAddress RegistrationAddress { get; set; }

		public PartyTaxScheme()
		{
			this.CompanyID = new CompanyID();
			this.RegistrationAddress = new RegistrationAddress();
		}
	}
}
