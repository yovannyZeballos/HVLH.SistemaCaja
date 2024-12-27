using FluentValidation;
using HVLH.SistemaCaja.Servicio.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.AppWin.Validaciones
{
	public class InsertarMedioPagoValidator : AbstractValidator<ListarTipoMedioPagoDTO>
	{
		public InsertarMedioPagoValidator()
		{
			RuleFor(x => x.Descripcion).NotEmpty().WithMessage("Debe ingresar la descripción").NotNull().WithMessage("Debe ingresar la descripción");
			RuleFor(x => x.FormaPago).NotEmpty().WithMessage("Debe ingresar la descripción corta").NotNull().WithMessage("Debe ingresar la descripción corta");
		}
	}
}
