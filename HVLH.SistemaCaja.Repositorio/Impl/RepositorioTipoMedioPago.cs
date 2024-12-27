using HVLH.SistemaCaja.Modelo;
using HVLH.SistemaCaja.Repositorio.Contextos;
using HVLH.SistemaCaja.Repositorio.Contratos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Repositorio.Impl
{
	public class RepositorioTipoMedioPago : RepositorioGenerico<SiheContexto, TipoMedioPago>, IRepositorioTipoMedioPago
	{
		public RepositorioTipoMedioPago(SiheContexto siheContexto) : base(siheContexto)
		{
		}

		public SiheContexto SiheContexto
		{
			get { return _siheContexto; }
		}

	}
}
