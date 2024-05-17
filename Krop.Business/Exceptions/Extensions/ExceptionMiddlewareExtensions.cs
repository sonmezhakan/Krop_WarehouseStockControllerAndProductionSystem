using Microsoft.AspNetCore.Builder;

namespace Krop.Business.Exceptions.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureCustomExceptionMiddleWare(this IApplicationBuilder app)
            => app.UseMiddleware<ExceptionMiddleware>();
    }
}
