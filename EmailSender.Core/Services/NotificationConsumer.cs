using MassTransit;
using BookingTables.Shared.EventModels;
using Core.IServices;

namespace EmailSender.Core.Services
{
    public class NotificationConsumer : IConsumer<Notification>
    {
        private readonly IEmailService _emailService;
        public NotificationConsumer(IEmailService emailService)
        {
            _emailService = emailService;
        }
        public async Task Consume(ConsumeContext<Notification> context)
        {
           await _emailService.SendNotification(context.Message.Email, context.Message.Tables);
          
        }
    }
}
