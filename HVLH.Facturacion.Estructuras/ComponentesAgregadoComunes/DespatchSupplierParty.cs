using HVLH.Facturacion.Estructuras.ComponentesBasicosComunes;

namespace HVLH.Facturacion.Estructuras.ComponentesAgregadoComunes
{
	public class DespatchSupplierParty
	{
		public CustomerAssignedAccountId CustomerAssignedAccountId { get; set; }
		public Party Party { get; set; }

		public DespatchSupplierParty()
		{
			CustomerAssignedAccountId = new CustomerAssignedAccountId();
			Party = new Party();
		}
	}
}
