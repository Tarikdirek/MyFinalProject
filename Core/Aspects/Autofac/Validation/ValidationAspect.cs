using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception // Aspect
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değildir");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            //ProductValidator un bir instanceını oluşturup IValidator türüne kullanılabilir haline getir
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            //ProductValidatorun basetypını yani AbstractValidatorun generic parametrelerinden 0.cısının tipini yakala
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            //Metodun(IResul Add) argümalarını(Product product) gez ordaki tip entityType daki tiple eşleşirse onları validate et
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
