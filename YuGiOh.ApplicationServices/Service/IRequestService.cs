using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YuGiOh.ApplicationCore.DTO;

namespace YuGiOh.ApplicationServices.Service;

public interface IRequestService
{
    public Task<RequestDto> CreateRequest(RequestDto create);
    public Task<IEnumerable<RequestDto>> GetAllRequestByAdmin(int id);
    public Task<IEnumerable<RequestDto>> GetAllRequestByPlayer(int id);
    
    public Task<bool> UpdateRequest(RequestDto update);
    
    public Task<bool> DeleteRequest(int Pid, int Tid);

}

