namespace ApiEmailSender.WebApi.Middleware
{
    public class GlobalExceptionHandlerMiddleware : IMiddleware
    {
        public Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            throw new NotImplementedException();
        }
    }
}
