using HVLH.SistemaCaja.Modelo;
using HVLH.SistemaCaja.Repositorio.Contextos;
using HVLH.SistemaCaja.Repositorio.Contratos;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Repositorio.Impl
{
	public class RepositorioTipoDocumento : RepositorioGenerico<SiheContexto, TipoDocumento>,IRepositorioTipoDocumento
	{
		public RepositorioTipoDocumento(SiheContexto siheContexto) : base(siheContexto)
		{
		}

		public SiheContexto SiheContexto
		{
			get { return _siheContexto; }
		}

		//public async Task Eliminar(int id)
		//{
		//	var tipoDocumento = await _siheContexto.TipoDocumentos.FirstOrDefaultAsync(x => x.Id == id);
		//	_siheContexto.TipoDocumentos.Remove(tipoDocumento);
		//	await _siheContexto.SaveChangesAsync();
		//}

		//public async Task Insertar(TipoDocumento tipoDocumento)
		//{
		//	await _siheContexto.TipoDocumentos.AddAsync(tipoDocumento);
		//	await _siheContexto.SaveChangesAsync();
		//}

		//public async Task Actualizar(TipoDocumento tipoDocumento)
		//{
		//	_siheContexto.TipoDocumentos.Update(tipoDocumento);
		//	await _siheContexto.SaveChangesAsync();
		//}

		//public async Task<List<TipoDocumento>> ListarxTipo()
		//{
		//	return await _siheContexto.TipoDocumentos.AsNoTracking().ToListAsync();
		//}

		//public async Task<TipoDocumento> Obtener(int id)
		//{
		//	return await _siheContexto.TipoDocumentos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
		//}

		public async Task<bool> Existe(string codigo)
		{
			return await _siheContexto.TipoDocumentos.AsNoTracking().AnyAsync(x => x.Codigo == codigo);
		}
	}
}
