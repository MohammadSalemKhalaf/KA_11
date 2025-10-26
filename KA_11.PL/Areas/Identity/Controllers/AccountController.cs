using KA_11.BLL.Services.Interfaces;
using KA_11.DAL.DTO.Requests;
using KA_11.DAL.DTO.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KA_11.PL.Areas.Identity.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("Identity")]
    public class AccountController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AccountController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        [HttpPost("Register")]
        public async Task<ActionResult<UserResponse>> Register([FromBody] RegisterRequest registerRequest)
        {
            var userResponse = await _authenticationService.RegisterAsync(registerRequest);
            return Ok(userResponse);
        }
        [HttpPost("Login")]
        public async Task<ActionResult<UserResponse>> Login([FromBody] LoginRequest loginRequest)
        {
            var userResponse = await _authenticationService.LoginAsync(loginRequest);
            return Ok(userResponse);
        }
        [HttpGet("ConfirmEmail")]
        public async Task<ActionResult<string>> ConfirmEmail([FromQuery] string token, [FromQuery] string userId)
        {
            var result = await _authenticationService.ConfirmEmailAsync(userId, token);
            return Ok(result);
        }
    }
}
