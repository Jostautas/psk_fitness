using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using psk_fitness.Client;
using psk_fitness.Client.Interfaces;
using psk_fitness.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();


var services = new Dictionary<Type, Type>
{
    { typeof(IWorkoutService), typeof(WorkoutService) },
    { typeof(ITopicService), typeof(TopicService) },
    { typeof(IExerciseService), typeof(ExerciseService) }
};

builder.Services.AddHttpClient<IWorkoutService, WorkoutService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7032");
});
builder.Services.AddHttpClient<ITopicService, TopicService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7032");
});
builder.Services.AddHttpClient<IExerciseService, ExerciseService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7032");
});

await builder.Build().RunAsync();
