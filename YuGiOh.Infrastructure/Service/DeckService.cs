using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Query;
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

    public async Task<IEnumerable<DeckDto>> GetDecksByUserIdAsync(int userId)
    {
        var _decks = await _dataRepository.FindAsync<Deck>(d => d.Player.Id == userId);
        
        return _mapper.Map<IEnumerable<DeckDto>>(_decks);
    }

    public async Task<DeckDto> RegisterDeck(DeckDto register)
    {
        var _deck = _mapper.Map<Deck>(register);

        //var _user = await _dataRepository.GetByIdAsync<User,Guid>(register.PalyerId);
        var _user = await _dataRepository.FindAsync<User>(d => d.Nick == register.Nick);
        var _Archetype = await _dataRepository.FindAsync<Archetype>(d => d.Id == register.Archetype);
        if (_user.Count() != 0)
        {
            _deck.Player = _user.First();
            _deck.Archetype = _Archetype.First();
            await _dataRepository.CreateAsync<Deck>(_deck);
        }
        return _mapper.Map<DeckDto>(_deck);
    }

    public async Task<bool> DeleteDeck(int deck)
    {
        var result = await _dataRepository.DeleteAsync<Deck,int>(deck);
        return result != null;
        
    }

    public async Task<bool> UpdateDeck(RegisterDeckDto register)
    {
        var _deck = _mapper.Map<Deck>(register);
        var result = await _dataRepository.UpdateAsync<Deck>(_deck);
        return result != null;
    }
    // public async Task<IEnumerable<RegisterDeckDto>> GetDecksByUserNickAsync(string nick)
    // {
    //     var _decks = await _dataRepository.FindAsync<Deck>(d => d.Player.Nick == nick);
    //     return _mapper.Map<IEnumerable<RegisterDeckDto>>(_decks);
    // }
}
