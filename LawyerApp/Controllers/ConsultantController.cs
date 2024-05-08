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
            var existingConsultant = await _consultantService.GetConsultantById(consultant.ConsultationId);

            if (existingConsultant != null)
            {

                return BadRequest(new { message = "ConsultationId already exists." });
            }

            var isConsultantCreated = await _consultantService.Create(consultant);

            if (isConsultantCreated)
            {
                return Ok(new { message = "Added Succesfully" });
            }
            else
            {
                return BadRequest(new { message = "Error" });
            }
        }
        [HttpGet("GetbyId")]
        public async Task<IActionResult> GetById(string consultationId)
        {
            var result = await _consultantService.GetConsultantById(consultationId);

            if (result != null)
            {
                return Ok(new { message = "Data Loaded Successfully", result });
            }
            else
            {
                return BadRequest(new { message = "Error" });
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
                return BadRequest(new { message = "Error" });
            }
            else
            {
                return BadRequest(new { message = "Data Not Found" });
            }
        }
        [HttpDelete("DeleteById")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var result = await _consultantService.DeleteById(id);
            if (result)
            {
                return Ok(new { message = "Data Deleted Successfully" });
            }
            else
            {
                return BadRequest(new { message = "Id Not Found" });
            }
        }
    }
}
