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

            service.AddScoped<ICustomerService,CustomerService>();
            service.AddScoped<ICustomerRepository,CustomerRepository>();

            service.AddScoped<IGroupMenuService, GroupMenuService>();
            service.AddScoped<IGroupMenuRepository, GroupMenuRepository>();

            service.AddScoped<IFoodService, FoodService>();
            service.AddScoped<IFoodRepository, FoodRepository>();

            service.AddScoped<IRawMaterialService, RawMaterialService>();
            service.AddScoped<IRawMaterialRepository, RawMaterialRepository>();
        }
    }
}