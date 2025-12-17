using LondonStockExchange.Utility;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;

namespace LondonStockExchange.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate requestDelegate, ILogger<ExceptionMiddleware> logger)
        {
            _requestDelegate = requestDelegate;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context) 
        {
            try
            {
                await _requestDelegate(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception");
                await HandleException(context, ex);
            }
        }

        private static Task HandleException(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            context.Response.StatusCode = exception switch
            {
                ArgumentException or ArgumentNullException => (int)HttpStatusCode.BadRequest,
                UnauthorizedAccessException => (int)HttpStatusCode.Unauthorized,
                KeyNotFoundException => (int)HttpStatusCode.NotFound,
                _ => (int)HttpStatusCode.InternalServerError

            };

            var errorResponse = new ErrorResponse()
            {
                StatusCode = context.Response.StatusCode,
                Message = context.Response.StatusCode == (int)HttpStatusCode.InternalServerError
                    ? "An unexpected error occurred."
                    : exception.Message
            };

            return context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));

        }
    }
}
