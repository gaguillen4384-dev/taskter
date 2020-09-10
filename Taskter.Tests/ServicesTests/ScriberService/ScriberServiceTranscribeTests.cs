using Microsoft.Extensions.DependencyInjection;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Taskter.Domain;
using Taskter.Services;
using Xunit;

namespace Taskter.Tests.ServicesTests
{
    // TODO: need to introduce a mock of json or json resource
    public class ScriberServiceTranscribeTests : IClassFixture<ScriberServiceFixture>
    {
        private ServiceProvider _serviceProvider;
        private readonly IScriberService _scriberService;
        Story _storyToTestOneLevel;

        public ScriberServiceTranscribeTests(ScriberServiceFixture fixture)
        {
            _serviceProvider = fixture.ServiceProvider;
            _scriberService = _serviceProvider.GetService<IScriberService>();
            // TODO: put this under setup so it can be reuse
            _storyToTestOneLevel = new Story
            {
                Name = "StoryName",
                ProjectAcronym = "ProjectName_ID",
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
        }


        [Fact]
        public void TranscribeIntoStoryFromJson_ReturnStoryNumber_ShouldPass_Test()
        {
            // TODO: mock the internal repo service call to have a passing test 
        }

    }
}
