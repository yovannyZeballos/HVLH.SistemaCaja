using HVLH.SistemaCaja.Comun;
using HVLH.SistemaCaja.Modelo;
using HVLH.SistemaCaja.Repositorio.Contextos;
using HVLH.SistemaCaja.Repositorio.Contratos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Repositorio.Impl
{
	public class RepositorioDocumento : RepositorioGenerico<SiheContexto, Documento>, IRepositorioDocumento
	{
		public RepositorioDocumento(SiheContexto siheContexto) : base(siheContexto)
		{
		}

		public SiheContexto SiheContexto
		{
			get { return _siheContexto; }
		}

		public async Task<Documento> Obtener(int id)
		{
			return await _siheContexto.Documentos
				.Include(x => x.Detalles)
				.Include(x => x.Cuotas)
				.Include(x => x.MedioPagoDocumento)
				.FirstOrDefaultAsync(o => o.Id == id);
		}

		public async Task<List<Documento>> ListarxTipo(string[] tipos)
		{
			var tipoDocumentos = await _siheContexto.RepositorioTipoDocumento.Listar();
			int[] tiposDocumentos = tipoDocumentos.Where(x => tipos.Contains(x.Codigo)).Select(x => x.Id).ToArray();

			return await _siheContexto.Documentos
				.Include(x => x.Detalles)
				.Include(x => x.MedioPagoDocumento)
				.Where(x => tiposDocumentos.Contains(x.IdTipoDocumento)).ToListAsync();
		}

		public async Task<List<Documento>> Listar(string tipoDocumento, string nroDocumento, DateTime fechaInicio, DateTime fechaFin, string usuario, int IdTipoMedioPago)
		{
			
            _siheContexto.Database.SetCommandTimeout(120);
            var tipoDocumentos = await _siheContexto.RepositorioTipoDocumento.Obtener(x => x.Codigo == tipoDocumento);
			var idTipoDocumento = tipoDocumentos == null ? 0 : tipoDocumentos.Id;


			return await _siheContexto.Documentos
			.Include(x => x.Detalles)
			.Include(x => x.Cuotas)
			.Include(x => x.MedioPagoDocumento)
			.Where(x => ((x.IdTipoDocumento == idTipoDocumento && idTipoDocumento > 0) || idTipoDocumento == 0) &&
						(((x.Serie + "-" + x.Numero.ToString()).Contains(nroDocumento) && nroDocumento != "") || nroDocumento == "") &&
						((x.UsuarioCreacion == usuario && usuario != "0") || usuario == "0") &&
						((x.MedioPagoDocumento.IdTipoMedioPago == IdTipoMedioPago && IdTipoMedioPago > 0) || IdTipoMedioPago == 0) &&
						 x.Fecha.Date >= fechaInicio.Date && x.Fecha.Date <= fechaFin.Date).ToListAsync();
		}

		public async Task<bool> ExisteDocumentoUsuario(string login)
		{
			return await _siheContexto.Documentos.AnyAsync(x => x.UsuarioCreacion == login);
		}

		public async Task<List<Documento>> ListarDocumentosParaResumen(DateTime fechaEmision)
		{
			var tipoDocumentos = await _siheContexto.RepositorioTipoDocumento.Listar();
			int idDocumentoBoleta = tipoDocumentos.FirstOrDefault(x => x.Codigo == "03").Id;
			int idDocumentoNC = tipoDocumentos.FirstOrDefault(x => x.Codigo == "07").Id;

			return await _siheContexto.Documentos
				.Include(x => x.Detalles)
				.Where(x => (x.IdTipoDocumento == idDocumentoBoleta || (x.IdTipoDocumento == idDocumentoNC && x.TipoDocumentoReferencia == "03")) &&
							x.Fecha.Date == fechaEmision.Date &&
							(x.Estado == ((int)EstadoDocumento.Generado).ToString() || x.Estado == ((int)EstadoDocumento.Impreso).ToString() || (x.Estado == ((int)EstadoDocumento.Anulado).ToString() && x.Enviado)) &&
							!_siheContexto.ResumenDetalles.Include(rd => rd.Resumen).Any(rd => rd.IdDocumento == x.Id && rd.Estado == EstadoResumenDetalle.Anular && rd.Resumen.Estado != EstadoResumen.Rechazado))
				.ToListAsync();
		}

		public async Task<List<Documento>> ListarDocumentosParaComunicacionBaja(DateTime fechaEmision)
		{
			var tipoDocumentos = await _siheContexto.RepositorioTipoDocumento.Listar();
			int idDocumentoFactura = tipoDocumentos.FirstOrDefault(x => x.Codigo == "01").Id;
			int idDocumentoNC = tipoDocumentos.FirstOrDefault(x => x.Codigo == "07").Id;

			return await _siheContexto.Documentos
				.Include(x => x.Detalles)
				.Where(x => (x.IdTipoDocumento == idDocumentoFactura || (x.IdTipoDocumento == idDocumentoNC && x.TipoDocumentoReferencia == "01")) &&
							x.Fecha.Date == fechaEmision.Date &&
							(x.Estado == ((int)EstadoDocumento.Anulado).ToString() && x.Enviado) &&
							!_siheContexto.ComunicacionBajaDetalles.Include(rd => rd.ComunicacionBaja).Any(rd => rd.IdDocumento == x.Id && rd.ComunicacionBaja.Estado != EstadoResumen.Rechazado))
				.ToListAsync();
		}

		public async Task<bool> ExisteDetalle(Expression<Func<DocumentoDetalle, bool>> predicado)
		{
			return await _siheContexto.DocumentoDetalles.AnyAsync(predicado);
		}

		public async Task<Documento> InsertarDocumento(Documento documento)
		{
			var numeroParam = new Microsoft.Data.SqlClient.SqlParameter("@Numero", SqlDbType.BigInt) { Direction = ParameterDirection.Output };
			var idParam = new Microsoft.Data.SqlClient.SqlParameter("@Id", SqlDbType.Int) { Direction = ParameterDirection.Output };
			var resultadoParam = new Microsoft.Data.SqlClient.SqlParameter("@Resultado", SqlDbType.Int) { Direction = ParameterDirection.Output };
			var mensajeParam = new Microsoft.Data.SqlClient.SqlParameter("@Mensaje", SqlDbType.VarChar) { Direction = ParameterDirection.Output, Size = 500 };

			await _siheContexto.Database.ExecuteSqlInterpolatedAsync($"exec usp_Caja_InsertarVentaCabecera {documento.IdTipoDocumento},{documento.IdTipoDocumentoSerie},{documento.Serie},{documento.Fecha},{documento.TipoOperacion},{documento.TipoDocumentoCliente},{documento.NumeroDocumentoCliente},{documento.RazonSocialCliente},{documento.Moneda},{documento.Igv},{documento.Gravadas},{documento.Exportacion},{documento.Inafecto},{documento.Exonerado},{documento.Gratuito},{documento.TotalPrecioVenta},{documento.TotalValorVenta},{documento.MontoTotal},{documento.FormaPago},{documento.Estado},{documento.NroPreventa},{documento.HoraParqueo},{documento.ResumenFirma},{documento.TipoNota},{documento.NroDocumentoReferencia},{documento.TipoDocumentoReferencia},{documento.FechaDocumentoReferencia},{documento.Enviado},{documento.BajaEnviada},{documento.UsuarioCreacion},{numeroParam} out,{idParam} out,{resultadoParam} out,{mensajeParam} out");

			int? resultado = Convert.ToInt32(resultadoParam.Value);
			int? id = Convert.ToInt32(idParam.Value);
			long? numero = Convert.ToInt32(numeroParam.Value);
			string mensaje = mensajeParam.Value.ToString();

			if (resultado != 0)
				throw new Exception(mensaje);

			return new Documento
			{
				Id =id.Value,
				Numero = numero.Value
			};
		}

	}
}
