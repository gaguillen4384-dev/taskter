using Taskter.Services;

namespace Taskter
{
    public class ConsoleApplication
    {
        private readonly IScriberService _scriber;
        public ConsoleApplication(IScriberService scriber)
        {
            _scriber = scriber;
        }

        /// <summary>
        /// Runs the application main logic
        /// </summary>
        public void Run(string jsonpath)
        {
            //string jsonPath = args[0];
            //Console.WriteLine("trying path: " + jsonPath);
            //if (Directory.Exists(jsonPath))
            //{
            //    var file = File.ReadAllText(jsonPath);

            //    if (string.IsNullOrWhiteSpace(file))
            //        Console.WriteLine("file was empty");
            //}
            //else
            //    Console.WriteLine("path not found");
            //// here a json must be passed in by param
            //var result = _scriber.TranscribeIntoStory();
        }
    }
}