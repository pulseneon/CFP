using CFP.Domain.Entities;
using CFP.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CFP.Infrastructure.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly DbContext _context;

        public ActivityRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<Activity> AddAsync(Activity activity)
        {
            var addedEntity = await _context.Activities.AddAsync(activity);
            await _context.SaveChangesAsync();
        
            return addedEntity.Entity;
        }

        public async Task<List<Activity>> GetAllAsync() => await _context.Activities.AsNoTracking().ToListAsync();
    }
}
