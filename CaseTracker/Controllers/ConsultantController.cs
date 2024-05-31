using CaseTracker.DataAccessLayer.DataContext;
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
    [EnableCors("MyCorsPolicy")]
    public class ConsultantController : ControllerBase
    {
        private readonly IConsultantService _consultantService;
      
        public ConsultantController(IConsultantService consultantService)
        {
            _consultantService = consultantService;
          
        }

        [AllowAnonymous]
        [HttpPost("AddNewConsultant")]
        public async Task<IActionResult> Add(CreateConsultantRequest consultantRequest)
        {
           return Ok(await _consultantService.Add(consultantRequest));
        }
        [AllowAnonymous]
        [HttpPost("AddNextSteps")]
        public async Task<IActionResult> CreateNextStep(CreateNextStepRequest request)
        {
            if (request?.ConsultantId == null)
            {
                return BadRequest(" Consultant ID not found");
            }
            return Ok(await _consultantService.CreateNextStep(request));
        }
        [AllowAnonymous]
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
        [AllowAnonymous]
        [HttpPost("AddAttachments")]
        public async Task<IActionResult> AddAttachments([FromForm] CreateAttachmentDTO dto)
        {
            return Ok(await _consultantService.AddAttachment(dto));
        }


        [AllowAnonymous]
        [HttpPut("UpdateConsultant")]
        public async Task<IActionResult> Update(UpdateConsultantRequest request)
        {
            return Ok(await _consultantService.UpdateConsultant(request));
        }
        [AllowAnonymous]
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteById(int id)
        {
            return Ok(await _consultantService.Delete(id));
        }
        [AllowAnonymous]
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(string consultantId)
        {
            Result? response = await _consultantService.GetById(consultantId);
            return Ok(response);
        }
        [AllowAnonymous]
        [HttpGet("GetAllConsultant")]
        public async Task<IActionResult> GetAllConsultant()
        {
            return Ok(await _consultantService.GetConsultant());
        }
        [AllowAnonymous]
        [HttpDelete("DeleteNextSteps")]
        public async Task<IActionResult> DeleteNextSteps(int NextStepId)
        {
            return Ok(await _consultantService.DeleteNextStep(NextStepId));
        }
        [AllowAnonymous]
        [HttpDelete("DeleteCommunicationUpdates")]
        public async Task<IActionResult> DeleteCommunicationUpdates(int CommunicationId)
        {
            return Ok(await _consultantService.DeleteCommunication(CommunicationId));
        }
        [AllowAnonymous]
        [HttpDelete("DeleteAttachments")]
        public async Task<IActionResult> DeleteAttachments(int AttachmentId)
        {
            return Ok(await _consultantService.DeleteAttachment(AttachmentId));
        }
        [AllowAnonymous]
        [HttpPut("UpdateStatusByConsultationId")]
        public async Task<IActionResult> UpdateStatusByConsultationId([FromBody] UpdateStatusRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _consultantService.UpdateStatus(request);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Error while updating status");
            }
        }

        [AllowAnonymous]
        [HttpGet("DownloadFile")]
        public async Task<IActionResult> DownloadFile(string fileName)
        {
            var filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Uploads\\files", fileName);
            
            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(filepath, out var contenttype))
            {
                contenttype = "application/octet-stream";
            }

            var bytes = await System.IO.File.ReadAllBytesAsync(filepath);
            Console.WriteLine(File(bytes, contenttype, Path.GetFileName(filepath)));
            return File(bytes, contenttype, Path.GetFileName(filepath));
        }
        [AllowAnonymous]
        [HttpGet("GetAllConsultantDashboard")]
        public async Task<IActionResult> GetAllConsultantDashboard()
        {
            return Ok(await _consultantService.GetConsultantDashboard());
        }
        [AllowAnonymous]
        [HttpGet("GetUpcomingConsultantDashboard")]
        public async Task<IActionResult> GetUpcomingConsultantDashboard()
        {
            return Ok(await _consultantService.GetUpcomingConsultant());
        }
        [AllowAnonymous]
        [HttpGet("GetAllConsultantStatusDashboard")]
        public async Task<IActionResult> GetAllConsultantStatusDashboard()
        {
            return Ok(await _consultantService.GetConsultantByStatus());
        }
    }
}
