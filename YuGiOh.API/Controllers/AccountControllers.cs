using Microsoft.AspNetCore.Mvc;
using YuGiOh.Domain.Models;
using YuGiOh.ApplicationCore.DTO;
using YuGiOh.ApplicationServices.Service;

namespace YuGiOh.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        public readonly IUserService userService;
        public AccountController(IUserService userService)
        {
            this.userService = userService;
        }
        // [HttpGet]
        // [Route("login")]
        // public async Task<ActionResult> Get(LoginRequest loginRequest)
        // {
        //     User? user = await userService.Get(loginRequest);
        //     return Ok(user);
        // }
        [HttpPost]
        public async Task<ActionResult> Create(RegisterUserDto registerUser)
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