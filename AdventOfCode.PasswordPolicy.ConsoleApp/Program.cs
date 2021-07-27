using System;
using AdventOfCode.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AdventOfCode.PasswordPolicy.ConsoleApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            var startup = new Startup();

            startup.ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var passwordPolicyServices = serviceProvider.GetService<IServices>();
            var answer = passwordPolicyServices.Run();
            Console.WriteLine(answer);
        }
    }
}
