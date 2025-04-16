using E_commerceWebsite.Application.Common.Interfaces;
using E_commerceWebsite.Infrastructure.Persistence;
using E_commerceWebsite.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shared.Common.ApiIntegration;
using Shared.Configurations;
using Shared.Exceptions;
using Shared.Common.ApiIntegration.Permissions;
using Shared.Common.ApiIntegration.ResClient;
using Shared.Common.Services;
using Microsoft.Extensions.Configuration;
using E_commerceWebsite.Infrastructure.Helper;


namespace E_commerceWebsite.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var databaseSettings = services.GetOptions<DatabaseSettings>(nameof(DatabaseSettings));
            if (databaseSettings == null || string.IsNullOrEmpty(databaseSettings.ConnectionString))
                throw new ArgumentNullException("Connection string is not configured.");

            services.AddDbContext<E_commerceWebsiteDbContext>(options =>
            {
                options.UseSqlServer(databaseSettings.ConnectionString, sqlOptions =>
                {
                    sqlOptions.UseCompatibilityLevel(110);
                    sqlOptions.MigrationsAssembly(typeof(E_commerceWebsiteDbContext).Assembly.FullName);
                });
            });

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<Token>();
            services.AddHttpContextAccessor();
            services.AddHttpClient();
            services.AddScoped<IPermissionsApiClient, PermissionsApiClient>();
            services.AddScoped<IStringRedisCacheService, StringRedisCacheServiceImpl>();
            services.AddScoped<IRolesRepository, RolesRepositories>();
            services.AddScoped<IPermissionsRepository, PermissionsRepositories>();
            services.AddScoped<CheckRolesRepositories>();


            return services;
        }
    }
}
