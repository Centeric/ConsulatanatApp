using CaseTracker.DataAccessLayer.Responses;
using CaseTracker.Service.DataLogics.IServices;
using CaseTracker.Service.Request;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaseTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyCorsPolicy")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("Add-User")]
        public async Task<IActionResult> Add(CreateUserRequest userRequest)
        {
            Result response = await _authService.Add(userRequest);
            return Ok(response);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            Result response = await _authService.Login(loginRequest.Email, loginRequest.Password);
            return Ok(response);
        }
        [HttpDelete("Delete-User/{id}")]
        public async Task<IActionResult> Delete(int userId)
        {
            Result response = await _authService.Delete(userId);
            return Ok(response);
        }

    }
}
