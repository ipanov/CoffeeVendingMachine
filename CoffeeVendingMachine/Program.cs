﻿using CoffeeVendingMachine.Decorators.CoffeeTypes.Factories;
using System;
using System.Collections.Generic;
using System.Linq;


namespace CoffeeVendingMachine
{
    internal class Program
    {
        private static readonly List<string> coffeeTypes = new List<string>() { "Latte", "Macchiato", "Espresso", "Americano", "Cappucino" };

        static void Main(string[] args)
        {
            Console.WriteLine("Coffee Vending Machine");
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
                    PickDifferentTypesOfCoffeeFrom3rdPartySources();
                    break;
                case ConsoleKey.D3:
                    break;
                default:
                    Console.WriteLine("Invalid option value");
                    break;
            }
        }

        private static void PickPredefinedListOfCoffeeTypes()
        {
            Console.WriteLine();
            Console.WriteLine("Pick a coffee type:");
            Console.WriteLine();
            foreach (var coffeeType in coffeeTypes)
            {
                Console.WriteLine("{0}", coffeeType);
            }

            Console.WriteLine();
            Console.WriteLine("Enter coffee type to select:");

            var inputSelectedCoffee = Console.ReadLine();

            if (coffeeTypes.Any(c => c == inputSelectedCoffee))
            {
                var coffee = CoffeeFactory.CreateCoffee(inputSelectedCoffee);
                Console.WriteLine($"You selected: {coffee.GetDescription()}");
                Console.WriteLine("Preparing your coffee...");
            }
            else
            {
                Console.WriteLine("Invalid coffee type entered. Please enter a valid cofee type");
            }
        }

        private static void PickDifferentTypesOfCoffeeFrom3rdPartySources()
        {
            var externalCoffeeTypes = new List<string>();

            foreach (var coffeeType in externalCoffeeTypes)
            {
                Console.WriteLine("{0}", coffeeType);
            }

            Console.WriteLine();
            Console.WriteLine("Enter coffee type to select:");

            var inputSelectedCoffee = Console.ReadLine();

            if (externalCoffeeTypes.Any(c => c == inputSelectedCoffee))
            {
                var coffee = CoffeeFactory.CreateCoffee(inputSelectedCoffee);
                Console.WriteLine($"You selected: {coffee.GetDescription()}");
                Console.WriteLine("Preparing your coffee...");
            }
            else
            {
                Console.WriteLine("Invalid coffee type entered. Please enter a valid cofee type");
            }
        }
    }
}