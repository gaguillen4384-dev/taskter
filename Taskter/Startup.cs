using Microsoft.Extensions.DependencyInjection;
using Taskter.Services;

namespace Taskter
{
    public class Startup
    {
        public static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddTransient<IScriberService, ScriberService>();
            services.AddTransient<IStoryValidator, StoryValidator>();
            services.AddTransient<IStringBuilderService, StringBuilderService>();
            // IMPORTANT! Register our application entry point
            services.AddTransient<ConsoleApplication>();
            return services;
        }
    }
}
