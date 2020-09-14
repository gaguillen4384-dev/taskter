using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taskter.Domain;

namespace Taskter.Services
{
    /// <summary>
    /// This is the concrete implementation of <see cref="IScriberService"/>
    /// </summary>
    public class ScriberService : IScriberService
    {
        private readonly IStoryValidator _validator;
        private readonly IStringBuilderService _stringBuilderService;
        private readonly IProjectRepositoryService _projectRepositoryService;

        public ScriberService(IStoryValidator validator,
            IStringBuilderService stringBuilderService,
            IProjectRepositoryService projectRepositoryService) 
        {
            _validator = validator;
            _stringBuilderService = stringBuilderService;
            _projectRepositoryService = projectRepositoryService;
        }

        /// <summary>
        /// concrete implementation of <see cref="IScriberService.TranscribeStory(Story, string)">
        /// </summary>
        public string TranscribeStory(Story storyMessage, string storyNumber = null)
        {
            _validator.ValidateStoryProperties(storyMessage);

            string result = Format(storyMessage, storyNumber);

            return result;
        }

        /// <summary>
        /// concrete implementation of <see cref="IScriberService.TranscribeNewStoryForProject(string)">
        /// </summary>
        public string TranscribeNewStoryForProject(string StoryMessage)
        {
            var jsonStory = JObject.Parse(StoryMessage);
            var story = _validator.ValidateJsonIntoStory(jsonStory);
            var latestNumber = _projectRepositoryService.UpdateLatestStoryNumberForProject(story.ProjectAcronym);
            var result = TranscribeStory(story, latestNumber);
            return result;
        }

        /// <summary>
        /// concrete implementation of <see cref="IScriberService.GetLatestStoryForProject(string)">
        /// </summary>
        public string GetLatestStoryForProject(string ProjectAcronym)
        {
            //TODO: We are going to need a blob storage set up for projects, not currently on (that requires more schema changes)
            throw new NotImplementedException();
        }

        /// <summary>
        /// concrete implementation of <see cref="IScriberService.GetLatestStoryNumberForProject(string)">
        /// </summary>
        public string GetLatestStoryNumberForProject(string ProjectAcronym)
        {
            return _projectRepositoryService.GetLatestStoryNumberForProject(ProjectAcronym);
        }

        /// <summary>
        /// Formats the story message into a string we can copy.
        /// </summary>
        private string Format(Story storyMessage, string storyNumber = null)
        {
            // here goes the first part of the formatted string
            StringBuilder formattedString = new StringBuilder();

            _stringBuilderService.FormatPartOfStory(formattedString, "Name", storyMessage.Name);

            if(string.IsNullOrWhiteSpace(storyNumber))
            {
                _stringBuilderService.FormatStoryNumber(formattedString, storyMessage.ProjectAcronym);
            }
            {
                _stringBuilderService.FormatStoryNumber(formattedString, storyMessage.ProjectAcronym, storyNumber);
            }

            // Here goes the message logic
            var messagelines = storyMessage.StoryMessage.ToList<MessageLine>();

            if (messagelines == null || !messagelines.Any())
                throw new ArgumentException("A story needs a message with atleast 1 messageline");

            return _stringBuilderService.FormatStoryMessages(formattedString, messagelines);
           
        }
    }
}
