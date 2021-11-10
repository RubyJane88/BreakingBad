using BreakingBad.API.Models.Dtos;
using BreakingBad.API.Models.Entities;

namespace BreakingBad.API.Contracts
{
    public interface ICharacterRepository
    {

        Task<IEnumerable<Character>> GetAllCharactersAsync();

        Task<CharacterDto> GetCharacterByIdAsync(int Id);

        Task<CharacterDto> CreateCharacterAsync(Character character);

        Task<CharacterDto> UpdateCharacterAsync(Character character);

        Task DeleteCharacterAsync(int Id);

        Task<bool> ExistsAsync(string name);
    }
}
