using Castle.DynamicProxy;
using System.Reflection;
using IInterceptor = Castle.DynamicProxy.IInterceptor;

namespace Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionAttributeBase>
                (true).ToList();
            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodInterceptionAttributeBase>(true);
            classAttributes.AddRange(methodAttributes);
            //classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger)));
            //Yukarıdaki ifade ile Loglama altyapısı hazır olan sistemlerde otomatik olarak gerçekleştirilir.
            //Ancak bizim projemizde şuanda Loglama alt yapısı hazır olmadığı için bu statement'ı şuanda kullanmıyoruz.

            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }

}
