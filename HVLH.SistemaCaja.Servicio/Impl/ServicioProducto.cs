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
	public class ServicioProducto : IServicioProducto
	{
		private readonly ISiheContexto _siheContexto;
		private readonly IMapper _mapper;

		public ServicioProducto(ISiheContexto siheContexto, IMapper mapper)
		{
			_siheContexto = siheContexto;
			_mapper = mapper;
		}

		public async Task Eliminar(int id)
		{
			var producto = await _siheContexto.RepositorioProducto.Obtener(p => p.Id == id) ?? throw new Exception("El producto a eliminar no existe");
			var existeDocumentos = await _siheContexto.RepositorioDocumento.ExisteDetalle(x => x.CodigoProducto == producto.Codigo);
			if (existeDocumentos) throw new Exception("El producto a eliminar tiene documentos asociados");
			_siheContexto.RepositorioProducto.Eliminar(producto);
			await _siheContexto.CommitAsync();
		}

		public async Task Guardar(GuardarProductoDTO productoDTO)
		{
			if (productoDTO.Id == 0)
			{
				var producto = _mapper.Map<Producto>(productoDTO);
				producto.UsuarioCreacion = productoDTO.Usuario;
				producto.FechaCreacion = DateTime.Now;
				await _siheContexto.RepositorioProducto.Agregar(producto);
			}
			else
			{
				var producto = await _siheContexto.RepositorioProducto.Obtener(p => p.Id == productoDTO.Id) ?? throw new Exception("El producto a actualizar no existe");
				producto.FechaModificacion = DateTime.Now;
				producto.UsuarioModificacion = productoDTO.Usuario;
				producto.Precio = productoDTO.Precio;
				producto.Descripcion = productoDTO.Descripcion;
				producto.IdUnidadMedida = productoDTO.IdUnidadMedida;
				producto.IdTipoAfectacionIgv = productoDTO.IdTipoAfectacionIgv;
			}

			await _siheContexto.CommitAsync();
		}

		public async Task<List<ListarProductoDTO>> Listar()
		{
			_siheContexto.RefreshAll();
			var productos = await _siheContexto.RepositorioProducto.Listar();
			return _mapper.Map<List<ListarProductoDTO>>(productos);
		}

		public async Task<ObtenerProductoDTO> Obtener(int id)
		{
			var producto = await _siheContexto.RepositorioProducto.Obtener(p => p.Id == id) ?? throw new Exception("El producto no existe");
			return _mapper.Map<ObtenerProductoDTO>(producto);

		}
	}
}
