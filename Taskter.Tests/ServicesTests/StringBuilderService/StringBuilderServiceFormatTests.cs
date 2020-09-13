using Microsoft.Extensions.DependencyInjection;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taskter.Domain;
using Taskter.Services;
using Xunit;

namespace Taskter.Tests.ServicesTests
{
    public class StringBuilderServiceFormatTests : IClassFixture<StringBuilderServiceFixture>
    {
        private readonly ServiceProvider _serviceProvider;
        private readonly IStringBuilderService _stringBuilderService;
        private readonly StringBuilder _stringBuilder;
        private readonly Story _storyToTestLevel;

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
            var test = "TST";
            _stringBuilderService.FormatStoryNumber(_stringBuilder, test);
            string testCompare = "TST-1";
            Assert.Equal(_stringBuilder.ToString(), testCompare);
        }
    }
}
