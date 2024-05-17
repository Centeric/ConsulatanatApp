using CaseTracker.DataAccessLayer.DataContext;
using CaseTracker.DataAccessLayer.Models;
using CaseTracker.DataAccessLayer.Responses;
using CaseTracker.Service.Common;
using CaseTracker.Service.DataLogics.IServices;
using CaseTracker.Service.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace CaseTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultantController : ControllerBase
    {
        private readonly IConsultantService _consultantService;
        private readonly ApplicationDbContext _context;

        public ConsultantController(IConsultantService consultantService, ApplicationDbContext context)
        {
            _consultantService = consultantService;
            _context = context;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDTO register)
        {
            var existingUser = await _context.UserDetail.FirstOrDefaultAsync(u => u.Email == register.Email);
            if (existingUser != null)
                return Conflict("Username already exists");

            var newUser = new UserDetails
            {
                Email = register.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(register.Password)
        };

            _context.UserDetail.Add(newUser);
            await _context.SaveChangesAsync();
            return Ok(Result.Success(Constants.Added));
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
       
    }
}
