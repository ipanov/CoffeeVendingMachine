using CoffeeVendingMachine.Shared.Interfaces;
using System.Collections.Generic;

namespace CoffeeVendingMachine.Decorators.CoffeeTypes
{
    public abstract class BaseCoffee : ICoffee
    {
        protected readonly ICoffee _decoratedCoffee;
        public string Type { get; set; }
        public List<string> Characteristics { get; set; } = new List<string>();

        public BaseCoffee(ICoffee coffee)
        {
            _decoratedCoffee = coffee;
        }

        public string GetDescription()
        {
            var characteristicsDescription = string.Join(", ", Characteristics);

            return string.Format("{0}, {1}", Type, characteristicsDescription);
        }
    }
}
