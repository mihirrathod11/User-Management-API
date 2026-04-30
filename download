namespace UserManagementAPI.Middleware
{
    // This middleware runs on every request and logs the method and path
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggingMiddleware> _logger;

        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Log before the request is handled
            _logger.LogInformation("Request: {Method} {Path}",
                context.Request.Method,
                context.Request.Path);

            // Pass the request to the next middleware
            await _next(context);

            // Log after the response is sent
            _logger.LogInformation("Response: {StatusCode}",
                context.Response.StatusCode);
        }
    }
}