using System.Net;
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
        [Route("available/{id}")]
        public async Task<ActionResult<IEnumerable<TournamentDto>>> AvailableTournaments(int id)
        {
            var available = await _TournamentService.AvailableTournamentsAsync(id);
            return Ok(available);
        }

        [HttpGet]
        [Route("All")]
        public async Task<ActionResult<IEnumerable<TournamentDto>>> GetAllTournaments()
        {
            var tournaments = await _TournamentService.GetAllTournaments();
            return Ok(tournaments);
        }
        
        [HttpGet]
        [Route("userId/{AdminId}")]
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
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _TournamentService.DeleteTournament(id);
            return Ok(result);
        }
        [HttpPut]
        [Route("update")]
        public async Task<ActionResult> Update(TournamentDto tournament)
        {
            var result = await _TournamentService.UpdateTournament(tournament);
            return Ok(result);
        }
        [HttpGet]
        [Route("signed/{id}")]
        public async Task<ActionResult<IEnumerable<TournamentDto>>> GetSignedUpTournament(int id)
        {
            var tournaments = await _TournamentService.SignedUpTournaments(id);
            return Ok(tournaments);
        }
    }
}