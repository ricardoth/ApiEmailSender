namespace ApiEmailSender.Infraestructure.Factory.EmailFactories
{
    public class EmailTicketBase64 : BaseEmail
    {
        public int IdTicket { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string NombreEvento { get; set; }
        public string NombreLugar { get; set; }
        public string NombreSector { get; set; }
        public long MontoTotal { get; set; }
        public string PdfBase64 { get; set; }

        public EmailTicketBase64(EmailConfig emailConfig) : base(emailConfig) { }

        public override async Task Send()
        {
            var email = CreateEmailMessage();
            email.Body = CreateBodyTicket();
            await base.SendEmail(email);
        }

        private MimeEntity CreateBodyTicket()
        {
            var bodyBuilder = new BodyBuilder { HtmlBody = CreateTemplateEmail() };
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

        private string CreateTemplateEmail()
        {
            string currentDirectory = Directory.GetCurrentDirectory() + "\\Template";
            string htmlTemplatePath = Path.Combine(currentDirectory, "plantillaEmailTicketConfirm.html");
            string htmlTemplate = File.ReadAllText(htmlTemplatePath);

            string htmlTemplateBody = htmlTemplate.Replace("{IdTicket}", IdTicket.ToString())
                                        .Replace("{NombreUser}", $"{Nombres} {ApellidoPaterno}")
                                        .Replace("{NombreEvento}", NombreEvento)
                                        .Replace("{NombreLugar}", NombreLugar)
                                        .Replace("{NombreSector}", NombreSector)
                                        .Replace("{MontoTotal}", MontoTotal.ToString());
            return htmlTemplateBody;
        }
    }
}