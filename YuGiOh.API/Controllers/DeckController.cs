using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using YuGiOh.ApplicationCore.DTO;
using YuGiOh.ApplicationServices.Service;

namespace YuGiOh.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeckController : ControllerBase
    {
        private readonly IDeckService _deckService;


        public DeckController(IDeckService deckService)
        {
            _deckService = deckService ?? throw new ArgumentNullException(nameof(deckService));
        }

        [HttpGet("userId/{userId}")]
        public async Task<ActionResult<IEnumerable<DeckDto>>> GetDecksByUserIdAsync(int userId)
        {
            var decks = await _deckService.GetAllDecksByUserIdAsync(userId);
            return Ok(decks);
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> RegisterDeck(DeckDto register)
        {

            var registeredDeck = await _deckService.RegisterDeck(register);
            return Ok(registeredDeck);

        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<ActionResult> DeleteDeck(int id)
        {
            var result = await _deckService.DeleteDeck(id);
            return Ok(result);
        }
        [HttpPut]
        [Route("update")]
        public async Task<ActionResult> UpdateDeck(DeckDto deckDto)
        {
            var result = await _deckService.UpdateDeck(deckDto);
            return Ok(result);
        }


    }
}
