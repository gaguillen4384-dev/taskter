using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Collections.Generic;
using Taskter.Domain;
using Taskter.Services;
using Xunit;

namespace Taskter.Tests.ServicesTests
{
    public class ScriberServiceTranscribeTests : IClassFixture<ScriberServiceFixture>
    {
        private readonly ServiceProvider _serviceProvider;
        private readonly IScriberService _scriberService;
        readonly Story _storyToTestOneLevel;
        readonly Story _newStoryToTestOneLevel;

        public ScriberServiceTranscribeTests(ScriberServiceFixture fixture)
        {
            _serviceProvider = fixture.ServiceProvider;
            _scriberService = _serviceProvider.GetService<IScriberService>();
            _storyToTestOneLevel = new Story
            {
                Name = "StoryName",
                ProjectAcronym = "TST",
                StoryMessage = new List<MessageLine>()
                {
                    new MessageLine
                    {
                        Line = "MessageLine",
                        Level = 0
                    }
                }
            };

            _newStoryToTestOneLevel = new Story
            {
                Name = "StoryName",
                ProjectAcronym = "NTST",
                StoryMessage = new List<MessageLine>()
                {
                    new MessageLine
                    {
                        Line = "MessageLine",
                        Level = 0
                    }
                }
            };
        }

        [Fact]
        public void TranscribeIntoStoryFromJson_ReturnString_ShouldPass_Test()
        {
            string testInput = JsonConvert.SerializeObject(_storyToTestOneLevel, Formatting.Indented);
            var result = _scriberService.TranscribeIntoStory(testInput);
            Assert.IsType<string>(result);
        }

        [Fact]
        public void TranscribeIntoStoryFromJson_ReturnFormulatedString_ShouldPass_Test()
        {
            string testInput = JsonConvert.SerializeObject(_storyToTestOneLevel, Formatting.Indented);
                
            var result = _scriberService.TranscribeIntoStory(testInput);
            string testCompare = $"\"Name\" : \"StoryName\"\r\n\"TST-1\"\r\n+MessageLine\r\n";
            Assert.Equal(result, testCompare);
        }

        [Fact]
        public void TranscribeNewStoryFromJson_ReturnFormulatedString_ShouldPass_Test()
        {
            string testInput = JsonConvert.SerializeObject(_newStoryToTestOneLevel, Formatting.Indented);

            var result = _scriberService.TranscribeNewStoryForProject(_newStoryToTestOneLevel.ProjectAcronym, testInput);

            var latestNumber = _scriberService.GetLatestStoryNumberForProject(_newStoryToTestOneLevel.ProjectAcronym);

            string testCompare = $"\"Name\" : \"StoryName\"\r\n\"NTST-{latestNumber}\"\r\n+MessageLine\r\n";
            Assert.Equal(result, testCompare);

        }

        [Fact]
        public void GetLatestStoryNumber_ReturnNumber_ShouldPass_Test()
        {
            string testInput = JsonConvert.SerializeObject(_storyToTestOneLevel, Formatting.Indented);
            var latestNumber = _scriberService.GetLatestStoryNumberForProject(_storyToTestOneLevel.ProjectAcronym);
            var testCompare = "1";
            Assert.Equal(latestNumber, testCompare);
        }

        [Fact]
        public void GetLatestStoryFromProject_ReturnFormulatedString_ShouldPass_Test()
        {
            // TODO: This is future storage invloving blob storage and schema changes, could progress to current on but that more in future.
        }

    }
}
