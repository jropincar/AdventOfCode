using System;
using AdventOfCode.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AdventOfCode.PassportProcessing.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            var startup = new Startup();

            startup.ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var tobogganTrajectoryServices = serviceProvider.GetService<IServices>();
            var answer = tobogganTrajectoryServices.Run();
            Console.WriteLine(answer);
        }
    }
}
