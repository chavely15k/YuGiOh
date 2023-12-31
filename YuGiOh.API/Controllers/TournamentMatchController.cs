using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using YuGiOh.ApplicationCore.DTO;
using YuGiOh.ApplicationServices.Service;
using YuGiOh.Domain.Models;

namespace YuGiOh.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TournamentMatchController : ControllerBase
    {
        private readonly ITournamentMatchService _matchService;
        

        public TournamentMatchController(ITournamentMatchService matchService)
        {
            _matchService = matchService ?? throw new ArgumentNullException(nameof(matchService));
        }

        [HttpPost]
        [Route("InitPhase")]
        public async Task<ActionResult<IEnumerable<MatchResultDto>>> InitPhase(PhaseDto phaseDto)
        {
            var matches = await _matchService.InitPhase(phaseDto);
            return Ok(matches);
        }

        [HttpGet]
        [Route("CreateRound")]
        public async Task<ActionResult> CreateRound(IList<MatchDto> matchDtos) {
            await _matchService.CreateRound(matchDtos);
            return Ok();
        }
        [HttpPost]
        [Route("test/{id}")]
        public async Task<ActionResult> Test(int id) 
        {
            var result = await _matchService.TournamentTest(id);
            return Ok(result);
        }

    }
}