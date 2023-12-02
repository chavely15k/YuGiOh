using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YuGiOh.ApplicationCore.DTO;


namespace YuGiOh.ApplicationServices.Service;

public interface IDeckService
{
    Task<ResponseDeckDto> RegisterDeck(DeckDto register);
    public  Task<IEnumerable<DeckDto>> GetAllDecksByUserIdAsync(int userId);
    Task<bool> DeleteDeck(int idDeck);
    Task<bool> UpdateDeck(DeckDto deck);

    // public  Task<IEnumerable<RegisterDeckDto>> GetDecksByUserNickAsync(string nick);
}
