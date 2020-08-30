using System.Text;

namespace Taskter.Services
{
    /// <summary>
    /// Responsible for interfacing with formatted stringbuilder
    /// </summary>
    public interface IStringBuilderService
    {

        /// <summary>
        /// Transform part of the story into a formatted string.
        /// </summary>
        void FormatPartOfStory(StringBuilder formattedString, string fieldName, string partOfStory);

        /// <summary>
        /// Finds the current number for the given project acronym into a formatted string.
        /// </summary>
        void FormatStoryNumber(StringBuilder formattedString, string projectAcronym);

        /// <summary>
        /// Transform each message of the story into a formatted string.
        /// </summary>
        void FormatStoryMessages();
    }
}
