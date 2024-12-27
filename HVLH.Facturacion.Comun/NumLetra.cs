using System;
using System.Text.RegularExpressions;

namespace HVLH.Facturacion.Comun
{
	public class NumLetra
	{
		private static string[] UNIDADES = new string[10]
		{
	  "",
	  "un ",
	  "dos ",
	  "tres ",
	  "cuatro ",
	  "cinco ",
	  "seis ",
	  "siete ",
	  "ocho ",
	  "nueve "
		};
		private static string[] DECENAS = new string[18]
		{
	  "diez ",
	  "once ",
	  "doce ",
	  "trece ",
	  "catorce ",
	  "quince ",
	  "dieciseis ",
	  "diecisiete ",
	  "dieciocho ",
	  "diecinueve",
	  "veinte ",
	  "treinta ",
	  "cuarenta ",
	  "cincuenta ",
	  "sesenta ",
	  "setenta ",
	  "ochenta ",
	  "noventa "
		};
		private static string[] CENTENAS = new string[10]
		{
	  "",
	  "ciento ",
	  "doscientos ",
	  "trecientos ",
	  "cuatrocientos ",
	  "quinientos ",
	  "seiscientos ",
	  "setecientos ",
	  "ochocientos ",
	  "novecientos "
		};
		private static Regex r;

		public static string Convertir(string numero, bool mayusculas)
		{
			string str1 = "";
			if (numero.IndexOf(".") == -1)
				numero += ".00";
			NumLetra.r = new Regex("\\d{1,9}.\\d{1,2}");
			if (NumLetra.r.Matches(numero).Count <= 0)
				return str1 = (string)null;
			string[] strArray = numero.Split('.');
			string str2 = strArray[1] + "/100 ";
			string str3 = int.Parse(strArray[0]) != 0 ? (int.Parse(strArray[0]) <= 999999 ? (int.Parse(strArray[0]) <= 999 ? (int.Parse(strArray[0]) <= 99 ? (int.Parse(strArray[0]) <= 9 ? NumLetra.getUnidades(strArray[0]) : NumLetra.getDecenas(strArray[0])) : NumLetra.getCentenas(strArray[0])) : NumLetra.getMiles(strArray[0])) : NumLetra.getMillones(strArray[0])) : "cero ";
			return mayusculas ? (str3 + " CON " + str2).ToUpper() : str3 + " CON " + str2;
		}

		private static string getUnidades(string numero)
		{
			string s = numero.Substring(numero.Length - 1);
			return NumLetra.UNIDADES[int.Parse(s)];
		}

		private static string getDecenas(string num)
		{
			int num1 = int.Parse(num);
			if (num1 < 10)
				return NumLetra.getUnidades(num);
			if (num1 <= 19)
				return NumLetra.DECENAS[num1 - 10];
			string unidades = NumLetra.getUnidades(num);
			return unidades.Equals("") ? NumLetra.DECENAS[int.Parse(num.Substring(0, 1)) + 8] : NumLetra.DECENAS[int.Parse(num.Substring(0, 1)) + 8] + "y " + unidades;
		}

		private static string getCentenas(string num)
		{
			if (int.Parse(num) <= 99)
				return NumLetra.getDecenas(string.Concat((object)int.Parse(num)));
			return int.Parse(num) == 100 ? " cien " : NumLetra.CENTENAS[int.Parse(num.Substring(0, 1))] + NumLetra.getDecenas(num.Substring(1));
		}

		private static string getMiles(string numero)
		{
			string num = numero.Substring(numero.Length - 3);
			string str = numero.Substring(0, numero.Length - 3);
			return int.Parse(str) > 0 ? NumLetra.getCentenas(str) + "mil " + NumLetra.getCentenas(num) : NumLetra.getCentenas(num) ?? "";
		}

		private static string getMillones(string numero)
		{
			string numero1 = numero.Substring(numero.Length - 6);
			string str = numero.Substring(0, numero.Length - 6);
			return (str.Length <= 1 ? NumLetra.getUnidades(str) + "millon " : NumLetra.getCentenas(str) + "millones ") + NumLetra.getMiles(numero1);
		}

		public static string ConvertirEn(int number)
		{
			if (number == 0)
				return "zero";
			if (number < 0)
				return "minus " + NumLetra.ConvertirEn(Math.Abs(number));
			string str = "";
			if (number / 1000000 > 0)
			{
				str = str + NumLetra.ConvertirEn(number / 1000000) + " million ";
				number %= 1000000;
			}
			if (number / 1000 > 0)
			{
				str = str + NumLetra.ConvertirEn(number / 1000) + " thousand ";
				number %= 1000;
			}
			if (number / 100 > 0)
			{
				str = str + NumLetra.ConvertirEn(number / 100) + " hundred ";
				number %= 100;
			}
			if (number > 0)
			{
				if (str != "")
					str += "and ";
				string[] strArray1 = new string[20]
				{
		  "zero",
		  "one",
		  "two",
		  "three",
		  "four",
		  "five",
		  "six",
		  "seven",
		  "eight",
		  "nine",
		  "ten",
		  "eleven",
		  "twelve",
		  "thirteen",
		  "fourteen",
		  "fifteen",
		  "sixteen",
		  "seventeen",
		  "eighteen",
		  "nineteen"
				};
				string[] strArray2 = new string[10]
				{
		  "zero",
		  "ten",
		  "twenty",
		  "thirty",
		  "forty",
		  "fifty",
		  "sixty",
		  "seventy",
		  "eighty",
		  "ninety"
				};
				if (number < 20)
				{
					str += strArray1[number];
				}
				else
				{
					str += strArray2[number / 10];
					if (number % 10 > 0)
						str = str + "-" + strArray1[number % 10];
				}
			}
			return str.ToUpper();
		}

		private static string NumWordsWrapper(double n)
		{
			double n1 = 0.0;
			if (n == 0.0)
				return "zero";
			double n2;
			try
			{
				string[] strArray = n.ToString().Split('.');
				n2 = double.Parse(strArray[0]);
				n1 = double.Parse(strArray[1]);
			}
			catch
			{
				n2 = n;
			}
			string str = NumLetra.NumWords(n2);
			if (n1 > 0.0)
			{
				if (str != "")
					str += " and ";
				switch (n1.ToString().Length)
				{
					case 1:
						str = str + NumLetra.NumWords(n1) + " tenths";
						break;
					case 2:
						str = str + NumLetra.NumWords(n1) + " hundredths";
						break;
					case 3:
						str = str + NumLetra.NumWords(n1) + " thousandths";
						break;
					case 4:
						str = str + NumLetra.NumWords(n1) + " ten-thousandths";
						break;
					case 5:
						str = str + NumLetra.NumWords(n1) + " hundred-thousandths";
						break;
					case 6:
						str = str + NumLetra.NumWords(n1) + " millionths";
						break;
					case 7:
						str = str + NumLetra.NumWords(n1) + " ten-millionths";
						break;
				}
			}
			return str;
		}

		public static string NumWords(double n)
		{
			string[] strArray1 = new string[19]
			{
		"one",
		"two",
		"three",
		"four",
		"five",
		"six",
		"seven",
		"eight",
		"nine",
		"ten",
		"eleven",
		"twelve",
		"thirteen",
		"fourteen",
		"fifteen",
		"sixteen",
		"seventeen",
		"eighteen",
		"nineteen"
			};
			string[] strArray2 = new string[8]
			{
		"twenty",
		"thirty",
		"fourty",
		"fifty",
		"sixty",
		"seventy",
		"eighty",
		"ninty"
			};
			string[] strArray3 = new string[21]
			{
		"thousand",
		"million",
		"billion",
		"trillion",
		"quadrillion",
		"quintillion",
		"sextillion",
		"septillion",
		"octillion",
		"nonillion",
		"decillion",
		"undecillion",
		"duodecillion",
		"tredecillion",
		"Quattuordecillion",
		"Quindecillion",
		"Sexdecillion",
		"Septdecillion",
		"Octodecillion",
		"Novemdecillion",
		"Vigintillion"
			};
			string str = "";
			bool flag = false;
			if (n < 0.0)
			{
				str += "negative ";
				n *= -1.0;
			}
			for (int index = (strArray3.Length + 1) * 3; index > 3; index -= 3)
			{
				double num = Math.Pow(10.0, (double)index);
				if (n >= num)
				{
					if (n % num > 0.0)
						str = str + NumLetra.NumWords(Math.Floor(n / num)) + " " + strArray3[index / 3 - 1] + ", ";
					else if (n % num == 0.0)
						str = str + NumLetra.NumWords(Math.Floor(n / num)) + " " + strArray3[index / 3 - 1];
					n %= num;
				}
			}
			if (n >= 1000.0)
			{
				str = n % 1000.0 <= 0.0 ? str + NumLetra.NumWords(Math.Floor(n / 1000.0)) + " thousand" : str + NumLetra.NumWords(Math.Floor(n / 1000.0)) + " thousand, ";
				n %= 1000.0;
			}
			if (0.0 <= n && n <= 999.0)
			{
				if ((int)n / 100 > 0)
				{
					str = str + NumLetra.NumWords(Math.Floor(n / 100.0)) + " hundred";
					n %= 100.0;
				}
				if ((int)n / 10 > 1)
				{
					if (str != "")
						str += " ";
					str += strArray2[(int)n / 10 - 2];
					flag = true;
					n %= 10.0;
				}
				if (n < 20.0 && n > 0.0)
				{
					if (str != "" && !flag)
						str += " ";
					str += flag ? "-" + strArray1[(int)n - 1] : strArray1[(int)n - 1];
					n -= Math.Floor(n);
				}
			}
			return str.ToUpper();
		}
	}
}
