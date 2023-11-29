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
    public class RequestService : AbstractDataService, IRequestService
    {
        public RequestService(IEntityRepository dataRepository, IMapper mapper) : base(dataRepository, mapper)
        {
        }

        public Task<RequestDto> CreateRequest(RequestDto request)
        {
            throw new NotImplementedException();

        }

        public async Task<bool> DeleteRequest(int Tid, int Pid)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<RequestDto>> GetAllRequestByAdmin(int id)
        {
            //var allRequest = await _dataRepository.FindAsync<Request>(d => );
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<RequestDto>> GetAllRequestByPlayer(int id)
        {
            var allRequest = await _dataRepository.FindAsync<Request>(d => d.PlayerId == id);
            DateTime now = DateTime.Now;
            LinkedList<RequestDto> result = new();
            foreach(var request in allRequest)
            {
                var tournament = await _dataRepository.GetByIdAsync<Tournament, int>(request.TournamentId);
                if(now.CompareTo(tournament.StartDate)>0)
                {
                    result.AddLast(_mapper.Map<RequestDto>(request));
                }
            }
            return result.OrderBy(x => x.Date).ToList();

        }

        public Task<bool> UpdateRequest(RequestDto update)
        {
            throw new NotImplementedException();
        }
    }
}
