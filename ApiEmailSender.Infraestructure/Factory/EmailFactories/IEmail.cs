using MimeKit;

namespace ApiEmailSender.Infraestructure.Factory.EmailFactories
{
    public interface IEmail
    {
        public string To { get; set; }
        public string Subject { get; set; }
        Task Send();
    }
}
