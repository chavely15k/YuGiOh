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

    public async Task<IEnumerable<DeckDto>> GetAllDecksByUserIdAsync(int userId)
    {
        var _decks = await _dataRepository.FindAsync<Deck>(d => d.Player.Id == userId);
        return _mapper.Map<IEnumerable<DeckDto>>(_decks);
    }
    public async Task<ResponseDeckDto> RegisterDeck(DeckDto register)
    {
        var deck = _mapper.Map<Deck>(register);
        var user = await _dataRepository.GetByIdAsync<User>(register.PalyerId);
        var archetype = await _dataRepository.GetByIdAsync<Archetype>(register.ArchetypeId);
        if (user != null && archetype != null)
        {
            deck.Player = user;
            deck.Archetype = archetype;
            await _dataRepository.CreateAsync<Deck>(deck);

            return new ResponseDeckDto
            {
                Id = deck.Id,
                Name = deck.Name,
                ArchetypeId = archetype.Id,
                ArchetypeName = archetype.Name,
                PlayerName = user.Name,
                PlayerId = user.Id,
                Message = "Deck added successfully",
                Success = true
            };

        }
        return new ResponseDeckDto
        {
            Message = "Unable to add deck. The provided IDs are not valid",
            Success = false
        };
    }
    public async Task<bool> DeleteDeck(int deck)
    {
        var result = await _dataRepository.DeleteAsync<Deck>(deck);
        return result != null;

    }
    public async Task<bool> UpdateDeck(DeckDto register)
    {
        var _deck = _mapper.Map<Deck>(register);
        var result = await _dataRepository.UpdateAsync<Deck>(_deck);
        return result != null;
    }

}
