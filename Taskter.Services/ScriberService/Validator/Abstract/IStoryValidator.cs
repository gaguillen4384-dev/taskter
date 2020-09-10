using Taskter.Domain;

namespace Taskter.Services
{
    /// <summary>
    /// Responsible for validation the story object wanting to be transcribe.
    /// </summary>
    public interface IStoryValidator
    {
        /// <summary>
        /// Validates the story properties.
        /// </summary>
        void ValidateStoryProperties(Story story);
    }
}
