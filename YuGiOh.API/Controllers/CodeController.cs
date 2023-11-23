using YuGiOh.Domain.Models;
using YuGiOh.ApplicationServices.Service;
using Microsoft.AspNetCore.Mvc;

namespace YuGiOh.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CodeController : ControllerBase
{
    public readonly ICodeService codeService;

    public CodeController(ICodeService codeService) {
        this.codeService = codeService;
    }

    [HttpGet]
    public async Task<string> Get()
    {
        return await codeService.GetAsync();
    }
}
