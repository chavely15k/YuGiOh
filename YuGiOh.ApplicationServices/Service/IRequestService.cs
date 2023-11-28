using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YuGiOh.ApplicationCore.DTO;

namespace YuGiOh.ApplicationServices.Service;

public interface IRequestService
{
    public Task<RequestDto> CreateRequest(RequestDto create);
    public Task<IEnumerable<RequestDto>> GetAllRequestByAdmin();
    public Task<IEnumerable<RequestDto>> GetAllRequestByPlayer();
    public Task<bool> DeleteRequest(int Id);
}

