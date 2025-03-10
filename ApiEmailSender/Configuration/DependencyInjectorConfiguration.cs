﻿namespace ApiEmailSender.WebApi.Configuration
{
    public static class DependencyInjectorConfiguration 
    {
        public static void UseDependencyInjectorConfiguration(this IServiceCollection service, IConfiguration configuration)
        {
            #region Don't Touch
            service.AddControllers();
            service.AddTransient<GlobalExceptionHandlerMiddleware>();
            service.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            service.AddAutoMapper(typeof(AutoMapperProfile));

            service.Configure<BasicAuthCredentials>(configuration.GetSection("BasicAuthCredentials"));

            service.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthMiddleware>("BasicAuthentication", null);

            service.AddApplicationInsightsTelemetry(configuration["ApplicationInsights:InstrumentationKey"]);
            #endregion

            #region Manual Dependencies
            var emailConfig = configuration.GetSection(nameof(EmailConfig)).Get<EmailConfig>();
            service.AddSingleton(emailConfig);
             
            DependencyInjection.UseDependencyInjectionApplication(service, configuration);
            #endregion
        }
    }
}
