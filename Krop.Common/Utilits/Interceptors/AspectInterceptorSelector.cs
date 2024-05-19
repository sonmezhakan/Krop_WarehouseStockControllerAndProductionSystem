using Castle.DynamicProxy;
using System.Reflection;

namespace Krop.Common.Utilits.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            //Classın attributelarını kontrol et
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                (true).ToList();
            //Metotun attributelarını kontrol et
            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);//Kontrol ettiği attributeları listeye ekle.

            return classAttributes.OrderBy(x => x.Priority).ToArray();//Listedeki attributeları Priority'e göre sırala ve döndür.
        }
    }
}
