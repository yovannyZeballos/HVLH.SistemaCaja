namespace HVLH.Facturacion.Servicio
{
	public interface IServicioSunatConsultas : IServicioSunat
	{
		RespuestaSincrono ConsultarConstanciaDeRecepcion(DatosDocumento request);
	}
}
