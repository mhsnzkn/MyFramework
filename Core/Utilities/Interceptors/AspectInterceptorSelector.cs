﻿using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();
            var methodAttributes = type.GetMethod(method.Name).GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();
            classAttributes.AddRange(methodAttributes);

            return classAttributes.OrderBy(a => a.Priority).ToArray();
        }
    }
}
