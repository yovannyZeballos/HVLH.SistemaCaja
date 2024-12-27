using PrinterUtility.EscPosEpsonCommands;
using PrinterUtility;
using System;
using System.Drawing;
using System.IO;
using System.Text;
using PrinterUtility.Enums;

namespace HVLH.SistemaCaja.TestPrint
{
	public class HelperPrinter
	{
		public static byte[] CortarPagina()
		{
			byte[] bytes = new byte[] { };

			for (int i = 0; i < 10; i++)
			{
				bytes = PrintExtensions.AddBytes(bytes, Encoding.UTF8.GetBytes("\n"));

			}

			return bytes;
		}

		public static byte[] SeparacionLinea(TipoLinea tipoLinea, ref byte[] bytes)
		{
			EscPosEpson obj = new EscPosEpson();
			bytes = PrintExtensions.AddBytes(bytes, obj.CharSize.Nomarl());
			switch (tipoLinea)
			{
				case TipoLinea.GUION:
					bytes = PrintExtensions.AddBytes(bytes, Encoding.UTF8.GetBytes("--------------------------------------------------------\n"));
					break;
				case TipoLinea.IGUAL:
					bytes = PrintExtensions.AddBytes(bytes, Encoding.UTF8.GetBytes("========================================================\n"));
					break;
				case TipoLinea.ASTERISCO:
					bytes = PrintExtensions.AddBytes(bytes, Encoding.UTF8.GetBytes("********************************************************\n"));
					break;
				case TipoLinea.BLANCO:
					bytes = PrintExtensions.AddBytes(bytes, Encoding.UTF8.GetBytes("                                                         \n"));
					break;
			}

			return bytes;
		}

		public static byte[] TextoCentrado(string texto, ref byte[] bytes)
		{
			EscPosEpson obj = new EscPosEpson();
			bytes = PrintExtensions.AddBytes(bytes, obj.CharSize.Nomarl());
			bytes = PrintExtensions.AddBytes(bytes, obj.FontSelect.FontB());
			bytes = PrintExtensions.AddBytes(bytes, obj.Alignment.Center());
			bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(texto + "\n"));
			return bytes;
		}

		public static byte[] TextoTitulo(string texto, ref byte[] bytes)
		{
			EscPosEpson obj = new EscPosEpson();

			bytes = PrintExtensions.AddBytes(bytes, obj.CharSize.Nomarl());
			bytes = PrintExtensions.AddBytes(bytes, obj.FontSelect.SpecialFontB());
			bytes = PrintExtensions.AddBytes(bytes, obj.Alignment.Center());
			bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(texto + "\n"));
			return bytes;
		}
		public static byte[] InsertarImagen(Bitmap codigoBitmap, ref byte[] bytes)
		{
			EscPosEpson obj = new EscPosEpson();
			bytes = PrintExtensions.AddBytes(bytes, obj.CharSize.Nomarl());
			bytes = PrintExtensions.AddBytes(bytes, GetLogo(codigoBitmap));
			// bytes = PrintExtensions.AddBytes(bytes, obj.QrCode.Print(texto, ErrorsCorrection.Percent25,QrCodeSize.Medio));
			return bytes;
		}

		public static byte[] TextoIzquierda(string texto, ref byte[] bytes)
		{
			EscPosEpson obj = new EscPosEpson();
			bytes = PrintExtensions.AddBytes(bytes, obj.CharSize.Nomarl());
			bytes = PrintExtensions.AddBytes(bytes, obj.FontSelect.FontB());
			bytes = PrintExtensions.AddBytes(bytes, obj.Alignment.Left());
			bytes = PrintExtensions.AddBytes(bytes, Encoding.ASCII.GetBytes(texto + "\n"));
			return bytes;
		}

		public static byte[] CortaTicket(ref byte[] bytes)
		{
			bytes = PrintExtensions.AddBytes(bytes, Encoding.UTF8.GetBytes("\x1B" + "d" + "\x09"));
			bytes = PrintExtensions.AddBytes(bytes, Encoding.UTF8.GetBytes("\x1B" + "m"));
			bytes = PrintExtensions.AddBytes(bytes, Encoding.UTF8.GetBytes("\x1B" + "d" + "\x02"));
			return bytes;

			//linea.AppendLine(); //Caracteres de corte. Estos comando varian segun el tipo de impresora
			//linea.AppendLine("\x1B" + "d" + "\x09"); //Avanza 9 renglones, Tambien varian
		}

		public static byte[] TextoExtremos(string textoIzquierdo, string textoDerecho, ref byte[] bytes)
		{
			EscPosEpson obj = new EscPosEpson();
			bytes = PrintExtensions.AddBytes(bytes, obj.CharSize.Nomarl());
			bytes = PrintExtensions.AddBytes(bytes, obj.FontSelect.FontB());
			Encoding iso = Encoding.GetEncoding("ISO-8859-1");


			int maxCar = 54, cortar;
			//variables que utilizaremos
			string textoIzq, textoDer, textoCompleto = "", espacios = "";

			//Si el texto que va a la izquierda es mayor a 18, cortamos el texto.
			if (textoIzquierdo.Length > 30)
			{
				cortar = textoIzquierdo.Length - 31;
				textoIzq = textoIzquierdo.Remove(31, cortar);
			}
			else
			{ textoIzq = textoIzquierdo; }

			textoCompleto = textoIzq;//Agregamos el primer texto.

			if (textoDerecho.Length > 20)//Si es mayor a 20 lo cortamos
			{
				cortar = textoDerecho.Length - 20;
				textoDer = textoDerecho.Remove(20, cortar);
			}
			else
			{ textoDer = textoDerecho; }

			//Obtenemos el numero de espacios restantes para poner textoDerecho al final
			int nroEspacios = maxCar - (textoIzq.Length + textoDer.Length);
			for (int i = 0; i < nroEspacios; i++)
			{
				espacios += " ";//agrega los espacios para poner textoDerecho al final
			}
			textoCompleto += espacios + textoDerecho;//Agregamos el segundo texto con los espacios para alinearlo a la derecha.
			bytes = PrintExtensions.AddBytes(bytes, obj.Alignment.Left());
			bytes = PrintExtensions.AddBytes(bytes, iso.GetBytes(textoCompleto + "\n"));
			return bytes;
		}
		public static string TextoExtremosPdf(string textoIzquierdo, string textoDerecho)
		{

			int maxCar = 70, cortar;
			//variables que utilizaremos
			string textoIzq, textoDer, textoCompleto = "", espacios = "";

			//Si el texto que va a la izquierda es mayor a 18, cortamos el texto.
			if (textoIzquierdo.Length > 18)
			{
				cortar = textoIzquierdo.Length - 19;
				textoIzq = textoIzquierdo.Remove(19, cortar);
			}
			else
			{ textoIzq = textoIzquierdo; }

			textoCompleto = textoIzq;//Agregamos el primer texto.

			if (textoDerecho.Length > 20)//Si es mayor a 20 lo cortamos
			{
				cortar = textoDerecho.Length - 20;
				textoDer = textoDerecho.Remove(20, cortar);
			}
			else
			{ textoDer = textoDerecho; }

			//Obtenemos el numero de espacios restantes para poner textoDerecho al final
			int nroEspacios = maxCar - (textoIzq.Length + textoDer.Length);
			for (int i = 0; i < nroEspacios; i++)
			{
				espacios += " ";//agrega los espacios para poner textoDerecho al final
			}
			return textoCompleto += espacios + textoDerecho;//Agregamos el segundo texto con los espacios para alinearlo a la derecha.
		}

		public static byte[] Texto3ColumnasDerecha(string descripcion, string cantidad, string importe, ref byte[] bytes)
		{

			EscPosEpson obj = new EscPosEpson();
			bytes = PrintExtensions.AddBytes(bytes, obj.CharSize.Nomarl());
			bytes = PrintExtensions.AddBytes(bytes, obj.FontSelect.FontB());
			Encoding iso = Encoding.GetEncoding("ISO-8859-1");


			int maxCar = 54, cortar;
			//variables que utilizaremos
			string texto1, texto2, texto3, textoCompleto = "", espacios = "";

			//Si el texto que va a la izquierda es mayor a 18, cortamos el texto.
			if (descripcion.Length > 35)
			{
				cortar = descripcion.Length - 35;
				texto1 = descripcion.Remove(35, cortar);
			}
			else
			{ texto1 = descripcion; }

			textoCompleto = texto1;//Agregamos el primer texto.

			if (cantidad.Length > 6)
			{
				cortar = cantidad.Length - 6;
				texto2 = cantidad.Remove(6, cortar);
			}
			else
			{ texto2 = cantidad; }

	
			int nroEspacios =  38 - textoCompleto.Length;
			for (int i = 0; i < nroEspacios; i++)
			{
				espacios += " ";
			}
			textoCompleto += espacios + texto2;

			if(importe.Length > 6)
			{
				cortar = importe.Length - 6;
				texto3 = importe.Remove(6, cortar);
			}
			else
			{ texto3 = importe; }


			//nroEspacios = 46 - textoCompleto.Length;
			nroEspacios = maxCar - (textoCompleto.Length + texto3.Length);
			espacios = "";
			for (int i = 0; i < nroEspacios; i++)
			{
				espacios += " ";
			}
			textoCompleto += espacios + texto3;


			bytes = PrintExtensions.AddBytes(bytes, obj.Alignment.Left());
			bytes = PrintExtensions.AddBytes(bytes, iso.GetBytes(textoCompleto + "\n"));
			return bytes;
		}
		public static byte[] Texto3ColumnasDerecha(string cant, decimal precio, decimal importe, ref byte[] bytes, bool EsGratuito)
		{
			StringBuilder linea = new StringBuilder();
			//Valida que cant precio e importe esten dentro del rango.
			if (cant.Length <= 20 && precio.ToString(Formatos.FormatoNumerico).Length <= 10 && importe.ToString(Formatos.FormatoNumerico).Length <= 10)
			{
				string elemento = "", espacios = "";
				int nroEspacios = 0;

				if (EsGratuito)
					espacios += "TRANS.GRAT.    ";
				else
					for (int i = 0; i < 15; i++)
					{
						espacios += " ";
					}


				elemento = espacios;

				nroEspacios = (8 - cant.Length);
				espacios = "";
				for (int i = 0; i < nroEspacios; i++)
				{
					espacios += " ";
				}
				elemento += espacios + cant;

				//Colocar el precio a la derecha.
				nroEspacios = (14 - precio.ToString(Formatos.FormatoNumerico).Length);
				espacios = "";
				for (int i = 0; i < nroEspacios; i++)
				{
					espacios += " ";
				}
				elemento += espacios + precio.ToString(Formatos.FormatoNumerico);

				//Colocar el importe a la derecha.
				nroEspacios = (17 - importe.ToString(Formatos.FormatoNumerico).Length);
				espacios = "";
				for (int i = 0; i < nroEspacios; i++)
				{
					espacios += " ";
				}
				elemento += espacios + importe.ToString(Formatos.FormatoNumerico);

				linea.Append(elemento);//Agregamos todo el elemento: nombre del articulo, cant, precio, importe.

			}
			else
			{
				linea.AppendLine("Los valores ingresados para esta fila");
				linea.AppendLine("superan las columnas soportdas por éste.");
				throw new Exception("Los valores ingresados para algunas filas del ticket\nsuperan las columnas soportdas por éste.");
			}

			EscPosEpson obj = new EscPosEpson();
			bytes = PrintExtensions.AddBytes(bytes, obj.CharSize.Nomarl());
			bytes = PrintExtensions.AddBytes(bytes, obj.FontSelect.FontB());
			bytes = PrintExtensions.AddBytes(bytes, obj.Alignment.Left());
			bytes = PrintExtensions.AddBytes(bytes, Encoding.UTF8.GetBytes(linea.ToString() + "\n"));
			return bytes;
		}

		public static string Texto3ColumnasDerechaPdf(string cant, decimal precio, decimal importe, bool EsGratuito)
		{
			StringBuilder linea = new StringBuilder();
			//Valida que cant precio e importe esten dentro del rango.
			if (cant.Length <= 20 && precio.ToString(Formatos.FormatoNumerico).Length <= 10 && importe.ToString(Formatos.FormatoNumerico).Length <= 10)
			{
				string elemento = "", espacios = "";
				int nroEspacios = 0;

				if (EsGratuito)
					espacios += "TRANS.GRAT.                       ";
				else
					for (int i = 0; i < 48; i++)
					{
						espacios += " ";
					}


				elemento = espacios;

				nroEspacios = (8 - cant.Length);
				espacios = "";
				for (int i = 0; i < nroEspacios; i++)
				{
					espacios += " ";
				}
				elemento += espacios + cant;

				//Colocar el precio a la derecha.
				nroEspacios = (14 - precio.ToString(Formatos.FormatoNumerico).Length);
				espacios = "";
				for (int i = 0; i < nroEspacios; i++)
				{
					espacios += " ";
				}
				elemento += espacios + precio.ToString(Formatos.FormatoNumerico);

				//Colocar el importe a la derecha.
				nroEspacios = (17 - importe.ToString(Formatos.FormatoNumerico).Length);
				espacios = "";
				for (int i = 0; i < nroEspacios; i++)
				{
					espacios += " ";
				}
				elemento += espacios + importe.ToString(Formatos.FormatoNumerico);

				linea.Append(elemento);//Agregamos todo el elemento: nombre del articulo, cant, precio, importe.

			}
			else
			{
				linea.AppendLine("Los valores ingresados para esta fila");
				linea.AppendLine("superan las columnas soportdas por éste.");
				throw new Exception("Los valores ingresados para algunas filas del ticket\nsuperan las columnas soportdas por éste.");
			}

			return linea.ToString();
		}

		public static byte[] TextoTotales(string texto, decimal importe, ref byte[] bytes)
		{
			EscPosEpson obj = new EscPosEpson();
			bytes = PrintExtensions.AddBytes(bytes, obj.CharSize.Nomarl());
			bytes = PrintExtensions.AddBytes(bytes, obj.FontSelect.FontB());

			int maxCar = 54, cortar;
			//variables que utilizaremos
			string textoIzq, textoDer, textoCompleto = "", espacios = "";

			//Si el texto que va a la izquierda es mayor a 18, cortamos el texto.
			if (texto.Length > 18)
			{
				cortar = texto.Length - 18;
				textoIzq = "           " + texto.Remove(18, cortar);
			}
			else
			{ textoIzq = "                  " + texto; }

			textoCompleto = textoIzq;//Agregamos el primer texto.

			if (importe.ToString(Formatos.FormatoNumerico).Length > 20)//Si es mayor a 20 lo cortamos
			{
				cortar = importe.ToString(Formatos.FormatoNumerico).Length - 20;
				textoDer = importe.ToString(Formatos.FormatoNumerico).Remove(20, cortar);
			}
			else
			{ textoDer = importe.ToString(Formatos.FormatoNumerico); }

			//Obtenemos el numero de espacios restantes para poner textoDerecho al final
			int nroEspacios = maxCar - (textoIzq.Length + textoDer.Length);
			for (int i = 0; i < nroEspacios; i++)
			{
				espacios += " ";//agrega los espacios para poner textoDerecho al final
			}
			textoCompleto += espacios + textoDer;//Agregamos el segundo texto con los espacios para alinearlo a la derecha.
			bytes = PrintExtensions.AddBytes(bytes, obj.Alignment.Left());
			bytes = PrintExtensions.AddBytes(bytes, Encoding.UTF8.GetBytes(textoCompleto + "\n"));
			return bytes;
		}

		public static string TextoTotalesPdf(string texto, decimal importe)
		{

			int maxCar = 85, cortar;
			//variables que utilizaremos
			string textoIzq, textoDer, textoCompleto = "", espacios = "";

			//Si el texto que va a la izquierda es mayor a 18, cortamos el texto.
			if (texto.Length > 18)
			{
				cortar = texto.Length - 18;
				textoIzq = "           " + texto.Remove(18, cortar);
			}
			else
			{ textoIzq = "                                 " + texto; }

			textoCompleto = textoIzq;//Agregamos el primer texto.

			if (importe.ToString(Formatos.FormatoNumerico).Length > 20)//Si es mayor a 20 lo cortamos
			{
				cortar = importe.ToString(Formatos.FormatoNumerico).Length - 20;
				textoDer = importe.ToString(Formatos.FormatoNumerico).Remove(20, cortar);
			}
			else
			{ textoDer = importe.ToString(Formatos.FormatoNumerico); }

			//Obtenemos el numero de espacios restantes para poner textoDerecho al final
			int nroEspacios = maxCar - (textoIzq.Length + textoDer.Length);
			for (int i = 0; i < nroEspacios; i++)
			{
				espacios += " ";//agrega los espacios para poner textoDerecho al final
			}
			textoCompleto += espacios + textoDer;//Agregamos el segundo texto con los espacios para alinearlo a la derecha.
			return textoCompleto;
		}

		public static byte[] Qr(string texto, ref byte[] bytes)
		{
			EscPosEpson obj = new EscPosEpson();
			bytes = PrintExtensions.AddBytes(bytes, obj.Alignment.Center());
			bytes = PrintExtensions.AddBytes(bytes, obj.QrCode.Print(texto, QrCodeSize.Medio));
			return bytes;

		}
		public static byte[] GetLogo(Bitmap codigoBitMap)
		{


			BitmapData data = GetBitmapData(codigoBitMap);
			System.Collections.BitArray dots = data.Dots;
			byte[] width = BitConverter.GetBytes(data.Width);

			int offset = 0;
			MemoryStream stream = new MemoryStream();
			BinaryWriter bw = new BinaryWriter(stream);

			bw.Write((char)0x1B);
			bw.Write('@');

			bw.Write((char)0x1B);
			bw.Write('3');
			bw.Write((byte)24);

			while (offset < data.Height)
			{
				bw.Write((char)0x1B);
				bw.Write('*');         // bit-image mode
				bw.Write((byte)33);    // 24-dot double-density
				bw.Write(width[0]);  // width low byte
				bw.Write(width[1]);  // width high byte

				for (int x = 0; x < data.Width; ++x)
				{
					for (int k = 0; k < 3; ++k)
					{
						byte slice = 0;
						for (int b = 0; b < 8; ++b)
						{
							int y = (((offset / 8) + k) * 8) + b;
							// Calculate the location of the pixel we want in the bit array.
							// It'll be at (y * width) + x.
							int i = (y * data.Width) + x;

							// If the image is shorter than 24 dots, pad with zero.
							bool v = false;
							if (i < dots.Length)
							{
								v = dots[i];
							}
							slice |= (byte)((v ? 1 : 0) << (7 - b));
						}

						bw.Write(slice);
					}
				}
				offset += 24;
				bw.Write((char)0x0A);
			}
			// Restore the line spacing to the default of 30 dots.
			bw.Write((char)0x1B);
			bw.Write('3');
			bw.Write((byte)30);

			bw.Flush();
			return stream.ToArray();
			//return logo + Encoding.Default.GetString(bytes);
		}

		public static BitmapData GetBitmapData(Bitmap bmpFileName)
		{
			using (var bitmap = bmpFileName)
			{
				var threshold = 127;
				var index = 0;
				double multiplier = 500; // this depends on your printer model. for Beiyang you should use 1000
				double scale = (double)(multiplier / (double)bitmap.Width);
				int xheight = (int)(bitmap.Height * scale);
				int xwidth = (int)(bitmap.Width * scale);
				var dimensions = xwidth * xheight;
				var dots = new System.Collections.BitArray(dimensions);

				for (var y = 0; y < xheight; y++)
				{
					for (var x = 0; x < xwidth; x++)
					{
						var _x = (int)(x / scale);
						var _y = (int)(y / scale);
						var color = bitmap.GetPixel(_x, _y);
						var luminance = (int)(color.R * 0.3 + color.G * 0.59 + color.B * 0.11);
						dots[index] = (luminance < threshold);
						index++;
					}
				}

				return new BitmapData()
				{
					Dots = dots,
					Height = (int)(bitmap.Height * scale),
					Width = (int)(bitmap.Width * scale)
				};
			}
		}

		public class BitmapData
		{
			public System.Collections.BitArray Dots
			{
				get;
				set;
			}

			public int Height
			{
				get;
				set;
			}

			public int Width
			{
				get;
				set;
			}
		}
	}
}
