using System;
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
    }
}
