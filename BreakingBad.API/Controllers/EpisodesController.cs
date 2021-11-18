using BreakingBad.API.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BreakingBad.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EpisodesController : ControllerBase
    {
        private readonly IEpisodeRepository _repo;

        public EpisodesController(IEpisodeRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEpisodes()
        {
            var episodes = await _repo.GetAllEpisodesAsync();
            var response = Ok(episodes);
            return response;
        }

        //GET: api/{episodeId}
        [HttpGet("{episodeId}")]
        public async Task<IActionResult> GetEpisodeById(int episodeId)
        {
            var episode = await _repo.GetEpisodeByIdAsync(episodeId);
            if (episode == null) return NotFound();

            var response = Ok(episode);
            return response;
        }

        //POST: api/episodes
        [HttpPost]
        public async Task<IActionResult> PostEpisode(Episode episode)
        {
            var episodeDto = await _repo.CreateEpisodeAsync(episode);
            var response = Ok(episodeDto);

            return response;
        }

        //DELETE: api/episodes/{episodeId}
        [HttpDelete("{episodeId}")]
        public async Task<IActionResult> DeleteEpisode(int episodeId)
        {
            await _repo.DeleteEpisodeAsync(episodeId);
            return NoContent();
        }

        //PUT: api/episodes/{episodeId}
        [HttpPut("{episodeId}")]
        public async Task<IActionResult> PutEpisode(int episodeId, Episode episode)
        {
            if (episodeId != episode.EpisodeId) return BadRequest();

            await _repo.UpdateEpisodeAsync(episode);
            return NoContent();
        }
    }
};