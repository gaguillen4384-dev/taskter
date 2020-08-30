using Newtonsoft.Json;
using System;
using System.Linq;
using System.Text;
using Taskter.Domain;

namespace Taskter.Services
{
    /// <summary>
    /// This is the concrete implementation of <see cref="IScriberService"/>
    /// </summary>
    public class ScriberService : IScriberService
    {
        private IStoryValidator _validator;
        private IStringBuilderService _stringBuilderService;

        public ScriberService(IStoryValidator validator,
            IStringBuilderService stringBuilderService) 
        {
            _validator = validator;
            _stringBuilderService = stringBuilderService;
        }


        /// <summary>
        /// Transcribes a given json and returns a string formatted properly into a story format.
        /// </summary>
        public string TranscribeIntoStory(string storyMessage)
        {
            var jsonTranscription = JsonConvert.DeserializeObject<Story>(storyMessage);

            _validator.ValidateStoryProperties(jsonTranscription);

            string result = Format(jsonTranscription); 

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        private string Format(Story storyMessage) 
        {
            // here goes the first part of the formatted string
            StringBuilder formattedString = new StringBuilder();

            _stringBuilderService.FormatPartOfStory(formattedString, "Name", storyMessage.Name);
            _stringBuilderService.FormatPartOfStory(formattedString, "ProjectAcronym", storyMessage.ProjectAcronym);

            // Here goes the project # from some repo

            // Here goes the message logic
            var messagelines = storyMessage.StoryMessage.ToList<MessageLine>();

            if (messagelines ==null || !messagelines.Any())
                throw new ArgumentException("A story needs a message with atleast 1 messageline");

            foreach (var message in messagelines) 
            {
                
            }

            return formattedString.ToString();
        }

    }
}
