using CaseTracker.DataAccessLayer.DataContext;
using CaseTracker.DataAccessLayer.Models;
using CaseTracker.DataAccessLayer.Responses;
using CaseTracker.Service.DataLogics.IServices;
using CaseTracker.Service.DataLogics.Services;
using CaseTracker.Service.Request;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CaseTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyCorsPolicy")]
    public class ConsultantController : ControllerBase
    {
        private readonly IConsultantService _consultantService;

        public ConsultantController(IConsultantService consultantService)
        {
            _consultantService = consultantService;
        }
  
        [HttpPost("AddNewConsultant")]
        public async Task<IActionResult> Add(CreateConsultantRequest consultantRequest)
        {
            return Ok(await _consultantService.Add(consultantRequest));
        }
        [HttpPost("AddNextSteps")]
        public async Task<IActionResult> CreateNextStep(CreateNextStepRequest request)
        {
            if (request?.ConsultantId == null)
            {
                return BadRequest(" Consultant ID not found");
            }
            return Ok(await _consultantService.CreateNextStep(request));
        }
        [HttpPost("AddCommunicationUpdates")]
        public async Task<IActionResult> CreateCommunication(CreateCommunicationRequest request)
        {
            if (request?.ConsultantId== null)
            {
                return BadRequest("Consultant ID not found");
            }
            return Ok(await _consultantService.CreateCommunicationUpdate(request));
        }
        [HttpPost("AddAttachments")]
        public async Task<IActionResult> AddAttachments([FromForm] int consultantId,  IFormFile file)
        {
            var request = new CreateAttachmentRequest(consultantId, file);
            return Ok(await _consultantService.AddAttachment(request));
        }
        [HttpPut("UpdateConsultant")]
        public async Task<IActionResult> Update(UpdateConsultantRequest request)
        {
            return Ok(await _consultantService.UpdateConsultant(request));
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteById(int id)
        {
            return Ok(await _consultantService.Delete(id));
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(string consultantId)
        {
            Result? response = await _consultantService.GetById(consultantId);
            return Ok(response);
        }
        [HttpGet("GetAllConsultant")]
        public async Task<IActionResult> GetAllConsultant()
        {
            return Ok(await _consultantService.GetConsultant());
        }
        [HttpDelete("DeleteNextSteps")]
        public async Task<IActionResult> DeleteNextSteps(int NextStepId)
        {
            return Ok(await _consultantService.DeleteNextStep(NextStepId));
        }
        [HttpDelete("DeleteCommunicationUpdates")]
        public async Task<IActionResult> DeleteCommunicationUpdates(int CommunicationId)
        {
            return Ok(await _consultantService.DeleteCommunication(CommunicationId));
        }
        [HttpDelete("DeleteAttachments")]
        public async Task<IActionResult> DeleteAttachments(int AttachmentId)
        {
            return Ok(await _consultantService.DeleteAttachment(AttachmentId));
        }

    }
}
