using Castle.DynamicProxy;

namespace psk_fitness.Interceptors;

public static class ServiceCollectionExtensions
{
    public static void AddProxiedScoped<TService, TImplementation>(this IServiceCollection services)
        where TService : class
        where TImplementation : class, TService
    {
        services.AddScoped<TImplementation>();
        services.AddScoped<TService>(provider =>
        {
            var proxyGenerator = new ProxyGenerator();
            var implementation = provider.GetRequiredService<TImplementation>();
            var interceptor = provider.GetRequiredService<LoggingInterceptor>();
            return proxyGenerator.CreateInterfaceProxyWithTarget<TService>(implementation, interceptor);
        });
    }
}