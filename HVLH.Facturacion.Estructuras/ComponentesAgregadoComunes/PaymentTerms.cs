using System;

namespace HVLH.Facturacion.Estructuras.ComponentesAgregadoComunes
{
    [Serializable]
    public class PaymentTerms
    {
        public string Id { get; set; }

        public decimal PaymentPercent { get; set; }

        public decimal Amount { get; set; }
        public string PaymentMeansID { get; set; }
        public DateTime? PaymentDueDate { get; set; }
    }
}
