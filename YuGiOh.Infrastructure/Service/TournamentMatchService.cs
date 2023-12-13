using System.Runtime.CompilerServices;
using System.Globalization;
using System.Data.Common;
using System.Numerics;
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
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using iText.Signatures;
using Microsoft.EntityFrameworkCore;

namespace YuGiOh.Infrastructure.Service {
    //TODO: probar todas las funciones de este servicio
    public class TournamentMatchService : AbstractDataServices, ITournamentMatchService {
        public TournamentMatchService(IEntityRepository dataRepository, IMapper mapper) 
            : base(dataRepository, mapper)
        {
        }


        public async Task<IList<MatchResultDto>> InitPhase(PhaseDto phaseDto) {
            IList<Match> matches; IList<MatchResultDto> result = new List<MatchResultDto>();
            var data = (await _dataRepository.FindAsync<Match>(m => m.TournamentId == phaseDto.TournamentId)).ToList();
            
            int x;
            if (data.Count() == 0) x = 0;
            else if (data.Where(m => m.Round > 0).Count() == 0) x = 1;
            else {
                data.ToList().Sort((x, y) => y.Round - x.Round);
                x = data[data.Count()-1].Round+1;
            }
            phaseDto.Round = x;
            if (x == 0) matches = await GenerateClassificationMatches(phaseDto);
            else if (x == 1) matches = await GenerateFirstRound(phaseDto);
            else matches = await GenerateRoundMatches(phaseDto);
            foreach (var match in matches) {
                var temp = _mapper.Map<MatchResultDto>(match);
                temp.PlayerOneNick = (await _dataRepository.GetByIdAsync<User>(temp.PlayerOneId)).Nick;
                temp.PlayerTwoNick = (await _dataRepository.GetByIdAsync<User>(temp.PlayerTwoId)).Nick;
                result.Add(temp);
            }
            return result;
        }

        public async Task CreateRound(IList<MatchDto> matchDtos) {
            foreach (var match in matchDtos) {
                await _dataRepository.CreateAsync<Match>(_mapper.Map<Match>(match));
            }
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
            if (matches.Count()*Math.Pow(2, phaseDto.Round-2) != phaseDto.Base) return new List<Match>();
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
        protected async Task<IList<Match>> GenerateFirstRound(PhaseDto phaseDto) {
            var matches = await _dataRepository.FindAsync<Match>(m => 
                m.TournamentId == phaseDto.TournamentId);

            var playersWithMoreVictories = (await _dataRepository.GetAllAsync<User>())
                .Select(p => new
                {
                    Player = p,
                    Victories = matches
                        .Where(m => (m.PlayerOneId == p.Id && m.PlayerOneResult == 2)
                                            || (m.PlayerTwoId == p.Id && m.PlayerTwoResult == 2))
                        .Sum(m => 2)
                })
                .OrderByDescending(p => p.Victories)
                .Take(phaseDto.Base)
                .Select(p => p.Player)
                .ToList();
            List<Match> result = new List<Match>();

            for (int i = 0; i < playersWithMoreVictories.Count()/2; i++) {
                result.Add(new Match() {
                    PlayerOneId = playersWithMoreVictories[i].Id,
                    PlayerTwoId = playersWithMoreVictories[playersWithMoreVictories.Count()-i-1].Id,
                    TournamentId = phaseDto.TournamentId,
                    Round = 1,
                    Group = i
                });
            }

            return result;
        }

        public async Task<bool> TournamentTest(int tournament)
        {
            var AllPlayers = await _dataRepository.Include<User>(p => p.Decks).Where(p => p.Decks.Count() > 0).ToListAsync();
            Tournament? tourney = await _dataRepository.GetByIdAsync<Tournament>(tournament);
            foreach(var player in AllPlayers) 
            {
                if(tourney == null) return false;
                var temp = await _dataRepository.CreateAsync<Request>(new Request
                {
                    PlayerId = player.Id,
                    Player = player,
                    DeckId = player.Decks.First().Id,
                    Deck = player.Decks.First(),
                    TournamentId = tourney.Id,
                    Tournament = tourney,
                    Status = RequestStatus.Approved,
                    Date = DateTime.Now.ToUniversalTime(),
                }); 
                if(temp == null) return false;
            }

            var matchesGP = await InitPhase(new PhaseDto{
                TournamentId = tournament,
            });
            Random rdm = new Random();
            (int left, int right)[] results = {(1,2), (2,1), (2,0), (0,2)};
            int i = 0;
            foreach(var match in matchesGP)
            {
                var result = results[rdm.Next(4)];
                var temp = await createMatch(new MatchDto{ 
                    Date = tourney.StartDate.AddMinutes(i++).ToUniversalTime(), 
                    Group = match.Group,
                    Round = match.Round,
                    PlayerOneId = match.PlayerOneId,
                    PlayerOneResult = result.left,
                    PlayerTwoId = match.PlayerTwoId,
                    PlayerTwoResult = result.right,
                    TournamentId = tournament,
                    });
                if(!temp) return false;
            }
            var matchesSF = await InitPhase(new PhaseDto{ Base = 4, Round = 1, TournamentId = tournament});
            foreach(var match in matchesSF)
            {
                var result = results[rdm.Next(4)];
                var temp = await createMatch(new MatchDto{ 
                    Date = tourney.StartDate.AddMinutes(i++).ToUniversalTime(), 
                    Group = match.Group,
                    Round = match.Round,
                    PlayerOneId = match.PlayerOneId,
                    PlayerOneResult = result.left,
                    PlayerTwoId = match.PlayerTwoId,
                    PlayerTwoResult = result.right,
                    TournamentId = tournament,
                    });
                if(!temp) return false;
            }
            var matchesF = await InitPhase(new PhaseDto{ Round = 2, TournamentId = tournament, Base = 2});
            foreach(var match in matchesF)
            {
                var result = results[rdm.Next(4)];
                var temp = await createMatch(new MatchDto{ 
                    Date = tourney.StartDate.AddMinutes(i++).ToUniversalTime(), 
                    Group = match.Group,
                    Round = match.Round,
                    PlayerOneId = match.PlayerOneId,
                    PlayerOneResult = result.left,
                    PlayerTwoId = match.PlayerTwoId,
                    PlayerTwoResult = result.right,
                    TournamentId = tournament,
                    });
                if(!temp) return false;
            }
            return true;
        }
        private async Task<bool> createMatch(MatchDto newMatch)
        {
            var matches = await _dataRepository.FindAsync<Match>(d => (d.PlayerOneId == newMatch.PlayerOneId && d.Date == newMatch.Date)||
                                                                        (d.PlayerTwoId == newMatch.PlayerTwoId && d.Date == newMatch.Date));
            if(matches.Count() > 0) return false;
            var match = await _dataRepository.CreateAsync<Match>(_mapper.Map<Match>(newMatch));
            return true;
        }
    }
}