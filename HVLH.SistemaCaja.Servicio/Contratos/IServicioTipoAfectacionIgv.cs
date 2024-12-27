﻿using HVLH.SistemaCaja.Servicio.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Servicio.Contratos
{
	public interface IServicioTipoAfectacionIgv
	{
		Task<List<TipoAfectacionIgvDTO>> Listar();
	}
}