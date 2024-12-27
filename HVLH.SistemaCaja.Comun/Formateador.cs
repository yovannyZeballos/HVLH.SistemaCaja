using System.Globalization;

namespace HVLH.SistemaCaja.Comun
{
	public class Formateador
	{
		private static CultureInfo formato = CultureInfo.InvariantCulture;

		public static string Numero(decimal numero)
		{
			return numero.ToString("###,###0.00", formato);
		}

		public static string Numero(double numero)
		{
			return numero.ToString("###,###0.00", formato);
		}

		public static string Numero(int numero)
		{
			return numero.ToString("###,###0.00", formato);
		}
	}
}
