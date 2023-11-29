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
            var _user = await userService.GetUserByNickAsync(loginRequest.Nick);

            if (_user != null)
            {
                var rolesId = _user.Roles?.Select(r => r.RoleId).ToList() ?? new List<int>();
                var roleTypes = new List<int>();

                foreach (var roleId in rolesId)
                {
                    var role = await roleService.GetRoleByIdAsync(roleId);
                    roleTypes.Add(role.Type);
                }

                return Ok(new
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
                return BadRequest(new
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