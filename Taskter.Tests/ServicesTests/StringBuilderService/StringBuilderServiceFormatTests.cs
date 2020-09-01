using Microsoft.Extensions.DependencyInjection;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private Story _storyToTestLevel;

        public StringBuilderServiceFormatTests(StringBuilderServiceFixture fixture)
        {
            _serviceProvider = fixture.ServiceProvider;
            _stringBuilderService = _serviceProvider.GetService<IStringBuilderService>();

            _storyToTestLevel = new Story
            {
                Name = "StoryName",
                ProjectAcronym = "ProjectName_ID",
                StoryMessage = new List<MessageLine>()
                {
                    new MessageLine
                    {
                        Line = "MessageLine",
                        Level = 1
                    },
                    new MessageLine
                    {
                        Line = "MessageLine1",
                        Level = 2
                    },

                }
            };

            _stringBuilder = new StringBuilder();
        }

        [Fact]
        public void FormatPartOfStory_ReturnFormulatedString_ShouldPass_Test() 
        {
            _stringBuilderService.FormatPartOfStory(_stringBuilder, "Name", _storyToTestLevel.Name);

            string testCompare = "\"Name\" : \"StoryName\"\r\n";
            Assert.Equal(_stringBuilder.ToString(), testCompare);
        }

        [Fact]
        public void FormatStoryMessage_ReturnFormulatedString_ShouldPass_Test() 
        {
            var result = _stringBuilderService.FormatStoryMessages(_stringBuilder, _storyToTestLevel.StoryMessage.ToList<MessageLine>());

            string testCompare = "+MessageLine\r\n++MessageLine1\r\n";
            Assert.Equal(result, testCompare);
        }

        [Fact]
        public void FormatStoryNumber_ReturnProperStoryNumber_ShouldPass_Test()
        {
            // TODO: REPO logic
            Assert.Equal(result, testCompare);
        }
    }
}
