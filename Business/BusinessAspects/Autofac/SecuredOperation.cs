using Core.Entities.IoC;
using Core.Utilities.Interceptors;
using Microsoft.AspNetCore.Http;
using System;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using Core.Extensions;
using Business.Constants;

namespace Business.BusinessAspects.Autofac
{
    //JWT
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;

        public SecuredOperation(string roles)
        {
            //aspecler , ile ayrıldığı için
            _roles = roles.Split(',');
            //Buda projemizi olurda windows formda çevirirsek aşağıdaki bir kaç kodu değiştirerek işleme devam etmemizi sağlar
            //_httpContext örnek IProductDal yazarak autofacte injectionlarımızı almamızı sağlar.
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();

        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            throw new Exception(Messages.AuthorizationDenied);
        }
    }
}
