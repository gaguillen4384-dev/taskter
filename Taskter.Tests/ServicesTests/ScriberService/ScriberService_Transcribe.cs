using Moq;
using Taskter;
using Xunit;

namespace Tests.ServicesTests
{
    public class ScriberService_Transcribe 
    {
        private Mock<IScriber> _scriberMock = new Mock<IScriber>();
        private IScriber _scriber;

        public ScriberService_Transcribe() 
        {
            _scriber = new Scriber();
        }

        [Fact]
        public void TranscribeIntoStoryFromJson_ReturnString()
        {
            // TODO: need to introduce a mock of json or json resource
            var result = _scriber.TranscribeIntoStory();
            Assert.IsType<string>(result);
        }
    }
}
