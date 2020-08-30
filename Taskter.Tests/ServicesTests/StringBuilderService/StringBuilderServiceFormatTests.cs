using Microsoft.Extensions.DependencyInjection;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Taskter.Domain;
using Taskter.Services;
using Xunit;

namespace Taskter.Tests.ServicesTests
{
    // TODO: need to introduce a mock of json or json resource
    public class StringBuilderServiceFormatTests : IClassFixture<StringBuilderServiceFixture>
    {
        private ServiceProvider _serviceProvider;
        private IStringBuilderService _stringBuilderService;
        private StringBuilder _stringBuilder;
        private Story _storyToTestOneLevel;

        public StringBuilderServiceFormatTests(StringBuilderServiceFixture fixture)
        {
            _serviceProvider = fixture.ServiceProvider;
            _stringBuilderService = _serviceProvider.GetService<IStringBuilderService>();


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

            _stringBuilder = new StringBuilder();
        }

        [Fact]
        public void FormatPartOfStory_ReturnFormulatedString_ShouldPass_Test() 
        {
            _stringBuilderService.FormatPartOfStory(_stringBuilder, "Name", _storyToTestOneLevel.Name);

            string testCompare = "\"Name\" : \"StoryName\"\r\n";
            Assert.Equal(_stringBuilder.ToString(),testCompare);
        }

        [Fact]
        public void FormatStoryMessage_RetrunFormulatedString_ShouldPass_Test() 
        {
            // TODO: get to have this tested
        }
    }
}
