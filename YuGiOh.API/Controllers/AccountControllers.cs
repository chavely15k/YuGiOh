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
        public async Task<ActionResult> Login(LoginRequestDto loginRequest)
        {
            bool isSuccessful = await userService.LoginAsync(loginRequest);
            if (isSuccessful)
            {
                var _user = await userService.GetUserByNickAsync(loginRequest.Nick);
                var rolesId = _user.Roles.Select(r => r.RoleId).ToList() ?? new List<int>();
                var roleTasks = rolesId.Select(async r => await roleService.GetRoleByIdAsync(r));
                var roles = await Task.WhenAll(roleTasks);
                var roleTypes = roles.Select(r => r.Type).ToList();

                return Ok(
                    new
                    {
                        Name = _user.Name,
                        Id = _user.Id,
                        Nick = _user.Nick,
                        Roles = roleTypes,
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