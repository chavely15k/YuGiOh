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

public class DeckService : AbstractDataServices, IDeckService
{
    public DeckService(IEntityRepository dataRepository, IMapper mapper) : base(dataRepository, mapper)
    {
    }

    public async Task<IEnumerable<RegisterDeckDto>> GetDecksByUserIdAsync(int userId)
    {
        var _decks = await _dataRepository.FindAsync<Deck>(d => d.Player.Id == userId);
        
        return _mapper.Map<IEnumerable<RegisterDeckDto>>(_decks);
    }

    public async Task<RegisterDeckDto> RegisterDeck(RegisterDeckDto register)
    {
        var _deck = _mapper.Map<Deck>(register);

        //var _user = await _dataRepository.GetByIdAsync<User,Guid>(register.PalyerId);
        var _user = await _dataRepository.FindAsync<User>(d => d.Nick == register.Nick);
        if (_user.Count() != 0)
        {
            _deck.Player = _user.First();
            await _dataRepository.CreateAsync<Deck>(_deck);
            
        }
        return _mapper.Map<RegisterDeckDto>(_deck);
    }

    // public async Task<IEnumerable<RegisterDeckDto>> GetDecksByUserNickAsync(string nick)
    // {
    //     var _decks = await _dataRepository.FindAsync<Deck>(d => d.Player.Nick == nick);
    //     return _mapper.Map<IEnumerable<RegisterDeckDto>>(_decks);
    // }
}
