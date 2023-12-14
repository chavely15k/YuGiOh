using Microsoft.AspNetCore.Mvc;
using YuGiOh.ApplicationCore.DTO;
using YuGiOh.ApplicationServices.Service;
using YuGiOh.Domain.Interfaces;
using YuGiOh.Infrastructure.Service;

namespace YuGiOh.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatServiceController : ControllerBase
    {
        private readonly IStatServices _statService;
        
        public StatServiceController(IStatServices statService)
        {
            _statService = statService ?? throw new ArgumentNullException(nameof(statService));
        }
        //sirve
        [HttpGet("allChampionsInTimeRange")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllChampionsInTimeRange([FromQuery] DateTime startTime, [FromQuery] DateTime endTime)
        {
            var rangeTime = new RangeTime(startTime, endTime);
            var champions = await _statService.GetAllChampionsInTimeRange(rangeTime);
            return Ok(champions);
        }
        //sirve
        [HttpGet("championArchetypeFrequency")]
        public async Task<ActionResult<IEnumerable<(string ArchetypeName, int Frequency)>>> GetChampionArchetypeFrequency([FromQuery] DateTime startTime, [FromQuery] DateTime endTime)
        {
            var rangeTime = new RangeTime(startTime, endTime);
            var championArchetypes = await _statService.GetChampionArchetypeFrequency(rangeTime);
            return Ok(championArchetypes);
        }
        //sirve
        [HttpGet("playersWithMostDecks")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetPlayersWithMostDecks([FromQuery] int n)
        {
            var playersWithMostDecks = await _statService.GetPlayersWithMostDecks(n);
            return Ok(playersWithMostDecks);
        }
        //sirve
        [HttpGet("locationWithMostChampions")]
        public async Task<ActionResult<string>> GetLocationWithMostChampions([FromQuery] DateTime startTime, [FromQuery] DateTime endTime)
        {
            var rangeTime = new RangeTime(startTime, endTime);
            var location = await _statService.GetLocationWithMostChampions(rangeTime);
            return Ok(location);
        }
        //sirve
        [HttpGet("mostPopularArchetypes")]
        public async Task<ActionResult<IEnumerable<string>>> GetMostPopularArchetypes([FromQuery] int n)
        {
            var archetypes = await _statService.GetMostPopularArchetypes(n);
            return Ok(archetypes);
        }
        //sirve
        [HttpGet("mostPopularLocationForArchetype")]
        public async Task<ActionResult<string>> GetMostPopularLocationForArchetype([FromQuery] int archetypeId)
        {
            var location = await _statService.GetMostPopularLocationForArchetype(archetypeId);
            return Ok(location);
        }
        //sirve
        [HttpGet("mostUsedArchetypeInTournament")]
        public async Task<ActionResult<string>> GetMostUsedArchetypeInTournament([FromQuery] int tournamentId)
        {
            var archetype = await _statService.GetMostUsedArchetypeInTournament(tournamentId);
            return Ok(archetype);
        }
        //TODO: error- System.InvalidOperationException: The LINQ expression 'match => new int[]
        [HttpGet("mostUsedArchetypesInRound")]
        public async Task<ActionResult<IEnumerable<string>>> GetMostUsedArchetypesInRound([FromQuery] int tournamentId, [FromQuery] int round)
        {
            var archetypes = await _statService.GetMostUsedArchetypesInRound(tournamentId, round);
            return Ok(archetypes);
        }
        //sirve
        [HttpGet("playersWithMostVictories")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetPlayersWithMostVictories([FromQuery] int n, [FromQuery] DateTime startTime, [FromQuery] DateTime endTime)
        {
            var rangeTime = new RangeTime(startTime, endTime);
            var playersWithMostVictories = await _statService.GetPlayersWithMostVictories(n, rangeTime);
            return Ok(playersWithMostVictories);
        }
        //TODO: error -System.NotSupportedException: Cannot apply binary operation on types 'timestamp with time zone' and 'timestamp without time zone', convert one of the operands first.
        [HttpGet("topArchetypesUsedByAtLeastOnePlay")]
        public async Task<ActionResult<IEnumerable<string>>> GetTopArchetypesUsedByAtLeastOnePlay([FromQuery] int n)
        {
            var archetypes = await _statService.GetTopArchetypesUsedByAtLeastOnePlay(n);
            return Ok(archetypes);
        }
        //sirve
        [HttpGet("tournamentChampion")]
        public async Task<ActionResult<UserDto>> GetTournamentChampion([FromQuery] int idTournament)
        {
            var champion = await _statService.GetTournamentChampion(idTournament);
            return Ok(champion);
        }
    }
}
