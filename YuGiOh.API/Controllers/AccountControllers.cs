using Microsoft.AspNetCore.Mvc;
using YuGiOh.Domain.Models;
using YuGiOh.ApplicationCore.DTO;
using YuGiOh.ApplicationServices.Service;

namespace YuGiOh.API.Controllers {
    
[ApiController]
[Route("account")]
public class AccountController : ControllerBase
{
    public readonly IUserService userService;
    public AccountController(IUserService userService) {
        this.userService = userService;
    }
    // [HttpGet]
    // [Route("login")]
    // public async Task<ActionResult> Get(LoginRequest loginRequest)
    // {
    //     User? user = await userService.Get(loginRequest);
    //     return Ok(user);
    // }
    [HttpPost ("register")]
    public async Task<ActionResult> Create(RegisterUserDto registerUser)
    {
        User? user = await userService.RegisterUserAsync(registerUser);
        return Ok(user);
    }
}
}