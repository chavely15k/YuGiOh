using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using YuGiOh.ApplicationCore.DTO;
using YuGiOh.Domain.Models;

namespace YuGiOh.ApplicationServices.Service
{
    public interface IStatServices
    {
        public Task<IEnumerable<UserDto>> TopDeckOwners(int n);
        public Task<IEnumerable<UserDto>> MostPopularArchetypes();

        public Task<string> ProvinceByArchetype(int id);

        public Task<UserDto> TournamentWinner(int id);

        public Task<UserDto> BestWinerInTime(DateTime init, DateTime end);
        
        public Task<string> MostUsedArchetypeInTournament(int id);

        public Task<int> MostWinnerArchetype(DateTime init, DateTime end);

        public Task<string> MostWinnerProvince(DateTime init, DateTime end);

        public Task<IEnumerable<ArchetypeDTO>> MostUsedArchetypeInRound(int TournamentId, int Round);

    }
}