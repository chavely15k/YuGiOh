using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using YuGiOh.ApplicationCore.Repository;
using YuGiOh.ApplicationServices.Service;
using YuGiOh.Domain.Models;

namespace YuGiOh.Infrastructure.Service;

public class RoleService : AbstractDataServices, IRoleService
{
    public RoleService(IEntityRepository dataRepository, IMapper mapper) : base(dataRepository, mapper)
    {
    }
    public async Task<Role> GetRoleByIdAsync(int RoleId)
    {
        return await _dataRepository.GetByIdAsync<Role>(RoleId);
    }
}
