using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using YuGiOh.ApplicationCore.Repository;
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
        public async Task<int> GetChampionArchetypeFrequency(IRangeTime rangeTime)
        {
            throw new NotImplementedException();
            //TODO:NotImplemented
        }

        // Método para obtener la ubicación con más campeones en un intervalo de tiempo
        public async Task<string> GetLocationWithMostChampions(IRangeTime rangeTime)
        {
            throw new NotImplementedException();
            //TODO:NotImplemented
        }

        // Método para obtener los arquetipos más populares entre los jugadores
        public async Task<IEnumerable<Archetype>> GetMostPopularArchetypes(int n)
        {
            var popularArchetypes = await _dbContext.Archetypes
                .OrderByDescending(archetype =>
                    _dbContext.Users.Count(user =>
                        _dbContext.Decks.Any(deck => deck.Archetype.Id == archetype.Id && deck.Player.Id == user.Id)))
                .Take(n)
                .ToListAsync();

            return popularArchetypes;
        }
        // Método para obtener la provincia/municipio donde es más popular un arquetipo dado
        public async Task<string> GetMostPopularLocationForArchetype(int ArchetypeId)
        {
            var mostPopularProvince = await _dbContext.Users
                .Where(user => _dbContext.Decks.Any(deck => deck.Archetype.Id == ArchetypeId && deck.Player.Id == user.Id))
                .GroupBy(user => user.Province)
                .OrderByDescending(group => group.Count())
                .Select(group => group.Key)
                .FirstOrDefaultAsync() ?? "No se encontró ninguna provincia";
            return mostPopularProvince;
        }
        // Método para obtener el arquetipo más utilizado en un torneo específico
        public async Task<string> GetMostUsedArchetypeInTournament(int idTournament)
        {
            var mostUsedArchetype = await _dbContext.Matches
                .Where(match => match.TournamentId == idTournament)
                .SelectMany(match => _dbContext.Decks
                    .Where(deck => deck.Player.Id == match.PlayerOne.Id || deck.Player.Id == match.PlayerTwo.Id)
                    .Select(deck => deck.Archetype))
                .GroupBy(archetype => archetype)
                .OrderByDescending(group => group.Count())
                .Select(group => group.Key.Name)
                .FirstOrDefaultAsync();

            return mostUsedArchetype;
        }
        // Método para obtener los arquetipos más utilizados en una ronda específica de un torneo
        public async Task<IEnumerable<Archetype>> GetMostUsedArchetypesInRound(int TournamentId, int Round)
        {
            var mostUsedArchetypes = await _dbContext.Matches
                .Where(match => match.TournamentId == TournamentId && match.Round == Round)
                .SelectMany(match => new[] { match.PlayerOne, match.PlayerTwo })
                .SelectMany(player => _dbContext.Decks
                    .Where(deck => deck.Player.Id == player.Id))
                .GroupBy(deck => deck.Archetype)
                .OrderByDescending(group => group.Count())
                .Select(group => group.Key)
                .ToListAsync();

            return mostUsedArchetypes;
        }
        // Método para obtener los jugadores con más decks en su poder (ordenados de mayor a menor)
        public async Task<IEnumerable<User>> GetPlayersWithMostDecks(int n)
        {
            return await _dbContext.Users
                .OrderByDescending(user => _dbContext.Decks
                    .Count(deck => deck.Player.Id == user.Id))
                .Take(n)
                .ToListAsync();
        }
        // Método para obtener el jugador con más victorias en un intervalo de tiempo
        public async Task<IEnumerable<User>> GetPlayersWithMostVictories(int n, IRangeTime rangeTime)
        {
            var baseQuery = _dbContext.Matches
                .Where(match => rangeTime.IsWithinRange(match.Date));

            return await baseQuery
                .Where(match => match.PlayerOneResult > match.PlayerTwoResult)
                .Select(match => match.PlayerOne)
                .Concat(baseQuery
                    .Where(match => match.PlayerTwoResult > match.PlayerOneResult)
                    .Select(match => match.PlayerTwo))
                .GroupBy(player => player.Id)
                .OrderByDescending(group => group.Count())
                .Take(n)
                .Select(group => group.First())
                .ToListAsync();
        }
        // Método para obtener los arquetipos más utilizados por al menos un jugador en los torneos
        public async Task<IEnumerable<Archetype>> GetTopArchetypesUsedByAtLeastOnePlay(int n)
        {
            return await _dbContext.Requests
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
            //TODO: Falta Filtrar por Round
            return await _dbContext.Matches
                .Where(match => match.TournamentId == idTournament)
                .SelectMany(match => new[]{
                    new { Player = match.PlayerOne, Result = match.PlayerOneResult },
                    new { Player = match.PlayerTwo, Result = match.PlayerTwoResult }})
                .OrderByDescending(tuple => tuple.Result)
                .Select(tuple => tuple.Player)
                .FirstOrDefaultAsync();

        }
    }
}
