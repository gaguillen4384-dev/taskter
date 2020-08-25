using Taskter;
using Xunit;

namespace Tests.ServicesTests.ScriberTests
{
    public class ScriberService_Transcribe
    {
        private IScriber _scriber;
        public ScriberService_Transcribe(IScriber scriber) 
        {
            _scriber = scriber;
        }

        [Fact]
        public void TranscribeIntoStoryFromJson_ReturnString()
        {
            // TODO: need to introduce a mock of json or json resource
            _scriber.TranscribeIntoStory();
        }
    }
}
