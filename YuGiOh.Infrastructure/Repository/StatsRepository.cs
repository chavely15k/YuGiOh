using Microsoft.EntityFrameworkCore;
using YuGiOh.ApplicationCore.Repository;
using YuGiOh.Domain.Interfaces;
using YuGiOh.Domain.Models;

namespace YuGiOh.Infrastructure.Repository
{
    public class StatsRepository : IStatsRepository
    {
        protected readonly YuGiOhDbContext _dbContext;

        public StatsRepository(YuGiOhDbContext dbContext)
        {
            this._dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        // Método para obtener la frecuencia del arquetipo campeón en un intervalo de tiempo
        public async Task<IEnumerable<(Archetype Archetype, int Frequency)>> GetChampionArchetypeFrequency(IRangeTime rangeTime)
        {
            var champions = await GetAllChampionsInTimeRange(rangeTime);

            return champions
                .SelectMany(champion => _dbContext.Decks
                    .Where(deck => deck.PlayerId == champion.Id)
                    .Include(deck => deck.Archetype))
                .GroupBy(deck => deck.Archetype)
                .OrderByDescending(group => group.Count())
                .Select(group => (group.Key, group.Count()));
        }
        // Método para obtener todos los campeones en un intervalo de tiempo
        public async Task<IEnumerable<User>> GetAllChampionsInTimeRange(IRangeTime rangeTime)
        {
            var tournamentsId = await _dbContext.Tournaments
                .Where(tournament => tournament.StartDate >= rangeTime._startTime && tournament.StartDate <= rangeTime._endTime)
                .Select(tournament => tournament.Id)
                .ToListAsync();

            var champions = new List<User>();

            foreach (var tournamentId in tournamentsId)
            {
                var champion = await GetTournamentChampion(tournamentId);
                if (champion != null)
                {
                    champions.Add(champion);
                }
            }
            return champions;
        }
        // Método para obtener la ubicación con más campeones en un intervalo de tiempo
        public async Task<string> GetLocationWithMostChampions(IRangeTime rangeTime)
        {
            var champions = await GetAllChampionsInTimeRange(rangeTime);
            var locationWithMostChampions = champions
                .GroupBy(champion => new { champion.Province, champion.Township })
                .Select(group => new
                {
                    Location = $"{group.Key.Province}, {group.Key.Township}",
                    Count = group.Count()
                })
                .OrderByDescending(group => group.Count)
                .FirstOrDefault();

            return locationWithMostChampions?.Location ?? "No champions found";
        }
        // Método para obtener los arquetipos más populares entre los jugadores
        public async Task<IEnumerable<Archetype>> GetMostPopularArchetypes(int n)
        {
            return await _dbContext.Archetypes
                .OrderByDescending(archetype =>
                    _dbContext.Users.Count(user =>
                        _dbContext.Decks.Any(deck => deck.ArchetypeId == archetype.Id && deck.PlayerId == user.Id)))
                .Take(n)
                .ToListAsync();
        }
        // Método para obtener la provincia/municipio donde es más popular un arquetipo dado
        public async Task<string> GetMostPopularLocationForArchetype(int ArchetypeId)
        {
            return await _dbContext.Users
                .Where(user => _dbContext.Decks.Any(deck => deck.ArchetypeId == ArchetypeId && deck.PlayerId == user.Id))
                .GroupBy(user => user.Province)
                .OrderByDescending(group => group.Count())
                .Select(group => group.Key)
                .FirstOrDefaultAsync() ?? "No se encontró ninguna provincia";

        }
        // Método para obtener el arquetipo más utilizado en un torneo específico
        public async Task<Archetype?> GetMostUsedArchetypeInTournament(int tournamentId)
        {
            return await _dbContext.Matches
                .Where(match => match.TournamentId == tournamentId)
                .SelectMany(match => _dbContext.Decks
                    .Where(deck => deck.PlayerId == match.PlayerOneId || deck.PlayerId == match.PlayerTwoId)
                    .Include(deck => deck.Archetype)
                    .Select(deck => deck.Archetype))
                .GroupBy(archetype => archetype)
                .OrderByDescending(group => group.Count())
                .Select(group => group.Key)
                .FirstOrDefaultAsync();
        }
        // Método para obtener los arquetipos más utilizados en una ronda específica de un torneo
        public async Task<IEnumerable<Archetype>> GetMostUsedArchetypesInRound(int TournamentId, int Round)
        {
            return await _dbContext.Matches
                .Where(match => match.TournamentId == TournamentId && match.Round == Round)
                .SelectMany(match => new[] { match.PlayerOneId, match.PlayerTwoId })
                .SelectMany(playerId => _dbContext.Decks
                    .Where(deck => deck.PlayerId == playerId))
                    .Include(deck => deck.Archetype)
                .GroupBy(deck => deck.Archetype)
                .OrderByDescending(group => group.Count())
                .Select(group => group.Key)
                .ToListAsync();
        }
        // Método para obtener los jugadores con más decks en su poder (ordenados de mayor a menor)
        public async Task<IEnumerable<User>> GetPlayersWithMostDecks(int n)
        {
            return await _dbContext.Users
                .OrderByDescending(user => _dbContext.Decks
                    .Count(deck => deck.PlayerId == user.Id))
                .Take(n)
                .ToListAsync();
        }
        // Método para obtener el jugador con más victorias en un intervalo de tiempo
        public async Task<IEnumerable<User>> GetPlayersWithMostVictories(int n, IRangeTime rangeTime)
        {
            var baseQuery = await _dbContext.Matches
                .Where(match => match.Date >= rangeTime._startTime && match.Date <= rangeTime._endTime)
                .Include(match => match.PlayerOne)
                .Include(match => match.PlayerTwo)
                .ToListAsync();

            return
                baseQuery.Where(match => match.PlayerOneResult > match.PlayerTwoResult)
                .Select(match => match.PlayerOne)
                .Concat(baseQuery
                    .Where(match => match.PlayerTwoResult > match.PlayerOneResult)
                    .Select(match => match.PlayerTwo))
                .GroupBy(player => player.Id)
                .OrderByDescending(group => group.Count())
                .Take(n)
                .Select(group => group.First());
        }
        // Método para obtener los arquetipos más utilizados por al menos un jugador en los torneos
        public async Task<IEnumerable<Archetype>> GetTopArchetypesUsedByAtLeastOnePlay(int n)
        {
            return await _dbContext.Requests
                .Include(request => request.Tournament)
                .Include(request => request.Deck)
                .Where(request => request.Tournament.StartDate < DateTime.Now)
                .Select(request => request.Deck)
                .GroupBy(deck => deck.Archetype)
                .OrderByDescending(group => group.Count())
                .Select(group => group.Key)
                .Take(n)
                .ToListAsync();
        }
        // Método para obtener al campeón de un torneo específico
        public async Task<User?> GetTournamentChampion(int idTournament)
        {
            var semiAndFinalGroup = await _dbContext.Matches
                .Include(match => match.PlayerOne)
                .Include(match => match.PlayerTwo)
                .Where(match => match.TournamentId == idTournament)
                .GroupBy(match => match.Round)
                .OrderByDescending(group => group.Key)
                .Take(2)
                .Select(group => new
                    {
                        Match = group.First(),  // Obtener el primer Match del grupo
                        MatchCount = group.Count()   // Obtener la cantidad de Match en el grupo
                    })
                .ToListAsync();


            // Ahora semiAndFinalGroup contiene solo los objetos Match


            var semifinal = semiAndFinalGroup.LastOrDefault();
            var final = semiAndFinalGroup.FirstOrDefault();

            if (semifinal != null && final != null)
            {
                var numberOfMatchesInSemifinal = semifinal.MatchCount;

                if (numberOfMatchesInSemifinal == 2)
                {
                    var champion = final.Match.PlayerOneResult > final.Match.PlayerTwoResult ?
                        final.Match.PlayerOne : final.Match.PlayerTwo;

                    return champion;
                }
            }
            return null;
        }
    }
}
