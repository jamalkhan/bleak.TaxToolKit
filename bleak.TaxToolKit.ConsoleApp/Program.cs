using System;
using bleak.TaxToolKit.ConsoleApp.Configuration;
using bleak.Api.Rest;
using bleak.TaxToolKit.ConsoleApp.CoinGecko.DTOs;
using bleak.TaxToolKit.ConsoleApp.Apps;

namespace bleak.TaxToolKit.ConsoleApp
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var appTypes = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(a => a.GetTypes())
                .Where(t => typeof(IConsoleApp).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
                .ToList();

            var appInstances = appTypes.Select(t => (IConsoleApp)Activator.CreateInstance(t)!)
            .ToList();

            do
            {
                Console.WriteLine("What would you like to do?");
                foreach (var app in appInstances)
                {
                    var attribute = (ConsoleAppSettingsAttribute)Attribute.GetCustomAttribute(app.GetType(), typeof(ConsoleAppSettingsAttribute));
                    if (attribute != null)
                    {
                        var appName = string.IsNullOrEmpty(attribute.Name) ? app.GetType().Name : attribute.Name;
                        Console.WriteLine($"{attribute.Id}. {appName}");
                    }
                }
                Console.WriteLine("Q. Exit");

                var response = Console.ReadLine();
                if (response!.ToLower() == "q")
                {
                    return;
                }

                var selectedApp = appInstances.FirstOrDefault(app =>
                {
                    var attribute = (ConsoleAppSettingsAttribute)Attribute.GetCustomAttribute(app.GetType(), typeof(ConsoleAppSettingsAttribute));
                    return attribute != null && attribute.Id.ToString() == response;
                });

                if (selectedApp != null)
                {
                    selectedApp.Run();
                }
                else
                {
                    Console.WriteLine("Invalid option. Please try again.");
                }
            } while (true);
        }



    }
}

