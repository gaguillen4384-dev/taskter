namespace Taskter
{
    public interface IScriber
    {
        /// <summary>
        /// Transcribes a given json and returns a string formatted properly into a story format.
        /// </summary>
        /// <returns></returns>
        string TranscribeIntoStory();
    }
}
