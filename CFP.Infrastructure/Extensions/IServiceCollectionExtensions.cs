using Microsoft.Extensions.DependencyInjection;

namespace CFP.Infrastructure.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabaseContext(this IServiceCollection services)
        {
            return services.AddDbContext<DbContext>();
        }
    }
}
