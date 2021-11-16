using BreakingBad.API.Models.Dtos;
using BreakingBad.API.Models.Entities;

namespace BreakingBad.API.Contracts
{
    public interface ICharacterRepository
    {
        Task<IEnumerable<CharacterDto>> GetAllCharactersAsync();

        Task<CharacterDto> GetCharacterByIdAsync(int charId);

        Task<CharacterDto> CreateCharacterAsync(Character character);

        Task<CharacterDto> UpdateCharacterAsync(Character character);

        Task DeleteCharacterAsync(int charId);

        Task<bool> ExistsAsync(int charId);
    }
}