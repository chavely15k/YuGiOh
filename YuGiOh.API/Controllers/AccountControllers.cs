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
        public readonly IRoleService roleService;
        public AccountController(IUserService userService, IRoleService roleService)
        {
            this.userService = userService;
            this.roleService = roleService;
        }
        [HttpPost("login")]

        public async Task<ActionResult> Login(LoginDto loginRequest)
        {
            var response = await userService.LoginAsync(loginRequest);
            return response.Success == true ?  Ok(response) :
            BadRequest(response);
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