using BreakingBad.API.Models.Dtos;
using BreakingBad.API.Models.Entities;

namespace BreakingBad.API.Contracts
{
    public interface IDeathRepository
    {
        Task<IEnumerable<DeathDto>> GetAllDeathAsync();

        Task<DeathDto> GetDeathByIdAsync(int deathId);

        Task<DeathDto> CreateDeathAsync(Death death);

        Task<DeathDto> UpdateDeathAsync(Death death);

        Task DeleteDeathAsync(int deathId);

        Task<bool> ExistsAsync(int deathId);
    }
}