namespace ApiEmailSender.Domain.DTOs
{
    public class EmailTicketDto
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public int IdTicket { get; set; }
        public string Base64 { get; set; }
    }
}
