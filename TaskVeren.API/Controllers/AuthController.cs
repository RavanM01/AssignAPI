using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskVeren.Business.DTOs.User;
using TaskVeren.Business.Services.Interfaces;

namespace TaskVeren.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        readonly IUserService userService;

        public AuthController(IUserService userService)
        {
            this.userService = userService;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Register([FromForm] RegisterDto dto)
        {
            try
            {
                await userService.Register(dto);
                return Ok("Register oldu");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromForm] LoginDto dto)
        {
            
            try
            {

                return Ok(await userService.Login(dto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
