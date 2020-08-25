using Microsoft.Extensions.DependencyInjection;
using System;

namespace Taskter
{
    public class Program
    {
        // TODO: Get DI out of program into startup
        private static IServiceProvider _serviceProvider;
        public static void Main(string[] args)
        {
            ConfigureServices();
            IServiceScope scope = _serviceProvider.CreateScope();
            scope.ServiceProvider.GetRequiredService<ConsoleApplication>().Run(args[0]);
            DisposeServices();
        }

        public static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddTransient<IScriber, Scriber>();
            // IMPORTANT! Register our application entry point
            services.AddTransient<ConsoleApplication>();
            return services;
        }

        private static void DisposeServices()
        {
            if (_serviceProvider == null)
            {
                return;
            }
            if (_serviceProvider is IDisposable)
            {
                ((IDisposable)_serviceProvider).Dispose();
            }
        }


    }
}
