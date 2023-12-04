using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using YuGiOh.ApplicationCore.DTO;
using YuGiOh.ApplicationServices.Service;

namespace YuGiOh.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MatchController : ControllerBase
    {
        private readonly IMatchService _matchService;
        

        public MatchController(IMatchService matchService)
        {
            _matchService = matchService ?? throw new ArgumentNullException(nameof(matchService));
        }

        [HttpGet("getMatchesByTournament/{tournamentId}")]
        public async Task<ActionResult<IEnumerable<MatchDto>>> GetMatchesByTournamentAsync(int tournamentId)
        {
            var matches = await _matchService.GetMatchesByTournament(tournamentId);
            return Ok(matches);
        }

        [HttpGet]
        [Route("getMatchesByPhase")]
        public async Task<ActionResult<MatchDto>> GetMatchesByPhase(MatchByPhaseDto matchByPhaseDto)
        {
            var matches = await _matchService.GetMatchesByPhase(matchByPhaseDto);
            return Ok(matches);
        }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult>UpdateMatch(MatchDto matchDto)
        {
            var match = await _matchService.UpdateMatch(matchDto);
            return Ok(match);
        }
        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<MatchResultDto>> CreateMatch(MatchDto match)
        {
            var result = _matchService.CreateMatch(match);
            return Ok(result);
        }

    }
}
