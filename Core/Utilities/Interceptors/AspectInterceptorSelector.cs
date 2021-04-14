using Castle.DynamicProxy;
using System;
using System.Linq;
using System.Reflection;

namespace Core.Utilities.Interceptors
{
    public abstract partial class MethodInterceptionBaseAttribute
    {
        public class AspectInterceptorSelector : IInterceptorSelector
        {
            public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
            {
                var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                    (true).ToList();
                var methodAttributes = type.GetMethod(method.Name)
                    .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
                classAttributes.AddRange(methodAttributes);
              //  classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger)));//otomatk sistemdeki tüm metotları loga dahil eder,log altyapısını yazdktan sonra tüm yazılan metotları otomatik kaydder bu tek satır

                return classAttributes.OrderBy(x => x.Priority).ToArray();
            }
        }
    }
}
