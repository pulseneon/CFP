using CFP.Application.Constants;
using CFP.Application.Exceptions;
using CFP.Application.Extensions;
using CFP.Application.Models.Requests;
using CFP.Application.Models.Responses;
using CFP.Application.Services.Interfaces;
using CFP.Domain.Entities;
using CFP.Infrastructure.Repositories.Interfaces;
using System.Globalization;
using System.Net;

namespace CFP.Application.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IActivityRepository _activityRepository;
        
        private const string _dateTimeFormat = "yyyy-MM-dd HH:mm.ss";

        public ApplicationService(IApplicationRepository applicationRepository, IActivityRepository activityRepository)
        {
            _applicationRepository = applicationRepository;
            _activityRepository = activityRepository;
        }

        public async Task<ApplicationResponse> GetApplicationAsync(Guid id)
        {
            var application = await _applicationRepository.GetByIdAsync(id);

            if (application is null)
            {
                throw new ApiException(HttpStatusCode.NotFound, ApiExceptionType.ApplicationNotFound, ApiExceptionMessage.ApplicationNotFound);
            }

            var activity = await _activityRepository.GetById((Guid)application.Activity);

            return application.ToResponse(activity.Name);
        }

        public async Task<ApplicationResponse> CreateApplicationAsync(ApplicationRequest request)
        {
            var usersNotConsidered = await _applicationRepository.GetAllNotSubmitByAuthorAsync(request.Author);
            if (usersNotConsidered.Count > 0)
            {
                throw new ApiException(HttpStatusCode.NotFound, "одна заявка уже открыта", ApiExceptionMessage.ActivityNotFound);
            }

            var activity = new Activity();
            if (request.Type != null)
            {
                activity = await _activityRepository.GetByName(request.Type);
            }

            if (activity == null && request.Type != null)
            {
                throw new ApiException(HttpStatusCode.NotFound, ApiExceptionType.ActivityNotFound, ApiExceptionMessage.ActivityNotFound);
            }

            var application = new Domain.Entities.Application()
            {
                Id = Guid.NewGuid(),
                Author = request.Author,
                Activity = activity.Id,
                Name = request.Name,
                Description = request.Description,
                Outline = request.Outline,
            };

            var result = await _applicationRepository.AddAsync(application);
            return result.ToResponse(activity.Name);
        }

        public async Task DeleteApplicationAsync(Guid id)
        {
            var application = await _applicationRepository.GetByIdAsync(id);

            if (application == null)
            {
                throw new ApiException(HttpStatusCode.NotFound, ApiExceptionType.ApplicationNotFound, ApiExceptionMessage.ApplicationNotFound);
            }

            if (application.Submitted == true)
            {
                throw new ApiException(HttpStatusCode.BadRequest, ApiExceptionType.ApplicationSubmitted, ApiExceptionMessage.ApplicationSubmitted);
            }

            await _applicationRepository.DeleteAsync(application);
        }

        public async Task SubmitApplicationAsync(Guid id)
        {
            var application = await _applicationRepository.GetByIdAsync(id);

            if (application == null)
            {
                throw new ApiException(HttpStatusCode.NotFound, ApiExceptionType.ApplicationNotFound, ApiExceptionMessage.ApplicationNotFound);
            }

            if (application.Submitted == true)
            {
                throw new ApiException(HttpStatusCode.Conflict, ApiExceptionType.ApplicationSubmitted, ApiExceptionMessage.ApplicationSubmitted);
            }

            if (application.Activity is null)
                throw new ApiException(HttpStatusCode.BadRequest, ApiExceptionType.NotAllRequiredFields, ApiExceptionMessage.NotAllRequiredFields);
            if (application.Name is null)
                throw new ApiException(HttpStatusCode.BadRequest, ApiExceptionType.NotAllRequiredFields, ApiExceptionMessage.NotAllRequiredFields);
            if (application.Outline is null)
                throw new ApiException(HttpStatusCode.BadRequest, ApiExceptionType.NotAllRequiredFields, ApiExceptionMessage.NotAllRequiredFields);

            await _applicationRepository.SubmitAsync(id);
        }

        public async Task<ApplicationResponse> GetCurrentApplication(Guid userId)
        {
            var result = await _applicationRepository.GetCurrentApplicationAsync(userId);

            if (result == null)
            {
                throw new ApiException(HttpStatusCode.NotFound, ApiExceptionType.CurrentApplicationNotFound, ApiExceptionMessage.CurrentApplicationNotFound);
            }

            var activity = await _activityRepository.GetById((Guid)result.Activity);

            return result.ToResponse(activity.Name);
        }

        public async Task<IEnumerable<ApplicationResponse>> GetApplicationsAsync(string submittedAfter, string unsubmittedOlder)
        {
            if (submittedAfter is not null && unsubmittedOlder is not null)
            {
                throw new ApiException(HttpStatusCode.BadRequest, ApiExceptionType.IncompatibleParameters, ApiExceptionMessage.IncompatibleParameters);
            }

            var applications = await _applicationRepository.GetAllAsync();
            var activities = await _activityRepository.GetAllAsync();

            if (!DateTime.TryParseExact(submittedAfter, _dateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedSubmittedAfter)
                && submittedAfter is not null)
            {
                throw new ApiException(HttpStatusCode.BadRequest, ApiExceptionType.IncompatibleParameters, ApiExceptionMessage.IncompatibleParameters);
            }

            if (!DateTime.TryParseExact(unsubmittedOlder, _dateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedUnsubmittedOlder)
                && unsubmittedOlder is not null)
            {
                throw new ApiException(HttpStatusCode.BadRequest, ApiExceptionType.IncompatibleParameters, ApiExceptionMessage.IncompatibleParameters);
            }

            if (submittedAfter is not null)
                applications = applications.submittedAfter(parsedSubmittedAfter);
            if (unsubmittedOlder is not null)
                applications = applications.unsubmittedOlder(parsedUnsubmittedOlder);

            return applications.ToResponse(activities);
        }

        public async Task<ApplicationResponse> EditApplicationAsync(Guid id, ApplicationEditRequest request)
        {
            var application = await _applicationRepository.GetByIdAsync(id);

            if (application == null)
            {
                throw new ApiException(HttpStatusCode.NotFound, ApiExceptionType.ApplicationNotFound, ApiExceptionMessage.ApplicationNotFound);
            }

            if (application.Submitted == true)
            {
                throw new ApiException(HttpStatusCode.Conflict, ApiExceptionType.ApplicationSubmitted, ApiExceptionMessage.ApplicationSubmitted);
            }

            var activity = new Activity();
            if (request.Activity != null)
            {
                activity = await _activityRepository.GetByName(request.Activity);
            }

            if (activity == null && request.Activity != null)
            {
                throw new ApiException(HttpStatusCode.NotFound, ApiExceptionType.ActivityNotFound, ApiExceptionMessage.ActivityNotFound);
            }

            application.Activity = activity.Id;
            application.Name = request.Name;
            application.Description = request.Description;
            application.Outline = request.Outline;

            var result = await _applicationRepository.EditAsync(application);
            return result.ToResponse(activity.Name);
        }
    }
}
