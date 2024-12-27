using HVLH.Facturacion.Estructuras.ComponentesBasicosComunes;
using System;

namespace HVLH.Facturacion.Estructuras.ComponentesAgregadoComunes
{
  [Serializable]
  public class Payment
  {
    public string PaidDate { get; set; }

    public int IdPayment { get; set; }

    public PayableAmount PaidAmount { get; set; }

    public Payment() => this.PaidAmount = new PayableAmount();
  }
}
