using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HVLH.SistemaCaja.AppWin.Helpers
{
	public static class Loading
	{
		private static FormLoading formLoading;
		public static void Mostrar()
		{
			formLoading = new FormLoading();
			formLoading.Show();

		}

		public static void Cerrar()
		{
			if (formLoading != null) { formLoading.Close(); }
		}
	}
}
