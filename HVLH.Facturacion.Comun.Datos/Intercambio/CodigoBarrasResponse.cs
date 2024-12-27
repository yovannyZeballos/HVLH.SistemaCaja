using System.Drawing;

namespace HVLH.Facturacion.Comun.Datos.Intercambio
{
	public class CodigoBarrasResponse : RespuestaComun
	{
		public byte[] CodigoBarrasBytes { get; set; }

		public Bitmap CodigoBarrasBitmap { get; set; }
	}
}
