using CFP.Application.Models.Requests;
using CFP.Application.Models.Responses;

namespace CFP.Application.Services.Interfaces
{
    public interface IActivityService
    {
        Task<ActivityResponse> AddActivityAsync(ActivityRequest request);
        Task<IEnumerable<ActivityResponse>> GetActivitiesAsync();
    }
}
