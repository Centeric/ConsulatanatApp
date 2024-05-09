using LawyerApp.DataAccessLayer.Infrastructure.IServices;
using LawyerApp.Models.Model;
using LawyerApp.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LawyerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService) 
        {
            _authService = authService;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(User user)
        {
            if (!ModelState.IsValid)
            {
                BadRequest(new { message = "Model State is not valid" });
            }
            var response = await _authService.Add(user);
            if (response)
            {
                return Ok(new {message="Register Successfully"});
            }
            return BadRequest(new {message = "Error"});

        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginView loginView)
        {
           var response = await _authService.Login(loginView.Email, loginView.Password);
            if (response != null)
            {
                return Ok(new {message ="Login Successfully",response});
            }
            return BadRequest(new { message = "Invalid Credentials" });
        }
    }
}
