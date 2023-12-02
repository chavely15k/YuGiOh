using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using YuGiOh.ApplicationCore.Repository;
using YuGiOh.ApplicationServices.Service;
using YuGiOh.Domain.Models;

namespace YuGiOh.Infrastructure.Service
{
    public class RequestService : AbstractDataServices, IRequestService
    {
        public RequestService(IEntityRepository dataRepository, IMapper mapper) : base(dataRepository, mapper)
        {
        }

        public async Task<RequestDto> CreateRequest(RequestDto request)
        {
            var _request = _mapper.Map<Request>(request);
            await _dataRepository.CreateAsync<Request>(_request);
            return _mapper.Map<RequestDto>(_request);

        }

        public async Task<bool> DeleteRequest(int PlayerId, int TournametId)
        {
            var result = await _dataRepository.DeleteAsync<Request>(
                new { PlayerId, TournametId });
            return result != null;
        }

        public async Task<IEnumerable<RequestDto>> GetAllRequestByAdmin(int id)
        {
            DateTime now = DateTime.Now;
            var tournaments = await _dataRepository.FindAsync<Tournament>(d => d.User.Id == id && d.StartDate.ToUniversalTime() > now.ToUniversalTime() );
            List<Request> requests = new();
            foreach(var tournamet in tournaments)
            {
                var req = await _dataRepository.FindAsync<Request>(d => d.TournamentId == tournamet.Id);
                requests = requests.Concat(req).ToList();
            }
            return _mapper.Map<IEnumerable<RequestDto>>(requests.OrderByDescending(d => d.Date).ToList());
        }

        public async Task<IEnumerable<RequestDto>> GetAllRequestByPlayer(int id)
        {
            var allRequest = await _dataRepository.FindAsync<Request>(d => d.PlayerId == id);
            LinkedList<RequestDto> result = new();
            foreach(var request in allRequest)
            {
                var tournament = await _dataRepository.GetByIdAsync<Tournament>(request.TournamentId);
                if(tournament != null && DateTime.Now.ToUniversalTime() < tournament.StartDate.ToUniversalTime())
                {
                    result.AddLast(_mapper.Map<RequestDto>(request));
                }
            }
            return result.OrderByDescending(x => x.Date).ToList();
        }

        public async Task<bool> UpdateRequest(RequestDto request)
        {
            var _request = _mapper.Map<Request>(request);
            //Todo: hay que hacer un checkeo que me valide si existe el usuario
            //var newRequest = await _dataRepository.GetByIdAsync<Request>(_request.GetById());
            //Todo: hay que hacer un checkeo de que el status que se manda se uno valido            
            var result = await _dataRepository.UpdateAsync<Request>(_request);
            return result != null;
        }
    } 
}
