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
            if (isSuccessful)
            {
                var _user = await userService.GetUserByNickAsync(loginRequest.Nick);
                var roles = _user.Roles?.Select(r => r.Role.Type).ToList() ?? new List<int>();
                
                return Ok(
                    new
                    {
                        Name = _user.Name,
                        Id = _user.Id,
                        Nick = _user.Nick,
                        Roles = roles,
                        Message = "Succesful Login ",
                        Success = true
                    });
            }
            else
            {
                return BadRequest(
                    new
                    {
                        Message = "Worng Credentials",
                        Success = false
                    });
            }
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