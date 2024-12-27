using FluentValidation;
using HVLH.SistemaCaja.Servicio.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.AppWin.Validaciones
{
	public class ActualizarUsuarioValidator : AbstractValidator<ActualizarUsuarioDTO>
	{
        public ActualizarUsuarioValidator()
        {
			RuleFor(x => x.Nombres).NotEmpty().WithMessage("Debe ingresar el Nombre");
			RuleFor(x => x.Id).GreaterThan(0).WithMessage("No seleccionó usuario para actualizar id=0");
		}
    }
}
