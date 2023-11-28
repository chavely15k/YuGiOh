using Microsoft.AspNetCore.Mvc;
using YuGiOh.Domain.Models;
using YuGiOh.ApplicationCore.DTO;
using YuGiOh.ApplicationServices.Service;

namespace YuGiOh.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        public readonly IUserService userService;
        public AccountController(IUserService userService)
        {
            this.userService = userService;
        }
        [HttpGet("login")]
        public async Task<ActionResult> Login(LoginRequestDto loginRequest)
        {
            bool isSuccessful = await userService.LoginAsync(loginRequest);
            return isSuccessful
                ? Ok(new
                {
                    Message = "Inicio de sesión exitoso",
                    Success = true


                })
                : BadRequest(new { Message = "Credenciales incorrectas", IsSuccessful = false });
        }
        [HttpPost("register")]
        public async Task<ActionResult> Register(UserDto registerUser)
        {
            if (await userService.IsNickTakenAsync(registerUser.Nick))
            {
                return BadRequest(new
                {
                    Message = "Nick already in use.",
                    Success = false
                });
            }

            var response = await userService.RegisterUserAsync(registerUser);
            return Ok(response);
        }
    }
}