using CFP.Application.Constants;
using CFP.Application.Exceptions;
using CFP.Application.Extensions;
using CFP.Application.Models.Requests;
using CFP.Application.Models.Responses;
using CFP.Application.Services.Interfaces;
using CFP.Domain.Entities;
using CFP.Infrastructure.Repositories.Interfaces;
using System.Net;

namespace CFP.Application.Services
{
    public class ActivityService: IActivityService
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
            if (await _repository.GetByName(request.Name) is not null)
            {
                throw new ApiException(HttpStatusCode.Conflict, ApiExceptionType.RecordExists, ApiExceptionMessage.RecordExists);
            }

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
