namespace ApiEmailSender.Infraestructure.Factory.EmailFactories
{
    public class EmailResetPassword : BaseEmail
    {
        public string UrlRetorno { get; set; }
        
        public EmailResetPassword(EmailConfig emailConfig) : base(emailConfig) { }

        public async override Task Send()
        {
            var email = CreateEmailMessage();
            email.Body = CreateBodyResetPassword();
            await base.SendEmail(email);
        }

        private MimeEntity CreateBodyResetPassword()
        {
            var bodyBuilder = new BodyBuilder { HtmlBody = CreateTemplateResetPassword() };
            return bodyBuilder.ToMessageBody();
        }

        private string CreateTemplateResetPassword()
        {
            string currentDirectory = Directory.GetCurrentDirectory() + "\\Template";
            string htmlTemplatePath = Path.Combine(currentDirectory, "resetPasswordTemplate.html");
            string htmlTemplate = File.ReadAllText(htmlTemplatePath);
            string htmlTemplateEmail = htmlTemplate.Replace("{UrlRetorno}", UrlRetorno);
            return htmlTemplateEmail;
        }
    }
}
