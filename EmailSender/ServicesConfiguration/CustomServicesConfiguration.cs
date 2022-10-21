using Core.IServices;
using Core.Services;
using Infrastructure;
using Infrastructure.UnitOfWork;

namespace EmailSender.API.ServicesConfiguration
{
    public static class CustomServicesConfiguration
    {
        public static void ConfigureCustomServices(this IServiceCollection services)
        {
            services.AddSingleton<IUnitOfWork, UnitOfWork>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddSingleton<IEmailService, GmailService>();
        }
    }
}
