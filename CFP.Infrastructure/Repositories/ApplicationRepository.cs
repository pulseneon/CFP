using CFP.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CFP.Infrastructure.Repositories
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly DbContext _context;

        public ApplicationRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<Domain.Entities.Application?> GetByIdAsync(Guid id)
        {
            return await _context.Applications.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Domain.Entities.Application>> GetAllNotSubmitByAuthorAsync(Guid id)
        {
            return await _context.Applications.AsNoTracking().Where(x => x.Author == id && x.Submitted == false).ToListAsync();
        }

        public async Task<Domain.Entities.Application> AddAsync(Domain.Entities.Application application)
        {
            var addedEntity = await _context.Applications.AddAsync(application);
            await _context.SaveChangesAsync();

            return addedEntity.Entity;
        }

        public async Task DeleteAsync(Domain.Entities.Application application)
        {
            var entity = await _context.Applications.AsNoTracking().FirstOrDefaultAsync(x => x.Id == application.Id);

            if (entity == null) return;

            _context.Applications.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task SubmitAsync(Guid id)
        {
            var entity = await _context.Applications.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null) return;

            entity.Submitted = true;
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Domain.Entities.Application> GetCurrentApplicationAsync(Guid userId)
        {
            var application = await _context.Applications.FirstOrDefaultAsync(x => x.Author == userId && x.Submitted == false);
            return application;
        }

        public async Task<List<Domain.Entities.Application>> GetAllAsync() => await _context.Applications.ToListAsync();

        public async Task<Domain.Entities.Application> EditAsync(Domain.Entities.Application application)
        {
            var entity = await _context.Applications.FindAsync(application);

            var result = _context.Applications.Update(entity);
            return result.Entity;
        }
    }
}
