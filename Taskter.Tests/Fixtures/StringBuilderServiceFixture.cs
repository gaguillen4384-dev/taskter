using Microsoft.Extensions.DependencyInjection;
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

            ServiceProvider = services.BuildServiceProvider();
        }
    }
}
