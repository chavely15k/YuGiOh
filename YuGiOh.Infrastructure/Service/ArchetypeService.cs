using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using YuGiOh.ApplicationCore.DTO;
using YuGiOh.ApplicationCore.Repository;
using YuGiOh.ApplicationServices.Service;
using YuGiOh.ApplicationServices.Service.AbstractClass;
using YuGiOh.Domain.Models;

namespace YuGiOh.Infrastructure.Service;

public class ArchetypeService : AbstractDataServices, IArchetypeService
{
    public ArchetypeService(IEntityRepository dataRepository, IMapper mapper) : base(dataRepository, mapper)
    {
    }

    public async Task<bool> CreateArchetype(ArchetypeDto archetype)
    {
        var _archetype = _mapper.Map<Archetype>(archetype);
        await _dataRepository.CreateAsync<Archetype>(_archetype);
        return true;
    }

    public Task<bool> DeleteDeck(int idArchetype)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ArchetypeDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateDeck(ArchetypeDto archetype)
    {
        throw new NotImplementedException();
    }
}
