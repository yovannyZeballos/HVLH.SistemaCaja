using AutoMapper;
using HVLH.SistemaCaja.Modelo;
using HVLH.SistemaCaja.Repositorio.Contextos;
using HVLH.SistemaCaja.Servicio.Contratos;
using HVLH.SistemaCaja.Servicio.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Servicio.Impl
{
	public class ServicioTipoMedioPago : IServicioTipoMedioPago
	{
		private readonly ISiheContexto _siheContexto;
		private readonly IMapper _mapper;

		public ServicioTipoMedioPago(ISiheContexto siheContexto, IMapper mapper)
		{
			_siheContexto = siheContexto;
			_mapper = mapper;
		}

		public async Task Eliminar(int id)
		{
			var medioPago = await _siheContexto.RepositorioTipoMedioPago.Obtener(x => x.Id == id);
			_siheContexto.RepositorioTipoMedioPago.Eliminar(medioPago);
			await _siheContexto.CommitAsync();
		}

		public async Task Insertar(ListarTipoMedioPagoDTO medioPagoDto)
		{
			if (medioPagoDto.Id == 0)
			{
				var medioPago = _mapper.Map<TipoMedioPago>(medioPagoDto);
				await _siheContexto.RepositorioTipoMedioPago.Agregar(medioPago);
			}
			else
			{
				var medioPago = await _siheContexto.RepositorioTipoMedioPago.Obtener(x => x.Id == medioPagoDto.Id);
				medioPago.Descripcion = medioPagoDto.Descripcion;
				medioPago.FormaPago = medioPagoDto.FormaPago;
				_siheContexto.RepositorioTipoMedioPago.Actualizar(medioPago);
			}

			await _siheContexto.CommitAsync();
		}

		public async Task<List<ListarTipoMedioPagoDTO>> Listar()
		{
			_siheContexto.RefreshAll();
			var tipos = await _siheContexto.RepositorioTipoMedioPago.Listar();
			return _mapper.Map<List<ListarTipoMedioPagoDTO>>(tipos);
		}

		public async Task<ListarTipoMedioPagoDTO> Obtener(int id)
		{
			var medioPago = await _siheContexto.RepositorioTipoMedioPago.Obtener(x => x.Id == id);
			return _mapper.Map<ListarTipoMedioPagoDTO>(medioPago);

		}
	}
}
