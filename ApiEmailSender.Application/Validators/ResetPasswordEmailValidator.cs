namespace ApiEmailSender.Application.Validators
{
    public class ResetPasswordEmailValidator : AbstractValidator<ResetPasswordEmailCommand>
    {
        public ResetPasswordEmailValidator()
        {
            RuleFor(x => x.ResetPasswordEmail.To).NotNull().NotEmpty().WithMessage("El Destinatario debe ser válido");
            RuleFor(x => x.ResetPasswordEmail.Subject).NotNull().NotEmpty().WithMessage("El Contenido debe ser válido");
            RuleFor(x => x.ResetPasswordEmail.UrlCambioContrasena).NotNull().NotEmpty().WithMessage("Debe contener una URL válida");
        }
    }
}
