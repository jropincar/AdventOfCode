using System;
using AdventOfCode.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AdventOfCode.ReportRepair.ConsoleApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            var startup = new Startup();

            startup.ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var reportRepairServices = serviceProvider.GetService<IServices>();
            var answer = reportRepairServices.Run();
            Console.WriteLine(answer);
        }
    }
}
