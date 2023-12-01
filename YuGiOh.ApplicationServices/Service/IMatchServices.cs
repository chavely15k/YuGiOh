using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YuGiOh.ApplicationCore.DTO;

namespace YuGiOh.ApplicationServices.Service
{
    public interface IMatchService
    {
        public Task<bool> UpdateMatch(MatchDto newMatch);

        public Task<IEnumerable<MatchDto>> GetMatchesByPhase(MatchByPhaseDto matchByPhaseDto);
        
        public Task<IEnumerable<MatchDto>> GetMatchesByTournament(int id);

    }
}