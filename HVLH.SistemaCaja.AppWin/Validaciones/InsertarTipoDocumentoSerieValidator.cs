using FluentValidation;
using HVLH.SistemaCaja.Servicio.DTO;

namespace HVLH.SistemaCaja.AppWin.Validaciones
{
	public class InsertarTipoDocumentoSerieValidator : AbstractValidator<InsertarTipoDocumentoSerieDTO>
	{
		public InsertarTipoDocumentoSerieValidator()
		{
			RuleFor(x => x.IdTipoDocumento).GreaterThan(0).WithMessage("Debe ingresar el tipo de documento");
			RuleFor(x => x.Serie).NotEmpty().WithMessage("Debe ingresar la serie").NotNull().WithMessage("Debe ingresar la serie");
			RuleFor(x => x.Serie).MinimumLength(4).WithMessage("La serie debe tener 4 digitos");
			RuleFor(x => x.Serie).MaximumLength(4).WithMessage("La serie debe tener 4 digitos");
			RuleFor(x => x.Tipo).NotEmpty().WithMessage("Debe ingresar el tipo").NotNull().WithMessage("Debe ingresar el tipo");
		}
	}
}
