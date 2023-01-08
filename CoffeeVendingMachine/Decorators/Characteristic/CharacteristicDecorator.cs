using CoffeeVendingMachine.Shared.Interfaces;
using System.Collections.Generic;

namespace CoffeeVendingMachine.Decorators.Characteristics
{
    public abstract class CharacteristicDecorator : ICoffee
    {
        private readonly ICoffee _decoratedCoffee;
        public string Type { get; set; }
        public List<string> Characteristics { get; set; }

        public CharacteristicDecorator(ICoffee coffee)
        {
            _decoratedCoffee = coffee;
        }

        public string GetDescription()
        {
            var characteristicsDescription = string.Join(", ", _decoratedCoffee.Characteristics);

            return string.Format("{0}, {1}", Type, characteristicsDescription);
        }
    }
}
