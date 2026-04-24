using ApplicaicationLayer;
using OrderService.Infrastructure;
using OrderService.Infrastructure.Services;
using OrderService.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddScoped<KafkaProducer>();
builder.Services.AddHostedService<OutboxProcessor>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
// Configure the HTTP request pipeline.
app.UseMiddleware<ExceptionMiddlewar>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
