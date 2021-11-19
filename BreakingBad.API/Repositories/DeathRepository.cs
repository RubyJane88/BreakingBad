using AutoMapper;
using BreakingBad.API.Contracts;
using BreakingBad.API.Models;
using BreakingBad.API.Models.Dtos;
using BreakingBad.API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BreakingBad.API.Repositories
{
    public class DeathRepository : IDeathRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public DeathRepository(ApplicationDbContext context, IMapper mapper, LinkGenerator linkGenerator)
        {
            _context = context;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }

        public async Task<IEnumerable<DeathDto>> GetAllDeathAsync()
        {
            try
            {
                var deaths = await _context.Deaths.ToListAsync();
                var deathsDto = _mapper.Map<IEnumerable<DeathDto>>(deaths);
                return deathsDto;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Error getting the deaths");
            }
        }

        public async Task<DeathDto> GetDeathByIdAsync(int deathId)
        {
            throw new NotImplementedException();
        }

        public async Task<DeathDto> CreateDeathAsync(Death death)
        {
            throw new NotImplementedException();
        }

        public async Task<DeathDto> UpdateDeathAsync(Death death)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteDeathAsync(int deathId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExistsAsync(int deathId)
        {
            throw new NotImplementedException();
        }
    }
}