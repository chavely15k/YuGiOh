using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using YuGiOh.ApplicationCore.DTO;
using YuGiOh.ApplicationServices.Service;

namespace YuGiOh.API.Controllers
{
    [ApiController]
    [Route("Tournament")]
    public class TournamentControler: ControllerBase
    {
        private readonly ITournamentServices _TournamentService;

        public TournamentControler(ITournamentServices services)
        {
            _TournamentService = services;
        }

        [HttpGet]
        [Route("All")]
        public async Task<ActionResult<IEnumerable<TournamentDto>>> GetAllTournaments()
        {
            var tournaments = await _TournamentService.GetAllTournaments();
            return Ok(tournaments);
        }
        
        [HttpGet]
        [Route("userId/{userId}")]
        public async Task<ActionResult<IEnumerable<TournamentDto>>> GetAllToutnamentsById(int AdminId)
        {
            var tournaments = await _TournamentService.GetAllTournamentsByAdmin(AdminId);
            return Ok(tournaments);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<TournamentDto>> CreateTournament(TournamentDto newTournament)
        {
            var tournament = await _TournamentService.CreateTournament(newTournament);
            return Ok(tournament);
        }

    }
}