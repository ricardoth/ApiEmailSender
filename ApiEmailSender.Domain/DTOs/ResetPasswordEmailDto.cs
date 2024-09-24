namespace ApiEmailSender.Domain.DTOs
{
    public class ResetPasswordEmailDto
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string UrlRetorno { get; set; }
    }
}
