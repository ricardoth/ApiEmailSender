namespace ApiEmailSender.Application.Validators
{
    public class SendEmailTicketValidator : AbstractValidator<SendEmailTicketCommand>
    {
        public SendEmailTicketValidator()
        {
            RuleFor(x => x.EmailTicket.To).NotNull().NotEmpty().WithMessage("El Destinatario debe ser válido");
            RuleFor(x => x.EmailTicket.Subject).NotNull().NotEmpty().WithMessage("El Contenido debe ser válido");
            RuleFor(x => x.EmailTicket.IdTicket).GreaterThan(0).WithMessage("El IdTicket debe ser mayor a 0");
            RuleFor(x => x.EmailTicket.Nombres).NotNull().NotEmpty().WithMessage("Los Nombres deben ser válido");
            RuleFor(x => x.EmailTicket.ApellidoPaterno).NotNull().NotEmpty().WithMessage("El Apellido debe ser válido");
            RuleFor(x => x.EmailTicket.NombreEvento).NotNull().NotEmpty().WithMessage("El Evento debe ser válido");
            RuleFor(x => x.EmailTicket.NombreLugar).NotNull().NotEmpty().WithMessage("El Lugar debe ser válido");
            RuleFor(x => x.EmailTicket.NombreSector).NotNull().NotEmpty().WithMessage("El Sector debe ser válido");
            RuleFor(x => x.EmailTicket.MontoTotal).GreaterThan(0).WithMessage("El Monto Total debe ser mayor a 0");
            RuleFor(x => x.EmailTicket.Base64).NotNull().NotEmpty().WithMessage("El base64 debe ser válido");
        }
    }
}