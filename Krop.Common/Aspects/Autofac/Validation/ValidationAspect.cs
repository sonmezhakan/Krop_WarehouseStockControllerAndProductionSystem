using Castle.DynamicProxy;
using FluentValidation;
using Krop.Common.CrossCuttingConcerns.Validation;
using Krop.Common.Utilits.Interceptors;

namespace Krop.Common.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))//Gelen parametrenin tipi IValidator değil ise hata fırlat
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değildir.");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)//Class veya metotun başında attribute çalıştırıyor.
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);//Validatorun instancesını oluştur.
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];//Validatorun tipini bul
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);//classın veya metotun parametrelerini kontrol et Validatorun tipine eşit olanları aktar.
            foreach (var entity in entities)//parametrelerde dön ve ValidationTool kullan.
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
