using System;
using System.Threading.Tasks;
using API.Dtos;
using API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
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

        
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUserAsync(UserToRegister userToRegisterDTO)
        {
            try
            {
                return Ok(await _authService.RegisterUserAsync(userToRegisterDTO));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUserAsync(UserToLogin userToLoginDTO)
        {
            try
            {
                return Ok(await _authService.LoginUserAsync(userToLoginDTO));
            }
            catch(Exception e)
            {
                return Unauthorized(e.Message);
            }
        }
    }
}