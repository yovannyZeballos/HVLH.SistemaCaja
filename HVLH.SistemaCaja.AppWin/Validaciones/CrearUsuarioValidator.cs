using FluentValidation;
using HVLH.SistemaCaja.Servicio.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.AppWin.Validaciones
{
	public class CrearUsuarioValidator : AbstractValidator<CrearUsuarioDTO>
	{
        public CrearUsuarioValidator()
        {
			RuleFor(x => x.Login).NotEmpty().WithMessage("Debe ingresar el Login");
			RuleFor(x => x.Nombres).NotEmpty().WithMessage("Debe ingresar el Nombre");
			RuleFor(x => x.Clave).NotEmpty().WithMessage("Debe ingresar la Clave");
		}
    }
}
