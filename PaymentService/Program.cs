using Payment.Infrastructure;
using PaymentService.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddPaymentInfra(builder.Configuration);
builder.Services.AddHostedService<PaymentConsumerService>();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();
// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
