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

        public Task<bool> DeleteRequest(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RequestDto>> GetAllRequestByAdmin()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RequestDto>> GetAllRequestByPlayer()
        {
            throw new NotImplementedException();
        }
    }
}
