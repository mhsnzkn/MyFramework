using Business.Constants;
using Castle.DynamicProxy;
using Core.Entities.Concrete;
using Core.IoC;
using Core.Utilities.Interceptors;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Business.BusinessAspects.Autofac
{
    public class SecuredOperations : MethodInterception
    {
        private string[] roles;
        private IHttpContextAccessor httpContextAccessor;
        public SecuredOperations(string roles)
        {
            this.roles = roles.Split(',');
            httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in roles)
            {
                if (roleClaims.Contains(role))
                    return;
            }

            throw new Exception(Messages.AuthorizationDenied);
        }
    }
}
