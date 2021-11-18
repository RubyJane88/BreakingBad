using AutoMapper;
using BreakingBad.API.Models.Dtos;
using BreakingBad.API.Models.Entities;

namespace BreakingBad.API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Character, CharacterDto>().ReverseMap();
            CreateMap<Episode, EpisodeDto>().ReverseMap();
        }
    }
}
