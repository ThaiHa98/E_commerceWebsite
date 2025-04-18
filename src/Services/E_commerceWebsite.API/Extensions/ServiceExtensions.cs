﻿using Common.Logging;
using IdentityServer4.AccessTokenValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.OpenApi.Models;
using Shared.Common;
using Shared.Common.Interfaces;
using Shared.Configurations;
using Shared.Exceptions;
using System.Reflection;

namespace E_commerceWebsite.API.Extensions
{
    public static class ServiceExtensions
    {
        //dung để ánh xạ các thiết lập cấu hình từ file cấu hình appsettings.json
        internal static IServiceCollection AddConfigurationSettings(this IServiceCollection services, IConfiguration configuration)
        {
            var databaseSettings = configuration.GetSection(nameof(DatabaseSettings))
                .Get<DatabaseSettings>();
            services.AddSingleton(databaseSettings);

            return services;
        }

        public static void ConfigureHealthChecks(this IServiceCollection services)
        {
            // Đăng ký cấu hình
            //khi được gọi trong quá trình khởi động ứng dụng, nó sẽ đảm bảo rằng các dịch vụ cần thiết (như SQL Server) đang hoạt động đúng cách
            var databaseSettings = services.GetOptions<DatabaseSettings>(nameof(DatabaseSettings));
            services.AddHealthChecks()
                .AddSqlServer(databaseSettings.ConnectionString,
                              name: "SqlServer Health",
                              failureStatus: HealthStatus.Degraded);
        }

        public static void ConfigureRedis(this IServiceCollection services)
        {
            var settings = services.GetOptions<CacheSettings>(nameof(CacheSettings));
            if (string.IsNullOrEmpty(settings.ConnectionString))
                throw new ArgumentNullException("Redis Connection string is not configured.");

            //Redis Configuration
            services.AddStackExchangeRedisCache(options => { options.Configuration = settings.ConnectionString; });
        }

        public static IServiceCollection ConfigureServices(this IServiceCollection services) =>
            services.AddTransient<ISerializeService, SerializeService>()
                    .AddTransient<LoggingDelegatingHandler>();

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "E_commerceWebsite API V1",
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: Authorization: Bearer {token}",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                Console.WriteLine("Security definition for JWT Bearer has been configured.");
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                });
            });
        }
    }
}
