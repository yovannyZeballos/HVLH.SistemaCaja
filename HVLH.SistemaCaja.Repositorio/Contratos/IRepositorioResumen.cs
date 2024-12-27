using HVLH.SistemaCaja.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Repositorio.Contratos
{
	public interface IRepositorioResumen : IRepositorioGenerico<Resumen>
	{
		Task<Resumen> Obtener(int id);
		Task<int> ObtenerCorrelativo(string numero);
	}
}
