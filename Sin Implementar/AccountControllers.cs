using Microsoft.AspNetCore.Mvc;
using YuGiOh.Domain.Models;
using YuGiOh.ApplicationCore.DTO;
using YuGiOh.ApplicationCore.Services;

namespace YuGiOh.API.Controllers {
    
[ApiController]
[Route("account")]
public class AccountController : ControllerBase
{
    public readonly IUserService userService;
    public AccountController(IUserService userService) {
        this.userService = userService;
    }
    [HttpGet]
    [Route("login")]
    public async Task<ActionResult> Get(LoginRequest loginRequest)
    {
        User? user = await userService.Get(loginRequest);
        return Ok(user);
    }
    [HttpPost]
    [Route("register")]
    public async Task<ActionResult> Create(RegisterUserRequest registerUserRequest)
    {
        User? user = await userService.Create(registerUserRequest);
        return Ok(user);
    }
}
}