using Azure;
using System.Text.Json;

namespace PaymentService.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate requestDelegate, ILogger<ExceptionMiddleware> logger)
        {
            _next = requestDelegate;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                {
                    _logger.LogError(ex, "Invalid Request");

                    var responce = new
                    {
                        message = "Invalid request",
                        status = false,
                        error = ex.Message

                    };

                    var jsonresponse = JsonSerializer.Serialize(responce);
                    await context.Response.WriteAsync(jsonresponse);
                }
            }
        }
    }
}
