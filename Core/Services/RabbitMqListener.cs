using Core.IServices;
using Core.Models;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class RabbitMqListener : BackgroundService
    {
        private readonly IEmailService _emailService;
        private IConnection _connection;
        private IModel _channel;
        public RabbitMqListener(IEmailService emailService)
        {
            _emailService = emailService;
            var factory = new ConnectionFactory() { HostName = "localhost" };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();
            var consumer = new EventingBasicConsumer(_channel);
            _channel.QueueDeclare("users", durable: true, exclusive: false, autoDelete: false, arguments: null);
            consumer.Received += async (model, eventArgs) =>
            {
                var body = eventArgs.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var obj = JsonConvert.DeserializeObject<RabbitReceive>(message);

                await _emailService.SendNotification(obj.Email, obj.Tables);
            };
            _channel.BasicConsume(queue: "users", autoAck: true, consumer: consumer);
            return Task.CompletedTask;
        }
        public override void Dispose()
        {
            _channel.Close();
            _connection.Close();
            base.Dispose();
        }
    }
}
