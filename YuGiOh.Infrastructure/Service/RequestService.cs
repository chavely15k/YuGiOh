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

        public Task<IEnumerable<RequestDto>> GetAllRequestByAdmin(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RequestDto>> GetAllRequestByPlayer(int id)
        {
            throw new NotImplementedException();
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
