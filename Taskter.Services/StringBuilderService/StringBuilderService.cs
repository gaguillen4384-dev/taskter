using System.Text;

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

        public void FormatStoryMessages()
        {
            throw new System.NotImplementedException();
        }

        public void FormatStoryNumber(StringBuilder formattedString, string projectAcronym)
        {
            throw new System.NotImplementedException();
        }
    }
}
