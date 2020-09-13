using Microsoft.Extensions.DependencyInjection;
using Taskter.Repository;
using Taskter.Services;

namespace Taskter.Tests
{
    public class StringBuilderServiceFixture
    {
        public ServiceProvider ServiceProvider { get; private set; }
        public StringBuilderServiceFixture() 
        {
            var services = new ServiceCollection();

            services.AddTransient<IStringBuilderService, StringBuilderService>();
            services.AddTransient<IProjectRepositoryService, ProjectRepositoryService>();
            services.AddTransient<IProjectRepository, ProjectRepository>();

            ServiceProvider = services.BuildServiceProvider();
        }
    }
}
