using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.DTOs;
using StudentManagementSystem.Helpers;

namespace StudentManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            if (dto.Email == "admin@gmail.com"
               && dto.Password == "admin123")
            {
                var token = JwtHelper.GenerateToken(_configuration);

                return Ok(new
                {
                    Message = "Login successful",
                    Token = token
                });
            }

            return Unauthorized(new
            {
                Message = "Invalid email or password"
            });
        }
    }
}
