using EmailService.Core.HostedServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<EmailHostedService>();
builder.Services.AddHostedService(provider => provider.GetService<EmailHostedService>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
/// <summary>
/// Declare Endpoint test-send-email 
/// </summary>

app.MapGet("/test-email", async (EmailHostedService hostedService) => {
    await hostedService.SendEmailAsync(new EmailService.Core.Common.Email.Model.EmailModel
    {
        EmailAddress = "emiliano.quiroga093@gmail.com",
        Subject = "Hello, World!",
        Body = "Hello from Hosted Service",
        Attachments = null
    });
}).WithName("TestEmail");
app.Run();
