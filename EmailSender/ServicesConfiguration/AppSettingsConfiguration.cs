using Core.Models.Options;

namespace EmailSender.ServicesConfiguration
{
    public static class AppSettingsConfiguration
    {
        public static void ConfigureOptionsRabbit (this IServiceCollection services,IConfiguration configuration)
        {
            services.Configure<RabbitMqOptions>(configuration.GetSection(RabbitMqOptions.RabbitMq));
        }
    }
}
