using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YuGiOh.ApplicationCore.DTO;

namespace YuGiOh.ApplicationServices.Service
{
    public interface ITournamentServices
    {
        public Task<RegisterDeckDto> CreateTournament(CreateTournamentDto create);
        public  Task<IEnumerable<RegisterDeckDto>> GetAllTournaments();
        public  Task<IEnumerable<RegisterDeckDto>> GetAllTournamentsByAdmin(int AdminId);
    }
}