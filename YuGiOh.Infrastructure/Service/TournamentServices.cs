using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Npgsql.Replication;
using YuGiOh.ApplicationCore.DTO;
using YuGiOh.ApplicationCore.Repository;
using YuGiOh.ApplicationServices.Service;
using YuGiOh.Domain.Models;


namespace YuGiOh.Infrastructure.Service
{
    public class TournamentServices : AbstractDataService, ITournamentServices
    {
        public TournamentServices(IDataRepository dataRepository, IMapper mapper) : base(dataRepository, mapper)
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

        public async Task<IEnumerable<TournamentDto>> GetAllTournaments()
        {
            var _Tournaments = await _dataRepository.GetAllAsync<Tournament>();
            return _mapper.Map<IEnumerable<TournamentDto>>(_Tournaments);
        }

        public async Task<IEnumerable<TournamentDto>> GetAllTournamentsByAdmin(Guid AdminId)
        {
            var _Tournaments = await _dataRepository.FindAsync<Tournament>(d => d.User.Id == AdminId);
            return _mapper.Map<IEnumerable<TournamentDto>>(_Tournaments);
        }



    }
}