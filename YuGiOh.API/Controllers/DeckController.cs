using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using YuGiOh.ApplicationCore.DTO;
using YuGiOh.ApplicationServices.Service;

namespace YuGiOh.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeckController : ControllerBase
    {
        private readonly IDeckService _deckService;
        

        public DeckController(IDeckService deckService)
        {
            _deckService = deckService ?? throw new ArgumentNullException(nameof(deckService));
        }

        [HttpGet("userId/{userId}")]
        public async Task<ActionResult<IEnumerable<RegisterDeckDto>>> GetDecksByUserIdAsync(int userId)
        {
            var decks = await _deckService.GetDecksByUserIdAsync(userId);
            return Ok(decks);
        }

        [HttpPost]
        public async Task<ActionResult<RegisterDeckDto>> RegisterDeck(RegisterDeckDto register)
        {
            
            var registeredDeck = await _deckService.RegisterDeck(register);
            return Ok(registeredDeck);

        }

        // [HttpGet("userNick/{nick}")]
        // public async Task<ActionResult<IEnumerable<RegisterDeckDto>>> GetDecksByUserNickAsync(string nick)
        // {
        //     //var decks = await _deckService.GetDecksByUserNickAsync(nick);
        //     //return Ok(decks);
        // }
    }
}


