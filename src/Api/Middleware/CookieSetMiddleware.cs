using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Api.Middleware
{
    public class CookieSetMiddleware
    {
        private readonly RequestDelegate _next;
        private HttpContext _context;

        public CookieSetMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (!context.Request.Cookies.ContainsKey("URLSH"))
            {
                _context = context;
                context.Response.OnStarting(OnStartingCallBack);
            }

            await _next.Invoke(context);
        }

        private Task OnStartingCallBack()
        {
            var cookieOptions = new CookieOptions
            {
                Path = "/",
                IsEssential = true,
                HttpOnly = false,
                Secure = false
            };
            _context.Response.Cookies.Append("URLSH", Guid.NewGuid().ToString(), cookieOptions);
            return Task.FromResult(0);
        }
    }
}