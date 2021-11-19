using BreakingBad.API.Controllers;
using BreakingBad.API.Data;
using BreakingBad.API.Models.Dtos;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BreakingBad.Unit.Tests
{
    public class EpisodesControllerTest
    {
        private readonly Mock<IEpisodeRepository> _mockRepo;
        private readonly EpisodesController _controller;

        public EpisodesControllerTest()
        {
            _mockRepo = new Mock<IEpisodeRepository>();
            _controller = new EpisodesController(_mockRepo.Object);
        }

        [Fact]
        public async Task GetEpisodes()
        {
            //arrange
            var mockEpisodesDtos = MockEpisodeData.GetAllEpisodes();
            _mockRepo.Setup(repository => repository.GetAllEpisodesAsync()).Returns(Task.FromResult(mockEpisodesDtos));

            //act
            var result = await _controller.GetAllEpisodes();
            var response = (OkObjectResult)result;
            var episodes = response.Value as IEnumerable<EpisodeDto>;

            //assert
            Assert.IsAssignableFrom<IActionResult>(result);
            Assert.NotNull(episodes);

            //Fluent Assertions version
            result.Should().BeAssignableTo<IActionResult>();
            response.StatusCode.Should().Be(200);
        }

        [Theory]
        [InlineData(1, 10)]
        public async Task GetEpisodeByIdTest(int validEpisodeId, int invalidEpisodeId)
        {
            //arrange
            var validId = validEpisodeId;
            var mockEpisodeDto = MockEpisodeData.GetAllEpisodes().FirstOrDefault(e => e.EpisodeId == validEpisodeId);

            _mockRepo.Setup(repository => repository.GetEpisodeByIdAsync(validId))
                .Returns(Task.FromResult(mockEpisodeDto));

            //act
            var result = await _controller.GetEpisodeById(validEpisodeId);
            var response = (OkObjectResult)result;
            var episodeById = response.Value as EpisodeDto;

            //assert
            Assert.IsAssignableFrom<IActionResult>(result);
            Assert.Equal(200, response.StatusCode);

            //Fluent Assertions version
            episodeById.Should().Subject.Equals(validEpisodeId);

            //arrange
            var invalidId = invalidEpisodeId;
            var mockInvalidEpisodeDto = MockEpisodeData.GetAllEpisodes().FirstOrDefault(e => e.EpisodeId == invalidId);

            _mockRepo.Setup(repository => repository.GetEpisodeByIdAsync(invalidEpisodeId))
                .Returns(Task.FromResult(mockInvalidEpisodeDto));

            //act
            var invalidResult = await _controller.GetEpisodeById(invalidEpisodeId);
            var notFoundResponse = (NotFoundResult)invalidResult;

            //assert
            Assert.Equal(404, notFoundResponse.StatusCode);

            //Fluent Assertions version
            notFoundResponse.StatusCode.Should().Be(404);
        }
    }
}