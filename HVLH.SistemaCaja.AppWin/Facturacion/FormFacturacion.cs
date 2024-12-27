using HVLH.SistemaCaja.AppWin.Helpers;
using HVLH.SistemaCaja.AppWin.IoC;
using HVLH.SistemaCaja.Servicio.Contratos;
using HVLH.SistemaCaja.Servicio.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using HVLH.SistemaCaja.Comun;
using System.Text;
using HVLH.SistemaCaja.AppWin.Validaciones;
using FluentValidation;
using HVLH.Facturacion.Comun.Datos.Modelos;
using System.IO;
using HVLH.Facturacion.Comun.Datos.Intercambio;

namespace HVLH.SistemaCaja.AppWin.Facturacion
{
	public partial class FormFacturacion : FormBase
	{
		#region . Variables .
		private readonly IServicioPreventa _servicioPreventa;
		private readonly IServicioTipoDocumento _servicioTipoDocumento;
		private readonly IServicioTipoDocumentoSerie _servicioTipoDocumentoSerie;
		private readonly IServicioFacturacion _servicioFacturacion;
		private readonly IServicioConfiguracion _servicioConfiguracion;
		private readonly IServicioTipoOperacion _servicioTipoOperacion;
		private readonly IServicioTipoMedioPago _servicioTipoMedioPago;
		private readonly IServicioCatalogoServicio _servicioCatalogoServicio;
		private readonly IServicioImpresion _servicioImpresion;
		private readonly IServicioXml _servicioXml;
		private readonly IServicioReniec _servicioReniec;
		private readonly IServicioSunat _servicioSunat;
		private readonly IServicioUsuario _servicioUsuario;
		private readonly IServicioPaciente _servicioPaciente;
		private readonly IServicioDocumento _servicioDocumento;
		private ObtenerConfiguracionDTO _configuracion;
		private string _resumenFirma;
		private List<CuotaDTO> _cuotas = new List<CuotaDTO>();
		#endregion

		#region . Propiedades .
		public int IdDocumento { private get; set; }
		public TipoSerie TipoSerie { get; set; } = TipoSerie.Electronico;
		public TipoDocumento TipoDocumento { get; set; } = TipoDocumento.Factura;
		private DateTime Fecha
		{
			get { return txtFecha.Value; }
			set { txtFecha.Value = value; }
		}

		private string Numero
		{
			get { return txtNumero.Text; }
			set { txtNumero.Text = value; }
		}

		private string TipoIgv
		{
			get { return txtTipoIGV.Text; }
			set { txtTipoIGV.Text = value; }
		}

		private string NroPreventa
		{
			get { return txtNroPreventa.Text; }
			set { txtNroPreventa.Text = value; }
		}

		private string RucCliente
		{
			get { return txtRucCliente.Text; }
			set { txtRucCliente.Text = value; }
		}

		private string NombreCliente
		{
			get { return txtNombreCliente.Text; }
			set { txtNombreCliente.Text = value; }

		}

		private string Subtotal
		{
			get { return txtSubtotal.Text; }
			set { txtSubtotal.Text = value; }
		}

		private string Igv
		{
			get { return txtIgv.Text; }
			set { txtIgv.Text = value; }
		}

		private string NoGravado
		{
			get { return txtNoGravado.Text; }
			set { txtNoGravado.Text = value; }
		}

		private string Icpber
		{
			get { return txtIcpber.Text; }
			set { txtIcpber.Text = value; }
		}

		private string TotalVenta
		{
			get { return txtTotalVenta.Text; }
			set { txtTotalVenta.Text = value; }
		}

		private string Efectivo
		{
			get { return txtEfectivo.Text; }
			set { txtEfectivo.Text = value; }
		}

		private string Vuelto
		{
			get { return txtVuelto.Text; }
			set { txtVuelto.Text = value; }
		}

		private string Moneda
		{
			get { return cboMoneda.SelectedValue.ToString(); }
			set { cboMoneda.SelectedValue = value; }
		}

		private int IdTipoDocumentoSerie
		{
			get { return Convert.ToInt32(cboSerie.SelectedValue); }
			set { cboMoneda.SelectedValue = value; }
		}

		private string TipoOperacion
		{
			get { return cboTipoOperacion.SelectedValue?.ToString(); }
			set { cboTipoOperacion.SelectedValue = value; }

		}
		private string Serie
		{
			get
			{
				var tipoDocumentoSerie = cboSerie.SelectedItem as ListarTipoDocumentoSerieDTO;
				return tipoDocumentoSerie?.Serie;
			}
		}

		private int FormaPago
		{
			get
			{
				var medioPago = cboTipoMedioPago.SelectedItem as ListarTipoMedioPagoDTO;
				return medioPago.FormaPago;
			}
		}

		private int IdTipoDocumento
		{
			get
			{
				var tipoDocumento = cboTipoDocumento.SelectedItem as ListarTipoDocumentoDTO;
				return tipoDocumento.Id;
			}
		}


		private int IdTipoMedioPago
		{
			get { return Convert.ToInt32(cboTipoMedioPago.SelectedValue); }
			set { cboTipoMedioPago.SelectedValue = value; }

		}

		private string HoraParqueo
		{
			get { return txtHoraParqueo.Text; }
			set { txtHoraParqueo.Text = value; }
		}

		private string TipoDocIdentidad
		{
			get { return cboTipoDocIdentidad.SelectedValue.ToString(); }
			set { cboTipoDocIdentidad.SelectedValue = value ?? ""; }
		}

		private string DescTipoMedioPago
		{
			get { return cboTipoMedioPago.Text; }

		}

		private DateTime? FechaReferencia
		{
			get { return txtFechaReferencia.Value; }
			set { txtFechaReferencia.Value = (DateTime)value; }
		}

		private string NumeroReferencia
		{
			get { return txtNumeroReferencia.Text; }
			set { txtNumeroReferencia.Text = value; }
		}

		private string TipoDocumentoReferencia
		{
			get { return cboTipoReferencia.SelectedValue?.ToString(); }
			set { cboTipoReferencia.SelectedValue = value; }
		}

		private string TipoNota
		{
			get { return cboTipoNota.SelectedValue?.ToString(); }
			set { cboTipoNota.SelectedValue = value; }
		}

		private string MotivoDescripcion
		{
			get { return cboTipoNota.Text; }

		}
		#endregion

		#region . Constructor .
		public FormFacturacion()
		{
			InitializeComponent();
			_servicioPreventa = InstanceFactory.GetInstance<IServicioPreventa>();
			_servicioTipoDocumento = InstanceFactory.GetInstance<IServicioTipoDocumento>();
			_servicioTipoDocumentoSerie = InstanceFactory.GetInstance<IServicioTipoDocumentoSerie>();
			_servicioFacturacion = InstanceFactory.GetInstance<IServicioFacturacion>();
			_servicioConfiguracion = InstanceFactory.GetInstance<IServicioConfiguracion>();
			_servicioTipoOperacion = InstanceFactory.GetInstance<IServicioTipoOperacion>();
			_servicioTipoMedioPago = InstanceFactory.GetInstance<IServicioTipoMedioPago>();
			_servicioCatalogoServicio = InstanceFactory.GetInstance<IServicioCatalogoServicio>();
			_servicioImpresion = InstanceFactory.GetInstance<IServicioImpresion>();
			_servicioXml = InstanceFactory.GetInstance<IServicioXml>();
			_servicioReniec = InstanceFactory.GetInstance<IServicioReniec>();
			_servicioUsuario = InstanceFactory.GetInstance<IServicioUsuario>();
			_servicioSunat = InstanceFactory.GetInstance<IServicioSunat>();
			_servicioPaciente = InstanceFactory.GetInstance<IServicioPaciente>();
			_servicioDocumento = InstanceFactory.GetInstance<IServicioDocumento>();
		}
		#endregion

		#region . Metodos .
		private async Task<bool> ValidarUsuarioCajero()
		{
			var usuario = await _servicioUsuario.Obtener(AppInfo.IdUsuario);
			if (!usuario.EsCajero)
			{
				MostrarMensajes.Advertencia($"El usuario {AppInfo.Usuario} no esta configurado como Cajero");
				Close();
				return false;

			}

			return true;

		}

		private async Task ListarTipoDocumento()
		{
			try
			{
				var tipoDocumentos = await _servicioTipoDocumento.Listar();
				tipoDocumentos = tipoDocumentos.Where(X => X.Codigo == ((int)TipoDocumento).ToString().PadLeft(2, '0')).ToList();
				cboTipoDocumento.DisplayMember = "Descripcion";
				cboTipoDocumento.ValueMember = "Codigo";
				cboTipoDocumento.DataSource = tipoDocumentos;
				cboTipoDocumento.SelectedValue = ((int)TipoDocumento).ToString().PadLeft(2, '0');
			}
			catch (Exception ex)
			{
				MostrarMensajes.DetalleError(ex);
			}


		}

		private async Task ObtenerPreventa()
		{
			try
			{
				if (!ValidarPreventa()) return;

				Loading.Mostrar();
				var preventa = await _servicioPreventa.Obtener(NroPreventa);
				Loading.Cerrar();

				LimpiarTotales();
				LimpiarDetalles();

				if (preventa.Count > 0)
				{
					var cabecera = preventa.First();
					RucCliente = cabecera.NroDocCliente;
					NombreCliente = cabecera.NombresPaciente;
					TipoDocIdentidad = cabecera.TipoDocCliente.ToString();
					Fecha = DateTime.Now;
					Subtotal = Formateador.Numero(Math.Round(cabecera.MontoTotal - cabecera.IgvTotal, 2));
					Igv = Formateador.Numero(Math.Round(cabecera.IgvTotal, 2));
					TotalVenta = Formateador.Numero(Math.Round(cabecera.MontoTotal, 2));

					int item = 1;

					foreach (var detalle in preventa)
					{
						dgvDetalle.Rows.Add(item, detalle.CodProducto, detalle.DescripcionProducto, Formateador.Numero(detalle.Cantidad), detalle.UnidadMedida,
							 Formateador.Numero(detalle.PorcentajeIgv), Formateador.Numero(detalle.PrecioUnitario), Formateador.Numero(detalle.Igv),
							Formateador.Numero(detalle.PrecioTotal), detalle.TipoIgv, "");
						item++;
					}
					txtNroPreventa.Enabled=false;
					//MessageBox.Show("Hay datos de preventa...!","Mensaje",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				}
               
            }
			catch (Exception ex)
			{
				Loading.Cerrar();
				MostrarMensajes.DetalleError(ex);
			}

		}

		private async Task ListarSeries(int idTipoDocumento)
		{
			try
			{
				var series = await _servicioTipoDocumentoSerie.Listar(idTipoDocumento);
				series = series.Where(x => x.Tipo == ((int)TipoSerie).ToString()).ToList();

				cboSerie.DisplayMember = "Serie";
				cboSerie.ValueMember = "Id";
				cboSerie.DataSource = series;

			}
			catch (Exception ex)
			{
				Loading.Cerrar();
				MostrarMensajes.DetalleError(ex);
			}

		}

		private void CargarMoneda()
		{
			cboMoneda.DisplayMember = "Text";
			cboMoneda.ValueMember = "Value";

			var items = new[] {
				new { Text = "SOLES", Value = "S" },
				new { Text = "DOLARES", Value = "D" }
			};

			cboMoneda.DataSource = items;
		}

		private void CargarTipoDocumentoIdentidad()
		{
			cboTipoDocIdentidad.DisplayMember = "Text";
			cboTipoDocIdentidad.ValueMember = "Value";

			var items = new[] {
				new { Text = "RUC", Value = "6" },
				new { Text = "DOC.TRIB.NO.DOM.SIN.RUC", Value = "0" },
				new { Text = "DNI", Value = "1" },
				new { Text = "Carnet de extranjería", Value = "4" },
				new { Text = "Pasaporte", Value = "7" },
				new { Text = "Cédula Diplomática de identidad", Value = "A" },
				new { Text = "DOC.IDENT.PAIS.RESIDENCIA-NO.D", Value = "B" },
				new { Text = "Tax Identification Number - TIN – Doc Trib PP.NN", Value = "C" },
				new { Text = "Identification Number - IN – Doc Trib PP. JJ", Value = "D" },
				new { Text = "TAM- Tarjeta Andina de Migración ", Value = "E" },
				new { Text = "Permiso Temporal de Permanencia - PTP", Value = "F" },
				new { Text = "Salvoconducto", Value = "G" },
				new { Text = "Carné Permiso Temp.Perman. - CPP", Value = "H" },

			};

			cboTipoDocIdentidad.DataSource = items;

			if (TipoDocumento == TipoDocumento.Factura)
				cboTipoDocIdentidad.SelectedValue = "6";
			else if (TipoDocumento == TipoDocumento.Boleta)
				cboTipoDocIdentidad.SelectedValue = "1";
		}

		private async Task<InsertarDocumentoDTO> ObtenerDatos()
		{
			var insertarDocumentoDTO = new InsertarDocumentoDTO
			{
				Moneda = Moneda,
				Estado = ((int)EstadoDocumento.Generado).ToString(),
				FormaPago = FormaPago.ToString(),
				Fecha = Fecha,
				Gravadas = Conversion.Decimal(Subtotal),
				IdTipoDocumentoSerie = IdTipoDocumentoSerie,
				Serie = Serie,
				Igv = Conversion.Decimal(Igv),
				MontoTotal = Conversion.Decimal(TotalVenta),
				Inafecto = Conversion.Decimal(NoGravado),
				NroPreventa = NroPreventa,
				RazonSocialCliente = NombreCliente.Trim(),
				NumeroDocumentoCliente = RucCliente,
				TipoOperacion = TipoOperacion,
				Usuario = AppInfo.Usuario,
				MedioPago = new MedioPagoDocumentoDTO
				{
					Importe = Conversion.Decimal(Efectivo),
					Diferencia = Conversion.Decimal(Vuelto),
					IdTipoMedioPago = IdTipoMedioPago
				},
				IdTipoDocumento = IdTipoDocumento,
				HoraParqueo = HoraParqueo,
				TipoDocumentoCliente = TipoDocIdentidad,
				TotalPrecioVenta = Conversion.Decimal(TotalVenta),
				NroDocumentoReferencia = NumeroReferencia,
				TipoDocumentoReferencia = TipoDocumentoReferencia,
				FechaDocumentoReferencia = string.IsNullOrEmpty(NumeroReferencia) ? null : FechaReferencia,
				TipoNota = TipoNota
			};

			insertarDocumentoDTO.TotalValorVenta = insertarDocumentoDTO.Gravadas + insertarDocumentoDTO.Inafecto;
			insertarDocumentoDTO.DirecionCliente = await ObtenerDireccionCLiente(RucCliente, TipoDocIdentidad);
			insertarDocumentoDTO.Detalle = new List<DocumentoDetalleDTO>();
			insertarDocumentoDTO.Citas = new List<DocumentoCitaDTO>();

			foreach (DataGridViewRow row in dgvDetalle.Rows)
			{
				var detalle = new DocumentoDetalleDTO();
				detalle.Item = Convert.ToInt32(row.Cells["ColItem"].Value);
				detalle.Cantidad = Conversion.Decimal(row.Cells["ColCantidad"].Value.ToString());
				detalle.CodigoProducto = row.Cells["ColCodigo"].Value.ToString();
				detalle.DescripcionProducto = row.Cells["ColDescripcion"].Value.ToString();
				detalle.Igv = Conversion.Decimal(row.Cells["ColIgv"].Value.ToString());
				detalle.TipoIgv = row.Cells["ColTipoAfectacion"].Value.ToString();
				detalle.UnidadMedida = row.Cells["ColUnidad"].Value.ToString();
				detalle.PrecioVentaUnitario = Conversion.Decimal(row.Cells["ColPrecioUnit"].Value.ToString());
				var porcentajeIGV = Conversion.Decimal(row.Cells["ColPorcentajeIgv"].Value.ToString());
				detalle.ValorUnitario = (detalle.PrecioVentaUnitario / (1 + (porcentajeIGV / 100.00m)));
				detalle.ValorVenta = Conversion.Decimal(row.Cells["ColPrecioTotal"].Value.ToString()) - detalle.Igv;
				detalle.Total = Conversion.Decimal(row.Cells["ColPrecioTotal"].Value.ToString());
				detalle.PorcentajeIgv = porcentajeIGV;
				detalle.PrecioTotal = Conversion.Decimal(row.Cells["ColPrecioTotal"].Value.ToString());
				insertarDocumentoDTO.Detalle.Add(detalle);


				// Cita
				var idCita = row.Cells["ColIdCita"].Value.ToString();
				if (!string.IsNullOrEmpty(idCita))
				{
					insertarDocumentoDTO.Citas.Add(new DocumentoCitaDTO { IdCita = idCita });
				}
			}

			insertarDocumentoDTO.Cuotas = _cuotas;

			return insertarDocumentoDTO;
		}

		private async Task GuardarVenta()
		{
			try
			{
				if (!ValidarPreventa()) return;

				var documento = await ObtenerDatos();

				if (!Validar(documento)) return;

				Loading.Mostrar();
				var numero = await _servicioFacturacion.InsertarVenta(documento);
				Loading.Cerrar();

				MostrarMensajes.Informacion(string.Format(Constantes.MENSAJE_REGISTRO_DOCUMENTO, TipoDocumento.ToString().Replace("_", " "), $"{documento.Serie}-{numero}"));
				Numero = numero.ToString();
				BloquearCabecera(false);
				BloquearDetalle(false);
				btnGuardarVenta.Enabled = false;
				btnImprimir.Enabled = true;


				toolStrip1.Focus();
				btnImprimir.Select();
			}
			catch (Exception ex)
			{
				Loading.Cerrar();
				MostrarMensajes.DetalleError(ex);
			}
		}

		private bool ValidarPreventa()
		{

			if (NroPreventa.StartsWith("F", StringComparison.OrdinalIgnoreCase) && (Serie == "B001" || Serie == "F001"))
			{
				MostrarMensajes.Advertencia("La serie seleccionada no es valida - Medicamentos B002");
				return false;
			}

			if (!NroPreventa.StartsWith("F", StringComparison.OrdinalIgnoreCase) && (Serie == "B002" || Serie == "F002"))
			{
				MostrarMensajes.Advertencia("La serie seleccionada no es valida - Solo se puede anexar Medicamentos en la serie 2");
				return false;
			}

			return true;
		}

		private async Task ObtenerConfiguracion()
		{
			try
			{
				_configuracion = await _servicioConfiguracion.Obtener();
			}
			catch (Exception ex)
			{
				Loading.Cerrar();
				MostrarMensajes.DetalleError(ex);
			}
		}

		private async Task ListarTipoOperacion()
		{
			try
			{
				var tipoOperacion = await _servicioTipoOperacion.Listar(((int)TipoDocumento).ToString().PadLeft(2, '0'));
				cboTipoOperacion.DisplayMember = "Descripcion";
				cboTipoOperacion.ValueMember = "Codigo";
				cboTipoOperacion.DataSource = tipoOperacion;
				cboTipoOperacion.SelectedValue = _configuracion.TipoOperacion;
			}
			catch (Exception ex)
			{
				MostrarMensajes.DetalleError(ex);
			}

		}

		private async Task ListarTiposMedioPago()
		{
			try
			{
				var tipos = await _servicioTipoMedioPago.Listar();
				cboTipoMedioPago.DisplayMember = "Descripcion";
				cboTipoMedioPago.ValueMember = "Id";
				cboTipoMedioPago.DataSource = tipos;
				cboTipoMedioPago.SelectedValue = tipos.FirstOrDefault().Id;
			}
			catch (Exception ex)
			{
				MostrarMensajes.DetalleError(ex);
			}

		}

		private void BloquearCabecera(bool enabled)
		{
			splitContainer1.Panel1.Enabled = enabled;
			btnCuotas.Enabled = enabled;
		}

		private void BloquearDetalle(bool enabled)
		{
			splitContainer1.Panel2.Enabled = enabled;
		}

		private bool Validar(InsertarDocumentoDTO insertarDocumentoDTO)
		{
			var ok = true;
			var validator = new InsertarDocumentoValidator();
			var results = validator.Validate(insertarDocumentoDTO);
			var failures = results.Errors;
			var mensajes = new StringBuilder();

			if (!results.IsValid)
			{
				foreach (var failure in failures)
				{
					mensajes.AppendLine(failure.ErrorMessage);
					ok = false;
				}
			}

			int tamañoNroDocumento = RucCliente.Length;

			switch (TipoDocIdentidad)
			{
				case "1":
					if (tamañoNroDocumento != 8)
					{
						mensajes.AppendLine("El DNI ingresado debe tener 8 digitos");
						ok = false;
					}
					break;
				case "6":
					if (tamañoNroDocumento != 11)
					{
						mensajes.AppendLine("El RUC ingresado debe tener 11 digitos");
						ok = false;
					}
					break;
				default:
					break;
			}


			if (TipoDocumento == TipoDocumento.Factura || TipoDocumento == TipoDocumento.Boleta)
			{
				if (insertarDocumentoDTO.MedioPago.Importe == 0)
				{
					mensajes.AppendLine("Debe ingresar el importe pagado por el cliente");
					ok = false;
				}

				if (insertarDocumentoDTO.MontoTotal == 0)
				{
					mensajes.AppendLine("El total de venta no puede ser 0");
					ok = false;
				}

				if (insertarDocumentoDTO.MedioPago.Importe < insertarDocumentoDTO.MontoTotal)
				{
					mensajes.AppendLine("El importe pagado por el cliente es menor al total del documento");
					ok = false;
				}

				if (TipoDocumento == TipoDocumento.Factura)
				{
					if (TipoDocIdentidad == "1")
					{
						mensajes.AppendLine("El tipo de documento debe ser RUC");
						ok = false;
					}
				}
			}

			if (TipoDocumento == TipoDocumento.Nota_de_Credito)
			{
				if (string.IsNullOrEmpty(TipoNota))
				{
					mensajes.AppendLine("Debe seleccionar el tipo de nota");
					ok = false;
				}

				if (TipoNota != "10")
				{
					if (string.IsNullOrEmpty(NumeroReferencia))
					{
						mensajes.AppendLine("Debe ingresar el numero del documento de referencia");
						ok = false;
					}

					if (string.IsNullOrEmpty(TipoDocumentoReferencia))
					{
						mensajes.AppendLine("Debe seleccionar el tipo del docuemento de referencia");
						ok = false;
					}
				}
			}

			if (cboFormaPago.SelectedValue.ToString() == "2"
				&& _cuotas.Count == 0)
			{
				mensajes.AppendLine("Si la forma de pago es al crédito, debe ingresar las cuotas");
				ok = false;
			}

			if (!ok)
				MostrarMensajes.Advertencia(mensajes.ToString());

			return ok;
		}

		private void CargarTipoIGV()
		{

			ColTipoAfectacion.DisplayMember = "Text";
			ColTipoAfectacion.ValueMember = "Value";

			var items = new[] {
				new { Text = "Gravado - Operación Onerosa", Value = "10" },
				new { Text = "Inafecto - Operación Onerosa", Value = "30" }
			};

			ColTipoAfectacion.DataSource = items;
		}

		private void Totalizar()
		{
			decimal igv = 0;
			decimal noGravado = 0;
			decimal gravado = 0;
			foreach (DataGridViewRow row in dgvDetalle.Rows)
			{
				string tipoIgv = row.Cells["ColTipoAfectacion"].Value?.ToString();

				igv += Convert.ToDecimal(string.IsNullOrEmpty(row.Cells["ColIgv"].Value.ToString()) ? "0" : row.Cells["ColIgv"].Value);

				if (tipoIgv == "10")
					gravado += Convert.ToDecimal(string.IsNullOrEmpty(row.Cells["ColPrecioTotal"].Value.ToString()) ? "0" : row.Cells["ColPrecioTotal"].Value);
				else
					noGravado += Convert.ToDecimal(string.IsNullOrEmpty(row.Cells["ColPrecioTotal"].Value.ToString()) ? "0" : row.Cells["ColPrecioTotal"].Value);
			}

			decimal total = gravado + noGravado;
			gravado = gravado - igv;
			Subtotal = Formateador.Numero(gravado);
			NoGravado = Formateador.Numero(noGravado);
			Igv = Formateador.Numero(igv);
			TotalVenta = Formateador.Numero(total);

		}

		private async Task ObtenerProducto()
		{
			try
			{
				var fila = dgvDetalle.Rows[dgvDetalle.CurrentCell.RowIndex];
				var codigo = fila.Cells["ColCodigo"].Value?.ToString();

				if (string.IsNullOrEmpty(codigo)) return;

				Loading.Mostrar();
				var producto = await _servicioCatalogoServicio.Obtener(codigo);
				Loading.Cerrar();
                if (producto == null) return;

                //MessageBox.Show(producto.Codigo.ToString());
                // Códigos No Permitidos cobrar Directo:
                //List<int> codigosNoPermitidos = new List<int> { 4583, 4835 };

				List<int> codigosNoPermitidos = new List<int> {
						4583, 4835, 6076, 50407, 50639, 51078, 51077,51074, 51073, 51107, 4351, 4051, 
						4580, 4372,	4395, 50092, 50264, 50617, 50084, 4374, 51133,50011, 4586,50320,
                        4054,4055,4061,4401,5823,6077,50018,50262,50329

                };

                if (codigosNoPermitidos.Contains(producto.IdProducto))
                {
                    if (string.IsNullOrEmpty(this.txtNroPreventa.Text))
                    {
                        MostrarMensajes.Advertencia("Para pagar este tipo de servicio el Paciente debe tener una cita - Consulte en Módulos de Citas o Admisión (CSM)");
						//VALIDAR
                        return;
                    }
                }

				var porcentajeIGV = producto.TipoIgv == "10" ? _configuracion.IGV : 0;  //Convert.ToDecimal(fila.Cells["ColPorcentajeIgv"].Value);
				if (fila.Index == -1) return;
				var cantidad = Convert.ToDecimal(fila.Cells["ColCantidad"].Value);

				var total = producto.Precio * cantidad;
				var igv = total - ((total) / (1 + (porcentajeIGV / 100.00M)));

				dgvDetalle.Rows[fila.Index].Cells["ColCodigo"].Value = producto.Codigo;
				dgvDetalle.Rows[fila.Index].Cells["ColDescripcion"].Value = producto.Descripcion;
				dgvDetalle.Rows[fila.Index].Cells["ColUnidad"].Value = producto.UnidadMedida;
				dgvDetalle.Rows[fila.Index].Cells["ColPrecioUnit"].Value = producto.Precio;
				dgvDetalle.Rows[fila.Index].Cells["ColIgv"].Value = Math.Round(igv, 2);
				dgvDetalle.Rows[fila.Index].Cells["ColPrecioTotal"].Value = Math.Round(total, 2);
				dgvDetalle.Rows[fila.Index].Cells["ColTipoAfectacion"].Value = producto.TipoIgv;
				dgvDetalle.Rows[fila.Index].Cells["ColPorcentajeIgv"].Value = porcentajeIGV;
			}
			catch (Exception ex)
			{
				Loading.Cerrar();
				MostrarMensajes.DetalleError(ex);
			}

		}

		private void ReclacularMontos(int rowIndex)
		{
			var colCantidad = dgvDetalle.Rows[rowIndex].Cells["ColCantidad"];
			var colPrecioUnit = dgvDetalle.Rows[rowIndex].Cells["ColPrecioUnit"];
			var colPorcentajeIgv = dgvDetalle.Rows[rowIndex].Cells["ColPorcentajeIgv"];
			//var colPrecioTotal = dgvDetalle.CurrentRow.Cells["ColPrecioTotal"];

			decimal cantidad = string.IsNullOrEmpty(colCantidad.Value?.ToString()) ? 1 : Convert.ToDecimal(colCantidad.Value);
			decimal precioUnitario = string.IsNullOrEmpty(colPrecioUnit.Value?.ToString()) ? 0 : Convert.ToDecimal(colPrecioUnit.Value);
			decimal porcentajeIgv = string.IsNullOrEmpty(colPorcentajeIgv.Value?.ToString()) ? 0 : Convert.ToDecimal(colPorcentajeIgv.Value);
			decimal precioTotal = Math.Round(precioUnitario * cantidad, 2);
			decimal igv = Math.Round(precioTotal - ((precioTotal) / (1 + (porcentajeIgv / 100.00M))), 2);

			dgvDetalle.Rows[rowIndex].Cells["ColCantidad"].Value = cantidad;
			dgvDetalle.Rows[rowIndex].Cells["ColPrecioUnit"].Value = precioUnitario;
			dgvDetalle.Rows[rowIndex].Cells["ColPrecioTotal"].Value = precioTotal;
			dgvDetalle.Rows[rowIndex].Cells["ColIgv"].Value = igv;

		}

		private void ReordenarItems()
		{
			if (dgvDetalle.Rows.Count == 0) return;

			int item = 1;
			foreach (DataGridViewRow row in dgvDetalle.Rows)
			{
				row.Cells[0].Value = item;
				item++;
			}

			dgvDetalle.Rows[item - 2].Cells["ColCodigo"].Selected = true;
			dgvDetalle.BeginEdit(true);
		}

		private void Limpiar()
		{
			Numero = "";
			Fecha = DateTime.Now;
			NroPreventa = "";
			RucCliente = "";
			NombreCliente = "";
			HoraParqueo = "";
			NumeroReferencia = "";
			cboTipoMedioPago.SelectedIndex = 0;
			LimpiarTotales();
			LimpiarDetalles();
			_cuotas.Clear();
		}

		private void LimpiarTotales()
		{
			Subtotal = "0.00";
			Igv = "0.00";
			NoGravado = "0.00";
			TotalVenta = "0.00";
			Efectivo = "0.00";
			Vuelto = "0.00";
		}

		private void LimpiarDetalles()
		{
			dgvDetalle.Rows.Clear();
		}

		private void EliminarDetalle()
		{
			var fila = dgvDetalle.CurrentRow;
			dgvDetalle.Rows.Remove(fila);
		}

		private async Task Imprimir()
		{
			try
			{
				Loading.Mostrar();
				IImpresionDocumentoDTO documnentoImpresion = null;

				var insertarDocumentoDTO = await ObtenerDatos();

				var resumenFirma = "";
				if (IdDocumento > 0)
					resumenFirma = _resumenFirma;
				else
					resumenFirma = GenerarXml(insertarDocumentoDTO);

				if (TipoDocumento == TipoDocumento.Factura || TipoDocumento == TipoDocumento.Boleta)
				{
					documnentoImpresion = new ImpresionFacturaDTO
					{
						DirecciónEmpresa = _configuracion.Direccion,
						Exonerado = insertarDocumentoDTO.Exonerado,
						Exportacion = insertarDocumentoDTO.Exportacion,
						Fecha = insertarDocumentoDTO.Fecha,
						FechaVencimiento = insertarDocumentoDTO.Fecha,
						FormaPago = insertarDocumentoDTO.FormaPago,
						Gratuito = insertarDocumentoDTO.Gratuito,
						Gravadas = insertarDocumentoDTO.Gravadas,
						HoraParqueo = insertarDocumentoDTO.HoraParqueo,
						Igv = insertarDocumentoDTO.Igv,
						Inafecto = insertarDocumentoDTO.Inafecto,
						Moneda = insertarDocumentoDTO.Moneda,
						MontoTotal = insertarDocumentoDTO.MontoTotal,
						Numero = Convert.ToInt32(Numero),
						NumeroDocumentoCliente = insertarDocumentoDTO.NumeroDocumentoCliente,
						RazonSocialCliente = insertarDocumentoDTO.RazonSocialCliente,
						DireccionCliente = insertarDocumentoDTO.DirecionCliente,
						RazonSocialEmpresa = _configuracion.RazonSocial,
						RucEmpresa = _configuracion.Ruc,
						Serie = insertarDocumentoDTO.Serie,
						TipoDocumentoCliente = insertarDocumentoDTO.TipoDocumentoCliente,
						Usuario = AppInfo.Usuario,
						Distrito = _configuracion.Distrito,
						Provincia = _configuracion.Provincia,
						IdTipoDocumento = insertarDocumentoDTO.IdTipoDocumento,
						ResumenFirma = resumenFirma,
						DescMedioPago = DescTipoMedioPago,
						ImportePago = insertarDocumentoDTO.MedioPago.Importe,
						Vuelto = insertarDocumentoDTO.MedioPago.Diferencia,
						Referencia = insertarDocumentoDTO.NroPreventa,
						Detalles = insertarDocumentoDTO.Detalle.Select(x => new DetalleImpresionDTO { Cantidad = x.Cantidad, Descripcion = x.DescripcionProducto, Importe = x.Total }).ToList(),
						Cuotas = _cuotas
					};

					if (TipoDocumento == TipoDocumento.Factura)
						await _servicioImpresion.Factura(documnentoImpresion);
					else if (TipoDocumento == TipoDocumento.Boleta)
						await _servicioImpresion.Boleta(documnentoImpresion);
				}
				else if (TipoDocumento == TipoDocumento.Nota_de_Credito)
				{
					documnentoImpresion = new ImpresionNotaDTO
					{
						DirecciónEmpresa = _configuracion.Direccion,
						Exonerado = insertarDocumentoDTO.Exonerado,
						Exportacion = insertarDocumentoDTO.Exportacion,
						Fecha = insertarDocumentoDTO.Fecha,
						FechaVencimiento = insertarDocumentoDTO.Fecha,
						FormaPago = insertarDocumentoDTO.FormaPago,
						Gratuito = insertarDocumentoDTO.Gratuito,
						Gravadas = insertarDocumentoDTO.Gravadas,
						HoraParqueo = insertarDocumentoDTO.HoraParqueo,
						Igv = insertarDocumentoDTO.Igv,
						Inafecto = insertarDocumentoDTO.Inafecto,
						Moneda = insertarDocumentoDTO.Moneda,
						MontoTotal = insertarDocumentoDTO.MontoTotal,
						Numero = Convert.ToInt32(Numero),
						NumeroDocumentoCliente = insertarDocumentoDTO.NumeroDocumentoCliente,
						RazonSocialCliente = insertarDocumentoDTO.RazonSocialCliente,
						DireccionCliente = insertarDocumentoDTO.DirecionCliente,
						RazonSocialEmpresa = _configuracion.RazonSocial,
						RucEmpresa = _configuracion.Ruc,
						Serie = insertarDocumentoDTO.Serie,
						TipoDocumentoCliente = insertarDocumentoDTO.TipoDocumentoCliente,
						Usuario = AppInfo.Usuario,
						Distrito = _configuracion.Distrito,
						Provincia = _configuracion.Provincia,
						IdTipoDocumento = insertarDocumentoDTO.IdTipoDocumento,
						ResumenFirma = resumenFirma,
						DescMedioPago = DescTipoMedioPago,
						ImportePago = insertarDocumentoDTO.MedioPago.Importe,
						Vuelto = insertarDocumentoDTO.MedioPago.Diferencia,
						DocumentoModifica = NumeroReferencia,
						TipoDocumentoModifica = TipoDocumentoReferencia,
						Motivo = MotivoDescripcion,
						Detalles = insertarDocumentoDTO.Detalle.Select(x => new DetalleImpresionDTO { Cantidad = x.Cantidad, Descripcion = x.DescripcionProducto, Importe = x.Total }).ToList(),
						Cuotas = _cuotas
					};

					await _servicioImpresion.NotaCredito(documnentoImpresion);
				}

				Loading.Cerrar();

				toolStrip1.Focus();
				btnImprimir.Select();
			}
			catch (Exception ex)
			{
				MostrarMensajes.DetalleError(ex);
				Loading.Cerrar();
			}
		}

		private string GenerarXml(InsertarDocumentoDTO insertarDocumentoDTO)
		{
			try
			{
				var documentoElectronico = new DocumentoElectronico
				{
					Emisor = new Contribuyente
					{
						Departamento = _configuracion.Departamento,
						Direccion = _configuracion.Direccion,
						Distrito = _configuracion.Distrito,
						Provincia = _configuracion.Provincia,
						Pais = "PE",
						NombreComercial = _configuracion.RazonSocial,
						NombreLegal = _configuracion.RazonSocial,
						NroDocumento = _configuracion.Ruc,
						TipoDocumento = "6",
						Ubigeo = _configuracion.Ubigeo
					},
					Exoneradas = insertarDocumentoDTO.Exonerado,
					Gravadas = insertarDocumentoDTO.Gravadas,
					Exportaciones = insertarDocumentoDTO.Exportacion,
					Inafectas = insertarDocumentoDTO.Inafecto,
					Gratuitas = insertarDocumentoDTO.Gratuito,
					IdDocumento = $"{insertarDocumentoDTO.Serie}-{Numero}",
					TipoDocumento = ((int)TipoDocumento).ToString().PadLeft(2, '0'),
					FechaEmision = insertarDocumentoDTO.Fecha.ToString("yyyy-MM-dd"),
					FechaVencimiento = insertarDocumentoDTO.Fecha.ToString("yyyy-MM-dd"),
					HoraEmision = insertarDocumentoDTO.Fecha.ToString("HH:mm:ss"),
					TipoOperacion = insertarDocumentoDTO.TipoOperacion,
					TotalVenta = insertarDocumentoDTO.MontoTotal,
					Moneda = insertarDocumentoDTO.Moneda == "S" ? "PEN" : "USD",
					Receptor = new Contribuyente
					{
						NroDocumento = insertarDocumentoDTO.NumeroDocumentoCliente,
						NombreComercial = insertarDocumentoDTO.RazonSocialCliente,
						NombreLegal = insertarDocumentoDTO.RazonSocialCliente,
						TipoDocumento = insertarDocumentoDTO.TipoDocumentoCliente
					},
					TotalIgv = insertarDocumentoDTO.Igv,
					TotalPrecioVenta = insertarDocumentoDTO.TotalPrecioVenta,
					TotalValorVenta = insertarDocumentoDTO.TotalValorVenta,
				};

				if (insertarDocumentoDTO.Cuotas.Count == 0) //Contado
				{
					documentoElectronico.FormaPagos = new List<FormaPago>
					{
						new FormaPago
						{
							Id = "Contado",
						}
					};
				}
				else
				{
					documentoElectronico.FormaPagos = new List<FormaPago>
					{
						new FormaPago
						{
							Id = "Credito",
							Monto = insertarDocumentoDTO.MontoTotal
						}
					};

					foreach (var cuota in insertarDocumentoDTO.Cuotas)
					{
						documentoElectronico.FormaPagos.Add(new FormaPago
						{
							Id = $"Cuota{cuota.Numero:000}",
							FechaVencimiento = cuota.Fecha.ToString("yyyy-MM-dd"),
							Monto = cuota.Monto
						});
					}
				}

				documentoElectronico.Items = new List<DetalleDocumento>();

				foreach (var item in insertarDocumentoDTO.Detalle)
				{
					documentoElectronico.Items.Add(new DetalleDocumento
					{
						CalculoIgv = item.PorcentajeIgv,
						Cantidad = item.Cantidad,
						CodigoItem = item.CodigoProducto,
						Descripcion = item.DescripcionProducto,
						Id = item.Item,
						Impuesto = item.Igv,
						PrecioVentaUnitario = item.PrecioVentaUnitario,
						TipoPrecio = "01",
						TipoImpuesto = item.TipoIgv,
						UnidadMedida = item.UnidadMedida,
						ValorUnitario = item.ValorUnitario,
						ValorVenta = item.ValorVenta
					});
				}

				documentoElectronico.Discrepancias = new List<Discrepancia>
				{
					new Discrepancia
					{
						Descripcion = MotivoDescripcion,
						NroReferencia = NumeroReferencia,
						Tipo = TipoNota
					}
				};

				documentoElectronico.Relacionados = new List<DocumentoRelacionado>
				{
					new DocumentoRelacionado
					{
						TipoDocumento = TipoDocumentoReferencia,
						NroDocumento = NumeroReferencia
					}
				};


				FirmadoResponse firmadoResponse = null;

				if (documentoElectronico.TipoDocumento == "01" || documentoElectronico.TipoDocumento == "03")
				{
					firmadoResponse = _servicioXml.Factura(new GenerarXmlDTO
					{
						CertificadoDigital = Convert.ToBase64String(File.ReadAllBytes(_configuracion.RutaCertificado)),
						PasswordCertificado = _configuracion.ClaveCertificado,
						Ruta = $"{_configuracion.CarpetaDocumentos}/XML",
						Documento = documentoElectronico
					});
				}
				else if (documentoElectronico.TipoDocumento == "07")
				{
					firmadoResponse = _servicioXml.NotaCredito(new GenerarXmlDTO
					{
						CertificadoDigital = Convert.ToBase64String(File.ReadAllBytes(_configuracion.RutaCertificado)),
						PasswordCertificado = _configuracion.ClaveCertificado,
						Ruta = $"{_configuracion.CarpetaDocumentos}/XML",
						Documento = documentoElectronico
					});
				}

				return firmadoResponse.ResumenFirma;

			}
			catch (Exception ex)
			{
				MostrarMensajes.DetalleError(ex);
			}

			return "";

		}

		private void CargarTipoNotaCredito()
		{
			cboTipoNota.DisplayMember = "Text";
			cboTipoNota.ValueMember = "Value";

			var items = new[] {
				new { Text = "Anulación de la operación", Value = "01" },
				new { Text = "Anulación por error en el RUC", Value = "02" },
				new { Text = "Corrección por error en la descripción", Value = "03" },
				new { Text = "Descuento global", Value = "04" },
				new { Text = "Descuento por ítem", Value = "05" },
				new { Text = "Devolución total", Value = "06" },
				new { Text = "Devolución por ítem", Value = "07" },
				new { Text = "Bonificación", Value = "08" },
				new { Text = "Disminución en el valor", Value = "09" },
				new { Text = "Otros Conceptos ", Value = "10" },
				new { Text = "Ajustes de operaciones de exportación", Value = "11" },
				new { Text = "Ajustes afectos al IVAP", Value = "12" },
				new { Text = "Corrección o modificación del monto neto pendiente de pago", Value = "13" },
			};

			cboTipoNota.DataSource = items;
		}

		private void CargarTipoDocumentoReferencia()
		{
			cboTipoReferencia.DisplayMember = "Text";
			cboTipoReferencia.ValueMember = "Value";

			var items = new[] {
				new { Text = "FACTURA", Value = "01" },
				new { Text = "BOLETA", Value = "03" },
			};

			cboTipoReferencia.DataSource = items;
		}

		private async Task<string> ObtenerDireccionCLiente(string nroDocumento, string tipoDocumento)
		{
			return await _servicioPaciente.ObtenerDireccion(nroDocumento, tipoDocumento);
		}

		private async Task ConsultarDocumento()
		{
			var documento = await _servicioDocumento.Obtener(IdDocumento);

			RucCliente = documento.NumeroDocumentoCliente;
			NombreCliente = documento.RazonSocialCliente;
			TipoDocIdentidad = documento.TipoDocumentoCliente;
			Fecha = documento.Fecha;
			Subtotal = Formateador.Numero(documento.Gravadas);
			NoGravado = Formateador.Numero(documento.Inafecto);
			Igv = Formateador.Numero(Math.Round(documento.Igv, 2));
			TotalVenta = Formateador.Numero(Math.Round(documento.MontoTotal, 2));
			Moneda = documento.Moneda;
			NroPreventa = documento.NroPreventa;
			Numero = documento.Numero.ToString();
			cboSerie.Text = documento.Serie;
			TipoOperacion = documento.TipoOperacion ?? "";
			HoraParqueo = documento.HoraParqueo;
			TipoNota = documento.TipoNota;
			TipoDocumentoReferencia = documento.TipoDocumentoReferencia;
			NumeroReferencia = documento.NroDocumentoReferencia;
			FechaReferencia = documento.FechaDocumentoReferencia ?? txtFechaReferencia.MinDate;
			IdTipoMedioPago = documento.MedioPagoDocumento.IdTipoMedioPago;
			Efectivo = Formateador.Numero(documento.MedioPagoDocumento.Importe);
			Vuelto = Formateador.Numero(documento.MedioPagoDocumento.Diferencia);
			_cuotas = documento.Cuotas.ToList();

			int item = 1;

			foreach (var detalle in documento.Detalles)
			{
				dgvDetalle.Rows.Add(item, detalle.CodigoProducto, detalle.DescripcionProducto, Formateador.Numero(detalle.Cantidad), detalle.UnidadMedida,
					 Formateador.Numero(detalle.PorcentajeIgv), Formateador.Numero(detalle.PrecioVentaUnitario), Formateador.Numero(detalle.Igv),
					Formateador.Numero(detalle.PrecioTotal), detalle.TipoIgv, "");
				item++;
			}

			BloquearCabecera(false);
			BloquearDetalle(false);
			btnGuardarVenta.Enabled = false;
			btnImprimir.Enabled = true;
			btnNuevaVenta.Enabled = false;
			lblTipoIGV.Visible = false;
			txtTipoIGV.Visible = false;
			btnCuotas.Enabled = true;

			if (_cuotas.Count > 0)
			{
				cboFormaPago.SelectedIndex = 1;
			}

			switch (TipoDocumento)
			{
				case TipoDocumento.None:
					break;
				case TipoDocumento.Factura:
					Text = $"FACTURA N° {documento.Serie}-{documento.Numero}";
					break;
				case TipoDocumento.Boleta:
					Text = $"BOLETA N° {documento.Serie}-{documento.Numero}";
					break;
				case TipoDocumento.Nota_de_Credito:
					Text = $"NOTA DE CREDITO N° {documento.Serie}-{documento.Numero}";
					break;
				default:
					break;
			}

			_resumenFirma = documento.ResumenFirma;

		}

		private void BloquerFecha()
		{
			if (TipoSerie == TipoSerie.Manual)
				txtFecha.Enabled = true;
			else
				txtFecha.Enabled = false;
		}
		#endregion

		#region . Eventos .
		private async void FormFacturacion_Load(object sender, EventArgs e)
		{
			await ListarTipoDocumento();
			CargarMoneda();
			CargarTipoDocumentoIdentidad();
			CargarTipoIGV();
			CargarFormaPago();
			await ObtenerConfiguracion();
			await ListarTipoOperacion();
			await ListarTiposMedioPago();

			if (TipoDocumento == TipoDocumento.Nota_de_Credito)
			{
				CargarTipoNotaCredito();
				CargarTipoDocumentoReferencia();
				lblTipoNota.Visible = true;
				cboTipoNota.Visible = true;
				gbDocumentoReferencia.Visible = true;
				txtEfectivo.Visible = false;
				txtVuelto.Visible = false;
				cboTipoMedioPago.Visible = false;
				lblVuelto.Visible = false;
				cboTipoOperacion.Visible = false;
				lblTipoOperacion.Visible = false;
			}

			if (TipoDocumento == TipoDocumento.Boleta)
			{
				cboFormaPago.Enabled = false;
				btnCuotas.Enabled = false;
			}

			if (IdDocumento == 0)
			{
				if (!await ValidarUsuarioCajero())
					return;

				Fecha = DateTime.Now;

				if (TipoSerie == TipoSerie.Manual && TipoDocumento == TipoDocumento.Factura)
				{
					lblTipoIGV.Visible = false;
					txtTipoIGV.Visible = false;
				}
			}
			else
			{
				await ConsultarDocumento();
			}

			BloquerFecha();

		}

		private async void TxtNroPreventa_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				await ObtenerPreventa();
			}
		}

		private async void CboTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
		{
			await ListarSeries(IdTipoDocumento);
		}

		private void TxtEfectivo_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				try
				{
					var totalVenta = Convert.ToDecimal(TotalVenta.Replace(",", ""));
					if (string.IsNullOrWhiteSpace(Efectivo))
					{
						Efectivo = "0";
					}
					var efectivo = Convert.ToDecimal(Efectivo.Trim().Replace(",", ""));
					Vuelto = Formateador.Numero(efectivo - totalVenta);
					txtEfectivo.Text = Formateador.Numero(efectivo);
					toolStrip1.Focus();
					btnGuardarVenta.Select();
				}
				catch (Exception ex)
				{
					MostrarMensajes.DetalleError(ex);
				}
			}

		}

		private async void BtnGuardarVenta_Click(object sender, EventArgs e)
		{
			await GuardarVenta();

		}

		private void TxtEfectivo_Leave(object sender, EventArgs e)
		{
			try
			{
				var totalVenta = Convert.ToDecimal(TotalVenta.Replace(",", ""));
				var efectivo = Convert.ToDecimal(Efectivo.Replace(",", ""));
				Vuelto = Formateador.Numero(efectivo - totalVenta);
				txtEfectivo.Text = Formateador.Numero(efectivo);

			}
			catch (Exception ex)
			{
				MostrarMensajes.DetalleError(ex);
			}
		}

		private void TxtEfectivo_KeyPress(object sender, KeyPressEventArgs e)
		{
            // Verificar si el TextBox contiene "0.00" y se presiona una tecla diferente a control
            if ((sender as TextBox).Text == "0.00" && !char.IsControl(e.KeyChar))
            {
                (sender as TextBox).Text = "";
            }

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
			{
				e.Handled = true;
			}

			// only allow one decimal point
			if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
			{
				e.Handled = true;
			}
		}

		private async void BtnImprimir_Click(object sender, EventArgs e)
		{

			await Imprimir();
		}

		private void DgvDetalle_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
		{
			if (dgvDetalle.CurrentCell.ColumnIndex == dgvDetalle.Columns["ColPrecioUnit"].Index
				|| dgvDetalle.CurrentCell.ColumnIndex == dgvDetalle.Columns["ColCantidad"].Index) //Desired Column
			{
				var tb = e.Control as TextBox;
				if (tb != null)
				{
					e.Control.KeyPress -= new KeyPressEventHandler(Cell_KeyPress);
					tb.KeyPress += new KeyPressEventHandler(Cell_KeyPress);
				}
			}

			if (e.Control is DataGridViewComboBoxEditingControl)
			{
				var cbec = e.Control as DataGridViewComboBoxEditingControl;
				cbec = e.Control as DataGridViewComboBoxEditingControl;
				cbec.SelectedIndexChanged -= CboTipoIgv_SelectedIndexChanged;
				cbec.SelectedIndexChanged += CboTipoIgv_SelectedIndexChanged;
			}

			if (dgvDetalle.CurrentCell.ColumnIndex == dgvDetalle.Columns["ColCodigo"].Index) //Desired Column
			{
				var tb = e.Control as TextBox;
				if (tb != null)
				{
					e.Control.KeyUp -= new KeyEventHandler(Cell_KeyUp);
					tb.KeyUp += new KeyEventHandler(Cell_KeyUp);
				}

			}
		}

		private void Cell_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (dgvDetalle.CurrentCell.ColumnIndex == dgvDetalle.Columns["ColPrecioUnit"].Index
				|| dgvDetalle.CurrentCell.ColumnIndex == dgvDetalle.Columns["ColCantidad"].Index)
			{
				if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
				{
					e.Handled = true;
				}

				if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
				{
					e.Handled = true;
				}
			}
		}

		private async void DgvDetalle_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == 1) //Codigo
			{
				await ObtenerProducto();

			}
			else if (e.ColumnIndex == 3 || e.ColumnIndex == 6)
			{
				ReclacularMontos(e.RowIndex);

			}

			Totalizar();
		}

		private void BtnAgregar_Click(object sender, EventArgs e)
		{
			dgvDetalle.Rows.Add(0, "", "", 1, "", _configuracion.IGV, "", "", "", "10", "");
			ReordenarItems();
		}

		private void CboTipoIgv_SelectedIndexChanged(object sender, EventArgs e)
		{
			var d = sender;
			var combo = (DataGridViewComboBoxEditingControl)sender;
			if (combo.SelectedValue == null) return;
			string tipoIgv = combo.SelectedValue?.ToString();
			dgvDetalle.CurrentRow.Cells["ColPorcentajeIgv"].Value = tipoIgv == "10" ? _configuracion.IGV : 0;
			dgvDetalle.CurrentRow.Cells["ColTipoAfectacion"].Value = tipoIgv;
			ReclacularMontos(dgvDetalle.CurrentRow.Index);
			Totalizar();
		}

		private void BtnEliminar_Click(object sender, EventArgs e)
		{
			if (dgvDetalle.CurrentCell == null)
			{
				MostrarMensajes.Advertencia("Debe seleccionar un registro");
				return;
			}

			if (MostrarMensajes.Pregunta("¿Está seguro de eliminar el registro?") == DialogResult.Cancel) return;


			EliminarDetalle();
			ReordenarItems();
			dgvDetalle.EndEdit();
			Totalizar();
		}

		private async void Cell_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F1)
			{
				if (dgvDetalle.CurrentCell.ColumnIndex == dgvDetalle.Columns["ColCodigo"].Index)
				{
					var formListado = new FormListadoProducto();
					formListado.ShowDialog();
					dgvDetalle.CurrentCell.Value = formListado.Producto?.Codigo;
					await ObtenerProducto();
					Totalizar();
				}
			}
		}

		private void BtnNuevaVenta_Click(object sender, EventArgs e)
		{
			Limpiar();
			LimpiarDetalles();
			LimpiarTotales();
			txtNroPreventa.Enabled = true;
			btnGuardarVenta.Enabled = true;
			btnImprimir.Enabled = false;
			BloquearCabecera(true);
			BloquearDetalle(true);
			txtNroPreventa.Focus();

		}

		private void BtnSalir_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void BtnBuscarDocumento_Click(object sender, EventArgs e)
		{
			var formDocumentos = new FormListadoDocumentosNC();
			formDocumentos.TipoDocSeleccionado = TipoDocumentoReferencia;
			formDocumentos.ShowDialog();
			var documento = formDocumentos.Documento;

			if (documento == null) return;

			NumeroReferencia = $"{documento.Serie}-{documento.Numero}";
			TipoDocumentoReferencia = documento.TipoDocumento;
			FechaReferencia = documento.Fecha;

			LimpiarTotales();
			LimpiarDetalles();

			RucCliente = documento.NumeroDocumentoCliente;
			NombreCliente = documento.RazonSocialCliente;
			TipoDocIdentidad = documento.TipoDocumentoCliente;
			Subtotal = Formateador.Numero(Math.Round(documento.Gravadas, 2));
			NoGravado = Formateador.Numero(Math.Round(documento.Inafecto, 2));
			Igv = Formateador.Numero(Math.Round(documento.Igv, 2));
			TotalVenta = Formateador.Numero(Math.Round(documento.MontoTotal, 2));
			_cuotas = documento.Cuotas.ToList();

			if (documento.Cuotas.Count > 0)
				cboFormaPago.SelectedIndex = 1;

			foreach (var detalle in documento.Detalles.OrderBy(x => x.Item))
			{
				dgvDetalle.Rows.Add(detalle.Item, detalle.CodigoProducto, detalle.DescripcionProducto, Formateador.Numero(detalle.Cantidad), detalle.UnidadMedida,
					detalle.PorcentajeIgv, Formateador.Numero(detalle.PrecioVentaUnitario), Formateador.Numero(detalle.Igv),
					Formateador.Numero(detalle.PrecioTotal), detalle.TipoIgv, "");
			}
		}

		private async void BtnConsultarReniecSunat_Click(object sender, EventArgs e)
		{
			try
			{
				if (TipoDocIdentidad == "1")
				{
					if (RucCliente.Length != 8)
					{
						MostrarMensajes.Advertencia($"El DNI ingresado es incorrecto");
						return;
					}

					Loading.Mostrar();
					var datosReniec = await _servicioReniec.Obtener(RucCliente);
					Loading.Cerrar();

					if (datosReniec == null)
					{
						MostrarMensajes.Advertencia($"El número de documento ingresado no existe {RucCliente}");
						return;
					}

					NombreCliente = $"{datosReniec.Nombres} {datosReniec.ApellidoPaterno} {datosReniec.ApellidoMaterno}";
					await _servicioPaciente.InsertarCliente(RucCliente, "1", datosReniec.ApellidoPaterno,
						datosReniec.ApellidoMaterno, datosReniec.Nombres, "", datosReniec.Direccion);

				}
				else if (TipoDocIdentidad == "6")
				{
					if (RucCliente.Length != 11)
					{
						MostrarMensajes.Advertencia($"El RUC ingresado es incorrecto");
						return;
					}

					Loading.Mostrar();
					var datosRuc = await _servicioSunat.ObtenerDatosRuc(RucCliente);
					Loading.Cerrar();

					if (datosRuc.CoError != "0000")
					{
						MostrarMensajes.Advertencia($"El RUC ingresado no existe {RucCliente}");
						NombreCliente = string.Empty;
						return;
					}

					if (datosRuc.EsActivo != "ACTIVO")
					{
						MostrarMensajes.Advertencia($"El RUC ingresado {RucCliente} se encuentra en estado: {datosRuc.EsActivo}");
						NombreCliente = string.Empty;
						return;
					}

					NombreCliente = datosRuc.NoEmpresa;
					await _servicioPaciente.InsertarCliente(RucCliente, "6", "", "", "", datosRuc.NoEmpresa, datosRuc.DeDireccion);
				}
			}
			catch (Exception ex)
			{
				MostrarMensajes.DetalleError(ex);
				Loading.Cerrar();
			}
		}

		private async void BtnBuscarPaciente_Click(object sender, EventArgs e)
		{
			try
			{
				Loading.Mostrar();
				var paciente = await _servicioPaciente.Obtener(RucCliente, TipoDocIdentidad);
				Loading.Cerrar();

				if (paciente == null)
				{
					MostrarMensajes.Informacion("No se pudo encontrar el cliente en la base de datos");
					return;
				}

				NombreCliente = $"{paciente.Nombres} {paciente.ApellidoPaterno} {paciente.ApellidoMaterno}";

			}
			catch (Exception ex)
			{
				MostrarMensajes.DetalleError(ex);
			}
			finally
			{
				Loading.Cerrar();
			}
		}

		private void TxtEfectivo_Enter(object sender, EventArgs e)
		{
			txtEfectivo.SelectAll();
		}

		private void BtnBuscarCitas_Click(object sender, EventArgs e)
		{
			var formCitas = new FormCitas();
			formCitas.ShowDialog();
			var citasSeleccionadas = formCitas.CitasSeleccionadas;

			if (citasSeleccionadas == null || citasSeleccionadas.Count == 0) return;

			try
			{
				LimpiarTotales();
				LimpiarDetalles();

				var cabecera = citasSeleccionadas.First();
				RucCliente = cabecera.NroDocCliente;
				NombreCliente = cabecera.NombresPaciente;
				TipoDocIdentidad = cabecera.TipoDocCliente.ToString();
				Fecha = DateTime.Now;
				NroPreventa = cabecera.IdCita;

				foreach (var detalle in citasSeleccionadas)
				{
					dgvDetalle.Rows.Add(0, detalle.CodProducto, detalle.DescripcionProducto, "1", "ZZ",
						 "0", Formateador.Numero(detalle.Precio), "0",
						Formateador.Numero(detalle.Precio), detalle.TipoIgv, detalle.IdCita);
				}
				ReordenarItems();
				Totalizar();
			}
			catch (Exception ex)
			{
				MostrarMensajes.DetalleError(ex);
			}
		}

		private void CargarFormaPago()
		{
			cboFormaPago.DisplayMember = "Text";
			cboFormaPago.ValueMember = "Value";

			var items = new[] {
				new { Text = "Contado", Value = "1" },
				new { Text = "Crédito", Value = "2" }
			};

			cboFormaPago.DataSource = items;
		}

		#endregion

		private void BtnCuotas_Click(object sender, EventArgs e)
		{
			var formCuotas = new FormCuotas();
			formCuotas.Cuotas = _cuotas;
			formCuotas.EsSoloConsulta = IdDocumento > 0;
			formCuotas.TotalFactura = Convert.ToDecimal(TotalVenta);
			formCuotas.ShowDialog();
			_cuotas = formCuotas.Cuotas;
		}

		private void CboFormaPago_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboFormaPago.SelectedValue.ToString() == "2")
			{
				btnCuotas.Enabled = true;
			}
			else
			{
				_cuotas.Clear();
				btnCuotas.Enabled = false;
			}
		}

		private void cboTipoMedioPago_SelectedIndexChanged(object sender, EventArgs e)
		{
			var medioPago = cboTipoMedioPago.SelectedItem as ListarTipoMedioPagoDTO;
			cboFormaPago.SelectedIndex = medioPago.FormaPago - 1;
		}
	}
}
