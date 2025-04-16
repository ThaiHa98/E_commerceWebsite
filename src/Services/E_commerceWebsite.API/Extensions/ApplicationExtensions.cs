using E_commerceWebsite.Application.Helper;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Shared.Middlewares;

namespace E_commerceWebsite.API.Extensions
{
    public static class ApplicationExtensions
    {
        public static void UseInfrastructure(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "E_commerceWebsite API");
                c.DisplayRequestDuration();
            });

            app.UseMiddleware<ErrorWrappingMiddleware>();

            app.UseStaticFiles();

            app.UseCors("AllowAngularApp"); // Đảm bảo sử dụng chính sách CORS đúng tên

            app.UseAuthentication();

            app.UseMiddleware<LastActivityMiddleware>();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/hc", new HealthCheckOptions()
                {
                    Predicate = _ => true,
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });
                endpoints.MapDefaultControllerRoute();
            });
        }

        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAngularApp", builder =>
                {
                    builder.WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .WithMethods("POST", "PUT", "GET", "DELETE", "OPTIONS")
                        .AllowCredentials();
                });
            });
        }
    }
}
