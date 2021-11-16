using BreakingBad.API.Contracts;
using BreakingBad.API.Controllers;
using BreakingBad.API.Data;
using BreakingBad.API.Models.Dtos;
using BreakingBad.API.Models.Entities;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BreakingBad.Unit.Tests
{
    public class CharactersControllerTest
    {
        private readonly Mock<ICharacterRepository> _mockRepo;
        private readonly CharactersController _controller;

        public CharactersControllerTest()
        {
            _mockRepo = new Mock<ICharacterRepository>();
            _controller = new CharactersController(_mockRepo.Object);
        }

        [Fact]
        public async Task GetCharactersTest()
        {
            //arrange
            var mockCharacterDtos = MockData.GetAllCharacters();
            _mockRepo.Setup(repository => repository.GetAllCharactersAsync())
                .Returns(Task.FromResult(mockCharacterDtos));

            //act
            var result = await _controller.GetAllCharacters();
            var response = (OkObjectResult)result;
            var characters = response.Value as IEnumerable<CharacterDto>;

            //assert
            Assert.IsAssignableFrom<IActionResult>(result);
            Assert.NotNull(characters);

            //Fluent Assertions versions
            result.Should().BeAssignableTo<IActionResult>();
            response.StatusCode.Should().Be(200);
        }

        [Theory]
        [InlineData(2, 1)]
        public async Task GetCharacterByIdTest(int validCharId, int invalidCharId)
        {
            //arrange
            var validCharacterId = validCharId;
            var mockCharacterDto = MockData.GetAllCharacters().FirstOrDefault(c => c.CharId == validCharId);

            _mockRepo.Setup(repository => repository.GetCharacterByIdAsync(validCharacterId))
                .Returns(Task.FromResult(mockCharacterDto));

            //act
            var result = await _controller.GetCharacterById(validCharId);
            var response = (OkObjectResult)result;
            var characterById = response.Value as CharacterDto;

            //assert
            Assert.IsAssignableFrom<IActionResult>(result);
            Assert.Equal(200, response.StatusCode);

            //Fluent Assertions version
            characterById.Should().Subject.Equals(validCharId);

            //arrange

            var invalidCharacterId = invalidCharId;
            var mockInvalidCharacterDto = MockData.GetAllCharacters().FirstOrDefault(c => c.CharId == invalidCharId);

            _mockRepo.Setup(repository => repository.GetCharacterByIdAsync(invalidCharacterId))
                .Returns(Task.FromResult(mockInvalidCharacterDto));

            //act
            var invalidResult = await _controller.GetCharacterById(invalidCharId);
            var notFoundResponse = (NotFoundResult)invalidResult;

            //assert
            Assert.Equal(404, notFoundResponse.StatusCode);

            //Fluent Assertions version
            notFoundResponse.StatusCode.Should().Be(404);
        }

        [Theory]
        [InlineData(1)]
        public async Task DeleteCharacterTest(int charId)
        {
            //arrange
            var mockCharacterDtos = MockData.GetAllCharacters();
            _mockRepo.Setup(repository => repository.GetAllCharactersAsync())
                .Returns(Task.FromResult(mockCharacterDtos));

            //act
            var result = await _controller.DeleteCharacter(charId);
            var response = (NoContentResult)result;

            //assert
            Assert.IsAssignableFrom<IActionResult>(result);
            Assert.Equal(204, response.StatusCode);

            //Fluent Assertions version
            result.Should().BeAssignableTo<IActionResult>();
            response.Equals(charId);
        }

        [Fact]
        public async Task PostCharacterTest()
        {
            //arrange
            var mockCharacterDto = MockData.GetOneCharacterDto();
            var newCharacter = new Character
            {
                CharId = 8,
                Name = "Saul Goodman",
                Birthday = new DateTime(),
                Occupation = new List<string>() { "Lawyer" },
                Img = new Uri(
                    "https://vignette.wikia.nocookie.net/breakingbad/images/1/16/Saul_Goodman.jpg/revision/latest?cb=20120704065846"),
                Nickname = "Jimmy McGill",
                Appearance = new List<string>() { "2", "3", "4", "5" },
                Portrayed = "Bob Odenkirk",
                Category = "Breaking Bad, Better Call Saul",
                BetterCallSaulAppearance = new List<string>() { "1", "2", "3", "4", "5" }
            };

            _mockRepo.Setup(repository => repository.CreateCharacterAsync(newCharacter))
                .Returns(Task.FromResult(mockCharacterDto));

            //act
            var result = await _controller.PostCharacter(newCharacter);
            var response = (OkObjectResult)result;
            var characterDto = response.Value as CharacterDto;

            //assert
            Assert.NotNull(characterDto);
            Assert.IsType<int>(characterDto.CharId);
            Assert.Equal(200, response.StatusCode);

            //Fluent Assertions version
            characterDto.Should().NotBeNull();
            response.StatusCode.Should().Be(200);
            characterDto.Equals(characterDto);
        }

        [Fact]
        public async Task PutCharacterTest()
        {
            //arrange
            var mockCharacter = MockData.GetOneCharacter();
            var mockCharacterDto = MockData.GetOneCharacterDto();

            _mockRepo.Setup(repository => repository.UpdateCharacterAsync(mockCharacter))
                .Returns(Task.FromResult(mockCharacterDto));
            mockCharacterDto.CharId = 1;

            //act
            var result = await _controller.PutCharacter(mockCharacterDto.CharId, mockCharacter);
            var response = (NoContentResult)result;

            //assert
            Assert.IsAssignableFrom<IActionResult>(result);
            Assert.Equal(204, response.StatusCode);
        }
    }
}