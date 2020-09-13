using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taskter.Domain;
using Taskter.Repository;

namespace Taskter.Services
{
    /// <summary>
    /// Concrete implementation of <see cref="IStringBuilderService">
    /// </summary>
    public class StringBuilderService : IStringBuilderService
    {
        private readonly IProjectRepositoryService _projectRepositoryService;
        public StringBuilderService(IProjectRepositoryService projectRepositoryService) 
        {
            _projectRepositoryService = projectRepositoryService; 
        }
        /// <summary>
        /// Concrete implementation of <see cref="IStringBuilderService.FormatPartOfStory(StringBuilder, string, string)">
        /// </summary>
        public void FormatPartOfStory(StringBuilder formattedString, string fieldName, string partOfStory)
        {
            formattedString.AppendLine($"\"{fieldName}\" : \"{partOfStory}\"");
        }

        /// <summary>
        /// Concrete implementation of <see cref="IStringBuilderService.FormatStoryMessages(StringBuilder, IList{MessageLine})">
        /// </summary>
        public string FormatStoryMessages(StringBuilder formattedString, IList<MessageLine> messagelines)
        {
            if (!messagelines.Any())
                return formattedString.ToString();

            foreach (var message in messagelines)
            {
                formattedString.AppendLine(new String('+', message.Level.Value) + $"{message.Line}");
            }

            return formattedString.ToString();
        }

        /// <summary>
        /// Concrete implementation of <see cref="IStringBuilderService.FormatStoryNumber(StringBuilder, string)">
        /// </summary>
        public void FormatStoryNumber(StringBuilder formattedString, string projectAcronym, string storyNumber = null)
        {
            if(storyNumber != null) 
            {
                formattedString.AppendLine($"\"{projectAcronym}-{storyNumber}\"");
            }
            else
            {
                var latestStoryNumber = _projectRepositoryService.GetLatestStoryNumberForProject(projectAcronym);
                formattedString.AppendLine($"\"{projectAcronym}-{latestStoryNumber}\"");
            }
        }
    }
}
