using CaseTracker.DataAccessLayer.DataContext;
using CaseTracker.DataAccessLayer.IDataServices;
using CaseTracker.DataAccessLayer.Models;
using CaseTracker.DataAccessLayer.Responses;

using CaseTracker.Service.DataLogics.IServices;
using CaseTracker.Service.DataLogics.Services;
using CaseTracker.Service.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace CaseTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  
    [Authorize]
    public class ConsultantController : ControllerBase
    {
        private readonly IConsultantService _consultantService;
        private readonly IConsultantRepo _consultantRepo;
        public ConsultantController(IConsultantService consultantService, IConsultantRepo consultantRepo)
        {
            _consultantService = consultantService;
            _consultantRepo = consultantRepo;
        }
    
        [HttpPost("AddNewConsultant")]
        public async Task<IActionResult> Add(CreateConsultantRequest consultantRequest)
        {
            var result = await _consultantService.Add(consultantRequest);

            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);

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

        //[HttpPost("AddAttachments")]
        //public async Task<IActionResult> AddAttachments([FromForm] List<IFormFile> files, string? consultationId, int consultantId)
        //{
        //    var requests = files.Select(file => new CreateAttachmentRequest(consultantId, consultationId, file)).ToList();
        //    return Ok(await _consultantService.AddAttachment(requests));
        //}
        // [Authorize]
     
        [HttpPost("AddAttachments")]
        public async Task<IActionResult> AddAttachments([FromForm] CreateAttachmentDTO dto)
        {
            return Ok(await _consultantService.AddAttachment(dto));
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
        [AllowAnonymous]
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(string consultationId)
        {
            Result? response = await _consultantService.GetById(consultationId);
          
            if (response.Data == null)
                    {
                return BadRequest(new  { message="The id is Not Found" });

            }
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
      
        [HttpPut("UpdateStatusByConsultationId")]
        public async Task<IActionResult> UpdateStatusByConsultationId([FromBody] UpdateStatusRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var allowedStatuses = new List<string> { "Pending", "On-Going", "Completed", "Awaiting Return Of Documents" };
            if (!allowedStatuses.Contains(request.NewStatus!))
            {
                return BadRequest(new { message = "Invalid status" });
            }
            var result = await _consultantService.UpdateStatus(request);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(new { message = "Error while updating status" });
            }
        }

        [AllowAnonymous]
        [HttpGet("DownloadFile")]
        public async Task<IActionResult> DownloadFile(string fileName)
        {
            var filepath = Path.Combine(Directory.GetCurrentDirectory(), "C:\\CaseTracker\\wwwroot\\Uploads\\files", fileName);
            
            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(filepath, out var contenttype))
            {
                contenttype = "application/octet-stream";
            }

            var bytes = await System.IO.File.ReadAllBytesAsync(filepath);
            Console.WriteLine(File(bytes, contenttype, Path.GetFileName(filepath)));
            return File(bytes, contenttype, Path.GetFileName(filepath));
        }
      
        [HttpGet("GetAllConsultantDashboard")]
        public async Task<IActionResult> GetAllConsultantDashboard()
        {
            return Ok(await _consultantService.GetConsultantDashboard());
        }
        
        [HttpGet("GetUpcomingConsultantDashboard")]
        public async Task<IActionResult> GetUpcomingConsultantDashboard()
        {
            return Ok(await _consultantService.GetUpcomingConsultant());
        }
        
        [HttpGet("GetAllConsultantStatusDashboard")]
        public async Task<IActionResult> GetAllConsultantStatusDashboard()
        {
            var result = await _consultantService.GetConsultantByStatus();
            return Ok(result);
        }
    }
}
