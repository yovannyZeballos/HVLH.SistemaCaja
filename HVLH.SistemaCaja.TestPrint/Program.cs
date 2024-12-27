using PrinterUtility.EscPosEpsonCommands;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Configuration;

namespace HVLH.SistemaCaja.TestPrint
{
	internal class Program
	{
		static void Main(string[] args)
		{
			try
			{
				byte[] bytes = new byte[] { };
				bytes = HelperPrinter.TextoTitulo("AESAULD HOSPITAL 'VICTOR LARCO HERRERA'", ref bytes);
				bytes = HelperPrinter.TextoCentrado("Av. Augusto Perez Aranibar N 600", ref bytes);
				bytes = HelperPrinter.TextoCentrado("Magdalena del Mar - Lima", ref bytes);
				bytes = HelperPrinter.TextoTitulo("R.U.C. 20159855938", ref bytes);
				bytes = HelperPrinter.TextoTitulo("BOLETA DE VENTA ELECTRONICA", ref bytes);
				bytes = HelperPrinter.TextoTitulo("B001-234456", ref bytes);
				bytes = HelperPrinter.SeparacionLinea(TipoLinea.BLANCO, ref bytes);
				bytes = HelperPrinter.TextoIzquierda("Cajero: ROSA AMELIA CHICANA CHICANA", ref bytes);
				bytes = HelperPrinter.TextoIzquierda("Fecha: 03/07/2023  Hora: 15:00:32", ref bytes);
				bytes = HelperPrinter.TextoIzquierda("RUC: 204456654567", ref bytes);
				bytes = HelperPrinter.TextoIzquierda("Sr(a): FONDO DE ASEGURAMIENTO EN SALUD DE LA DIRECCION", ref bytes);
				bytes = HelperPrinter.TextoIzquierda("Direccion: JR TAHUANTINSUYO NRO 172 - 176 - URB SAN JUAN BAUTISTA/CHORRILLOS", ref bytes);
				bytes = HelperPrinter.TextoIzquierda("Forma de pago: Conatdo", ref bytes);
				bytes = HelperPrinter.SeparacionLinea(TipoLinea.GUION, ref bytes);
				bytes = HelperPrinter.TextoExtremos("CONCEPTO", "CANT.   IMPORTE.", ref bytes);
				bytes = HelperPrinter.SeparacionLinea(TipoLinea.GUION, ref bytes);
				bytes = HelperPrinter.Texto3ColumnasDerecha("SERTRALINA (COMO CLORHIDRATO) 50 mg TABLET", "90", "13.73", ref bytes);
				bytes = HelperPrinter.Texto3ColumnasDerecha("RISPERIDONA 2 mg TABLET", "90", "12.97", ref bytes);
				bytes = HelperPrinter.Texto3ColumnasDerecha("RISPERIDONA 2 mg TABLET", "90", "12.97", ref bytes);
				bytes = HelperPrinter.Texto3ColumnasDerecha("RISPERIDONA 2 mg TABLET", "90", "12.97", ref bytes);
				bytes = HelperPrinter.Texto3ColumnasDerecha("RISPERIDONA 2 mg TABLET", "90", "12.97", ref bytes);
				bytes = HelperPrinter.Texto3ColumnasDerecha("CLONAZEPAM 500 mg (0.5 mg) TABLET", "10", "1.10", ref bytes);
				bytes = HelperPrinter.Texto3ColumnasDerecha("CLONAZEPAM 500 mg (0.5 mg) TABLET", "10", "1.10", ref bytes);
				bytes = HelperPrinter.Texto3ColumnasDerecha("CLONAZEPAM 500 mg (0.5 mg) TABLET", "10", "1.10", ref bytes);
				bytes = HelperPrinter.Texto3ColumnasDerecha("CLONAZEPAM 500 mg (0.5 mg) TABLET", "10", "1.10", ref bytes);
				bytes = HelperPrinter.Texto3ColumnasDerecha("CLONAZEPAM 500 mg (0.5 mg) TABLET", "10", "1.10", ref bytes);
				bytes = HelperPrinter.Texto3ColumnasDerecha("CLONAZEPAM 500 mg (0.5 mg) TABLET", "10", "1.10", ref bytes);
				bytes = HelperPrinter.Texto3ColumnasDerecha("CLONAZEPAM 500 mg (0.5 mg) TABLET", "10", "1.10", ref bytes);
				bytes = HelperPrinter.Texto3ColumnasDerecha("CLONAZEPAM 500 mg (0.5 mg) TABLET", "10", "1.10", ref bytes);
				bytes = HelperPrinter.Texto3ColumnasDerecha("CLONAZEPAM 500 mg (0.5 mg) TABLET", "10", "1.10", ref bytes);
				bytes = HelperPrinter.Texto3ColumnasDerecha("CLONAZEPAM 500 mg (0.5 mg) TABLET", "10", "1.10", ref bytes);
				bytes = HelperPrinter.Texto3ColumnasDerecha("CLONAZEPAM 500 mg (0.5 mg) TABLET", "10", "1.10", ref bytes);
				bytes = HelperPrinter.Texto3ColumnasDerecha("CLONAZEPAM 500 mg (0.5 mg) TABLET", "10", "1.10", ref bytes);
				bytes = HelperPrinter.Texto3ColumnasDerecha("CLONAZEPAM 500 mg (0.5 mg) TABLET", "10", "1.10", ref bytes);
				bytes = HelperPrinter.Texto3ColumnasDerecha("CLONAZEPAM 500 mg (0.5 mg) TABLET", "10", "1.10", ref bytes);
				bytes = HelperPrinter.Texto3ColumnasDerecha("CLONAZEPAM 500 mg (0.5 mg) TABLET", "10", "1.10", ref bytes);
				bytes = HelperPrinter.Texto3ColumnasDerecha("CLONAZEPAM 500 mg (0.5 mg) TABLET", "10", "1.10", ref bytes);
				bytes = HelperPrinter.Texto3ColumnasDerecha("CLONAZEPAM 500 mg (0.5 mg) TABLET", "10", "1.10", ref bytes);
				bytes = HelperPrinter.Texto3ColumnasDerecha("CLONAZEPAM 500 mg (0.5 mg) TABLET", "10", "1.10", ref bytes);
				bytes = HelperPrinter.Texto3ColumnasDerecha("CLONAZEPAM 500 mg (0.5 mg) TABLET", "10", "1.10", ref bytes);
				bytes = HelperPrinter.Texto3ColumnasDerecha("CLONAZEPAM 500 mg (0.5 mg) TABLET", "10", "1.10", ref bytes);
				bytes = HelperPrinter.SeparacionLinea(TipoLinea.GUION, ref bytes);
				bytes = HelperPrinter.TextoTotales("SUB-TOTAL S/", 27.80M, ref bytes);
				bytes = HelperPrinter.TextoTotales("IGV S/", 5, ref bytes);
				bytes = HelperPrinter.TextoTotales("TOTAL S/", 32.8M, ref bytes);
				bytes = HelperPrinter.SeparacionLinea(TipoLinea.BLANCO, ref bytes);
				bytes = HelperPrinter.TextoCentrado("NO HAY DEVOLUCION DE DINERO. TODO CAMBIO DE", ref bytes);
				bytes = HelperPrinter.TextoCentrado("PRODUCTO Y/O SERVICIO SE HARA DENTRO DE LAS", ref bytes);
				bytes = HelperPrinter.TextoCentrado("8 HORAS PREVIA PRESENTACION DEL COMPROBANTE", ref bytes);
				bytes = HelperPrinter.TextoCentrado("VERIFICACION DEL CAJERO CENTRAL", ref bytes);
				bytes = HelperPrinter.SeparacionLinea(TipoLinea.BLANCO, ref bytes);
				bytes = HelperPrinter.TextoCentrado("Representacion Impresa de la Factura Electronica", ref bytes);
				bytes = HelperPrinter.TextoCentrado("Autorizada mediante resolucion:", ref bytes);
				bytes = HelperPrinter.TextoCentrado("Res. Int. 034-005-0005612/SUNAT", ref bytes);
				bytes = HelperPrinter.TextoCentrado("Este documento puede ser validado en:", ref bytes);
				bytes = HelperPrinter.TextoCentrado("www.pagina.com/documentos", ref bytes);
				bytes = HelperPrinter.TextoCentrado("Valor resumen: nkTk4434ytalsdfjfg/sdskf=", ref bytes);
				bytes = HelperPrinter.SeparacionLinea(TipoLinea.BLANCO, ref bytes);
				bytes = HelperPrinter.Qr("20106897914|03|B127|02822737|0.46|3.0|2022-05-31|6|70123397", ref bytes);
				bytes = HelperPrinter.CortaTicket(ref bytes);

				RawPrinterHelper.Printer(ConfigurationManager.AppSettings.Get("NombreImpresora"), bytes);
				Console.WriteLine("Ticket enviado a la impresora ", ConfigurationManager.AppSettings.Get("NombreImpresora"));
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			Console.ReadLine();

		}

	}
	public class Ticket
	{
		PrintDocument pdoc = null;
		int ticketNo;
		DateTime TicketDate;
		String Source, Destination, DrawnBy;
		float Amount;

		public int TicketNo
		{
			//set the person name
			set { this.ticketNo = value; }
			//get the person name 
			get { return this.ticketNo; }
		}
		public DateTime ticketDate
		{
			//set the person name
			set { this.TicketDate = value; }
			//get the person name 
			get { return this.TicketDate; }
		}

		public String source
		{
			//set the person name
			set { this.Source = value; }
			//get the person name 
			get { return this.Source; }
		}
		public String destination
		{
			//set the person name
			set { this.Destination = value; }
			//get the person name 
			get { return this.Destination; }
		}
		public float amount
		{
			//set the person name
			set { this.Amount = value; }
			//get the person name 
			get { return this.Amount; }
		}
		public String drawnBy
		{
			//set the person name
			set { this.DrawnBy = value; }
			//get the person name 
			get { return this.DrawnBy; }
		}

		public Ticket()
		{

		}
		public Ticket(int ticketNo, DateTime TicketDate, String Source,
			   String Destination, float Amount, String DrawnBy)
		{
			this.ticketNo = ticketNo;
			this.TicketDate = TicketDate;
			this.Source = Source;
			this.Destination = Destination;
			this.Amount = Amount;
			this.DrawnBy = DrawnBy;
		}
		public void print()
		{
			PrintDialog pd = new PrintDialog();
			pdoc = new PrintDocument();
			PrinterSettings ps = new PrinterSettings();
			Font font = new Font("Courier New", 15);


			PaperSize psize = new PaperSize("Custom", 100, 200);
			//ps.DefaultPageSettings.PaperSize = psize;

			pd.Document = pdoc;
			pd.Document.DefaultPageSettings.PaperSize = psize;
			//pdoc.DefaultPageSettings.PaperSize.Height =320;
			pdoc.DefaultPageSettings.PaperSize.Height = 200;

			pdoc.DefaultPageSettings.PaperSize.Width = 100;

			pdoc.PrintPage += new PrintPageEventHandler(pdoc_PrintPage);

			DialogResult result = pd.ShowDialog();
			if (result == DialogResult.OK)
			{
				PrintPreviewDialog pp = new PrintPreviewDialog();
				pp.Document = pdoc;
				result = pp.ShowDialog();
				if (result == DialogResult.OK)
				{
					pdoc.Print();
				}
			}

		}
		void pdoc_PrintPage(object sender, PrintPageEventArgs e)
		{
			Graphics graphics = e.Graphics;
			Font font = new Font("Courier New", 10);
			float fontHeight = font.GetHeight();
			int startX = 50;
			int startY = 55;
			int Offset = 40;
			graphics.DrawString("AESALUD HOSPITAL VICTOR LARCO HERRERA", new Font("Courier New", 14),
								new SolidBrush(Color.Black), startX, startY + Offset);
			Offset = Offset + 20;
			graphics.DrawString("Ticket No:" + this.TicketNo,
					 new Font("Courier New", 14),
					 new SolidBrush(Color.Black), startX, startY + Offset);
			Offset = Offset + 20;
			graphics.DrawString("Ticket Date :" + this.ticketDate,
					 new Font("Courier New", 12),
					 new SolidBrush(Color.Black), startX, startY + Offset);
			Offset = Offset + 20;
			String underLine = "------------------------------------------";
			graphics.DrawString(underLine, new Font("Courier New", 10),
					 new SolidBrush(Color.Black), startX, startY + Offset);

			Offset = Offset + 20;
			String Source = this.source;
			graphics.DrawString("From " + Source + " To " + Destination, new Font("Courier New", 10),
					 new SolidBrush(Color.Black), startX, startY + Offset);

			Offset = Offset + 20;
			String Grosstotal = "Total Amount to Pay = " + this.amount;

			Offset = Offset + 20;
			underLine = "------------------------------------------";
			graphics.DrawString(underLine, new Font("Courier New", 10),
					 new SolidBrush(Color.Black), startX, startY + Offset);
			Offset = Offset + 20;

			graphics.DrawString(Grosstotal, new Font("Courier New", 10),
					 new SolidBrush(Color.Black), startX, startY + Offset);
			Offset = Offset + 20;
			String DrawnBy = this.drawnBy;
			graphics.DrawString("Conductor - " + DrawnBy, new Font("Courier New", 10),
					 new SolidBrush(Color.Black), startX, startY + Offset);
		}
	}
}
