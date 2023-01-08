using CoffeeVendingMachine.Shared.Interfaces;
using CoffeeVendingMachine.Models;
using System;

namespace CoffeeVendingMachine.Decorators.CoffeeTypes.Factories
{
    public static class CoffeeFactory
    {

        public static ICoffee CreateCoffee(string type)
        {
            switch (type)
            {
                case "Latte":
                    return new Latte(new Coffee());
                case "Macchiato,":
                    return new Macchiato(new Coffee());
                case "Espresso":
                    return new Espresso(new Coffee());
                case "Americano":
                    return new Americano(new Coffee());
                case "Cappucinno":
                    return new Cappucino(new Coffee());
                default:
                    throw new InvalidOperationException("Invalid Coffee Type value");
            }
        }
    }
}
