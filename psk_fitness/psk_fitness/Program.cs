using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using psk_fitness.Components;
using psk_fitness.Components.Account;
using psk_fitness.Data;
using psk_fitness.Interfaces;
using psk_fitness.Repositories;
using psk_fitness;
using psk_fitness.ClientServices;
using psk_fitness.Properties;
using psk_fitness.Interfaces.Services;
using psk_fitness.Services;
using psk_fitness.Interceptors;
using psk_fitness.ClientServices.Decorators;

var builder = WebApplication.CreateBuilder(args);
var useDecoratedService = bool.Parse(Environment.GetEnvironmentVariable("UseDecoratedTopicClientService") ?? "false");

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSingleton<LoggingInterceptor>();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, PersistingServerAuthenticationStateProvider>();

builder.Services.AddTransient<ITopicRepository, TopicRepository>();
builder.Services.AddTransient<IExerciseRepository, ExerciseRepository>();
builder.Services.AddTransient<IWorkoutRepository, WorkoutRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(Constants.BaseHttpUri) });

if (useDecoratedService)
{
    builder.Services.AddTransient<TopicClientService>();

    builder.Services.AddTransient<ITopicClientService, SortingTopicClientServiceDecorator>(provider =>
        new SortingTopicClientServiceDecorator(provider.GetRequiredService<TopicClientService>()));
}
else
{
    builder.Services.AddTransient<ITopicClientService, TopicClientService>();
}

builder.Services.AddTransient<ITopicService, TopicService>();
// Proxy HAS to be declared AFTER the service
builder.Services.AddProxiedScoped<ITopicService, TopicService>();

builder.Services.AddScoped<StateContainer>();
builder.Services.AddTransient<ITopicFriendRepository, TopicFriendRepository>();

builder.Services.Configure<CustomLoggingOptions>(
    builder.Configuration.GetSection(CustomLoggingOptions.SectionName));

builder.Services.AddAutoMapper(options => {
    options.AddProfile<MappingProfile>();
});

builder.Services.AddHttpClient<ITopicFriendService, TopicFriendService>(client =>
{
    client.BaseAddress = new Uri(Constants.BaseHttpUri);
});


builder.Services.AddTransient<IWorkoutService, WorkoutService>();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = IdentityConstants.ApplicationScheme;
    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
})
    .AddIdentityCookies();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseMigrationsEndPoint();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddInteractiveServerRenderMode()
    .AddAdditionalAssemblies(typeof(psk_fitness.Client._Imports).Assembly);

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.MapControllers();

app.Run();