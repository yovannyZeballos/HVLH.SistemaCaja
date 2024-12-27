using System;

namespace HVLH.Facturacion.Comun
{
	public class Conversion
	{
		public static string Enletras(decimal num)
		{
			long int64 = Convert.ToInt64(Math.Truncate(num));
			int int32 = Convert.ToInt32(Math.Round((num - (decimal)int64) * 100M, 2));
			string str = int32 > 0 ? string.Format(" CON {0}/100", (object)int32) : " CON 00/100";
			return Conversion.ToText((decimal)int64) + str;
		}

		private static string ToText(decimal value)
		{
			value = Math.Truncate(value);
			string str;
			if (value == 0M)
				str = "CERO";
			else if (value == 1M)
				str = "UNO";
			else if (value == 2M)
				str = "DOS";
			else if (value == 3M)
				str = "TRES";
			else if (value == 4M)
				str = "CUATRO";
			else if (value == 5M)
				str = "CINCO";
			else if (value == 6M)
				str = "SEIS";
			else if (value == 7M)
				str = "SIETE";
			else if (value == 8M)
				str = "OCHO";
			else if (value == 9M)
				str = "NUEVE";
			else if (value == 10M)
				str = "DIEZ";
			else if (value == 11M)
				str = "ONCE";
			else if (value == 12M)
				str = "DOCE";
			else if (value == 13M)
				str = "TRECE";
			else if (value == 14M)
				str = "CATORCE";
			else if (value == 15M)
				str = "QUINCE";
			else if (value < 20M)
				str = "DIECI" + Conversion.ToText(value - 10M);
			else if (value == 20M)
				str = "VEINTE";
			else if (value < 30M)
				str = "VEINTI" + Conversion.ToText(value - 20M);
			else if (value == 30M)
				str = "TREINTA";
			else if (value == 40M)
				str = "CUARENTA";
			else if (value == 50M)
				str = "CINCUENTA";
			else if (value == 60M)
				str = "SESENTA";
			else if (value == 70M)
				str = "SETENTA";
			else if (value == 80M)
				str = "OCHENTA";
			else if (value == 90M)
				str = "NOVENTA";
			else if (value < 100M)
				str = Conversion.ToText(Math.Truncate(value / 10M) * 10M) + " Y " + Conversion.ToText(value % 10M);
			else if (value == 100M)
				str = "CIEN";
			else if (value < 200M)
				str = "CIENTO " + Conversion.ToText(value - 100M);
			else if (value == 200M || value == 300M || (value == 400M || value == 600M) || value == 800M)
				str = Conversion.ToText(Math.Truncate(value / 100M)) + "CIENTOS";
			else if (value == 500M)
				str = "QUINIENTOS";
			else if (value == 700M)
				str = "SETECIENTOS";
			else if (value == 900M)
				str = "NOVECIENTOS";
			else if (value < 1000M)
				str = Conversion.ToText(Math.Truncate(value / 100M) * 100M) + " " + Conversion.ToText(value % 100M);
			else if (value == 1000M)
				str = "MIL";
			else if (value < 2000M)
				str = "MIL " + Conversion.ToText(value % 1000M);
			else if (value < 1000000M)
			{
				str = Conversion.ToText(Math.Truncate(value / 1000M)) + " MIL";
				if (value % 1000M > 0M)
					str = str + " " + Conversion.ToText(value % 1000M);
			}
			else if (value == 1000000M)
				str = "UN MILLON";
			else if (value < 2000000M)
				str = "UN MILLON " + Conversion.ToText(value % 1000000M);
			else if (value < 1000000000000M)
			{
				str = Conversion.ToText(Math.Truncate(value / 1000000M)) + " MILLONES ";
				if (value - Math.Truncate(value / 1000000M) * 1000000M > 0M)
					str = str + " " + Conversion.ToText(value - Math.Truncate(value / 1000000M) * 1000000M);
			}
			else if (value == 1000000000000M)
				str = "UN BILLON";
			else if (value < 2000000000000M)
			{
				str = "UN BILLON " + Conversion.ToText(value - Math.Truncate(value / 1000000000000M) * 1000000000000M);
			}
			else
			{
				str = Conversion.ToText(Math.Truncate(value / 1000000000000M)) + " BILLONES";
				if (value - Math.Truncate(value / 1000000000000M) * 1000000000000M > 0M)
					str = str + " " + Conversion.ToText(value - Math.Truncate(value / 1000000000000M) * 1000000000000M);
			}
			return str;
		}
	}
}
