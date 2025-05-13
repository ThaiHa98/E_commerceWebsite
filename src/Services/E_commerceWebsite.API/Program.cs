using E_commerceWebsite.API.Extensions;
using E_commerceWebsite.Application;
using E_commerceWebsite.Infrastructure;
using E_commerceWebsite.Infrastructure.Helper;
using Serilog;
using E_commerceWebsite.API.Identity;
using Microsoft.Extensions.Caching.Distributed;
using Shared.Common.ApiIntegration.ResClient;
using Shared.Common.ApiIntegration.KeyApp;
using Shared.Common.ApiIntegration.Permissions;
using Shared.Common.ApiIntegration;

var builder = WebApplication.CreateBuilder(args);

Log.Information($"Start {builder.Environment.ApplicationName} up");

try
{
    // Add services to the container.
    builder.Host.AddAppConfigurations();
    builder.Services.ConfigureAuthenticationHandler(builder.Configuration);
    builder.Services.AddConfigurationSettings(builder.Configuration);
    builder.Services.AddApplicationServices();
    builder.Services.AddInfrastructureServices(builder.Configuration);
    builder.Services.ConfigureHealthChecks();
    builder.Services.ConfigureServices();
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.ConfigureSwagger();
    builder.Services.ConfigureRedis();
    builder.Services.AddMemoryCache();
    builder.Services.AddScoped<IKeyAppApiClient, KeyAppApiClient>();
    builder.Services.AddScoped<IPermissionsApiClient, PermissionsApiClient>();

    builder.Services.ConfigureCors();

    var app = builder.Build();

    //using (var scope = app.Services.CreateScope())
    //{
    //    var redisService = scope.ServiceProvider.GetRequiredService<IStringRedisCacheService>();
    //    var options = new DistributedCacheEntryOptions
    //    {
    //        AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(30) // tu? ch?nh th?i gian
    //    };

    //    await redisService.SetStringAsync("ResClientId", "abc-123456", options);
    //}

    app.UseInfrastructure();

    app.UseMiddleware<IdleTimeoutMiddleware>();

    app.UseCors("AllowAngularApp");

    app.UseAuthentication();

    app.UseAuthorization();

    app.Run();
}
catch (Exception ex)
{
    string type = ex.GetType().Name;
    if (type.Equals("StopTheHostException", StringComparison.Ordinal)) throw;

    Log.Fatal(ex, $"Unhandled exception: {ex.Message}");
}
finally
{
    Log.Information($"Shut down {builder.Environment.ApplicationName} complete");
    Log.CloseAndFlush();
}
