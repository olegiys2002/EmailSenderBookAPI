using Core.Models.Options;
using EmailSender.Core.ExternalModels.OptionsModels;

namespace EmailSender.API.ServicesConfiguration
{
    public static class AppSettingsConfiguration
    {
        public static void ConfigureOptionsRabbit (this IServiceCollection services,IConfiguration configuration)
        {
            services.Configure<RabbitMqOptions>(configuration.GetSection(RabbitMqOptions.RabbitMq));
            services.Configure<MongoDbConnectionSettings>(configuration.GetSection(MongoDbConnectionSettings.MongoDB));
        }
    }
}
