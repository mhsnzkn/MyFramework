using Core.CrossCuttingConcerns.Caching;
using Core.IoC;
using Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Castle.DynamicProxy;
using System.Linq;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheAspect : MethodInterception
    {
        private int duration;
        private readonly ICacheManager cache;

        public CacheAspect(int duration=60)
        {
            this.duration = duration;
            this.cache = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        public override void Intercept(IInvocation invocation)
        {
            var methodName = $"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}";
            var arguments = invocation.Arguments.ToArray();
            var key = $"{methodName}({string.Join(',', arguments.Select(a => a?.ToString() ?? "<Null>"))})";
            if (cache.IsAdded(key))
            {
                invocation.ReturnValue = cache.Get(key);
                return;
            }

            invocation.Proceed();
            cache.Add(key, invocation.ReturnValue, duration);
        }

    }
}
