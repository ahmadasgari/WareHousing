using Microsoft.EntityFrameworkCore;
using WareHousingApi.DataModel;

namespace WareHousingApi.WebApi.Extensions
{
    public static class AddDbContextServiceExtension
    {
        public static IServiceCollection AddDbContextService(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("WareHousingApiConnectionString"));
            });
            return services;

        }
    }
}
