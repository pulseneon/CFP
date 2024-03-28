using CFP.Application.Models.Responses;
using CFP.Domain.Entities;

namespace CFP.Application.Extensions
{
    public static class ResponseExtensions
    {
        public static ActivityResponse ToResponse(this Activity response) => new ActivityResponse()
        {
            Activity = response.Name,
            Description = response.Description,
        };

        public static IEnumerable<ActivityResponse> ToResponse(this List<Activity> response) =>
            response.Select(activity => new ActivityResponse
        {
            Activity = activity.Name,
            Description = activity.Description,
        });
    }
}
