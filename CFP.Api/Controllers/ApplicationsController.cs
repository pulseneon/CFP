using CFP.Application.Attributes;
using CFP.Application.Models.Requests;
using CFP.Application.Models.Responses;
using CFP.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CFP.Api.Controllers
{
    [Route("api/applications")]
    [ApiController]
    public class ApplicationsController : ControllerBase
    {
        private readonly ApplicationService _service;

        public ApplicationsController(ApplicationService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<ApplicationResponse> GetApplicationAsync(Guid id)
        {
            return await _service.GetApplicationAsync(id);
        }

        [HttpGet]
        public async Task<IEnumerable<ApplicationResponse>> GetApplicationsAsync(DateTime? submittedAfter, DateTime? unsubmittedOlder)
        {
            return await _service.GetApplicationsAsync(submittedAfter, unsubmittedOlder);
        }

        [HttpPost]
        public async Task<ApplicationResponse> AddApplicationAsync([AnyFieldRequired]ApplicationRequest request)
        {
            return await _service.CreateApplicationAsync(request);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApplication(Guid id)
        {
            await _service.DeleteApplicationAsync(id);

            return Ok();
        }

        [HttpPost("{id}/submit")]
        public async Task<IActionResult> SubmitApplication(Guid id)
        {
            await _service.SubmitApplicationAsync(id);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ApplicationResponse> PutApplication(Guid id, [AnyFieldRequired]ApplicationEditRequest request)
        {
            return await _service.EditApplicationAsync(id, request);
        }
    }
}
