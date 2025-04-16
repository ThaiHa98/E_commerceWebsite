using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerceWebsite.Infrastructure.Helper
{
    public class IdleTimeoutMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IdleTimeoutMiddleware(RequestDelegate next, IHttpContextAccessor httpContextAccessor)
        {
            _next = next;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var lastActiveTimeCookie = context.Request.Cookies["lastActiveTime"];

            if (!string.IsNullOrEmpty(lastActiveTimeCookie))
            {
                DateTime lastActiveTime = DateTime.Parse(lastActiveTimeCookie);
                if (DateTime.Now - lastActiveTime > TimeSpan.FromMinutes(3)) 
                {
                    // Nếu người dùng không hoạt động trong 3 phút, yêu cầu đăng nhập lại
                    context.Response.Cookies.Delete("authenticationToken");
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsync("Session expired. Please log in again.");
                    return;
                }
            }
            context.Response.OnStarting(() =>
            {
                context.Response.Cookies.Append("lastActiveTime", DateTime.Now.ToString(), new CookieOptions { HttpOnly = true });
                return Task.CompletedTask;
            });
            await _next(context);
        }
    }
}
