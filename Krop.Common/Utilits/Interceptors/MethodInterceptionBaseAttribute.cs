using Castle.DynamicProxy;

namespace Krop.Common.Utilits.Interceptors
{
    //Attributeların class ve attributelarda oluşturabilmemizi sağlıyor.
    //Birden fazla attribute kullanılmasına izin veriyor.
    //Inherite edilmesine izin veriyor.
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; }//Bir class veya metot da birden fazla attribute olabilir. Bu attributeların hanginisinin önce çalışacağınız int tipinde değer vererek sıralamasını yapmak için kullanıyoruz.

        public virtual void Intercept(IInvocation invocation)
        {

        }
    }
}
