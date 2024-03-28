using CFP.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CFP.Application.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services.AddScoped<ActivityService>()
                .AddScoped<ApplicationService>();
        }
    }
}
