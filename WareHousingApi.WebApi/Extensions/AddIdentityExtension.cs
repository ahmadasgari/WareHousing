using Microsoft.AspNetCore.Identity;
using WareHousingApi.DataModel;
using WareHousingApi.DataModel.Entities;

namespace WareHousingApi.WebApi.Extensions
{
    public static class AddIdentityExtension
    {
        public static IServiceCollection AddIdentityService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity<ApplicationUsers, ApplicationRoles>(opt =>
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireNonAlphanumeric = false;
            })
               .AddRoles<ApplicationRoles>()
               .AddRoleValidator<RoleValidator<ApplicationRoles>>()
               .AddRoleManager<RoleManager<ApplicationRoles>>()
               .AddSignInManager<SignInManager<ApplicationUsers>>()
               .AddEntityFrameworkStores<ApplicationDbContext>();
                return services;
                
        }
    }
}
