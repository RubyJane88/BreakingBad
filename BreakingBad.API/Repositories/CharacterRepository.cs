using AutoMapper;
using BreakingBad.API.Contracts;
using BreakingBad.API.Models;
using BreakingBad.API.Models.Dtos;
using BreakingBad.API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BreakingBad.API.Repositories
{
    public class CharacterRepository : ICharacterRepository

    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CharacterRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Character>> GetAllCharactersAsync()
        {
            try
            {
                var characters = await _context
                                                        .Characters
                                                        .Include(c => c.Occupation)
                                                        .ToListAsync();

                return characters;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Error getting all the characters");
            }
        }

        public async Task<CharacterDto> GetCharacterByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<CharacterDto> CreateCharacterAsync(Character character)
        {
            throw new NotImplementedException();
        }

        public async Task<CharacterDto> UpdateCharacterAsync(Character character)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteCharacterAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExistsAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}
