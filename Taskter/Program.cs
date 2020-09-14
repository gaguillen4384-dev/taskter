using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using Taskter.Repository;
using Taskter.Services;

namespace Taskter
{
    public class Program
    {
        // TODO: Get DI out of program into startup
        private readonly static IServiceProvider _serviceProvider;
        public static void Main(string[] args)
        {
            //setup our DI
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddSingleton<ConsoleApplication>()
                .AddTransient<IScriberService, ScriberService>()
                .AddTransient<IStoryValidator, StoryValidator>()
                .AddTransient<IStringBuilderService, StringBuilderService>()
                .AddTransient<IProjectRepositoryService, ProjectRepositoryService>()
                .AddSingleton<IProjectRepository, ProjectRepository>()
                .BuildServiceProvider();

            ////configure console logging
            //serviceProvider
            //    .GetService<ILoggerFactory>()
            //    .AddConsole(LogLevel.Debug);

            var logger = serviceProvider.GetService<ILoggerFactory>()
                .CreateLogger<Program>();
            logger.LogDebug("Starting application");

            //do the actual work here
            var ConsoleApplication = serviceProvider.GetService<ConsoleApplication>();
            ConsoleApplication.Run();

            logger.LogDebug("All done!");

        }

        /// <summary>
        /// TODO: This needs to be used to meet standars, well extension methods are the end goal.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IScriberService, ScriberService>();
            services.AddTransient<IStoryValidator, StoryValidator>();
            services.AddTransient<IStringBuilderService, StringBuilderService>();
            services.AddTransient<IProjectRepositoryService, ProjectRepositoryService>();
            services.AddSingleton<IProjectRepository, ProjectRepository>();
            // IMPORTANT! Register our application entry point
            services.AddSingleton<ConsoleApplication>();
            return services;
        }
    }
}
