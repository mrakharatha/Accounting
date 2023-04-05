using Accounting.Application.Interfaces;
using Accounting.Application.Services;
using Accounting.Domain.Interfaces;
using Accounting.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.IoC.Accounting
{

    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection service)
        {
            service.AddScoped<IPermissionService, PermissionService>();
            service.AddScoped<IPermissionRepository, PermissionRepository>();



            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IUserRepository, UserRepository>();
        }
    }
}