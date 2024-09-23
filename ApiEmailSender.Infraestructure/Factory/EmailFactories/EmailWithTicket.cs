using ApiEmailSender.Domain.ValueObjects;
using MimeKit;

namespace ApiEmailSender.Infraestructure.Factory.EmailFactories
{
    public class EmailWithTicket : BaseEmail
    {
        public int IdTicket { get; set; }
        public string Body { get; set; }
        public string PdfBase64 { get; set; }
        public EmailWithTicket(EmailConfig emailConfig) : base(emailConfig) { }

        public override async Task Send()
        {
            var email = CreateEmailMessage();
            email.Body = CreateBody();
            await base.Send(email);
        }

        private MimeEntity CreateBody()
        {
            var bodyBuilder = new BodyBuilder { HtmlBody = Body };
            byte[] pdfBytes = Convert.FromBase64String(PdfBase64);
            MemoryStream ms = new MemoryStream(pdfBytes);
            bodyBuilder.Attachments.Add(CreateAttachments(ms));
            return bodyBuilder.ToMessageBody();

        }

        private MimePart CreateAttachments(MemoryStream ms)
        {
            return new MimePart("application", "pdf")
            {
                Content = new MimeContent(ms, ContentEncoding.Default),
                ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                ContentTransferEncoding = ContentEncoding.Base64,
                FileName = $"Ticket N° {IdTicket}"
            };
        }

    }
}
