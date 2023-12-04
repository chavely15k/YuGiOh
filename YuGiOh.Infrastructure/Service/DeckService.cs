using AutoMapper;
using Microsoft.EntityFrameworkCore;
using YuGiOh.ApplicationCore.DTO;
using YuGiOh.ApplicationCore.Repository;
using YuGiOh.ApplicationServices.Service;
using YuGiOh.Domain.Models;


namespace YuGiOh.Infrastructure.Service;

public class DeckService : AbstractDataServices, IDeckService
{
    public DeckService(IEntityRepository dataRepository, IMapper mapper) : base(dataRepository, mapper)
    {
    }

    public async Task<IEnumerable<DeckDto>> GetAllDecksByUserIdAsync(int userId)
    {

        var foundDecks = await _dataRepository
      .Include<Deck>(d => d.Archetype, d => d.Player)
      .Where(d => d.Player.Id == userId)
      .ToListAsync();
        return _mapper.Map<IEnumerable<DeckDto>>(foundDecks);
    }
    public async Task<ResponseDeckDto> RegisterDeck(DeckDto register)
    {
        var deck = _mapper.Map<Deck>(register);
        var user = await _dataRepository.GetByIdAsync<User>(register.PlayerId);
        var archetype = await _dataRepository.GetByIdAsync<Archetype>(register.ArchetypeId);
        if (user != null && archetype != null)
        {
            deck.Player = user;
            deck.Archetype = archetype;
            await _dataRepository.CreateAsync<Deck>(deck);

            if(register.ExtraDeckSize > 60 || register.ExtraDeckSize < 40 || register.ExtraDeckSize > 15 
                || register.ExtraDeckSize < 0 || register.SideDeckSize > 15 || register.SideDeckSize < 0)
                {
                    return new ResponseDeckDto
                    {
                        Message = "Main deck size most be no more than 60 and no less than 40 cards, and the extra and side decks can't have more than 15",
                        Success = false
                    };
                }
                else return new ResponseDeckDto
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
        var archetype = await _dataRepository.GetByIdAsync<Archetype>(register.ArchetypeId);
        _deck.Archetype = archetype;
        var result = await _dataRepository.UpdateAsync<Deck>(_deck);
        return result != null;
    }

}
