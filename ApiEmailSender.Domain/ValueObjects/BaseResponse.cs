namespace ApiEmailSender.Domain.ValueObjects
{
    public class BaseResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}
