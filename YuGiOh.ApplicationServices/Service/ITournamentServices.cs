using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YuGiOh.ApplicationCore.DTO;

namespace YuGiOh.ApplicationServices.Service
{
    public interface ITournamentServices
    {
        public Task<TournamentDto> CreateTournament(TournamentDto create);
        public  Task<IEnumerable<TournamentDto>> GetAllTournaments();
        public  Task<IEnumerable<TournamentDto>> GetAllTournamentsByAdmin(int AdminId);
    }
}