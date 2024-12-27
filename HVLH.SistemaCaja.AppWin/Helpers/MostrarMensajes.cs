using System;
using System.Windows.Forms;

namespace HVLH.SistemaCaja.AppWin.Helpers
{
	public static class MostrarMensajes
	{
		public static void DetalleError(Exception ex)
		{
			MessageBox.Show(ex.Message, "Sistema de Caja",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		public static void Advertencia(string mensaje)
		{
			MessageBox.Show(mensaje, "Sistema de Caja",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}

		public static void Informacion(string mensaje)
		{
			MessageBox.Show(mensaje, "Sistema de Caja",
					MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		public static DialogResult Pregunta(string mensaje)
		{
			return MessageBox.Show(mensaje, "Sistema de Caja",
					MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
		}
	}
}
