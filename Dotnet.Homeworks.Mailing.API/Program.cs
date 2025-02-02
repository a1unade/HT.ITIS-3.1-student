using Dotnet.Homeworks.Mailing.API.Configuration;
using Dotnet.Homeworks.Mailing.API.Services;
using Dotnet.Homeworks.Mailing.API.ServicesExtensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<EmailConfig>(builder.Configuration.GetSection("EmailConfig"));

builder.Services.AddScoped<IMailingService, MailingService>();
builder.Services.Configure<RabbitMqConfig>(builder.Configuration.GetSection("RabbitMq"));

builder.Services.AddMasstransitRabbitMq(
    builder.Configuration.GetSection(nameof(RabbitMqConfig))
        .Get<RabbitMqConfig>()!);

var app = builder.Build();

app.Run();