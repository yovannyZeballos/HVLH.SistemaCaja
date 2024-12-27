using HVLH.Facturacion.Comun.Datos.Contratos;
using HVLH.Facturacion.Comun;
using HVLH.Facturacion.Comun.Datos.Modelos;
using HVLH.Facturacion.Xml;
using HVLH.Facturacion.Xml._2._1;
using HVLH.SistemaCaja.Comun;
using HVLH.SistemaCaja.Repositorio.Contextos;
using HVLH.SistemaCaja.Servicio.Contratos;
using HVLH.SistemaCaja.Servicio.DTO;
using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;

namespace HVLH.SistemaCaja.Servicio.Impl
{
	public class ServicioImpresion : IServicioImpresion
	{
		private readonly ISiheContexto _siheContexto;
		public readonly IFormatProvider Formato = CultureInfo.InvariantCulture;
		public ServicioImpresion(ISiheContexto siheContexto)
		{
			_siheContexto = siheContexto;
		}

		public async Task Factura(IImpresionDocumentoDTO documentoDTO)
		{
			var impresionFactura = documentoDTO as ImpresionFacturaDTO;

			var horaParqueo = string.IsNullOrEmpty(impresionFactura.HoraParqueo) ? "" : $"Ingreso: {impresionFactura.HoraParqueo}";

			byte[] bytes = new byte[] { };
			bytes = HelperPrinter.TextoTitulo(impresionFactura.RazonSocialEmpresa, ref bytes);
			bytes = HelperPrinter.TextoCentrado(impresionFactura.DirecciónEmpresa, ref bytes);
			bytes = HelperPrinter.TextoCentrado($"{impresionFactura.Distrito} - {impresionFactura.Provincia}", ref bytes);
			bytes = HelperPrinter.TextoTitulo($"R.U.C. {impresionFactura.RucEmpresa}", ref bytes);
			bytes = HelperPrinter.TextoTitulo("FACTURA ELECTRONICA", ref bytes);
			bytes = HelperPrinter.TextoTitulo($"{impresionFactura.Serie}-{impresionFactura.Numero}", ref bytes);
			bytes = HelperPrinter.SeparacionLinea(TipoLinea.BLANCO, ref bytes);
			bytes = HelperPrinter.TextoIzquierda($"Cajero: {impresionFactura.Usuario}", ref bytes);
			bytes = HelperPrinter.TextoIzquierda($"Fecha: {impresionFactura.Fecha:dd/MM/yyyy}  Hora: {impresionFactura.Fecha:HH:mm:ss} {horaParqueo}", ref bytes);

			if (impresionFactura.Cuotas.Count > 0)
				bytes = HelperPrinter.TextoIzquierda($"Fecha vencimiento: {impresionFactura.Cuotas[impresionFactura.Cuotas.Count - 1].Fecha:dd/MM/yyyy}", ref bytes);
			else
				bytes = HelperPrinter.TextoIzquierda($"Fecha vencimiento: {impresionFactura.Fecha:dd/MM/yyyy}", ref bytes);

			bytes = HelperPrinter.TextoIzquierda($"RUC: {impresionFactura.NumeroDocumentoCliente} Nro referencia: {impresionFactura.Referencia}", ref bytes);
			bytes = HelperPrinter.TextoIzquierda($"Sr(a): {impresionFactura.RazonSocialCliente}", ref bytes);
			bytes = HelperPrinter.TextoIzquierda($"Direccion: {impresionFactura.DireccionCliente}", ref bytes);


			if (impresionFactura.Cuotas.Count > 0)
			{
				bytes = HelperPrinter.TextoIzquierda("Forma de pago: Credito", ref bytes);

				foreach (var cuota in impresionFactura.Cuotas)
					bytes = HelperPrinter.TextoIzquierda($"       CUOTA {cuota.Numero} - {cuota.Fecha:dd/MM/yyyy} - {(impresionFactura.Moneda == "S" ? "S/" : "$")} {cuota.Monto}", ref bytes);
			}
			else
			{
				bytes = HelperPrinter.TextoIzquierda("Forma de pago: Contado", ref bytes);
			}

			bytes = HelperPrinter.TextoIzquierda($"Método de pago: {impresionFactura.DescMedioPago}", ref bytes);
			bytes = HelperPrinter.SeparacionLinea(TipoLinea.GUION, ref bytes);
			bytes = HelperPrinter.TextoExtremos("CONCEPTO", "CANT.   IMPORTE.", ref bytes);
			bytes = HelperPrinter.SeparacionLinea(TipoLinea.GUION, ref bytes);

			foreach (var item in impresionFactura.Detalles)
			{
				bytes = HelperPrinter.Texto3ColumnasDerecha(item.Descripcion, item.Cantidad.ToString(), Formateador.Numero(item.Importe), ref bytes);
			}

			bytes = HelperPrinter.SeparacionLinea(TipoLinea.GUION, ref bytes);
			bytes = HelperPrinter.TextoTotales($"SUB-TOTAL {(impresionFactura.Moneda == "S" ? "S/" : "$")}", impresionFactura.Gratuito + impresionFactura.Inafecto + impresionFactura.Exonerado + impresionFactura.Gravadas + impresionFactura.Exportacion, ref bytes);
			bytes = HelperPrinter.TextoTotales($"IGV  {(impresionFactura.Moneda == "S" ? "S/" : "$")}", impresionFactura.Igv, ref bytes);
			bytes = HelperPrinter.TextoTotales($"TOTAL  {(impresionFactura.Moneda == "S" ? "S/" : "$")}", impresionFactura.MontoTotal, ref bytes);
			bytes = HelperPrinter.SeparacionLinea(TipoLinea.BLANCO, ref bytes);
			bytes = HelperPrinter.TextoIzquierda($"SON: {NumLetra.Convertir(impresionFactura.MontoTotal.ToString("###0.#0", Formato), true)} {(impresionFactura.Moneda != "S" ? "DOLARES AMERICANOS" : "SOLES")}", ref bytes);
			bytes = HelperPrinter.SeparacionLinea(TipoLinea.BLANCO, ref bytes);
			bytes = HelperPrinter.TextoCentrado("NO HAY DEVOLUCION DE DINERO. TODO CAMBIO DE", ref bytes);
			bytes = HelperPrinter.TextoCentrado("PRODUCTO Y/O SERVICIO SE HARA DENTRO DE LAS", ref bytes);
			bytes = HelperPrinter.TextoCentrado("24 HORAS PREVIA PRESENTACION DEL COMPROBANTE", ref bytes);
			bytes = HelperPrinter.TextoCentrado("VERIFICACION DEL CAJERO CENTRAL", ref bytes);
			bytes = HelperPrinter.SeparacionLinea(TipoLinea.BLANCO, ref bytes);
			bytes = HelperPrinter.TextoCentrado("Representacion Impresa de la Factura Electronica", ref bytes);
			bytes = HelperPrinter.TextoCentrado("Autorizada mediante resolucion:", ref bytes);
			bytes = HelperPrinter.TextoCentrado("Res. Int. 034-005-0005612/SUNAT", ref bytes);
			bytes = HelperPrinter.TextoCentrado("Este documento puede ser validado en:", ref bytes);
			bytes = HelperPrinter.TextoCentrado("https://www.nubefact.com/buscar", ref bytes);
			bytes = HelperPrinter.TextoCentrado($"Valor resumen: {impresionFactura.ResumenFirma}", ref bytes);
			bytes = HelperPrinter.SeparacionLinea(TipoLinea.BLANCO, ref bytes);
			bytes = HelperPrinter.Qr($"{impresionFactura.RucEmpresa}|01|{impresionFactura.Serie}|{impresionFactura.Numero}|{impresionFactura.Igv}|{impresionFactura.MontoTotal}|" +
				$"{impresionFactura.Fecha:yyyy-MM-dd}|{impresionFactura.TipoDocumentoCliente}|{impresionFactura.NumeroDocumentoCliente}|", ref bytes);
			bytes = HelperPrinter.CortaTicket(ref bytes);
			RawPrinterHelper.Printer(ConfigurationManager.AppSettings.Get("NombreImpresora"), bytes);

			var documento = await _siheContexto.RepositorioDocumento.Obtener(x => x.Serie == impresionFactura.Serie && x.Numero == impresionFactura.Numero && x.IdTipoDocumento == impresionFactura.IdTipoDocumento);
			documento.FechaModificacion = DateTime.Now;
			documento.UsuarioModificacion = impresionFactura.Usuario;


            //Validación Si el documento está enviado a SUNAT #3 o #5 ANULADO no realizar el cambio en la Bd a Impreso.
            if (documento.Estado != "3" && documento.Estado!="5")
            {
                documento.Estado = ((int)EstadoDocumento.Impreso).ToString();
            }
            //documento.Estado = ((int)EstadoDocumento.Impreso).ToString();

			documento.ResumenFirma = impresionFactura.ResumenFirma;
			await _siheContexto.CommitAsync();

		}

		public async Task Boleta(IImpresionDocumentoDTO documentoDTO)
		{

			var impresionFactura = documentoDTO as ImpresionFacturaDTO;
			byte[] bytes = new byte[] { };

			var horaParqueo = string.IsNullOrEmpty(impresionFactura.HoraParqueo) ? "" : $"Ingreso: {impresionFactura.HoraParqueo}";

			bytes = HelperPrinter.TextoTitulo(impresionFactura.RazonSocialEmpresa, ref bytes);
			bytes = HelperPrinter.TextoCentrado(impresionFactura.DirecciónEmpresa, ref bytes);
			bytes = HelperPrinter.TextoCentrado($"{impresionFactura.Distrito} - {impresionFactura.Provincia}", ref bytes);
			bytes = HelperPrinter.TextoTitulo($"R.U.C. {impresionFactura.RucEmpresa}", ref bytes);
			bytes = HelperPrinter.TextoTitulo("BOLETA DE VENTA ELECTRONICA", ref bytes);
			bytes = HelperPrinter.TextoTitulo($"{impresionFactura.Serie}-{impresionFactura.Numero}", ref bytes);
			bytes = HelperPrinter.SeparacionLinea(TipoLinea.BLANCO, ref bytes);
			bytes = HelperPrinter.TextoIzquierda($"Cajero: {impresionFactura.Usuario}", ref bytes);
			bytes = HelperPrinter.TextoIzquierda($"Fecha: {impresionFactura.Fecha:dd/MM/yyyy}  Hora: {impresionFactura.Fecha:HH:mm:ss} {horaParqueo}", ref bytes);
			bytes = HelperPrinter.TextoIzquierda($"DNI: {impresionFactura.NumeroDocumentoCliente} Nro referencia: {impresionFactura.Referencia}", ref bytes);
			bytes = HelperPrinter.TextoIzquierda($"Sr(a): {impresionFactura.RazonSocialCliente}", ref bytes);
			bytes = HelperPrinter.TextoIzquierda($"Forma de pago: {(impresionFactura.FormaPago == "1" ? "Contado" : "Credito")}", ref bytes);
			bytes = HelperPrinter.TextoIzquierda($"Método de pago: {impresionFactura.DescMedioPago}", ref bytes);
			bytes = HelperPrinter.SeparacionLinea(TipoLinea.GUION, ref bytes);
			bytes = HelperPrinter.TextoExtremos("CONCEPTO", "CANT.   TOTAL.", ref bytes);
			bytes = HelperPrinter.SeparacionLinea(TipoLinea.GUION, ref bytes);

			foreach (var item in impresionFactura.Detalles)
			{
				bytes = HelperPrinter.Texto3ColumnasDerecha(item.Descripcion, item.Cantidad.ToString(), Formateador.Numero(item.Importe), ref bytes);
			}

			bytes = HelperPrinter.SeparacionLinea(TipoLinea.GUION, ref bytes);
			bytes = HelperPrinter.TextoTotales($"SUB-TOTAL {(impresionFactura.Moneda == "S" ? "S/" : "$")}", impresionFactura.Gratuito + impresionFactura.Inafecto + impresionFactura.Exonerado + impresionFactura.Gravadas + impresionFactura.Exportacion, ref bytes);
			bytes = HelperPrinter.TextoTotales($"IGV  {(impresionFactura.Moneda == "S" ? "S/" : "$")}", impresionFactura.Igv, ref bytes);
			bytes = HelperPrinter.TextoTotales($"TOTAL  {(impresionFactura.Moneda == "S" ? "S/" : "$")}", impresionFactura.MontoTotal, ref bytes);
			bytes = HelperPrinter.SeparacionLinea(TipoLinea.BLANCO, ref bytes);
			bytes = HelperPrinter.TextoIzquierda($"SON: {NumLetra.Convertir(impresionFactura.MontoTotal.ToString("###0.#0", Formato), true)} {(impresionFactura.Moneda != "S" ? "DOLARES AMERICANOS" : "SOLES")}", ref bytes);

			if(impresionFactura.DescMedioPago.ToUpper() == "EFECTIVO")
			{
				bytes = HelperPrinter.SeparacionLinea(TipoLinea.BLANCO, ref bytes);
				bytes = HelperPrinter.TextoTotales($"{impresionFactura.DescMedioPago.ToUpper()} {(impresionFactura.Moneda == "S" ? "S/" : "$")}", impresionFactura.ImportePago, ref bytes);
				bytes = HelperPrinter.TextoTotales($"VUELTO {(impresionFactura.Moneda == "S" ? "S/" : "$")}", impresionFactura.Vuelto, ref bytes);
			}
			
			bytes = HelperPrinter.SeparacionLinea(TipoLinea.BLANCO, ref bytes);
			bytes = HelperPrinter.TextoCentrado("NO HAY DEVOLUCION DE DINERO. TODO CAMBIO DE", ref bytes);
			bytes = HelperPrinter.TextoCentrado("PRODUCTO Y/O SERVICIO SE HARA DENTRO DE LAS", ref bytes);
			bytes = HelperPrinter.TextoCentrado("24 HORAS PREVIA PRESENTACION DEL COMPROBANTE", ref bytes);
			bytes = HelperPrinter.TextoCentrado("VERIFICACION DEL CAJERO CENTRAL", ref bytes);
			bytes = HelperPrinter.SeparacionLinea(TipoLinea.BLANCO, ref bytes);
			bytes = HelperPrinter.TextoCentrado("Representacion Impresa de la Boleta de venta Electronica", ref bytes);
			bytes = HelperPrinter.TextoCentrado("Autorizada mediante resolucion:", ref bytes);
			bytes = HelperPrinter.TextoCentrado("Res. Int. 034-005-0005612/SUNAT", ref bytes);
			bytes = HelperPrinter.TextoCentrado("Este documento puede ser validado en:", ref bytes);
			bytes = HelperPrinter.TextoCentrado("https://www.nubefact.com/buscar", ref bytes);
			bytes = HelperPrinter.TextoCentrado($"Valor resumen: {impresionFactura.ResumenFirma}", ref bytes);
			bytes = HelperPrinter.SeparacionLinea(TipoLinea.BLANCO, ref bytes);
			bytes = HelperPrinter.Qr($"{impresionFactura.RucEmpresa}|01|{impresionFactura.Serie}|{impresionFactura.Numero}|{impresionFactura.Igv}|{impresionFactura.MontoTotal}|" +
				$"{impresionFactura.Fecha:yyyy-MM-dd}|{impresionFactura.TipoDocumentoCliente}|{impresionFactura.NumeroDocumentoCliente}|", ref bytes);
			bytes = HelperPrinter.CortaTicket(ref bytes);
			RawPrinterHelper.Printer(ConfigurationManager.AppSettings.Get("NombreImpresora"), bytes);

			var documento = await _siheContexto.RepositorioDocumento.Obtener(x => x.Serie == impresionFactura.Serie && x.Numero == impresionFactura.Numero && x.IdTipoDocumento == impresionFactura.IdTipoDocumento);
			documento.FechaModificacion = DateTime.Now;
			documento.UsuarioModificacion = impresionFactura.Usuario;

            //Validación Si el documento está enviado a SUNAT #3 o #5 ANULADO no realizar el cambio en la Bd a Impreso.

            if (documento.Estado != "3" && documento.Estado != "5")
            {
                documento.Estado = ((int)EstadoDocumento.Impreso).ToString();
            }

            //documento.Estado = ((int)EstadoDocumento.Impreso).ToString();
			documento.ResumenFirma = impresionFactura.ResumenFirma;
			await _siheContexto.CommitAsync();

		}

		public async Task NotaCredito(IImpresionDocumentoDTO documentoDTO)
		{

			var impresionFactura = documentoDTO as ImpresionNotaDTO;
			byte[] bytes = new byte[] { };
			bytes = HelperPrinter.TextoTitulo(impresionFactura.RazonSocialEmpresa, ref bytes);
			bytes = HelperPrinter.TextoCentrado(impresionFactura.DirecciónEmpresa, ref bytes);
			bytes = HelperPrinter.TextoCentrado($"{impresionFactura.Distrito} - {impresionFactura.Provincia}", ref bytes);
			bytes = HelperPrinter.TextoTitulo($"R.U.C. {impresionFactura.RucEmpresa}", ref bytes);
			bytes = HelperPrinter.TextoTitulo("NOTA DE CREDITO ELECTRONICA", ref bytes);
			bytes = HelperPrinter.TextoTitulo($"{impresionFactura.Serie}-{impresionFactura.Numero}", ref bytes);
			bytes = HelperPrinter.SeparacionLinea(TipoLinea.BLANCO, ref bytes);
			bytes = HelperPrinter.TextoIzquierda($"Cajero: {impresionFactura.Usuario}", ref bytes);
			bytes = HelperPrinter.TextoIzquierda($"Fecha: {impresionFactura.Fecha:dd/MM/yyyy}  Hora: {impresionFactura.Fecha:HH:mm:ss}", ref bytes);
			bytes = HelperPrinter.TextoIzquierda($"RUC: {impresionFactura.NumeroDocumentoCliente}", ref bytes);
			bytes = HelperPrinter.TextoIzquierda($"Sr(a): {impresionFactura.RazonSocialCliente}", ref bytes);
			bytes = HelperPrinter.TextoIzquierda($"Direccion: {impresionFactura.DireccionCliente}", ref bytes);
			if (impresionFactura.Cuotas.Count > 0)
			{
				bytes = HelperPrinter.TextoIzquierda("Forma de pago: Credito", ref bytes);

				foreach (var cuota in impresionFactura.Cuotas)
					bytes = HelperPrinter.TextoIzquierda($"       CUOTA {cuota.Numero} - {cuota.Fecha:dd/MM/yyyy} - {(impresionFactura.Moneda == "S" ? "S/" : "$")} {cuota.Monto}", ref bytes);
			}
			else
			{
				bytes = HelperPrinter.TextoIzquierda("Forma de pago: Contado", ref bytes);
			}
			bytes = HelperPrinter.TextoIzquierda($"Método de pago: {impresionFactura.DescMedioPago}", ref bytes);
			bytes = HelperPrinter.SeparacionLinea(TipoLinea.GUION, ref bytes);
			bytes = HelperPrinter.TextoExtremos("CONCEPTO", "CANT.   IMPORTE.", ref bytes);
			bytes = HelperPrinter.SeparacionLinea(TipoLinea.GUION, ref bytes);

			foreach (var item in impresionFactura.Detalles)
			{
				bytes = HelperPrinter.Texto3ColumnasDerecha(item.Descripcion, item.Cantidad.ToString(), Formateador.Numero(item.Importe), ref bytes);
			}

			bytes = HelperPrinter.SeparacionLinea(TipoLinea.GUION, ref bytes);
			bytes = HelperPrinter.TextoTotales($"SUB-TOTAL {(impresionFactura.Moneda == "S" ? "S/" : "$")}", impresionFactura.Gratuito + impresionFactura.Inafecto + impresionFactura.Exonerado + impresionFactura.Gravadas + impresionFactura.Exportacion, ref bytes);
			bytes = HelperPrinter.TextoTotales($"IGV  {(impresionFactura.Moneda == "S" ? "S/" : "$")}", impresionFactura.Igv, ref bytes);
			bytes = HelperPrinter.TextoTotales($"TOTAL  {(impresionFactura.Moneda == "S" ? "S/" : "$")}", impresionFactura.MontoTotal, ref bytes);
			bytes = HelperPrinter.SeparacionLinea(TipoLinea.BLANCO, ref bytes);
			bytes = HelperPrinter.TextoIzquierda($"SON: {NumLetra.Convertir(impresionFactura.MontoTotal.ToString("###0.#0", Formato), true)} {(impresionFactura.Moneda != "S" ? "DOLARES AMERICANOS" : "SOLES")}", ref bytes);
			bytes = HelperPrinter.SeparacionLinea(TipoLinea.BLANCO, ref bytes);

			var tipoDocumentoDesc = "";
			if (impresionFactura.TipoDocumentoModifica == "01") tipoDocumentoDesc = "FACTURA";
			else if (impresionFactura.TipoDocumentoModifica == "03") tipoDocumentoDesc = "BOLETA";

			bytes = HelperPrinter.TextoIzquierda($"Documento Modifica: {tipoDocumentoDesc}-{impresionFactura.DocumentoModifica}", ref bytes);
			bytes = HelperPrinter.TextoIzquierda($"Motivo: {impresionFactura.Motivo}", ref bytes);

			bytes = HelperPrinter.SeparacionLinea(TipoLinea.BLANCO, ref bytes);
			bytes = HelperPrinter.TextoCentrado("NO HAY DEVOLUCION DE DINERO. TODO CAMBIO DE", ref bytes);
			bytes = HelperPrinter.TextoCentrado("PRODUCTO Y/O SERVICIO SE HARA DENTRO DE LAS", ref bytes);
			bytes = HelperPrinter.TextoCentrado("24 HORAS PREVIA PRESENTACION DEL COMPROBANTE", ref bytes);
			bytes = HelperPrinter.TextoCentrado("VERIFICACION DEL CAJERO CENTRAL", ref bytes);
			bytes = HelperPrinter.SeparacionLinea(TipoLinea.BLANCO, ref bytes);
			bytes = HelperPrinter.TextoCentrado("Representacion Impresa de la Nota de credito Electronica", ref bytes);
			bytes = HelperPrinter.TextoCentrado("Autorizada mediante resolucion:", ref bytes);
			bytes = HelperPrinter.TextoCentrado("Res. Int. 034-005-0005612/SUNAT", ref bytes);
			bytes = HelperPrinter.TextoCentrado("Este documento puede ser validado en:", ref bytes);
			bytes = HelperPrinter.TextoCentrado("https://www.nubefact.com/buscar", ref bytes);
			bytes = HelperPrinter.TextoCentrado($"Valor resumen: {impresionFactura.ResumenFirma}", ref bytes);
			bytes = HelperPrinter.SeparacionLinea(TipoLinea.BLANCO, ref bytes);
			bytes = HelperPrinter.Qr($"{impresionFactura.RucEmpresa}|01|{impresionFactura.Serie}|{impresionFactura.Numero}|{impresionFactura.Igv}|{impresionFactura.MontoTotal}|" +
				$"{impresionFactura.Fecha:yyyy-MM-dd}|{impresionFactura.TipoDocumentoCliente}|{impresionFactura.NumeroDocumentoCliente}|", ref bytes);
			bytes = HelperPrinter.CortaTicket(ref bytes);
			RawPrinterHelper.Printer(ConfigurationManager.AppSettings.Get("NombreImpresora"), bytes);

			var documento = await _siheContexto.RepositorioDocumento.Obtener(x => x.Serie == impresionFactura.Serie && x.Numero == impresionFactura.Numero && x.IdTipoDocumento == impresionFactura.IdTipoDocumento);
			documento.FechaModificacion = DateTime.Now;
			documento.UsuarioModificacion = impresionFactura.Usuario;

            //Validación Si el documento está enviado a SUNAT #3 o #5 ANULADO no realizar el cambio en la Bd a Impreso.
            if (documento.Estado != "3" && documento.Estado != "5")
            {
                documento.Estado = ((int)EstadoDocumento.Impreso).ToString();
            }
            //documento.Estado = ((int)EstadoDocumento.Impreso).ToString();
			documento.ResumenFirma = impresionFactura.ResumenFirma;
			await _siheContexto.CommitAsync();

		}

		public async Task ReporteVenta(List<ObtenerDocumentoDTO> documentos, DateTime fechaInicio, DateTime fechafin, string cajero, string descMedioPago)
		{
			var configuracion = await _siheContexto.RepositorioConfiguracion.Obtener();
			byte[] bytes = new byte[] { };
			bytes = HelperPrinter.TextoTitulo(configuracion.RazonSocial, ref bytes);
			bytes = HelperPrinter.TextoCentrado(configuracion.Direccion, ref bytes);
			bytes = HelperPrinter.TextoCentrado($"{configuracion.Distrito} - {configuracion.Provincia}", ref bytes);
			bytes = HelperPrinter.SeparacionLinea(TipoLinea.BLANCO, ref bytes);
			bytes = HelperPrinter.TextoIzquierda($"Fecha: {DateTime.Now.ToString("dd/MM/yyyy", Formato)}", ref bytes);
			bytes = HelperPrinter.TextoIzquierda($"Hora: {DateTime.Now.ToString("HH:mm:ss", Formato)}", ref bytes);
			bytes = HelperPrinter.TextoCentrado($"CIERRE DE CAJA{(descMedioPago == "TODOS" ?  "" : $": {descMedioPago}")}", ref bytes);
			bytes = HelperPrinter.TextoCentrado($"Desde: {fechaInicio.ToString("dd/MM/yyyy", Formato)} Hasta: {fechafin.ToString("dd/MM/yyyy", Formato)}", ref bytes);
			bytes = HelperPrinter.SeparacionLinea(TipoLinea.BLANCO, ref bytes);
			bytes = HelperPrinter.TextoIzquierda($"Cajero: {cajero}", ref bytes);

			foreach (var item in documentos)
			{
				if (item.TipoDocumento == "07")
				{
					item.Detalles.Select(x => { x.PrecioTotal *= -1; x.Cantidad *= -1; return x; }).ToList();
				}
			}

			var detallesConceptoSoles = documentos.Where(x => x.Moneda == "S" &&
													  x.Estado != ((int)EstadoDocumento.Anulado).ToString() &&
													  x.Estado != ((int)EstadoDocumento.Baja_Aceptada).ToString() &&
													  x.Serie != "B002" &&
													  x.Serie != "F002")
				.SelectMany(o => o.Detalles)
				.ToList();

			var detallesConceptoSolesMedicamento = documentos.Where(x => x.Moneda == "S" &&
													  x.Estado != ((int)EstadoDocumento.Anulado).ToString() &&
													  x.Estado != ((int)EstadoDocumento.Baja_Aceptada).ToString() &&
													  (x.Serie == "B002" ||
													  x.Serie == "F002"))
				.SelectMany(o => o.Detalles)
				.ToList();

			if (detallesConceptoSoles.Count > 0 || detallesConceptoSolesMedicamento.Count > 0)
			{
				bytes = HelperPrinter.SeparacionLinea(TipoLinea.GUION, ref bytes);
				bytes = HelperPrinter.TextoExtremos("CONCEPTO", "CANT.   IMPORTE.", ref bytes);
				bytes = HelperPrinter.SeparacionLinea(TipoLinea.GUION, ref bytes);
			}

			var resultSoles = detallesConceptoSoles
				.GroupBy(x => x.CodigoProducto)
				.Select(x => new
				{
					Concepto = x.First().DescripcionProducto,
					Cantidad = x.Sum(c => c.Cantidad),
					Importe = x.Sum(t => t.PrecioTotal)
				});

			var cantidadMedicamentos = detallesConceptoSolesMedicamento.Select(x => x.Cantidad).Sum();
			var montoMedicamentos = detallesConceptoSolesMedicamento.Select(x => x.PrecioTotal).Sum();


			foreach (var item in resultSoles)
				bytes = HelperPrinter.Texto3ColumnasDerecha(item.Concepto, Formateador.Numero(item.Cantidad), (item.Importe < 0 ? "(-)" : "") + Formateador.Numero(Math.Abs(item.Importe)), ref bytes);

			if (montoMedicamentos > 0)
				bytes = HelperPrinter.Texto3ColumnasDerecha("MEDICAMENTOS", Formateador.Numero(cantidadMedicamentos), (montoMedicamentos < 0 ? "(-)" : "") + Formateador.Numero(Math.Abs(montoMedicamentos)), ref bytes);

			if (detallesConceptoSoles.Count > 0 || detallesConceptoSolesMedicamento.Count > 0)
			{
				bytes = HelperPrinter.SeparacionLinea(TipoLinea.GUION, ref bytes);
				bytes = HelperPrinter.Texto3ColumnasDerecha("TOTAL S/", Formateador.Numero(resultSoles.Select(x => x.Cantidad).Sum() + cantidadMedicamentos), Formateador.Numero(resultSoles.Select(x => x.Importe).Sum() + montoMedicamentos), ref bytes);
				bytes = HelperPrinter.SeparacionLinea(TipoLinea.BLANCO, ref bytes);
			}


			var detallesConceptoDolares = documentos.Where(x => x.Moneda == "D" &&
												x.Estado != ((int)EstadoDocumento.Anulado).ToString() &&
												x.Estado != ((int)EstadoDocumento.Baja_Aceptada).ToString() &&
												x.Serie != "B002" &&
												x.Serie != "F002")
				.SelectMany(o => o.Detalles)
				.ToList();

			var detallesConceptoDolaresMedicamento = documentos.Where(x => x.Moneda == "D" &&
													  x.Estado != ((int)EstadoDocumento.Anulado).ToString() &&
													  x.Estado != ((int)EstadoDocumento.Baja_Aceptada).ToString() &&
													  (x.Serie == "B002" ||
													  x.Serie == "F002"))
				.SelectMany(o => o.Detalles)
				.ToList();

			if (detallesConceptoDolares.Count > 0 || detallesConceptoDolaresMedicamento.Count > 0)
			{
				bytes = HelperPrinter.SeparacionLinea(TipoLinea.GUION, ref bytes);
				bytes = HelperPrinter.TextoExtremos("CONCEPTO", "CANT.   IMPORTE.", ref bytes);
				bytes = HelperPrinter.SeparacionLinea(TipoLinea.GUION, ref bytes);
			}

			var resultDolares = detallesConceptoDolares
				.GroupBy(x => x.CodigoProducto)
				.Select(x => new
				{
					Concepto = x.First().DescripcionProducto,
					Cantidad = x.Sum(c => c.Cantidad),
					Importe = x.Sum(t => t.PrecioTotal)
				});

			cantidadMedicamentos = detallesConceptoDolaresMedicamento.Select(x => x.Cantidad).Sum();
			montoMedicamentos = detallesConceptoDolaresMedicamento.Select(x => x.PrecioTotal).Sum();

			foreach (var item in resultDolares)
				bytes = HelperPrinter.Texto3ColumnasDerecha(item.Concepto, Formateador.Numero(item.Cantidad), (item.Importe < 0 ? "(-)" : "") + Formateador.Numero(Math.Abs(item.Importe)), ref bytes);

			if (montoMedicamentos > 0)
				bytes = HelperPrinter.Texto3ColumnasDerecha("MEDICAMENTOS", Formateador.Numero(cantidadMedicamentos), (montoMedicamentos < 0 ? "(-)" : "") + Formateador.Numero(Math.Abs(montoMedicamentos)), ref bytes);


			if (detallesConceptoDolares.Count > 0)
			{
				bytes = HelperPrinter.SeparacionLinea(TipoLinea.GUION, ref bytes);
				bytes = HelperPrinter.Texto3ColumnasDerecha("TOTAL $", Formateador.Numero(resultDolares.Select(x => x.Cantidad).Sum() + cantidadMedicamentos), Formateador.Numero(resultDolares.Select(x => x.Importe).Sum() + montoMedicamentos), ref bytes);
				bytes = HelperPrinter.SeparacionLinea(TipoLinea.BLANCO, ref bytes);
			}


			//SOLES
			var detallesResumenSoles = documentos
				.Where(x => x.Moneda == "S" && x.Estado != ((int)EstadoDocumento.Anulado).ToString() && x.Estado != ((int)EstadoDocumento.Baja_Aceptada).ToString())
				.GroupBy(x => new { x.Serie, x.TipoDocumento })
				.Select(x => new
				{
					Descripcion = $"Ventas {ObtenerDescripcionTipoDocumento(x.First().TipoDocumento)} serie {x.First().Serie}",
					Cantidad = x.Count(),
					Importe = x.Sum(t => t.MontoTotal),
					TipoDocumento = x.First().TipoDocumento
				});

			var detallesResumenAnuladosSoles = documentos
				.Where(x => x.Moneda == "S" && (x.Estado == ((int)EstadoDocumento.Anulado).ToString() || x.Estado == ((int)EstadoDocumento.Baja_Aceptada).ToString()))
				.GroupBy(x => x.Serie)
				.Select(x => new
				{
					Descripcion = $"Anulado {ObtenerDescripcionTipoDocumento(x.First().TipoDocumento)} serie {x.First().Serie}",
					Cantidad = x.Count(),
					Importe = x.Sum(t => t.MontoTotal),
					TipoDocumento = x.First().TipoDocumento
				});

			if (detallesResumenSoles.Count() > 0 || detallesResumenAnuladosSoles.Count() > 0)
			{
				bytes = HelperPrinter.SeparacionLinea(TipoLinea.GUION, ref bytes);
				bytes = HelperPrinter.TextoExtremos("RESUMEN", "CANT.   MONTOS.", ref bytes);
				bytes = HelperPrinter.SeparacionLinea(TipoLinea.GUION, ref bytes);
			}

			foreach (var item in detallesResumenSoles)
			{
				bytes = HelperPrinter.Texto3ColumnasDerecha(item.Descripcion, item.Cantidad.ToString(), (item.TipoDocumento == "07" ? "(-)" : "") + Formateador.Numero(item.Importe), ref bytes);
			}

			foreach (var item in detallesResumenAnuladosSoles)
			{
				bytes = HelperPrinter.Texto3ColumnasDerecha(item.Descripcion, item.Cantidad.ToString(), (item.TipoDocumento != "07" ? "(-)" : "") + Formateador.Numero(item.Importe), ref bytes);
			}

			if (detallesResumenSoles.Count() > 0 || detallesResumenAnuladosSoles.Count() > 0)
			{
				bytes = HelperPrinter.SeparacionLinea(TipoLinea.GUION, ref bytes);
				bytes = HelperPrinter.TextoExtremos("VENTAS GENERALES S/",
					Formateador.Numero(detallesResumenSoles.Sum(x => x.TipoDocumento != "07" ? x.Importe : x.Importe * -1)), ref bytes);
				bytes = HelperPrinter.SeparacionLinea(TipoLinea.BLANCO, ref bytes);
			}


			//DOLARES
			var detallesResumenDolares = documentos
				.Where(x => x.Moneda == "D" && x.Estado != ((int)EstadoDocumento.Anulado).ToString() && x.Estado != ((int)EstadoDocumento.Baja_Aceptada).ToString())
				.GroupBy(x => new { x.Serie, x.TipoDocumento })
				.Select(x => new
				{
					Descripcion = $"Ventas {ObtenerDescripcionTipoDocumento(x.First().TipoDocumento)} serie {x.First().Serie}",
					Cantidad = x.Count(),
					Importe = x.Sum(t => t.MontoTotal),
					TipoDocumento = x.First().TipoDocumento
				});

			var detallesResumenAnuladosDolares = documentos
				.Where(x => x.Moneda == "D" && (x.Estado == ((int)EstadoDocumento.Anulado).ToString() || x.Estado == ((int)EstadoDocumento.Baja_Aceptada).ToString()))
				.GroupBy(x => x.Serie)
				.Select(x => new
				{
					Descripcion = $"Anulado {ObtenerDescripcionTipoDocumento(x.First().TipoDocumento)} serie {x.First().Serie}",
					Cantidad = x.Count(),
					Importe = x.Sum(t => t.MontoTotal),
					TipoDocumento = x.First().TipoDocumento
				});

			if (detallesResumenDolares.Count() > 0 || detallesResumenAnuladosDolares.Count() > 0)
			{
				bytes = HelperPrinter.SeparacionLinea(TipoLinea.GUION, ref bytes);
				bytes = HelperPrinter.TextoExtremos("RESUMEN", "CANT.   MONTOS.", ref bytes);
				bytes = HelperPrinter.SeparacionLinea(TipoLinea.GUION, ref bytes);
			}

			foreach (var item in detallesResumenDolares)
			{
				bytes = HelperPrinter.Texto3ColumnasDerecha(item.Descripcion, item.Cantidad.ToString(), (item.TipoDocumento == "07" ? "(-)" : "") + Formateador.Numero(item.Importe), ref bytes);
			}

			foreach (var item in detallesResumenAnuladosDolares)
			{
				bytes = HelperPrinter.Texto3ColumnasDerecha(item.Descripcion, item.Cantidad.ToString(), (item.TipoDocumento != "07" ? "(-)" : "") + Formateador.Numero(item.Importe), ref bytes);
			}

			if (detallesResumenDolares.Count() > 0 || detallesResumenAnuladosDolares.Count() > 0)
			{
				bytes = HelperPrinter.SeparacionLinea(TipoLinea.GUION, ref bytes);
				bytes = HelperPrinter.TextoExtremos("VENTAS GENERALES $",
					Formateador.Numero(detallesResumenDolares.Sum(x => x.TipoDocumento != "07" ? x.Importe : x.Importe * -1)), ref bytes);
				bytes = HelperPrinter.SeparacionLinea(TipoLinea.BLANCO, ref bytes);
			}

			bytes = HelperPrinter.SeparacionLinea(TipoLinea.GUION, ref bytes);
			bytes = HelperPrinter.CortaTicket(ref bytes);
			RawPrinterHelper.Printer(ConfigurationManager.AppSettings.Get("NombreImpresora"), bytes);
		}

		private string ObtenerDescripcionTipoDocumento(string tipoDocumento)
		{
			switch (tipoDocumento)
			{
				case "01":
					return "FACTURA";
				case "03":
					return "BOLETA";
				case "07":
					return "NOTA CREDITO";
				case "08":
					return "NOTA DEBITO";
				default:
					return "";
			}
		}
	}
}
