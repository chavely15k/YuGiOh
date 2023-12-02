using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YuGiOh.Domain.Models;

namespace YuGiOh.ApplicationCore.Repository
{
    public interface IStatsRepository
    {

        public Task<IEnumerable<User>>GetPlayersWithMostDecks(int n);
        public Task<IEnumerable<Archetype>> GetMostPopularArchetypes(int n);

        public Task<string> GetMostPopularLocationForArchetype(int ArchetypeId);

        public Task<User> GetTournamentChampion(int idTournament);

        public Task<User> GetPlayersWithMostVictories(int n,IRangeTime rangeTime);

        public Task<string> GetMostUsedArchetypeInTournament(int idTournament);

        public Task<int> GetChampionArchetypeFrequency(IRangeTime rangeTime);

        public Task<string> GetLocationWithMostChampions(IRangeTime rangeTime);

        public Task<IEnumerable<Archetype>> GetMostUsedArchetypesInRound(int TournamentId, int Round);
        public Task<IEnumerable<Archetype>> GetTopArchetypesUsedByAtLeastOnePlay(int n);

    }
}