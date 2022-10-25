using MassTransit;
using EmailSender.Core.Services;

namespace EmailSender.API.ServicesConfiguration
{
    public static class MassTransitConfiguration
    {
        public static void ConfigureMassTransit(this IServiceCollection services,IConfiguration configuration)
        {
            var rabbitMqHost = configuration["RabbitMq:hostName"];

            services.AddMassTransit(config =>
            {
                config.AddConsumer<NotificationConsumer>();

                config.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host(rabbitMqHost);
                    cfg.ReceiveEndpoint("notification-received", e =>
                    {
                        e.ConfigureConsumer<NotificationConsumer>(ctx);
                    });
                });
            });
        }
    }
}
