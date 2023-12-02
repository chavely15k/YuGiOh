using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YuGiOh.Domain.Models;

namespace YuGiOh.ApplicationCore.Repository
{
    public interface IStatsRepository
    {

        public Task<IEnumerable<User>> GetPlayersWithMostDecks(int n);
        public Task<IEnumerable<User>> GetMostPopularArchetypes();

        public Task<string> GetMostPopularLocationForArchetype(int id);

        public Task<User> GetTournamentChampion(int id);

        public Task<User> GetPlayersWithMostVictories(DateTime init, DateTime end);

        public Task<string> GetMostUsedArchetypeInTournament(int id);

        public Task<int> GetChampionArchetypeFrequency(DateTime init, DateTime end);

        public Task<string> GetLocationWithMostChampions(DateTime init, DateTime end);

        public Task<IEnumerable<Archetype>> GetMostUsedArchetypesInRound(int TournamentId, int Round);
        public Task<IEnumerable<Archetype>> MostUsedArchetypeInTournament();

    }
}