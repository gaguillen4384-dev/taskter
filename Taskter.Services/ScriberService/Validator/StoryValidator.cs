using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using Taskter.Domain;

namespace Taskter.Services
{
    /// <summary>
    /// Concrete implementation of <see cref="IStoryValidator">
    /// </summary>
    public class StoryValidator : IStoryValidator
    {
        /// <summary>
        /// Concrete implementation of <see cref="IStoryValidator.ValidateStoryProperties(Story)">
        /// </summary>
        public void ValidateStoryProperties(Story story)
        {
            if (string.IsNullOrWhiteSpace(story.Name))
                throw new ArgumentException("The Story is missing a 'Name'");

            if (string.IsNullOrWhiteSpace(story.ProjectAcronym))
                throw new ArgumentException("The Story is missing a 'ProjectAcronym'");

            if (story.StoryMessage == null)
                throw new ArgumentException("The Story is missing a 'ProjectAcronym'");

            foreach (var message in story.StoryMessage) 
            {
                if (!message.Level.HasValue)
                    message.Level = 1;

                if (message.Level.Value <= 0)
                    message.Level = 1;
            }
        }

        /// <summary>
        /// Concrete implementation of <see cref="IStoryValidator.ValidateJsonToBeMapped(JObject)">
        /// </summary>
        public Story ValidateJsonIntoStory(JObject jObjectStory)
        {
            var story = new Story();
            var name = "Story.Name";
            var projectAcronym = "Story.Project";
            var messages = "Story.StoryMessage[*]";

            // checks if the json has the properties
            if (!string.IsNullOrWhiteSpace((string)jObjectStory.SelectToken(name)))
                MapToStoryName(jObjectStory, name, story);

            if (!string.IsNullOrWhiteSpace((string)jObjectStory.SelectToken(projectAcronym)))
                MapToProjectAcronym(jObjectStory, projectAcronym, story);

            if (jObjectStory.SelectTokens(messages).Any())
                MapStoryMessage(jObjectStory, messages, story);

            return story;
        }

        /// <summary>
        /// Maps the story name
        /// </summary>
        private void MapToStoryName(JObject jsonStory, string jsonPath, Story story) 
        {
            story.Name = (string)jsonStory.SelectToken(jsonPath);
        }

        /// <summary>
        /// Maps the project acronym
        /// </summary>
        private void MapToProjectAcronym(JObject jsonStory, string jsonPath, Story story)
        {
            story.ProjectAcronym = (string)jsonStory.SelectToken(jsonPath);
        }

        /// <summary>
        /// Maps each MessageLine from Json.
        /// </summary>
        private void MapStoryMessage(JObject jsonStory, string jsonPath,Story story)
        {
            var listOfMessages = new List<MessageLine>();
            var arrayOfMessages = jsonStory.SelectTokens(jsonPath).ToList();

            foreach (var messageLineToken in arrayOfMessages)
            {
                var messageLine = new MessageLine();
                // Mapped each property as a Jtoken from messageline object
                messageLine.Line = (string)messageLineToken.SelectToken("MessageLine.line");
                messageLine.Level = (int)messageLineToken.SelectToken("MessageLine.level");

                listOfMessages.Add(messageLine);
            }

            story.StoryMessage = listOfMessages;
        }
    }
}
