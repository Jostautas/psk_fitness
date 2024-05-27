namespace psk_fitness.Interceptors;

using Castle.DynamicProxy;
using Microsoft.Extensions.Options;
using psk_fitness.Properties;


public class LoggingInterceptor(IOptionsMonitor<CustomLoggingOptions> _options) : IInterceptor
{
    public void Intercept(IInvocation invocation)
    {
        if (_options.CurrentValue.LoggingEnabled) {
            var invokedClassName = invocation.MethodInvocationTarget?.DeclaringType?.Name;
            var invokedMethodName = invocation.Method.Name;
            // parameters contain user id
            var parameterInfos = invocation.Method.GetParameters();
            var arguments = parameterInfos.Select((param, index) => $"{param.Name}: {invocation.Arguments[index]?.ToString() ?? "<null>"}");
            
            var logEntry = $"""
            ------------------------------------------------------------
                Timestamp: {DateTime.Now},
                Class: {invokedClassName},
                Method: {invokedMethodName},
                Argument-value: {string.Join(", ", arguments)}
            ------------------------------------------------------------
            """;

            Console.WriteLine("Intercepted!");
            Console.WriteLine(logEntry);
            LogToFileAsync(logEntry).Wait();

            invocation.Proceed();
        }
    }

    private Task LogToFileAsync(string logEntry)
    {
        Directory.CreateDirectory(Path.GetDirectoryName(_options.CurrentValue.LogPath));
        return File.AppendAllTextAsync(_options.CurrentValue.LogPath, logEntry + Environment.NewLine);
    }
}
