using ApiEmailSender.Application.Email.Query;
using ApiEmailSender.WebApi.Helpers;
using MediatR;
using System.Reflection;

namespace ApiEmailSender.WebApi.Configuration
{
    public static class DependencyInjectorConfiguration 
    {
        public static void UseDependencyInjectorConfiguration(this IServiceCollection service, IConfiguration configuration)
        {
            #region Don't Touch
            service.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            service.AddAutoMapper(typeof(AutoMapperProfile));
            #endregion

            #region Manual Dependencies
            service.AddScoped<IRequestHandler<EmailSenderQuery, EmailSenderResult>, EmailSenderHandler>();
            #endregion
        }
    }
}
