namespace ApiEmailSender.Domain.DTOs
{
    public class ResetPasswordEmailDto
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string UrlCambioContrasena { get; set; }
    }
}
