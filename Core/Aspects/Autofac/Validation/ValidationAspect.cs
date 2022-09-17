using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.NewFolder.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değildir.");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)//sanal sınıfı override etme işlemini gerçekleştirdik.
        {
            //Doğrulama metodun başında yapılacağı için OnBefore metodunu kullanmaktayız.
            //Reflection = çalışma anında farklı şeyleride çalıştırabilmenizi sağlıyor.
            var validator = (IValidator)Activator.CreateInstance(_validatorType);//IValıdator referans tutucu olarak görev alır.Dolayısıyla Diyelimki ProductValidator'ın çalışma tipini bul diyor.
            //Yukarıdaki ifadede çalışma zamanında instance oluşturmak istersek eğer kullanılan yapıdır.Activator.CreateInstance.
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }

        //protected override void OnException(IInvocation invocation, Exception e)
        //{
        //    base.OnException(invocation, e);
        //    //Sistem hata verdiğinde ne yapayım anlamına gelmektedir.
        //}
    }
}
