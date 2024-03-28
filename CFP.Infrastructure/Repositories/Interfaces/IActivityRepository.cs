using CFP.Domain.Entities;

namespace CFP.Infrastructure.Repositories.Interfaces
{
    public interface IActivityRepository
    {
        Task<Activity> AddAsync(Activity activity);
        Task<List<Activity>> GetAllAsync();
        Task<Activity?> GetById(Guid id);
        Task<Activity?> GetByName(string name);
    }
}
