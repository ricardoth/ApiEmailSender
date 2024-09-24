namespace ApiEmailSender.Application.Validators
{
    public class EmailTicketDtoValidator : AbstractValidator<EmailTicketDto>
    {
        public EmailTicketDtoValidator()
        {
            RuleFor(x => x.To).NotNull().NotEmpty().WithMessage("El Destinatario debe ser válido").EmailAddress().WithMessage("El correo debe tener un formato válido");
            RuleFor(x => x.Subject).NotNull().NotEmpty().WithMessage("El Contenido debe ser válido");
            RuleFor(x => x.IdTicket).GreaterThan(0).WithMessage("El IdTicket debe ser mayor a 0");
            RuleFor(x => x.Nombres).NotNull().NotEmpty().WithMessage("Los Nombres deben ser válido");
            RuleFor(x => x.ApellidoPaterno).NotNull().NotEmpty().WithMessage("El Apellido debe ser válido");
            RuleFor(x => x.NombreEvento).NotNull().NotEmpty().WithMessage("El Evento debe ser válido");
            RuleFor(x => x.NombreLugar).NotNull().NotEmpty().WithMessage("El Lugar debe ser válido");
            RuleFor(x => x.NombreSector).NotNull().NotEmpty().WithMessage("El Sector debe ser válido");
            RuleFor(x => x.MontoTotal).GreaterThan(0).WithMessage("El Monto Total debe ser mayor a 0");
            RuleFor(x => x.Base64).NotNull().NotEmpty().WithMessage("El base64 debe ser válido");
        }
    }
}
