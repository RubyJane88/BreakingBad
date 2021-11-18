using BreakingBad.API.Contracts;
using BreakingBad.API.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BreakingBad.API.Controllers
{
    [ApiController]
    [Route("api/characters")]
    public class CharactersController : ControllerBase
    {
        private readonly ICharacterRepository _repo;

        public CharactersController(ICharacterRepository repo)
        {
            _repo = repo;
        }

        //GET: api/characters
        [HttpGet]
        public async Task<IActionResult> GetAllCharacters()
        {
            var characters = await _repo.GetAllCharactersAsync();
            var response = Ok(characters);

            return response;
        }

        //GET: api/characters/{id:chardId}
        [HttpGet("{charId}")]
        public async Task<IActionResult> GetCharacterById(int charId)
        {
            var character = await _repo.GetCharacterByIdAsync(charId);

            if (character == null) return NotFound();
            var response = Ok(character);
            return response;
        }

        //GET: by category

        //DELETE: api/characters/{charId}
        [HttpDelete("{charId}")]
        public async Task<IActionResult> DeleteCharacter(int chardId)
        {
            await _repo.DeleteCharacterAsync(chardId);
            return NoContent();
        }

        //POST: api/characters/
        [HttpPost]
        public async Task<IActionResult> PostCharacter(Character character)
        {
            var characterDto = await _repo.CreateCharacterAsync(character);
            var response = Ok(characterDto);

            return response;
        }

        //PUT: api/characters/{chardId}
        [HttpPut]
        public async Task<IActionResult> PutCharacter([FromRoute] int charId, [FromBody] Character character)
        {
            if (charId != character.CharId) return BadRequest();

            await _repo.UpdateCharacterAsync(character);
            return NoContent();
        }
    }
}