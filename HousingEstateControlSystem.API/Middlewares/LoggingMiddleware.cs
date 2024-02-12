using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace HousingEstateControlSystem.API.Middlewares
{
 
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggingMiddleware> _logger;

        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            // Loglama işlemleri burada gerçekleştirilir
            _logger.LogInformation($"HTTP request: {context.Request.Method} {context.Request.Path}");

            // Middleware zincirinin bir sonraki aşamasına geç
            await _next(context);
        }
    }

}
