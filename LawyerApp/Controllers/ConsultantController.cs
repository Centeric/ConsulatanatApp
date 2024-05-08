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
        [HttpPost("AddNew")]
        public async Task<IActionResult> Create(Consultant consultant)
        {
            var isConsultanCreated = await _consultantService.Create(consultant);

            if (isConsultanCreated)
            {
                return Ok(new { message = "Added Succesfully" });
            }
            else
            {
                return BadRequest("Error");
            }
        }
        [HttpGet("GetbyId")]
        public async Task<IActionResult> GetById(string consultationId)
        {
            var result = await _consultantService.GetConsultantById(consultationId);

            if (result != null)
            {
                return Ok(new {message = "Data Loaded Successfully"});
            }
            else
            {
                return BadRequest("Error");
            }
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateConsultant(Consultant consultant)
        {
            if (consultant != null)
            {
                var result = await _consultantService.UpdateConsultation(consultant);
                if (result)
                {
                    return Ok(new { message = "Updated Successfully" });
                }
                return BadRequest("Error");
            }
            else
            {
                return BadRequest("Data Not Found");
            }
        }
    }
}
