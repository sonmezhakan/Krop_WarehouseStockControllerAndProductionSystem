namespace Krop.Business.Exceptions.Middlewares.Transaction
{
    [AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class TransactionScopeAttribute : Attribute
    {
    }
}
