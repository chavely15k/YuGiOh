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
        public  Task<IEnumerable<ResponseTournamentDto>> GetAllTournaments();
        public  Task<IEnumerable<ResponseTournamentDto>> GetAllTournamentsByAdmin(int AdminId);
        public Task<IEnumerable<ResponseTournamentDto>> AvailableTournamentsAsync(int id);

        public Task<IEnumerable<ResponseTournamentDto>> SignedUpTournaments(int id);
        
        public Task<bool> UpdateTournament(TournamentDto tournament);
        public Task<bool> DeleteTournament(int Id);
    }
}