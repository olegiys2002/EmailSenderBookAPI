using Core.IServices;
using Core.Models;
using MailKit.Net.Smtp;
using MimeKit;

namespace Core.Services
{
    public class GmailService : IEmailService
    {
        public GmailService()
        {
  
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
            //var notification = new Notification()
            //{ 
            //    CreatedAt = DateTime.Now ,
            //    UpdatedAt = DateTime.Now,
            //    Message = message,
            //};
            //await _notificationService.CreateNotification(notification);
        }
    }
}
