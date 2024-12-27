using System;

namespace HVLH.Facturacion.Estructuras.ComponentesAgregadoComunes
{
  [Serializable]
  public class PaymentMeans
  {
    public PayeeFinancialAccount PayeeFinancialAccount { get; set; }

    public PaymentMeans() => this.PayeeFinancialAccount = new PayeeFinancialAccount();
  }
}
