using AutoMapper;
using BreakingBad.API.Controllers;
using BreakingBad.API.Models;
using BreakingBad.API.Models.Dtos;
using BreakingBad.API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BreakingBad.API.Repositories
{
    public class EpisodeRepository : IEpisodeRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public EpisodeRepository(ApplicationDbContext context, IMapper mapper, LinkGenerator linkGenerator)
        {
            _context = context;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }

        public async Task<IEnumerable<EpisodeDto>> GetAllEpisodesAsync()
        {
            try
            {
                var episodes = await _context.Episodes.ToListAsync();
                var episodeDto = _mapper.Map<IEnumerable<EpisodeDto>>(episodes);

                return episodeDto;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Error getting the episodes");
            }
        }

        public async Task<EpisodeDto> GetEpisodeByIdAsync(int episodeId)
        {
            try
            {
                var episode = await _context.Episodes.FindAsync(episodeId);
                var episodeDto = _mapper.Map<EpisodeDto>(episode);
                return episodeDto;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Error getting the episode with that id");
            }
        }

        public async Task<EpisodeDto> CreateEpisodeAsync(Episode episode)
        {
            try
            {
                _context.Episodes.Add(episode);

                await _context.SaveChangesAsync();

                var episodeDto = _mapper.Map<EpisodeDto>(episode);
                return episodeDto;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception(e.Message);
            }
        }

        public async Task<EpisodeDto> UpdateEpisodeAsync(Episode episode)
        {
            try
            {
                var exists = await ExistsAsync(episode.EpisodeId);
                if (!exists) throw new Exception("Not found!");

                _context.Update(episode);
                await _context.SaveChangesAsync();
                var episodeDto = _mapper.Map<EpisodeDto>(episode);
                return episodeDto;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception(e.Message);
            }
        }

        public async Task DeleteEpisodeAsync(int episodeId)
        {
            try
            {
                var exists = await ExistsAsync(episodeId);
                if (!exists) throw new Exception("Not Found!");

                _context.Remove(await _context.Episodes.FindAsync(episodeId));
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> ExistsAsync(int episodeId) =>
            await _context.Episodes.AnyAsync(e => e.EpisodeId == episodeId);
    }
}