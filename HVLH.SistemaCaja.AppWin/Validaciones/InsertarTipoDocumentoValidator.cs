using FluentValidation;
using HVLH.SistemaCaja.Servicio.DTO;

namespace HVLH.SistemaCaja.AppWin.Validaciones
{
	public class InsertarTipoDocumentoValidator : AbstractValidator<InsertarTipoDocumentoDTO>
	{
		public InsertarTipoDocumentoValidator()
		{
			RuleFor(x => x.Codigo).NotEmpty().WithMessage("Debe ingresar el código").NotNull().WithMessage("Debe ingresar el código");
			RuleFor(x => x.Descripcion).NotEmpty().WithMessage("Debe ingresar la descripción").NotNull().WithMessage("Debe ingresar la descripción");
			RuleFor(x => x.DescripcionCorta).NotEmpty().WithMessage("Debe ingresar la descripción corta").NotNull().WithMessage("Debe ingresar la descripción corta");
		}
	}
}
