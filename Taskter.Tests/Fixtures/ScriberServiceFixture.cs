using Microsoft.Extensions.DependencyInjection;
using Taskter.Services;

namespace Taskter.Tests
{
    public class ScriberServiceFixture
    {
        public ServiceProvider ServiceProvider { get; private set; }
        public ScriberServiceFixture()
        {
            var services = new ServiceCollection();

            services.AddTransient<IStringBuilderService, StringBuilderService>();
            services.AddTransient<IStoryValidator, StoryValidator>();
            services.AddTransient<IScriberService, ScriberService>();

            ServiceProvider = services.BuildServiceProvider();
        }
    }
}
