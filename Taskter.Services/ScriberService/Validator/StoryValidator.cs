using System;
using Taskter.Domain;

namespace Taskter.Services
{
    public class StoryValidator : IStoryValidator
    {
        public void ValidateStoryProperties(Story story)
        {
            if (string.IsNullOrWhiteSpace(story.Name))
                throw new ArgumentException("The Story is missing a 'Name'");

            if (string.IsNullOrWhiteSpace(story.ProjectAcronym))
                throw new ArgumentException("The Story is missing a 'ProjectAcronym'");

            if (story.StoryMessage == null)
                throw new ArgumentException("The Story is missing a 'ProjectAcronym'");
        }
    }
}
