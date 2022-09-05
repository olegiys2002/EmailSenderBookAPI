using Core.IServices;
using MailKit.Net.Smtp;
using MimeKit;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class GmailService : IEmailService
    {
        private readonly INotificationService _notificationService;
        public GmailService(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }
        public async Task SendNotification(string email, List<int> tables)
        {
            var emailMessage = new MimeMessage();
            var tablesNumber = "";
            var message = "";

            foreach (var table in tables)
            {
                var tableId = table.ToString();
                tablesNumber += tableId + " ";
            }
            emailMessage.From.Add(new MailboxAddress("Администрация", "oa6092698@gmail.com"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = "Заказ";
            
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = $"Вы заказали столики {tablesNumber}"
            };

            message = $"Вы заказали столики {tablesNumber}";

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 465, true);
                await client.AuthenticateAsync("oa6092698@gmail.com", "avwldvwrsasmujnq");
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
            var notification = _notificationService.GetNotification(message);
            await _notificationService.CreateNotification(notification);
        }
    }
}
