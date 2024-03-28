using CFP.Application.Models.Requests;
using CFP.Application.Models.Responses;

namespace CFP.Application.Services.Interfaces
{
    public interface IApplicationService
    {
        Task<ApplicationResponse> CreateApplicationAsync(ApplicationRequest request);
        Task DeleteApplicationAsync(Guid id);
        Task<ApplicationResponse> EditApplicationAsync(Guid id, ApplicationEditRequest request);
        Task<ApplicationResponse> GetApplicationAsync(Guid id);
        Task<IEnumerable<ApplicationResponse>> GetApplicationsAsync(DateTime? submittedAfter, DateTime? unsubmittedOlder);
        Task<ApplicationResponse> GetCurrentApplication(Guid userId);
        Task SubmitApplicationAsync(Guid authorId);
    }
}
