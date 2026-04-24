using Azure;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace OrderService.Middleware
{
    public class ExceptionMiddlewar
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddlewar> _logger;

        public ExceptionMiddlewar(RequestDelegate requestDelegate, ILogger<ExceptionMiddlewar> logger)
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
            catch(Exception ex)
            {
                _logger.LogError(ex, "Something went wrong");

                var responce = new
                {
                    Message = "Internal Server Error",
                    Status = false,
                    error = ex.Message
                };

                var jsonresponse = JsonSerializer.Serialize(responce);
                await context.Response.WriteAsync(jsonresponse);
            }
        }
    }
}
