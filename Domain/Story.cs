using System.Collections.Generic;

namespace Taskter.Domain
{
    public class Story
    {
        public string Name = string.Empty;

        public string ProjectAcronym = string.Empty;

        public IEnumerable<MessageLine> StoryMessage = null;
    }
}
