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
using YuGiOh.Domain.Enums;

namespace YuGiOh.Infrastructure.Service {
    //TODO: probar todas las funciones de este servicio
    public class TournamentMatchService : AbstractDataServices, ITournamentMatchService {
        public TournamentMatchService(IEntityRepository dataRepository, IMapper mapper) 
            : base(dataRepository, mapper)
        {
        }


        public async Task<IList<MatchDto>> InitPhase(PhaseDto phaseDto) {
            IList<Match> matches; IList<MatchDto> result = new List<MatchDto>();
            if (phaseDto.Round == 0) matches = await GenerateClassificationMatches(phaseDto);
            else matches = await GenerateRoundMatches(phaseDto);
            foreach (var match in matches) {
                result.Add(_mapper.Map<MatchDto>(match));
                await _dataRepository.CreateAsync<Match>(match);
            }
            return result;
        }

        protected async Task<IList<Match>> GenerateClassificationMatches(PhaseDto phaseDto) {
            var players = (await _dataRepository.FindAsync<Request>(r => (r.TournamentId == phaseDto.TournamentId && r.Status == RequestStatus.Approved))).Select(r => r.PlayerId).ToList();
            List<Match> matches = new List<Match>();

            for (int i = 0; i < players.Count() - 1; i++) {
                for (int j = i + 1; j < players.Count(); j++) {
                    matches.Add( new Match() {
                        PlayerOneId = players[i],
                        PlayerTwoId = players[j],
                        TournamentId = phaseDto.TournamentId,
                        Round = 0,
                        Group = 0
                    });
                }
            }
            return matches;
        }
        protected async Task<IList<Match>> GenerateRoundMatches(PhaseDto phaseDto) {
            var matches = (await _dataRepository.FindAsync<Match>(m => m.TournamentId == phaseDto.TournamentId && m.Round == phaseDto.Round - 1)).ToList();
            matches.Sort((x, y) => x.Group - y.Group);
            int g = matches[matches.Count()-1].Group + 1;
            var winners = matches.Select(m => (m.PlayerOneResult > m.PlayerTwoResult ? m.PlayerOneId : m.PlayerTwoId)).ToList();
            List<Match> result = new List<Match>();
            for (int i = 0; i < winners.Count(); i += 2) {
                result.Add(new Match() {
                    PlayerOneId = winners[i],
                    PlayerTwoId = winners[i+1],
                    TournamentId = phaseDto.TournamentId,
                    Round = phaseDto.Round,
                    Group = g++
                });
            }
            return result;
        }
    }
}