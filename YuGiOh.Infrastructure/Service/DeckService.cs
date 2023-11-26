using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using YuGiOh.ApplicationCore.DTO;
using YuGiOh.ApplicationCore.Repository;
using YuGiOh.ApplicationServices.Service;
using YuGiOh.Domain.Models;


namespace YuGiOh.Infrastructure.Service;

public class DeckService : AbstractDataService, IDeckService
{
    public DeckService(IDataRepository dataRepository, IMapper mapper) : base(dataRepository, mapper)
    {
    }

    public Task<IEnumerable<RegisterDeckDto>> GetDecksByUserIdAsync(int userId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<RegisterDeckDto>> GetDecksByUserNickAsync(string nick)
    {
        throw new NotImplementedException();
    }

    public async Task<RegisterDeckDto> RegisterDeck(RegisterDeckDto register)
    {
        var _deck = _mapper.Map<Deck>(register);
        await _dataRepository.CreateAsync<Deck>(_deck);
        return _mapper.Map<RegisterDeckDto>(_deck);
    }
}
