namespace ApiEmailSender.Application.Validators
{
    public class ResetEmailPasswordDtoValidator : AbstractValidator<ResetPasswordEmailDto>
    {
        public ResetEmailPasswordDtoValidator()
        {

            RuleFor(x => x.To).NotNull().NotEmpty().WithMessage("El Destinatario debe ser válido").EmailAddress().WithMessage("El correo debe tener un formato válido");
            RuleFor(x => x.Subject).NotNull().NotEmpty().WithMessage("El Contenido debe ser válido");
            RuleFor(x => x.UrlRetorno).NotNull().NotEmpty().WithMessage("Debe contener una URL válida");
        }
    }
}
