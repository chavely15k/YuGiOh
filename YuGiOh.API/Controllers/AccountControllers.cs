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
                ? Ok(new { Message = "Inicio de sesión exitoso", IsSuccessful = true })
                : BadRequest(new { Message = "Credenciales incorrectas", IsSuccessful = false });
        }
        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterUserDto registerUser)
        {
            if (await userService.IsNickTakenAsync(registerUser.Nick))
            {
                return BadRequest(new { Message = "El nick ya está en uso." });
            }

            var register = await userService.RegisterUserAsync(registerUser);

            var response = new
            {
                Message = "Registro exitoso.",
                User = register
            };

            return Ok(response);
        }
    }
}