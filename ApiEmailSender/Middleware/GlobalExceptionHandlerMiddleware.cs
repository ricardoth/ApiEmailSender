namespace ApiEmailSender.WebApi.Middleware
{
    public class GlobalExceptionHandlerMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            ErrorResponse errorResponse = new()
            {
                StatusCode = (int)HttpStatusCode.InternalServerError,
                Message = exception.Message
            };

            switch (exception)
            {
                case NotFoundException notFoundException:
                    errorResponse.Message = notFoundException.Message;
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;

                case BadRequestException badRequestException:
                    errorResponse.Message = badRequestException.Message;
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;

                case ValidationResultException validationResultException:
                    errorResponse.Message = validationResultException.Message;
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;

                default:
                    //Registrar traza
                    break;
            }

            errorResponse.StatusCode = context.Response.StatusCode;
            await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
        }
    }
}
