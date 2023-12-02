using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using YuGiOh.ApplicationCore.DTO;
using YuGiOh.ApplicationServices.Service;
using YuGiOh.Domain.Models;

namespace YuGiOh.API.Controllers
{
    [Route("[controller]")]
    public class ArchetypeController : Controller
    {
        private readonly IArchetypeService _archetype;

        public ArchetypeController(IArchetypeService archetype)
        {
            _archetype = archetype;
        }

        [HttpGet]
        [Route("get")]
        public async Task<ActionResult<IEnumerable<ArchetypeDto>>> GetArchetypes()
        {
            var archetypes =  await _archetype.GetAllAsync();
            return Ok(archetypes);
        }
    }
}