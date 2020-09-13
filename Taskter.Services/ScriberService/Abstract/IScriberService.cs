namespace Taskter.Services
{
    /// <summary>
    /// Responsible for scribing a piece of text into a story format.
    /// </summary>
    public interface IScriberService
    {
        /// <summary>
        /// Transcribes a given json and returns a string formatted properly into a story format.
        /// </summary>
        /// <returns></returns>
        string TranscribeIntoStory(string StoryMessage, string StoryNumber = null);

        /// <summary>
        /// Get latest story (blob) for the project acronym.
        /// </summary>
        string GetLatestStoryForProject(string ProjectAcronym);

        /// <summary>
        /// Get latest story number for the project acronym.
        /// </summary>
        string GetLatestStoryNumberForProject(string ProjectAcronym);

        /// <summary>
        /// Insert new story for project acronym.
        /// </summary>
        string TranscribeNewStoryForProject(string ProjectAcronym, string StoryMessage);
    }
}
