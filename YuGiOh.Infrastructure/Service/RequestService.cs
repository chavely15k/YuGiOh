using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using YuGiOh.ApplicationCore.Repository;
using YuGiOh.ApplicationServices.Service;
using YuGiOh.Domain.Models;
using YuGiOh.ApplicationCore.DTO;
using YuGiOh.Domain.Enums;

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
            _request.Date = DateTime.Now.ToUniversalTime();
            await _dataRepository.CreateAsync<Request>(_request);
            return _mapper.Map<RequestDto>(_request);
        }

        public async Task<bool> DeleteRequest(int PlayerId, int TournamentId)
        {
            var result = await _dataRepository.DeleteAsync<Request>(
                new {PlayerId,TournamentId});
            return result != null;
        }

        public async Task<IEnumerable<ResponseRequestDto>> GetAllRequestByAdmin(int id)
        {
            DateTime now = DateTime.Now;
            var tournaments = await _dataRepository.FindAsync<Tournament>(d => d.User.Id == id && d.StartDate.ToUniversalTime() > now.ToUniversalTime() );
            List<Request> requests = new();
            foreach(var tournamet in tournaments)
            {
                var req = await _dataRepository.FindAsync<Request>(d => d.TournamentId == tournamet.Id && d.Status == RequestStatus.Pending);
                requests = requests.Concat(req).ToList();
            }
            var result = _mapper.Map<IEnumerable<ResponseRequestDto>>(requests.OrderByDescending(d => d.Date).ToList());
            foreach(var res in result)
            {
                res.PlayerName = (await _dataRepository.GetByIdAsync<User>(res.PlayerId)).Nick;
                res.TournamentName = (await _dataRepository.GetByIdAsync<Tournament>(res.TournamentId)).Name;
            }
            return result;
        }

        public async Task<IEnumerable<ResponseRequestDto>> GetAllRequestByPlayer(int id)
        {
            var allRequest = await _dataRepository.FindAsync<Request>(d => d.PlayerId == id && d.Status == RequestStatus.Pending);
            LinkedList<ResponseRequestDto> result = new();
            foreach(var request in allRequest)
            {
                var tournament = await _dataRepository.GetByIdAsync<Tournament>(request.TournamentId);
                if(tournament != null && DateTime.Now.ToUniversalTime() < tournament.StartDate.ToUniversalTime())
                {
                    var temp = _mapper.Map<ResponseRequestDto>(request);
                    temp.PlayerName = (await _dataRepository.GetByIdAsync<User>(temp.PlayerId)).Nick;
                    temp.TournamentName = (await _dataRepository.GetByIdAsync<Tournament>(temp.TournamentId)).Name;
                    result.AddLast(temp);
                }
            }
            return result.OrderByDescending(x => x.Date).ToList();
        }

        public async Task<bool> UpdateRequest(RequestDto request)
        {
            var _request = _mapper.Map<Request>(request);
            switch(request.Status)
            {
                case "Approved": _request.Status = RequestStatus.Approved; 
                break;
                case "Rejected": _request.Status = RequestStatus.Rejected;
                break;
                default: break;   
            }
            //Todo: hay que hacer un checkeo que me valide si existe el usuario
            //var newRequest = await _dataRepository.GetByIdAsync<Request>(_request.GetById());
            //Todo: hay que hacer un checkeo de que el status que se manda se uno valido            
            var result = await _dataRepository.UpdateAsync<Request>(_request);
            return result != null;
        }
    } 
}
