using BreakingBad.API.Models.Dtos;
using BreakingBad.API.Models.Entities;

namespace BreakingBad.API.Controllers
{
    public interface IEpisodeRepository
    {
        Task<IEnumerable<EpisodeDto>> GetAllEpisodesAsync();

        Task<EpisodeDto> GetEpisodeByIdAsync(int episodeId);

        Task<EpisodeDto> CreateEpisodeAsync(Episode episode);

        Task<EpisodeDto> UpdateEpisodeAsync(Episode episode);

        Task DeleteEpisodeAsync(int episodeId);

        Task<bool> ExistsAsync(int episodeId);
    }
}