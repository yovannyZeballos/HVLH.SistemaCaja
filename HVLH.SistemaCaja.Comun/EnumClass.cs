namespace HVLH.SistemaCaja.Comun
{
	public enum TipoSerie
	{
		Manual = 0,
		Electronico = 1
	}

	public enum TipoDocumento
	{
		None = 0,
		Factura = 1,
		Boleta = 3,
		Nota_de_Credito = 7
	}

	public enum EstadoDocumento
	{
		Generado = 1,
		Impreso = 2,
		Aceptado = 3,
		Rechazado = 4,
		Anulado = 5,
		Baja_Aceptada = 6
	}

	public enum EstadoPreventa
	{

		Pagado = 4,
		Pendiente = 3,
        Anulado = 9,
    }

	public enum TipoLinea
	{
		GUION = 0,
		IGUAL = 1,
		ASTERISCO = 2,
		BLANCO = 3
	}

	public enum Estado
	{
		Activo = 1,
		Inactivo = 2,
		Bloqueado = 3
	}

	public enum EstadoResumen
	{
		Generado = 1,
		Rechazado = 2,
		Enviado = 3,
		Aceptado = 4
	}

	public enum EstadoResumenDetalle
	{
		Adicionar = 1,
		Modificar = 2,
		Anular = 3
	}
}
