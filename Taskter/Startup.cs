using Microsoft.Extensions.DependencyInjection;

namespace Taskter
{
    public class Startup
    {
        public static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddTransient<IScriber, Scriber>();
            // IMPORTANT! Register our application entry point
            services.AddTransient<ConsoleApplication>();
            return services;
        }
    }
}
