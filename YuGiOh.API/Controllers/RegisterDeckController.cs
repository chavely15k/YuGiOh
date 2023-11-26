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
    public class RegisterDeckController : ControllerBase
    {
        private readonly IDeckService _deckService;

        public RegisterDeckController(IDeckService deckService)
        {
            _deckService = deckService ?? throw new ArgumentNullException(nameof(deckService));
        }

        [HttpGet("userId/{userId}")]
        public async Task<ActionResult<IEnumerable<RegisterDeckDto>>> GetDecksByUserIdAsync(Guid userId)
        {
            var decks = await _deckService.GetDecksByUserIdAsync(userId);
            return Ok(decks);
        }

        // [HttpGet("userNick/{nick}")]
        // public async Task<ActionResult<IEnumerable<RegisterDeckDto>>> GetDecksByUserNickAsync(string nick)
        // {
        //     //var decks = await _deckService.GetDecksByUserNickAsync(nick);
        //     //return Ok(decks);
        // }

        [HttpPost]
        public async Task<ActionResult<RegisterDeckDto>> RegisterDeck(RegisterDeckDto register)
        {

            var registeredDeck = await _deckService.RegisterDeck(register);
            return Ok(registeredDeck);

        }
    }
}


