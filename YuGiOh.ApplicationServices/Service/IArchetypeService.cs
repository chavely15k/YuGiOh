using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YuGiOh.ApplicationCore.DTO;

namespace YuGiOh.ApplicationServices.Service;

public interface IArchetypeService
{
    public Task<IEnumerable<ArchetypeDto>> GetAllAsync();
    public Task<bool> CreateArchetype(ArchetypeDto archetype);
    Task<bool> DeleteArchetype(int idArchetype);
    Task<bool> UpdateArchetype(ArchetypeDto archetype);

}
