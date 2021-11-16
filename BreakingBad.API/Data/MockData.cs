using BreakingBad.API.Models.Dtos;
using BreakingBad.API.Models.Entities;

namespace BreakingBad.API.Data
{
    public static class MockData
    {
        public static IEnumerable<CharacterDto> GetAllCharacters()
        {
            var characterDtos = new List<CharacterDto>
            {
                new()
                {
                    CharId = 2,
                    Name = "Walter White",
                    Birthday = new DateTime(1958, 09, 07),
                    Occupation = new List<string>() {"High School Chemistry Teacher", "Meth King Pin"},
                    Img = new Uri(
                        "https://static.wikia.nocookie.net/breakingbad/images/8/88/WalterWhite.png/revision/latest/scale-to-width-down/1000?cb=20140712163255&path-prefix=de"),
                    Nickname = "Heisenberg",
                    Appearance = new List<string>() {"1", "2", "3", "4", "5"},
                    Portrayed = "Bryan Cranston",
                    Category = "Breaking Bad",
                    BetterCallSaulAppearance = new List<string>() {"None"}
                },

                new()
                {
                    CharId = 3,
                    Name = "Skyler White",
                    Birthday = new DateTime(1970, 11, 08),
                    Occupation = new List<string>
                    {
                        "House wife",
                        "Book Keeper",
                        "Car Wash Manager",
                        "Taxi Dispatcher"
                    },
                    Img = new Uri("https://s-i.huffpost.com/gen/1317262/images/o-ANNA-GUNN-facebook.jpg"),
                    Nickname = "Sky",
                    Appearance = new List<string> {"1", "2", "3", "4", "5"},
                    Portrayed = "Anna Gunn",
                    BetterCallSaulAppearance = new List<string>() {"None"}
                },

                new()
                {
                    CharId = 4,
                    Name = "Walter White Jr.",
                    Birthday = new DateTime(1993, 07, 08),
                    Occupation = new List<string> {"Teenager"},
                    Img = new Uri(
                        "https://media1.popsugar-assets.com/files/thumbor/WeLUSvbAMS_GL4iELYAUzu7Bpv0/fit-in/1024x102"),
                    Nickname = "Flynn",
                    Appearance = new List<string>() {"1", "2", "3", "4", "5"},
                    Portrayed = "RJ Mitte",
                    Category = "Breaking Bad",
                    BetterCallSaulAppearance = new List<string>() { },
                }
            };

            return characterDtos;
        }

        public static Character GetOneCharacter()
        {
            var character = new Character
            {
                CharId = 1,
                Name = "Henry Schrader",
                Birthday = new DateTime(),
                Occupation = new List<string> { "DFA Agent" },
                Img = new Uri(
                    "https://vignette.wikia.nocookie.net/breakingbad/images/b/b7/HankS5.jpg/revision/latest/scale-to-width-down/700?cb=20120620014136"),
                Nickname = "Hank",
                Appearance = new List<string> { "1", "2", "3", "4", "5" },
                Portrayed = "Dean Norris",
                Category = "Breaking Bad",
                BetterCallSaulAppearance = new List<string> { },
            };

            return character;
        }

        public static CharacterDto GetOneCharacterDto()
        {
            var characterDto = new CharacterDto
            {
                CharId = 6,
                Name = "Marie Schrader",
                Birthday = new DateTime(),
                Occupation = new List<string> { "Housewife", "Clepto" },
                Img = new Uri(
                    "https://vignette.wikia.nocookie.net/breakingbad/images/1/10/Season_2_-_Marie.jpg/revision/latest?cb=20120617211645"),
                Nickname = "Marie",
                Appearance = new List<string> { "1", "2", "3", "4", "5" },
                Portrayed = "Betsy Brandt",
                Category = "Breaking Bad",
                BetterCallSaulAppearance = new List<string> { },
            };

            return characterDto;
        }
    }
}