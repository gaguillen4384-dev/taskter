using System;
using System.IO;
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
        public void Run()
        {
            bool endApp = false;

            while (!endApp)
            {
                // Ask the user to type the first number.
                Console.WriteLine("Type a path for story json, and then press Enter");
                string jsonPath = Console.ReadLine();
                Console.WriteLine("------------------------\n");
                Console.WriteLine("------------------------\n");
                if (File.Exists(jsonPath))
                {
                    var storyFile = File.ReadAllText(jsonPath);

                    if (string.IsNullOrWhiteSpace(storyFile))
                        Console.WriteLine("file was empty");

                    // here a json must be passed in by param
                    var result = _scriber.TranscribeNewStoryForProject(storyFile);

                    Console.WriteLine(result);
                    Console.WriteLine("------------------------\n");
                    // Wait for the user to respond before closing.
                    Console.WriteLine("Press any key to start a new story mapping...");
                    Console.ReadKey();
                    ReRun(endApp);
                }
                else
                    Console.WriteLine("path not found");
            }
        }

        /// <summary>
        /// Repeate logic 
        /// </summary>
        private void ReRun(bool endApp) 
        {
            // if wanted to here change the endapp to something else
            Run();
        }
    }
}