using FluentValidation;
using HVLH.SistemaCaja.Servicio.DTO;

namespace HVLH.SistemaCaja.AppWin.Validaciones
{
	public class InsertarDocumentoValidator : AbstractValidator<InsertarDocumentoDTO>
	{
		public InsertarDocumentoValidator()
		{
			RuleFor(x => x.IdTipoDocumento).GreaterThan(0).WithMessage("Debe ingresar el tipo de documento");
			RuleFor(x => x.IdTipoDocumentoSerie).GreaterThan(0).WithMessage("Debe ingresar la serie del documento");
			RuleFor(x => x.Fecha).NotEmpty().WithMessage("Debe ingresar la fecha del documento").NotNull().WithMessage("Debe ingresar la fecha del documento");
			RuleFor(x => x.Moneda).NotEmpty().WithMessage("Debe ingresar la moneda del documento").NotNull().WithMessage("Debe ingresar la moneda del documento");
			RuleFor(x => x.TipoDocumentoCliente).NotEmpty().WithMessage("Debe ingresar el tipo de documento del cliente").NotNull().WithMessage("Debe ingresar el tipo de documento del cliente");
			RuleFor(x => x.NumeroDocumentoCliente).NotEmpty().WithMessage("Debe ingresar el numero de documento del cliente").NotNull().WithMessage("Debe ingresar el numero de documento del cliente");
			RuleFor(x => x.RazonSocialCliente).NotEmpty().WithMessage("Debe ingresar el nombre del cliente").NotNull().WithMessage("Debe ingresar el nombre del cliente");
			RuleFor(x => x.Detalle).NotNull().WithMessage("Debe ingresar los detalles del documento");
			RuleFor(x => x.Detalle.Count).GreaterThan(0).WithMessage("Debe ingresar los detalles del documento");
			RuleFor(x => x.FormaPago).NotNull().WithMessage("Debe ingresar la forma de pago");
			RuleFor(x => x.FormaPago).NotEmpty().WithMessage("Debe ingresar la forma de pago");
			RuleFor(x => x.MedioPago).NotNull().WithMessage("Debe ingresar la forma de pago");
			/*RuleFor(x => x.MedioPago.Importe).GreaterThan(0).WithMessage("Debe ingresar el importe pagado por el cliente");
			RuleFor(x => x.MedioPago.Importe).GreaterThanOrEqualTo(x => x.MontoTotal).WithMessage("El importe pagado por el cliente es menor al total del documento");*/

		}
	}
}
