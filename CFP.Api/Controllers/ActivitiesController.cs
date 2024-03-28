using CFP.Application.Models.Requests;
using CFP.Application.Models.Responses;
using CFP.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CFP.Api.Controllers
{
    [Route("api/activities")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly ActivityService _service;

        public ActivitiesController(ActivityService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<ActivityResponse>> GetActivitiesAsync()
        {
            return await _service.GetActivitiesAsync();
        }

        [HttpPost]
        public async Task<ActivityResponse> AddActivitiesAsync([Required] ActivityRequest request)
        {
            return await _service.AddActivityAsync(request);
        }
    }
}
