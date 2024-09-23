using ApiEmailSender.Application.Commands;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApiEmailSender.Application
{
    public static class DependencyInjection
    {
        public static void UseDependencyInjectionApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IRequestHandler<SendEmailTicketCommand, bool>, SendEmailTicketCommandHandler>();
        }
    }
}
