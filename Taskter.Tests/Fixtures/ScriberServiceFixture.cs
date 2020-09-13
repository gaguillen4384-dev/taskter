using Microsoft.Extensions.DependencyInjection;
using Taskter.Repository;
using Taskter.Services;

namespace Taskter.Tests
{
    public class ScriberServiceFixture
    {
        public ServiceProvider ServiceProvider { get; private set; }
        public ScriberServiceFixture()
        {
            var services = new ServiceCollection();

            services.AddTransient<IStoryValidator, StoryValidator>();
            services.AddTransient<IScriberService, ScriberService>();
            services.AddTransient<IStringBuilderService, StringBuilderService>();
            services.AddTransient<IProjectRepositoryService, ProjectRepositoryService>();
            services.AddTransient<IProjectRepository, ProjectRepository>();

            ServiceProvider = services.BuildServiceProvider();
        }
    }
}
