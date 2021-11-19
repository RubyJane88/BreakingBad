using BreakingBad.API.Models.Dtos;
using BreakingBad.API.Models.Entities;

namespace BreakingBad.API.Data
{
    public static class MockEpisodeData
    {
        public static IEnumerable<EpisodeDto> GetAllEpisodes()
        {
            var episodeDtos = new List<EpisodeDto>

            {
                new()
                {
                    EpisodeId = 1,
                    Title = "Pilot",
                    Season = "1",
                    Episodes = 1,
                    AirDate = new DateTime(2008, 09, 03),
                    // Characters = new List<Characters>(),
                    Series = "Breaking Bad"
                },

                new()
                {
                    EpisodeId = 2,
                    Title = "Cat's in the Bag" ,
                    Season = "2",
                    Episodes = 2,
                    AirDate = new DateTime(2008, 09, 03),
                    // Characters = new List<Characters>(),
                    Series = "Breaking Bad"
                },

                new()
                {
                    EpisodeId = 3,
                    Title = "...And ",
                    Season = "1",
                    Episodes = 1,
                    AirDate = new DateTime(2008, 09, 03),
                    // Characters = new List<Characters>(),
                    Series = "Breaking Bad"
                },
            };

            return episodeDtos;
        }

        public static Episode GetOneEpisode()
        {
            var episode = new Episode
            {
                EpisodeId = 4,
                Title = "Cancer Man",
                Season = "1",
                Episodes = 4,
                AirDate = new DateTime(2008, 02, 17),
                // Characters = new List<Characters>(),
                Series = "Breaking Bad"
            };
            return episode;
        }

        public static EpisodeDto GetOneEpisodeDto()
        {
            var episodeDto = new EpisodeDto
            {
                EpisodeId = 5,
                Title = "Gray Matter",
                Season = "1",
                Episodes = 5,
                // Characters = new List<Characters>(),
                AirDate = new DateTime(2008, 02, 24),
                Series = "Breaking Bad"
            };
            return episodeDto;
        }
    };
}