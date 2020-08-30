using Taskter.Domain;

namespace Taskter.Services
{
    public interface IStoryValidator
    {
        void ValidateStoryProperties(Story story);
    }
}
