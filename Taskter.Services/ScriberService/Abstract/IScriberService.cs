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
        string TranscribeIntoStory(string StoryMessage);
    }
}
