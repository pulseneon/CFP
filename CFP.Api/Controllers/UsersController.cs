using CFP.Application.Models.Responses;
using CFP.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CFP.Api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationService _applicationService;

        public UsersController(ApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet("{id}/currentapplication")]
        public async Task<ApplicationResponse> GetCurrentApplication(Guid id)
        {
            return await _applicationService.GetCurrentApplication(id);
        }
    }
}
