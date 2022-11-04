using MassTransit;
using EmailSender.Core.Services;
using RabbitMQ.Client;

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
                config.AddDelayedMessageScheduler();

                config.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host(rabbitMqHost);
                    cfg.UseDelayedMessageScheduler();

                    cfg.ReceiveEndpoint("notification-received", e =>
                    {
                        e.ConfigureConsumer<NotificationConsumer>(ctx);
                        e.UseDelayedRedelivery(r => r.Intervals(TimeSpan.FromMinutes(1), TimeSpan.FromMinutes(2), TimeSpan.FromMinutes(3)));
                    });
                  
                });
            });
        }
    }
}
