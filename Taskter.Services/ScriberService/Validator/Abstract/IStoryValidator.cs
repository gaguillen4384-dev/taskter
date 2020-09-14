using Newtonsoft.Json.Linq;
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

        /// <summary>
        /// Validates the json passed in for desired properties.
        /// </summary>
        Story ValidateJsonIntoStory(JObject jObjectStory);
    }
}
