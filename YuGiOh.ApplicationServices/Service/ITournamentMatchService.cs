using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YuGiOh.ApplicationCore.DTO;
using YuGiOh.Domain.Models;

namespace YuGiOh.ApplicationServices.Service
{
    public interface ITournamentMatchService
    {
        public Task<IList<MatchResultDto>> InitPhase(PhaseDto phaseDto);

        public Task CreateRound(IList<MatchDto> matchDtos);
        
    }
}
