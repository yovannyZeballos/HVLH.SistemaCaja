namespace HVLH.Facturacion.Comun.Datos.Modelos
{
	public class FormaPago
	{
		/// <summary>
		/// Id
		/// </summary>
		/// <example>Credito</example>
		public string Id { get; set; }

		/// <summary>
		/// Monto
		/// </summary>
		/// <example>1000.00</example>
		public decimal Monto { get; set; }

		/// <summary>
		/// Fecha Vencimiento
		/// </summary>
		/// <example>2021-01-01</example>
		public string FechaVencimiento { get; set; }
	}
}
