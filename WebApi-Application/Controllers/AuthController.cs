using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.Common.Models;
using WebApi.Infrastucture.Services;

namespace WebApi_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtTokenService _tokenService;

        public AuthController(JwtTokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            if (request.Username == "admin"
                && request.Password == "1234")
            {
                var token = _tokenService
                    .GenerateToken(request.Username, request.Role);

                return Ok(new { Token = token });
            }

            return Unauthorized();
        }
    }
}
