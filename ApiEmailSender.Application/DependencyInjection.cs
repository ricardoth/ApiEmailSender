namespace ApiEmailSender.Application
{
    public static class DependencyInjection
    {
        public static void UseDependencyInjectionApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddFluentValidation(c => c.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddScoped<IEmailFactory, EmailFactory>();
            services.AddScoped<IRequestHandler<SendEmailTicketCommand, BaseResponse>, SendEmailTicketCommandHandler>();
            services.AddScoped<IRequestHandler<ResetPasswordEmailCommand, BaseResponse>, ResetPasswordEmailCommandHandler>();
        }
    }
}
