namespace psk_fitness.Middleware;

using System.Diagnostics;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using psk_fitness.Properties;

public class LoggingMiddleware
{
    public readonly RequestDelegate _next;
    public readonly IOptionsMonitor<CustomLoggingOptions> _options;

    public LoggingMiddleware(RequestDelegate next, IOptionsMonitor<CustomLoggingOptions> options)
    {
        _next = next;
        _options = options;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (_options.CurrentValue.LoggingEnabled) {

            // Get user information
            var user = context.User;
            var userName = user.Identity?.Name ?? "Anonymous";
            var userPermissions = string.Join(", ", user.FindAll(ClaimTypes.Role));
            if (userPermissions.IsNullOrEmpty()) {
                userPermissions = "None";
            }

            // Get invocation information
            var httpMethodName = context.Request.Method;
            var invokedClassName = context.Request.RouteValues["controller"] ?? "Unknown";
            var invokedMethodName = context.Request.RouteValues["action"] ?? "Unknown";

            // Ignore unncessary logs
            if (!invokedClassName.Equals("Unknown") && !invokedMethodName.Equals("Unknown"))  {

                // Create log entry
                var logEntry = $"""
                ------------------------------------------------------------
                    Timestamp: {DateTime.Now},
                    User: {userName},
                    Permissions: {userPermissions},
                    HTTP Method: {httpMethodName},
                    ControllerClass: {invokedClassName},
                    Method: {invokedMethodName}
                ------------------------------------------------------------
                """;

                // Log to file
                await LogToFileAsync(logEntry);

            }

        }
        // Call the next middleware in the pipeline
        await _next(context);
}

    private Task LogToFileAsync(string logEntry)
    {
        Directory.CreateDirectory(Path.GetDirectoryName(_options.CurrentValue.LogPath));
        return File.AppendAllTextAsync(_options.CurrentValue.LogPath, logEntry + Environment.NewLine);
    }
}
