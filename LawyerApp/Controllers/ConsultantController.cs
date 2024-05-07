using LawyerApp.DataAccessLayer.Infrastructure.IServices;
using LawyerApp.Models.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LawyerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultantController : ControllerBase
    {
        private readonly IConsultantService _consultantService;
        public ConsultantController(IConsultantService consultantService)
        {
            _consultantService = consultantService;
        }
        [HttpPost]
        public async Task<IActionResult> Create(Consultant consultant)
        {
            var isConsultanCreated = await _consultantService.Create(consultant);

            if (isConsultanCreated)
            {
                return Ok(isConsultanCreated);
            }
            else
            {
                return BadRequest("Error");
            }
        }
    }
}
