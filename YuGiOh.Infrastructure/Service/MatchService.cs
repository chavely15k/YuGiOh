using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Query;
using YuGiOh.ApplicationCore.DTO;
using YuGiOh.ApplicationCore.Repository;
using YuGiOh.ApplicationServices.Service;
using YuGiOh.Domain.Models;

namespace YuGiOh.Infrastructure.Service {
    public class MatchService : AbstractDataServices, IMatchService {
        public MatchService(IEntityRepository dataRepository, IMapper mapper) : base(dataRepository, mapper)
        {
        }

        public async Task<bool> UpdateMatch(MatchDto newMatch) {
            Match match = _mapper.Map<Match>(newMatch);
            var result = await _dataRepository.UpdateAsync<Match>(match);
            return result != null;
        }

        public async Task<IEnumerable<MatchDto>> GetMatchesByPhase(MatchByPhaseDto matchByPhaseDto) {
            var matches = await _dataRepository.FindAsync<Match>(m => (m.Round == matchByPhaseDto.Round && m.TournamentId == matchByPhaseDto.TournamentId));
            return _mapper.Map<IEnumerable<MatchDto>>(matches);
        }
        
        public async Task<IEnumerable<MatchDto>> GetMatchesByTournament(int id) {
            var matches = await _dataRepository.FindAsync<Match>(m => (m.TournamentId == id));
            return _mapper.Map<IEnumerable<MatchDto>>(matches);
        }
        public async Task<MatchResultDto> CreateMatch(MatchDto newMatch) 
        {
            var matches = await _dataRepository.FindAsync<Match>(d => (d.PlayerOneId == newMatch.PlayerOneId && d.Date == newMatch.Date)||
                                                                        (d.PlayerTwoId == newMatch.PlayerTwoId && d.Date == newMatch.Date));
            if(matches.Count() > 0) return new MatchResultDto{
                Message = "uno de los jugadores ya tiene otra partida a esa hora",
                Success = false
            };
            var match = await _dataRepository.CreateAsync<Match>(_mapper.Map<Match>(newMatch));
            return new MatchResultDto{
                        Message = "Succesfuly added",
                        Success = true
            };
        }
    }
}