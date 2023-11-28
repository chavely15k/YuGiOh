using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YuGiOh.ApplicationCore.DTO;


namespace YuGiOh.ApplicationServices.Service;

public interface IDeckService
{
    Task<RegisterDeckDto> RegisterDeck(RegisterDeckDto register);
    public  Task<IEnumerable<RegisterDeckDto>> GetDecksByUserIdAsync(int userId);

    Task<bool> DeleteDeck(int deck);
    // public  Task<IEnumerable<RegisterDeckDto>> GetDecksByUserNickAsync(string nick);
}
