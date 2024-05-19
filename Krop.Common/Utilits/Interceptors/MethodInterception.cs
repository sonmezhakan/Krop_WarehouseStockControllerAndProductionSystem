using Castle.DynamicProxy;

namespace Krop.Common.Utilits.Interceptors
{
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        protected virtual void OnBefore(IInvocation invocation) { }//Class veya metotun başında attribute çalıştırıyor.
        protected virtual void OnAfter(IInvocation invocation) { }//Class veya metotun sonunda attribute çalıştırıyor.
        protected virtual void OnException(IInvocation invocation, System.Exception e) { }//Hata fırlatıyor.
        protected virtual void OnSuccess(IInvocation invocation) { }//İşlemin başarılı olduğunu belirtiyor.
        public override void Intercept(IInvocation invocation)//İşlem metotumuz
        {
            var isSuccess = true;
            OnBefore(invocation);
            try
            {
                invocation.Proceed();//İşlemi yap 
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation, e);// hata alırsan OnException fırlat
                throw;
            }
            finally
            {
                if (isSuccess)//İşlem başarılı ise OnSuccess çalıştır.
                {
                    OnSuccess(invocation);
                }
            }
            OnAfter(invocation);
        }
    }
}
