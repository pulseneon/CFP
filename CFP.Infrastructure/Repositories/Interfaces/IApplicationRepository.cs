namespace CFP.Infrastructure.Repositories.Interfaces
{
    public interface IApplicationRepository
    {
        Task<Domain.Entities.Application> AddAsync(Domain.Entities.Application application);
        Task DeleteAsync(Domain.Entities.Application application);
        Task<Domain.Entities.Application> EditAsync(Domain.Entities.Application application);
        Task<List<Domain.Entities.Application>> GetAllAsync();
        Task<List<Domain.Entities.Application>> GetAllNotSubmitByAuthorAsync(Guid id);
        Task<Domain.Entities.Application?> GetByIdAsync(Guid id);
        Task<Domain.Entities.Application> GetCurrentApplicationAsync(Guid userId);
        Task SubmitAsync(Guid id);
    }
}
