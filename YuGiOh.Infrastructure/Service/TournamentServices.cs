using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata;
using Npgsql.Replication;
using YuGiOh.ApplicationCore.DTO;
using YuGiOh.ApplicationCore.Repository;
using YuGiOh.ApplicationServices.Service;
using YuGiOh.Domain.Enums;
using YuGiOh.ApplicationServices.Service.AbstractClass;
using YuGiOh.Domain.Models;


namespace YuGiOh.Infrastructure.Service
{
    public class TournamentServices : AbstractDataServices, ITournamentServices
    {
        public TournamentServices(IEntityRepository dataRepository, IMapper mapper) : base(dataRepository, mapper)
        {
        }

        public async Task<TournamentDto> CreateTournament(TournamentDto create)
        {
            var _Tournament = _mapper.Map<Tournament>(create);
            var _user = await _dataRepository.FindAsync<User>(d => d.Id == create.AdminId);
            if (_user.Count() != 0)
            {
                _Tournament.User = _user.First();
                await _dataRepository.CreateAsync<Tournament>(_Tournament);
            }
            return _mapper.Map<TournamentDto>(_Tournament);

        }

        public async Task<bool> DeleteTournament(int Id)
        {
            var result = await _dataRepository.DeleteAsync<Tournament>(Id);
            if(result != null) return true;
            else return false;
        }

        public async Task<IEnumerable<TournamentDto>> GetAllTournaments()
        {
            var _Tournaments = await _dataRepository.GetAllAsync<Tournament>();
            return _mapper.Map<IEnumerable<TournamentDto>>(_Tournaments);
        }

        public async Task<IEnumerable<TournamentDto>> AvailableTournamentsAsync(int id)
        {
            var _tournaments = await _dataRepository.FindAsync<Tournament>(d => d.Id == id && d.StartDate.ToUniversalTime() > DateTime.Now.ToUniversalTime());
            var _request = await _dataRepository.FindAsync<Request>(d => d.PlayerId == id && d.Status == RequestStatus.Approved);
            LinkedList<TournamentDto> result = new();
            foreach(var tournament in _tournaments)
            {
                if(_request.Select(d => d.TournamentId == tournament.Id).Count() == 0)
                {
                    result.AddLast(_mapper.Map<TournamentDto>(tournament));
                }
            }
            return result;
        }

        public async Task<IEnumerable<TournamentDto>> GetAllTournamentsByAdmin(int AdminId)
        {
            var _Tournaments = await _dataRepository.FindAsync<Tournament>(d => d.User.Id == AdminId);
            return _mapper.Map<IEnumerable<TournamentDto>>(_Tournaments);
        }
        public async Task<bool> UpdateTournament(TournamentDto tournament)
        {
            var newTournament = _mapper.Map<Tournament>(tournament);
            var result = await _dataRepository.UpdateAsync<Tournament>(newTournament);
            return result != null;
        }

    }
}