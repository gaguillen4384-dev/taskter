using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taskter.Domain;

namespace Taskter.Services
{
    public class StringBuilderService : IStringBuilderService
    {
        // TODO: Test for this class is required
        /// <summary>
        /// Transform part of the story to a formatted string.
        /// </summary>
        public void FormatPartOfStory(StringBuilder formattedString, string fieldName, string partOfStory)
        {
            formattedString.AppendLine($"\"{fieldName}\" : \"{partOfStory}\"");
        }

        /// <summary>
        /// Given a list of message lines it formats a story message.
        /// </summary>
        public string FormatStoryMessages(StringBuilder formattedString, IList<MessageLine> messagelines)
        {
            if (!messagelines.Any())
                return formattedString.ToString();

            foreach (var message in messagelines)
            {
                //TODO: this really belongs at the UI/interface layer. this introduces a 0 and 1 based debate when it should be just dumb
                formattedString.AppendLine(new String('+', message.Level.Value) + $"{message.Line}");
            }

            return formattedString.ToString();
        }

        // TODO: REPO might be sqllite or a plain text file JSON.
        public void FormatStoryNumber(StringBuilder formattedString, string projectAcronym)
        {
            throw new System.NotImplementedException();
        }
    }
}
