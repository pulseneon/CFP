using CFP.Infrastructure.Repositories;
using CFP.Infrastructure.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CFP.Infrastructure.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabaseContext(this IServiceCollection services)
        {
            return services.AddDbContext<DbContext>();
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services.AddTransient<IActivityRepository, ActivityRepository>()
                .AddTransient<IApplicationRepository, ApplicationRepository>();
        }
    }
}
