using BreakingBad.API.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BreakingBad.API.Controllers
{
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

    }
}
