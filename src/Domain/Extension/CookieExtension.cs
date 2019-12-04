using System;
using Microsoft.AspNetCore.Http;

namespace Domain.Extension
{
    public static class CookieExtension
    {
        private const string cookieName = "URLSH";

        public static Guid GetURLSH(this HttpContext context)
        {
            if (context.Request.Cookies.ContainsKey(cookieName))
            {
                return Guid.Parse(context.Request.Cookies[cookieName]);
            }

            var cookieOptions = new CookieOptions
            {
                Path = "/",
                IsEssential = true,
                HttpOnly = false,
                Secure = false
            };
            var cookieValue = Guid.NewGuid();
            context.Response.Cookies.Append(cookieName, cookieValue.ToString(), cookieOptions);
            return cookieValue;
        }
    }
}