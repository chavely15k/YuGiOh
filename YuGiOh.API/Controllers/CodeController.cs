using System.Collections.Generic;
using System.Net.Mime;
using YuGiOh.Domain.Models;
using YuGiOh.ApplicationServices.Service;
using Microsoft.AspNetCore.Mvc;

namespace YuGiOh.Controllers;

[ApiController]
[Route("api/code")]
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

    [HttpPost]
    public async Task Post(Dictionary<string, string> data) {
        await codeService.SetAsync(data["Text"]);
    }

    [HttpGet]
    [Route("generate")]
    public async Task<string> Generate() {
        return await codeService.GenerateAsync();
    }
}
