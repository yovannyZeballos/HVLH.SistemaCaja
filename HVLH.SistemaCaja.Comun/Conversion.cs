using System;

namespace HVLH.SistemaCaja.Comun
{
	public class Conversion
	{
		public static decimal Decimal(string numero) => Convert.ToDecimal(numero.Replace(",", ""));
	}
}
