using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using psk_fitness.Client;
using psk_fitness.Client.Interfaces;
using psk_fitness.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();
builder.Services.AddHttpClient<IWorkoutService, WorkoutService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7032");
});
builder.Services.AddHttpClient<ITopicService, TopicService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7032");
});
builder.Services.AddScoped(sp => {
    var clientFactory = sp.GetRequiredService<IHttpClientFactory>();
    var client = clientFactory.CreateClient("WorkoutServiceClient");
    return new WorkoutService(client);
});
builder.Services.AddScoped(sp => {
    var clientFactory = sp.GetRequiredService<IHttpClientFactory>();
    var client = clientFactory.CreateClient("TopicServiceClient");
    return new TopicService(client);
});
await builder.Build().RunAsync();
