using Krop.Business.Exceptions.Types;
using Microsoft.AspNetCore.Http;

namespace Krop.Business.Exceptions.Middlewares
{
    public class AuthorizationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthorizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);

            if (context.Response.StatusCode == 401)
            {
                throw new AuthorizationException("Yetiniz Yok!");
            }
        }
    }
}
