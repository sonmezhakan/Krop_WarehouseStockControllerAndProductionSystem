using Krop.Business.Exceptions.Types;
using Krop.DataAccess.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using System.Reflection;

namespace Krop.Business.Exceptions.Middlewares.Transaction
{
    public class TransactionMiddleware
    {
        private readonly RequestDelegate _next;

        public TransactionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, KropContext dbContext)
        {
            var endpoint = context.Features.Get<IEndpointFeature>()?.Endpoint;
            var methodInfo = endpoint?.Metadata.GetMetadata<MethodInfo>();

            if (methodInfo != null && methodInfo.GetCustomAttribute<TransactionScopeAttribute>() != null)
            {
                await using var transaction = await dbContext.Database.BeginTransactionAsync();
                try
                {
                    await _next(context);
                    //await dbContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    throw new TransactionException("İşlem Gerçekleştirilemedi!");
                }
            }
            else
            {
                await _next(context);
            }
        }
    }
}
