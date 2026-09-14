using System.Net;
using System.Text.Json;

namespace SmartRecruitmentMatchingPlatform.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(
            RequestDelegate next,
            ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                context.Response.ContentType = "application/json";

                switch (ex.Message)
                {
                    case "Invalid credentials.":
                        context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        break;

                    case "Email already exists.":
                        context.Response.StatusCode = (int)HttpStatusCode.Conflict;
                        break;

                    default:
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                var response = new
                {
                    statusCode = context.Response.StatusCode,
                    message = ex.Message
                };

                var json = JsonSerializer.Serialize(response);

                await context.Response.WriteAsync(json);
            }
        }
    }
}