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

        public async Task<IEnumerable<CharacterDto>> GetAllCharactersAsync()
        {
            try
            {
                var characters = await _context
                                                        .Characters

                                                        .ToListAsync();
                var characterDtos = _mapper.Map<IEnumerable<CharacterDto>>(characters);

                return characterDtos;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Error getting all the characters");
            }
        }

        public async Task<CharacterDto> GetCharacterByIdAsync(int charId)
        {
            try
            {
                var character = await _context.Characters.FindAsync(charId);
                var characterDto = _mapper.Map<CharacterDto>(character);
                return characterDto;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Error getting character with that id");
            }
        }

        public async Task<CharacterDto> CreateCharacterAsync(Character character)
        {
            try
            {
                _context.Characters.Add(character);
                await _context.SaveChangesAsync();

                var characterDto = _mapper.Map<CharacterDto>(character);
                return characterDto;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Error creating a new breaking bad character");
            }
        }

        public async Task DeleteCharacterAsync(int charId)
        {
            try
            {
                var exists = await ExistsAsync(charId);
                if (!exists) throw new Exception("Not Found");

                _context.Remove(await _context.Characters.FindAsync(charId));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Error deleting character item");
            }
        }

        public async Task<CharacterDto> UpdateCharacterAsync(Character character)
        {
            try
            {
                var exists = await ExistsAsync(character.CharId);
                if (!exists) throw new Exception("Not Found");

                _context.Update(character);
                await _context.SaveChangesAsync();
                var characterDto = _mapper.Map<CharacterDto>(character);
                return characterDto;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Error updating the character item");
            }
        }

        public async Task<bool> ExistsAsync(int charId) => await _context.Characters.AnyAsync(c => c.CharId == charId);
    }
}