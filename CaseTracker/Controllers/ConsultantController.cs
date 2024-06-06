﻿using CaseTracker.DataAccessLayer.DataContext;
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
    [EnableCors("AllowAnyOrigin")]
    [Authorize]
    public class ConsultantController : ControllerBase
    {
        private readonly IConsultantService _consultantService;
      
        public ConsultantController(IConsultantService consultantService)
        {
            _consultantService = consultantService;
          
        }
        [Authorize]
        [HttpPost("AddNewConsultant")]
        public async Task<IActionResult> Add(CreateConsultantRequest consultantRequest)
        {
           return Ok(await _consultantService.Add(consultantRequest));
        }
        [Authorize]
        [HttpPost("AddNextSteps")]
        public async Task<IActionResult> CreateNextStep(CreateNextStepRequest request)
        {
            if (request?.ConsultantId == null)
            {
                return BadRequest(" Consultant ID not found");
            }
            return Ok(await _consultantService.CreateNextStep(request));
        }
        [Authorize]
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
        [AllowAnonymous]
        [HttpPost("AddAttachments")]
        public async Task<IActionResult> AddAttachments([FromForm] CreateAttachmentDTO dto)
        {
            return Ok(await _consultantService.AddAttachment(dto));
        }


        [Authorize]
        [HttpPut("UpdateConsultant")]
        public async Task<IActionResult> Update(UpdateConsultantRequest request)
        {
            return Ok(await _consultantService.UpdateConsultant(request));
        }
        [Authorize]
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteById(int id)
        {
            return Ok(await _consultantService.Delete(id));
        }
        
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(string consultationId)
        {
            Result? response = await _consultantService.GetById(consultationId);
            return Ok(response);
        }
        [Authorize]
        [HttpGet("GetAllConsultant")]
        public async Task<IActionResult> GetAllConsultant()
        {
            return Ok(await _consultantService.GetConsultant());
        }
        [Authorize]
        [HttpDelete("DeleteNextSteps")]
        public async Task<IActionResult> DeleteNextSteps(int NextStepId)
        {
            return Ok(await _consultantService.DeleteNextStep(NextStepId));
        }
        [Authorize]
        [HttpDelete("DeleteCommunicationUpdates")]
        public async Task<IActionResult> DeleteCommunicationUpdates(int CommunicationId)
        {
            return Ok(await _consultantService.DeleteCommunication(CommunicationId));
        }
        [Authorize]
        [HttpDelete("DeleteAttachments")]
        public async Task<IActionResult> DeleteAttachments(int AttachmentId)
        {
            return Ok(await _consultantService.DeleteAttachment(AttachmentId));
        }
        [Authorize]
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

        
        [HttpGet("DownloadFile")]
        public async Task<IActionResult> DownloadFile(string fileName)
        {
            var filepath = Path.Combine(Directory.GetCurrentDirectory(), "C:\\Users\\CentricTech\\source\\repos\\ConsulatanatApp\\CaseTracker\\wwwroot\\Uploads\\files", fileName);
            
            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(filepath, out var contenttype))
            {
                contenttype = "application/octet-stream";
            }

            var bytes = await System.IO.File.ReadAllBytesAsync(filepath);
            Console.WriteLine(File(bytes, contenttype, Path.GetFileName(filepath)));
            return File(bytes, contenttype, Path.GetFileName(filepath));
        }
        [Authorize]
        [HttpGet("GetAllConsultantDashboard")]
        public async Task<IActionResult> GetAllConsultantDashboard()
        {
            return Ok(await _consultantService.GetConsultantDashboard());
        }
        [Authorize]
        [HttpGet("GetUpcomingConsultantDashboard")]
        public async Task<IActionResult> GetUpcomingConsultantDashboard()
        {
            return Ok(await _consultantService.GetUpcomingConsultant());
        }
        [Authorize]
        [HttpGet("GetAllConsultantStatusDashboard")]
        public async Task<IActionResult> GetAllConsultantStatusDashboard()
        {
            var result = await _consultantService.GetConsultantByStatus();
            return Ok(result);
        }
    }
}
