using CoffeeVendingMachine.Decorators.Characteristics;
using CoffeeVendingMachine.Factories;
using CoffeeVendingMachine.Services;
using CoffeeVendingMachine.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;

namespace CoffeeVendingMachine
{
    internal class Program
    {
        private static readonly List<string> coffeeTypes = new List<string>() { "Latte", "Macchiato", "Espresso", "Americano", "Cappucino" };

        static async Task Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Coffee Vending Machine");
                Console.WriteLine();
                Console.WriteLine("Press Ctrl-C to exit");
                Console.WriteLine();

                ConsoleKey response;
                do
                {
                    Console.WriteLine("Please choose an option");
                    Console.WriteLine();
                    Console.WriteLine("1. Pick from a predefined list of Coffee types");
                    Console.WriteLine("2. Pick different types of Coffee from 3rd party sources");
                    Console.WriteLine("3. Customize a basic Coffee, create unique types of Coffee");
                    Console.WriteLine();
                    Console.WriteLine("Enter option to select:");

                    response = Console.ReadKey().Key;
                    if (response != ConsoleKey.Enter)
                        Console.WriteLine();

                } while (response != ConsoleKey.D1 && response != ConsoleKey.D2 && response != ConsoleKey.D3);

                switch (response)
                {
                    case ConsoleKey.D1:
                        PickPredefinedListOfCoffeeTypes();
                        break;
                    case ConsoleKey.D2:
                        await PickDifferentTypesOfCoffeeFromThirdPartySources();
                        break;
                    case ConsoleKey.D3:
                        CustomizeBasicCoffee();
                        break;
                    default:
                        Console.WriteLine("Invalid option value");
                        break;
                }
                Console.WriteLine();
            }
        }

        private static void CustomizeBasicCoffee()
        {
            Console.WriteLine();
            Console.WriteLine("Pick a basic Coffee:");
            Console.WriteLine();
            foreach (var coffeeType in coffeeTypes)
            {
                Console.WriteLine(coffeeType);
            }

            Console.WriteLine();
            Console.WriteLine("Enter coffee type to select:");

            var inputSelectedCoffee = Console.ReadLine();

            if (coffeeTypes.Any(c => c == inputSelectedCoffee))
            {
                var basicCoffee = CoffeeFactory.CreateCoffee(inputSelectedCoffee);

                Console.WriteLine();
                Console.WriteLine("Name your unique coffee type:");
                var inputCustomCoffee = Console.ReadLine();

                if (inputCustomCoffee != null)
                {
                    var customCoffee = CoffeeFactory.CreateCoffee(inputCustomCoffee, basicCoffee);

                    var characteristics = GetPredefinedCharacteristics();

                    CustomizeCharacteristics(customCoffee, characteristics);
                }
                else
                {
                    Console.WriteLine("Invalid coffee type entered. Please enter a valid cofee type");
                }

            }
            else
            {
                Console.WriteLine("Invalid coffee type entered. Please enter a valid cofee type");
            }
        }

        private static void PickPredefinedListOfCoffeeTypes()
        {
            Console.WriteLine();
            Console.WriteLine("Pick a coffee type:");
            Console.WriteLine();
            foreach (var coffeeType in coffeeTypes)
            {
                Console.WriteLine(coffeeType);
            }

            Console.WriteLine();
            Console.WriteLine("Enter coffee type to select:");

            var inputSelectedCoffee = Console.ReadLine();

            if (coffeeTypes.Any(c => c == inputSelectedCoffee))
            {
                var coffee = CoffeeFactory.CreateCoffee(inputSelectedCoffee);
                Console.WriteLine($"Preparing your {coffee.GetDescription()}...");
            }
            else
            {
                Console.WriteLine("Invalid coffee type entered. Please enter a valid cofee type");
            }
        }

        private static void CustomizeCharacteristics(ICoffee coffee, List<Type> characteristics)
        {
            Console.WriteLine();
            Console.WriteLine($"Pick a characteristic to customize your {coffee.Type} coffee:");
            Console.WriteLine();

            foreach (var characteristic in characteristics)
            {
                Console.WriteLine(characteristic.Name);
            }

            Console.WriteLine();
            Console.WriteLine("Enter characteristic to select:");

            var inputCharacteristic = Console.ReadLine();

            if (characteristics.Any(c => c.Name == inputCharacteristic))
            {
                Type characteristic = characteristics.Single(c => c.Name == inputCharacteristic);

                var instance = Activator.CreateInstance(characteristic, coffee);

                ConsoleKey response;
                do
                {
                    Console.WriteLine();
                    Console.WriteLine($"Would you like to continue customizing your {coffee.Type} coffee ? [Y/N]");
                    response = Console.ReadKey().Key;
                    if (response != ConsoleKey.Enter)
                        Console.WriteLine();

                } while (response != ConsoleKey.Y && response != ConsoleKey.N);

                switch (response)
                {
                    case ConsoleKey.Y:
                        characteristics.Remove(characteristic);
                        CustomizeCharacteristics((ICoffee)instance, characteristics);
                        break;
                    case ConsoleKey.N:
                        Console.WriteLine($"Preparing your {((ICoffee)instance).GetDescription()}...");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid characteristic entered. Please enter a valid cofee type");
                CustomizeCharacteristics(coffee, characteristics);
            }
        }

        private static async Task PickDifferentTypesOfCoffeeFromThirdPartySources()
        {
            using HttpClient client = new();

            var thirdPartyCoffees = await ApiClient.GetCoffeesAsync(client);

            Console.WriteLine();
            Console.WriteLine("Pick a coffee type:");
            Console.WriteLine();

            foreach (var coffee in thirdPartyCoffees.Select(c => c.Type))
            {
                Console.WriteLine(coffee);
            }

            Console.WriteLine();
            Console.WriteLine("Enter coffee type to select:");

            var inputSelectedCoffee = Console.ReadLine();

            if (thirdPartyCoffees.Any(c => c.Type == inputSelectedCoffee))
            {
                var thirdPartyCoffee = thirdPartyCoffees.Single(c => c.Type == inputSelectedCoffee);
                Console.WriteLine($"Preparing your {thirdPartyCoffee.GetDescription()}...");
            }
            else
            {
                Console.WriteLine("Invalid coffee type entered. Please enter a valid cofee type");
            }
        }

        private static List<Type> GetPredefinedCharacteristics()
        {
            var characteristics = new List<Type>();
            foreach (Type type in Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(CharacteristicDecorator))))
            {
                characteristics.Add(type);
            }
                
            return characteristics;
        }
    }
}
