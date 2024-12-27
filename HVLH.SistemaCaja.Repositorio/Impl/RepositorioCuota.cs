using HVLH.SistemaCaja.Modelo;
using HVLH.SistemaCaja.Repositorio.Contextos;
using HVLH.SistemaCaja.Repositorio.Contratos;

namespace HVLH.SistemaCaja.Repositorio.Impl
{
	public class RepositorioCuota : RepositorioGenerico<SiheContexto, Cuota>, IRepositorioCuota
	{
		public RepositorioCuota(SiheContexto siheContexto) : base(siheContexto)
		{
		}

		public SiheContexto SiheContexto
		{
			get { return _siheContexto; }
		}
	}
}
