using DataAccessLayer;
using LawyerApp.DataAccessLayer.Infrastructure.IServices;
using LawyerApp.Models.Model;
using LawyerApp.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LawyerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultantController : ControllerBase
    {
        private readonly IConsultantService _consultantService;
        private readonly ApplicationDbContext applicationDbContext;
        public ConsultantController(IConsultantService consultantService, ApplicationDbContext context)
        {
            _consultantService = consultantService;
            applicationDbContext = context;
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
        [HttpPost("AddNextSteps")]
        public async Task<IActionResult> AddNextSteps(NextStepView next)
        {

            var isNextStepCreated = await _consultantService.CreateNextSteps(next);
            if (isNextStepCreated)
            {
                return Ok(new { message = "NextSteps added" });
            }
            return BadRequest(new {message = "Error"});
        }
        [HttpPost("AddCommunicationUpdates")]
        public async Task<IActionResult> AddCommunicationUpdate(CommunicationUpdateView inp)
        {
            var isNextStepCreated = await _consultantService.CreateCommunicationUpdate(inp);
            if (isNextStepCreated)
            {
                return Ok(new { message = "CommunicationUpdates added" });
            }
            return BadRequest(new { message = "Error" });
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
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetConsultantList()
        {
  
               var consultantList = await _consultantService.GetAllConsultant();
            //var viewModel = new ConsultantView
            //{
            //    Id = consultantList..Id,
            //    ConsultationId = result.ConsultationId,
            //    TimeShareName = result.TimeShareName,
            //    ClientName = result.ClientName,
            //    ConsultationStatus = result.ConsultationStatus,
            //    TimeShare = result.TimeShare,
            //    PaymentReceived = result.PaymentReceived,
            //    LeadConsultant = result.LeadConsultant,
            //    AssistantConsultant = result.AssistantConsultant,
            //    FilingDate = result.FilingDate,
            //    HearingDate = result.HearingDate,
            //    DeadlineForDocumentSubmission = result.DeadlineForDocumentSubmission,
            //    DateOfTransfer = result.DateOfTransfer,
            //    CaseSummary = result.CaseSummary,
            //    NextSteps = result.NextSteps.Select(n => n.NextStep).ToList(),
            //    CommunicationUpdates = result.CommunicationUpdates.Select(c => c.CommunicationUpdate).ToList()
            //};
            //return viewModel;
            if (consultantList == null)
            {
                return NotFound();
            }
            else
            {

                var consultantViews = consultantList.Select(c => new ConsultantView
                {
                    ConsultationId = c.ConsultationId,
                    ClientName = c.ClientName,
                    TimeShareName = c.TimeShareName,
                    ConsultationStatus = c.ConsultationStatus,
                    TimeShare = c.TimeShare,
                    FilingDate = c.FilingDate,
                    HearingDate = c.HearingDate,
                    DateOfTransfer = c.DateOfTransfer,
                    // Add other properties as needed
                }).ToList();
               // return consultantL;
            }
            return Ok(consultantList);
        }
    }
}
