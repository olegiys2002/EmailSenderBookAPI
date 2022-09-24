using Core.IServices;
using Core.Models;
using Core.Services;
using EmailSender.ServicesConfiguration;
using Infrastructure;
using Infrastructure.UnitOfWork;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSingleton<IUnitOfWork, UnitOfWork>();
builder.Services.AddSingleton<INotificationService, NotificationService>();
builder.Services.ConfigureOptionsRabbit(builder.Configuration);
builder.Services.AddSingleton<AppDB>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IEmailService, GmailService>();
builder.Services.AddHostedService<RabbitMqListener>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
