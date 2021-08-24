using Core.CrossCuttingConcerns.Caching;
using Core.IoC;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Core.Utilities.Interceptors;
using Castle.DynamicProxy;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheRemoveAspect : MethodInterception
    {
        private string pattern;
        private readonly ICacheManager cache;

        public CacheRemoveAspect(string pattern)
        {
            this.pattern = pattern;
            this.cache = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            cache.RemoveByPattern(pattern);
        }
    }
}
