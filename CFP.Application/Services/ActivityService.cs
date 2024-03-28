using CFP.Application.Extensions;
using CFP.Application.Models.Requests;
using CFP.Application.Models.Responses;
using CFP.Domain.Entities;
using CFP.Infrastructure.Repositories.Interfaces;

namespace CFP.Application.Services
{
    public class ActivityService
    {
        private readonly IActivityRepository _repository;

        public ActivityService(IActivityRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ActivityResponse>> GetActivitiesAsync()
        {
            var entities = await _repository.GetAllAsync();
            return entities.ToResponse();
        }

        public async Task<ActivityResponse> AddActivityAsync(ActivityRequest request)
        {
            var activity = new Activity()
            {
                Id = Guid.NewGuid(),
                Description = request.Description,
                Name = request.Name,
            };

            var result = await _repository.AddAsync(activity);

            return result.ToResponse();
        }
    }
}
