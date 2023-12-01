using YuGiOh.Domain.Models;
using YuGiOh.ApplicationServices.Service;
using YuGiOh.ApplicationCore.Repository;

namespace YuGiOh.Infrastructure.Service {
    public class MatchService : AbstractDataServices, IMatchService {
        public DeckService(IEntityRepository dataRepository, IMapper mapper) : base(dataRepository, mapper)
        {
        }

        public async Task<bool> UpdateMatch(MatchDto newMatch) {
            Match match = _mapper.Map<Deck>(newMatch);
            var result = await _dataRepository.UpdateAsync<Match>(match);
            return result != null;
        }

        public async Task<IEnumerable<MatchDto>> GetMatchesByPhase(MatchByPhaseDto matchByPhaseDto) {
            var matches = _dataRepository.FindAsync(m => (m.Round == matchByPhaseDto.Round && m.TournamentId == matchByPhaseDto.TournamentId));
            return _mapper.Map<IEnumerable<MatchDto>>(matches);
        }
        
        public async Task<IEnumerable<MatchDto>> GetMatchesByTournament(int id) {
            var matches = _dataRepository.FindAsync(m => (m.TournamentId == id));
            return _mapper.Map<IEnumerable<MatchDto>>(matches);
        }
    }
}